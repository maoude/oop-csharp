/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     11 — Tokenizers · Semi-Structured Data · JSON
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: typed JSON serialization and deserialization using System.Text.Json.JsonSerializer.
 *           Practice: Serialize, SerializeIndented, Deserialize, TryDeserialize, [JsonPropertyName] mapping.
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace OopCsharp.Week11.Part3_JsonSerializer.Exercises;

// ── Model classes — do not modify ──────────────────────────────────────────

public class PersonRecord
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public bool IsActive { get; set; }
}

public class ProductRecord
{
    [JsonPropertyName("product_name")]
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public string[] Tags { get; set; } = Array.Empty<string>();
}

// ── Your implementation ─────────────────────────────────────────────────────

/// <summary>Thin wrapper around System.Text.Json.JsonSerializer.</summary>
public class JsonSerializerHelper
{
    /// <summary>Returns compact JSON (no indentation) for <paramref name="obj"/>.</summary>
    public string Serialize<T>(T obj)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>Returns pretty-printed JSON with WriteIndented = true.</summary>
    public string SerializeIndented<T>(T obj)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a typed object deserialized from <paramref name="json"/>.
    /// Throws <see cref="JsonException"/> for invalid JSON.
    /// </summary>
    public T? Deserialize<T>(string json)
    {
        // TODO: implement
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns <c>true</c> and the deserialized result on success.
    /// Returns <c>false</c> and <c>default</c> on any exception — must never throw.
    /// </summary>
    public bool TryDeserialize<T>(string json, out T? result)
    {
        // TODO: implement
        throw new NotImplementedException();
    }
}
