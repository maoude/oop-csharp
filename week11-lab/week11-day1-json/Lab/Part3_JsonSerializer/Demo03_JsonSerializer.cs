/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     11 — Tokenizers · Semi-Structured Data · JSON
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — System.Text.Json JsonSerializer: typed serialization, deserialization, [JsonPropertyName], TryDeserialize pattern.
 *           Read this file before starting Exercise 1.
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace OopCsharp.Week11.Part3_JsonSerializer.Demo;

// ── Model classes used in the demo ─────────────────────────────────────────
public class DemoPerson
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public bool IsActive { get; set; }
}

public class DemoProduct
{
    [JsonPropertyName("product_name")]
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public string[] Tags { get; set; } = Array.Empty<string>();
}

public static class Demo03_JsonSerializer
{
    public static void Run()
    {
        Console.WriteLine("=== Demo 03 — System.Text.Json JsonSerializer ===\n");

        var person = new DemoPerson { Name = "Alice", Age = 30, IsActive = true };

        // 1. Compact serialization
        string compact = JsonSerializer.Serialize(person);
        Console.WriteLine($"Compact:  {compact}");

        // 2. Pretty-printed serialization
        string pretty = JsonSerializer.Serialize(person,
            new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine($"\nIndented:\n{pretty}");

        // 3. Deserialization
        string json = """{"Name":"Bob","Age":25,"IsActive":false}""";
        var bob = JsonSerializer.Deserialize<DemoPerson>(json);
        Console.WriteLine($"\nDeserialized: {bob?.Name}, age {bob?.Age}");

        // 4. [JsonPropertyName] — maps C# Name ↔ JSON "product_name"
        var product = new DemoProduct { Name = "Widget", Price = 9.99, Tags = ["sale", "new"] };
        string prodJson = JsonSerializer.Serialize(product);
        Console.WriteLine($"\nProduct JSON: {prodJson}");
        var roundTrip = JsonSerializer.Deserialize<DemoProduct>(prodJson);
        Console.WriteLine($"Round-trip Name: {roundTrip?.Name}");

        // 5. Null handling
        string nullJson = JsonSerializer.Serialize<DemoPerson?>(null);
        Console.WriteLine($"\nSerialize(null) → \"{nullJson}\"");
        DemoPerson? nullResult = JsonSerializer.Deserialize<DemoPerson>("null");
        Console.WriteLine($"Deserialize(\"null\") → {nullResult?.ToString() ?? "(null)"}");

        // 6. List round-trip
        var people = new List<DemoPerson>
        {
            new() { Name = "Carol", Age = 28 },
            new() { Name = "Dave",  Age = 35 }
        };
        string listJson = JsonSerializer.Serialize(people);
        Console.WriteLine($"\nList JSON: {listJson}");
        var list2 = JsonSerializer.Deserialize<List<DemoPerson>>(listJson);
        Console.WriteLine($"Deserialized list count: {list2?.Count}");

        // 7. TryDeserialize pattern — catch internally, never propagate
        Console.WriteLine("\n--- TryDeserialize pattern ---");
        bool ok = TryDeserialize<DemoPerson>("NOT_JSON", out var bad);
        Console.WriteLine($"Invalid JSON → ok={ok}, result={bad}");
        bool ok2 = TryDeserialize<DemoPerson>(compact, out var good);
        Console.WriteLine($"Valid JSON   → ok={ok2}, Name={good?.Name}");
    }

    private static bool TryDeserialize<T>(string json, out T? result)
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
