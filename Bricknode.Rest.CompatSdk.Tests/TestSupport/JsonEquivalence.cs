using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Xunit.Sdk;

namespace CompatSdkTests.TestSupport;

/// <summary>
/// Compares two objects by their canonical JSON form ("do they look the same?").
/// Nulls are NOT ignored, so a value that is lost during a mapping round-trip (becomes null)
/// shows up as a difference instead of being silently hidden.
/// </summary>
public static class JsonEquivalence
{
    private static readonly JsonSerializerOptions SerializeOptions = new()
    {
        // Keep nulls so dropped values are visible. Write numbers/enums consistently.
        WriteIndented = false,
    };

    public static string Canonical(object? value, bool normalizeDateTimes = false)
    {
        var json = JsonSerializer.Serialize(value, value?.GetType() ?? typeof(object), SerializeOptions);
        var node = JsonNode.Parse(json);
        return Sort(node, normalizeDateTimes)?.ToJsonString() ?? "null";
    }

    public static void AssertEquivalent(object? expected, object? actual, bool normalizeDateTimes = false)
    {
        var expectedJson = Canonical(expected, normalizeDateTimes);
        var actualJson = Canonical(actual, normalizeDateTimes);

        if (!string.Equals(expectedJson, actualJson, StringComparison.Ordinal))
        {
            throw new XunitException(
                "Objects are not JSON-equivalent after round-trip.\n" +
                "--- expected (original) ---\n" + expectedJson + "\n" +
                "--- actual (round-tripped) ---\n" + actualJson);
        }
    }

    private static JsonNode? Sort(JsonNode? node, bool normalizeDateTimes)
    {
        switch (node)
        {
            case JsonObject obj:
            {
                var sorted = new JsonObject();
                foreach (var kvp in obj.OrderBy(p => p.Key, StringComparer.Ordinal))
                    sorted[kvp.Key] = Sort(kvp.Value?.DeepClone(), normalizeDateTimes);
                return sorted;
            }
            case JsonArray arr:
            {
                var sortedArray = new JsonArray();
                foreach (var item in arr.ToList())
                    sortedArray.Add(Sort(item?.DeepClone(), normalizeDateTimes));
                return sortedArray;
            }
            case JsonValue value when normalizeDateTimes && value.TryGetValue<string>(out var s) && LooksLikeIsoDateTime(s):
            {
                // Compare datetimes by INSTANT: "2026-04-28T11:26:55+02:00" == "2026-04-28T09:26:55Z".
                // Offset-less strings are treated as UTC (deterministic across machines).
                var instant = System.Globalization.DateTimeStyles.AssumeUniversal;
                var dto = DateTimeOffset.Parse(s, System.Globalization.CultureInfo.InvariantCulture, instant);
                return JsonValue.Create(dto.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFF'Z'", System.Globalization.CultureInfo.InvariantCulture));
            }
            default:
                return node;
        }
    }

    private static bool LooksLikeIsoDateTime(string s) =>
        s.Length >= 19 && s.Length <= 35 &&
        char.IsDigit(s[0]) && char.IsDigit(s[1]) && char.IsDigit(s[2]) && char.IsDigit(s[3]) &&
        s[4] == '-' && s[7] == '-' && s[10] == 'T' && s[13] == ':' &&
        DateTimeOffset.TryParse(s, System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.AssumeUniversal, out _);
}
