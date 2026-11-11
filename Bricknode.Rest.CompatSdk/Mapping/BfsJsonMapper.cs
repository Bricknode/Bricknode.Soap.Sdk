namespace Bricknode.Soap.Sdk.Mapping;

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Bridges the SOAP-shaped <c>BfsApi.*</c> DTOs and the NSwag-generated REST records.
/// Both sides share property names (the REST records carry <c>[JsonPropertyName]</c> values that
/// equal the SOAP property names), so a System.Text.Json round-trip maps them automatically.
/// Differences that JSON already absorbs: array &lt;-&gt; ICollection, class &lt;-&gt; record,
/// DateTime &lt;-&gt; DateTimeOffset, and casing (via case-insensitive matching).
/// </summary>
internal static class BfsJsonMapper
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        Converters = { new SoapCompatDateTimeConverter() },
    };

    /// <summary>
    /// Makes <see cref="DateTime"/> values behave EXACTLY like the SOAP SDK so migrated consumer
    /// code sees the same dates (no localization drift; enforced by SoapRestWireParityTests,
    /// which compares against the real XmlSerializer behavior).
    ///
    /// Receive (REST response -> consumer), matching XmlSerializer on the same wire values:
    ///  - UTC values ("Z" on the wire; zero offset after the DateTimeOffset hop) stay UTC
    ///    (Kind=Utc, clock-face untouched),
    ///  - non-zero offsets convert to machine-local (Kind=Local),
    ///  - offset-less values keep their clock-face (Kind=Unspecified),
    ///  - the MinValue instant maps to exactly <see cref="DateTime.MinValue"/>: the SOAP wire
    ///    sends unset dates offset-less (Unspecified) while the REST server stamps them "Z" —
    ///    this keeps == DateTime.MinValue checks working identically.
    ///
    /// Send (consumer -> REST request): always written as UTC — the same format the SDK receives,
    /// so both sides of the wire carry the same representation. Utc/Local values convert
    /// instant-exact; Unspecified values are stamped UTC without shifting the clock-face
    /// (the SOAP wire carried them as a bare face).
    /// </summary>
    private sealed class SoapCompatDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (string.IsNullOrWhiteSpace(value))
                return default;

            if (!HasOffset(value))
                return DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None); // face kept, Kind=Unspecified

            var instant = DateTimeOffset.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);

            if (instant == DateTimeOffset.MinValue)
                return DateTime.MinValue;

            return instant.Offset == TimeSpan.Zero
                ? instant.UtcDateTime      // wire "Z": XmlSerializer keeps UTC
                : instant.LocalDateTime;   // explicit offset: XmlSerializer converts to local
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var utc = value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(value, DateTimeKind.Utc) // bare face -> same face as UTC
                : value.ToUniversalTime();                      // instant-exact

            writer.WriteStringValue(utc.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture));
        }

        private static bool HasOffset(string value)
        {
            if (value.EndsWith("Z", StringComparison.OrdinalIgnoreCase))
                return true;

            var timeStart = value.IndexOf('T');
            return timeStart >= 0 && value.IndexOfAny(['+', '-'], timeStart) >= 0;
        }
    }

    /// <summary>Maps <paramref name="source"/> to <typeparamref name="TTarget"/> via a JSON round-trip.</summary>
    public static TTarget? Map<TTarget>(object? source)
    {
        if (source is null)
            return default;

        var json = JsonSerializer.Serialize(source, source.GetType(), Options);
        return JsonSerializer.Deserialize<TTarget>(json, Options);
    }
}
