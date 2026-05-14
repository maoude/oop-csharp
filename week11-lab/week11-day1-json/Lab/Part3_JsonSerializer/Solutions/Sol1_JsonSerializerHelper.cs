/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     11 — Tokenizers · Semi-Structured Data · JSON
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_JsonSerializerHelper. [INSTRUCTOR ONLY]
 *           Do not open until after submitting your own implementation.
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace OopCsharp.Week11.Part3_JsonSerializer.Solutions;

public class SolPersonRecord
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public bool IsActive { get; set; }
}

public class SolProductRecord
{
    [JsonPropertyName("product_name")]
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public string[] Tags { get; set; } = Array.Empty<string>();
}

/// <summary>Reference implementation of JsonSerializerHelper.</summary>
public class Sol1_JsonSerializerHelper
{
    /// <summary>Returns compact JSON for obj.</summary>
    public string Serialize<T>(T obj) =>
        JsonSerializer.Serialize(obj);

    /// <summary>Returns pretty-printed JSON for obj.</summary>
    public string SerializeIndented<T>(T obj) =>
        JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });

    /// <summary>Returns a typed object; throws JsonException for invalid JSON.</summary>
    public T? Deserialize<T>(string json) =>
        JsonSerializer.Deserialize<T>(json);

    /// <summary>Returns true + result on success; false + default on any exception.</summary>
    public bool TryDeserialize<T>(string json, out T? result)
    {
        try
        {
            result = JsonSerializer.Deserialize<T>(json);
            return true;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }
}
