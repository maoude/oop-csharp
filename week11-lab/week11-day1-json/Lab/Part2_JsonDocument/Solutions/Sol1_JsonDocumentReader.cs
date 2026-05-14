using System.Text.Json;

namespace OopCsharp.Week11.Part2_JsonDocument.Solutions;

/// <summary>Reference implementation of JsonDocumentReader.</summary>
public class Sol1_JsonDocumentReader
{
    /// <summary>Returns the string value of key; null if absent or JSON null; throws JsonException for invalid JSON.</summary>
    public string? ReadStringProperty(string json, string key)
    {
        using var doc = JsonDocument.Parse(json);
        if (!doc.RootElement.TryGetProperty(key, out var element)) return null;
        if (element.ValueKind == JsonValueKind.Null) return null;
        return element.GetString();
    }

    /// <summary>Returns the numeric value of key as double; null if absent or not a number.</summary>
    public double? ReadNumberProperty(string json, string key)
    {
        using var doc = JsonDocument.Parse(json);
        if (!doc.RootElement.TryGetProperty(key, out var element)) return null;
        if (element.ValueKind != JsonValueKind.Number) return null;
        return element.GetDouble();
    }

    /// <summary>Returns the boolean value of key; null if absent or not a boolean.</summary>
    public bool? ReadBoolProperty(string json, string key)
    {
        using var doc = JsonDocument.Parse(json);
        if (!doc.RootElement.TryGetProperty(key, out var element)) return null;
        if (element.ValueKind == JsonValueKind.True)  return true;
        if (element.ValueKind == JsonValueKind.False) return false;
        return null;
    }

    /// <summary>Returns all string elements of the array at key; empty array if absent.</summary>
    public string[] ReadStringArray(string json, string key)
    {
        using var doc = JsonDocument.Parse(json);
        if (!doc.RootElement.TryGetProperty(key, out var element)) return Array.Empty<string>();
        if (element.ValueKind != JsonValueKind.Array)  return Array.Empty<string>();
        return element.EnumerateArray()
                      .Select(e => e.GetString() ?? "")
                      .ToArray();
    }

    /// <summary>Returns the number of elements in the array at key; 0 if absent.</summary>
    public int GetArrayLength(string json, string key)
    {
        using var doc = JsonDocument.Parse(json);
        if (!doc.RootElement.TryGetProperty(key, out var element)) return 0;
        if (element.ValueKind != JsonValueKind.Array)  return 0;
        return element.GetArrayLength();
    }

    /// <summary>Returns all top-level property names of the JSON object.</summary>
    public string[] GetObjectKeys(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.EnumerateObject()
                              .Select(p => p.Name)
                              .ToArray();
    }
}
