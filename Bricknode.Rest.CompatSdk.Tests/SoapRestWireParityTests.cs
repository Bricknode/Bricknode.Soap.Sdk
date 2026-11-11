using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using BfsApi;
using Bricknode.Soap.Sdk.Mapping;
using CompatSdkTests.TestSupport;
using Xunit;
using RestApi = global::Bricknode.Rest.CompatSdk;

namespace CompatSdkTests;

/// <summary>
/// THE parity guarantee: the same server-side data must reach the consumer with the same values
/// whether it travels over SOAP (old SDK) or REST (compat SDK).
///
/// SOAP path : XmlSerializer out + in — exactly what the ASMX server and the legacy SOAP SDK use
///             (the BfsApi DTOs kept their original XML attributes).
/// REST path : JSON in the verified server format (every date as UTC "Z", exact property names)
///             -> NSwag client options -> BfsJsonMapper -> BfsApi DTO.
///
/// DateTimes are compared by INSTANT: the documented difference is Kind only (SOAP's XmlSerializer
/// hands out machine-local Kind=Local, the compat SDK hands out Kind=Utc — same moment in time).
/// </summary>
public class SoapRestWireParityTests
{
    private static readonly XmlSerializer SoapWire = new(typeof(GetAccountsResponse));

    /// <summary>NSwag clients run on default options (no custom converters).</summary>
    private static readonly JsonSerializerOptions RestClientOptions = new();

    /// <summary>
    /// Produces the REST server's wire format (verified live): Newtonsoft with
    /// DateTimeZoneHandling.Utc — every date serialized as UTC with a "Z" suffix.
    /// </summary>
    private static readonly JsonSerializerOptions RestServerWireOptions = new()
    {
        Converters = { new ServerWireDateTimeConverter() },
    };

    [Fact]
    public void Same_server_data_reaches_the_consumer_identically_via_soap_and_rest()
    {
        var serverData = ObjectFiller.Create<GetAccountsResponse>();

        AssertParity(serverData);
    }

    [Fact]
    public void Unset_dates_stay_DateTime_MinValue_on_both_paths()
    {
        var serverData = ObjectFiller.Create<GetAccountsResponse>();
        var row = serverData.Result[0];
        row.CreatedDate = default; // Kind=Unspecified MinValue: SOAP wire emits it bare,
                                   // the REST server emits "0001-01-01T00:00:00Z".

        var (soapView, restView) = DeserializeBothPaths(serverData);

        Assert.Equal(DateTime.MinValue.Ticks, soapView.Result[0].CreatedDate.Ticks);
        Assert.Equal(DateTime.MinValue.Ticks, restView.Result[0].CreatedDate.Ticks);

        AssertParity(serverData);
    }

    [Fact]
    public void Real_timestamps_are_identical_on_both_paths_value_and_kind()
    {
        var serverData = ObjectFiller.Create<GetAccountsResponse>();
        var utcCreated = new DateTime(2026, 4, 28, 9, 26, 55, 933, DateTimeKind.Utc);
        serverData.Result[0].CreatedDate = utcCreated;

        var (soapView, restView) = DeserializeBothPaths(serverData);

        var soapDate = soapView.Result[0].CreatedDate;
        var restDate = restView.Result[0].CreatedDate;

        // The guarantee: consumer code sees EXACTLY the same DateTime as with the SOAP SDK —
        // same clock-face, same Kind — and the instant matches the server's value.
        Assert.Equal(soapDate, restDate);
        Assert.Equal(soapDate.Kind, restDate.Kind);
        Assert.Equal(utcCreated, restDate.ToUniversalTime());
    }

    private static void AssertParity(GetAccountsResponse serverData)
    {
        var (soapView, restView) = DeserializeBothPaths(serverData);

        // STRICT comparison — clock-faces, kinds/offsets and all. The REST view must serialize
        // byte-for-byte like the SOAP view, so migrated consumer code cannot tell the difference.
        JsonEquivalence.AssertEquivalent(soapView, restView);
    }

    private static (GetAccountsResponse SoapView, GetAccountsResponse RestView) DeserializeBothPaths(
        GetAccountsResponse serverData)
    {
        // --- SOAP: server (ASMX/XmlSerializer) -> wire -> legacy SDK (XmlSerializer) ---
        string soapWire;
        using (var writer = new StringWriter())
        {
            SoapWire.Serialize(writer, serverData);
            soapWire = writer.ToString();
        }

        GetAccountsResponse soapView;
        using (var reader = new StringReader(soapWire))
        {
            soapView = (GetAccountsResponse)SoapWire.Deserialize(reader)!;
        }

        // --- REST: server (Newtonsoft, dates as UTC "Z") -> wire -> compat SDK ---
        var restWire = JsonSerializer.Serialize(serverData, RestServerWireOptions);
        var restRecord = JsonSerializer.Deserialize<RestApi.GetAccountsResponse>(restWire, RestClientOptions)!;
        var restView = BfsJsonMapper.Map<GetAccountsResponse>(restRecord)!;

        return (soapView, restView);
    }

    /// <summary>
    /// Mimics the REST server's serializer (Newtonsoft DateTimeZoneHandling.Utc): Unspecified is
    /// stamped UTC without shifting, Local is converted — everything is written with "Z".
    /// </summary>
    private sealed class ServerWireDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.GetDateTime();

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var utc = value.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
                : value.ToUniversalTime();

            writer.WriteStringValue(utc.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFF'Z'", CultureInfo.InvariantCulture));
        }
    }
}
