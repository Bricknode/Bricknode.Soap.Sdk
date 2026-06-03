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

    public static string Canonical(object? value)
    {
        var json = JsonSerializer.Serialize(value, value?.GetType() ?? typeof(object), SerializeOptions);
        var node = JsonNode.Parse(json);
        return Sort(node)?.ToJsonString() ?? "null";
    }

    public static void AssertEquivalent(object? expected, object? actual)
    {
        var expectedJson = Canonical(expected);
        var actualJson = Canonical(actual);

        if (!string.Equals(expectedJson, actualJson, StringComparison.Ordinal))
        {
            throw new XunitException(
                "Objects are not JSON-equivalent after round-trip.\n" +
                "--- expected (original) ---\n" + expectedJson + "\n" +
                "--- actual (round-tripped) ---\n" + actualJson);
        }
    }

    private static JsonNode? Sort(JsonNode? node)
    {
        switch (node)
        {
            case JsonObject obj:
            {
                var sorted = new JsonObject();
                foreach (var kvp in obj.OrderBy(p => p.Key, StringComparer.Ordinal))
                    sorted[kvp.Key] = Sort(kvp.Value?.DeepClone());
                return sorted;
            }
            case JsonArray arr:
            {
                var sortedArray = new JsonArray();
                foreach (var item in arr.ToList())
                    sortedArray.Add(Sort(item?.DeepClone()));
                return sortedArray;
            }
            default:
                return node;
        }
    }
}
