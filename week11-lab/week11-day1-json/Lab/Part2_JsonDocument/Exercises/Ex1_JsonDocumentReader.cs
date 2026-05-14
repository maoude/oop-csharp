using System.Text.Json;

namespace OopCsharp.Week11.Part2_JsonDocument.Exercises;

/// <summary>Reads JSON values dynamically using System.Text.Json.JsonDocument.</summary>
public class JsonDocumentReader
{
    /// <summary>
    /// Returns the string value of <paramref name="key"/> in <paramref name="json"/>.
    /// Returns <c>null</c> if the key is absent or its value is JSON <c>null</c>.
    /// Throws <see cref="JsonException"/> for invalid JSON.
    /// </summary>
    public string? ReadStringProperty(string json, string key)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the numeric value of <paramref name="key"/> as <c>double</c>.
    /// Returns <c>null</c> if the key is absent or its value is not a JSON number.
    /// </summary>
    public double? ReadNumberProperty(string json, string key)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns <c>true</c> or <c>false</c> for JSON boolean values.
    /// Returns <c>null</c> if the key is absent or its value is not a JSON boolean.
    /// </summary>
    public bool? ReadBoolProperty(string json, string key)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns all string elements of the array at <paramref name="key"/>.
    /// Returns an empty array if the key is absent.
    /// </summary>
    public string[] ReadStringArray(string json, string key)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the number of elements in the array at <paramref name="key"/>.
    /// Returns 0 if the key is absent.
    /// </summary>
    public int GetArrayLength(string json, string key)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns all top-level property names of <paramref name="json"/>.
    /// </summary>
    public string[] GetObjectKeys(string json)
    {
        // TODO: implement
        throw new NotImplementedException();
    }
}
