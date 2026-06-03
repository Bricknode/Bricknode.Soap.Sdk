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
        Converters = { new UtcDateTimeConverter() },
    };

    /// <summary>
    /// The SOAP side uses <see cref="DateTime"/> while the REST records use
    /// <see cref="DateTimeOffset"/>. Without normalization a round-trip rebinds the value to the
    /// machine's local offset (same instant, different <see cref="DateTime.Kind"/>/text). This
    /// converter keeps <see cref="DateTime"/> values in UTC on both read and write so mappings are
    /// lossless and deterministic across machines/time zones.
    /// </summary>
    private sealed class UtcDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetDateTimeOffset(out var dto))
                return dto.UtcDateTime;

            var dateTime = reader.GetDateTime();
            return dateTime.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(dateTime, DateTimeKind.Utc)
                : dateTime.ToUniversalTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var utc = value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
                : value.ToUniversalTime();

            writer.WriteStringValue(utc.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFK", CultureInfo.InvariantCulture));
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
