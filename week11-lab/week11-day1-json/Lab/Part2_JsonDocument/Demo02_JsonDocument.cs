/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     11 — Tokenizers · Semi-Structured Data · JSON
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — System.Text.Json JsonDocument: TryGetProperty, ValueKind checks, array/object enumeration, disposal.
 *           Read this file before starting Exercise 1.
 */

using System.Text.Json;

namespace OopCsharp.Week11.Part2_JsonDocument.Demo;

public static class Demo02_JsonDocument
{
    public static void Run()
    {
        Console.WriteLine("=== Demo 02 — System.Text.Json JsonDocument ===\n");

        string json = """
            {
                "name": "Alice",
                "age": 30,
                "active": true,
                "score": 9.5,
                "nickname": null,
                "tags": ["admin", "user"],
                "address": { "city": "Beirut", "zip": "1001" }
            }
            """;

        // 1. Parse inside a using block — JsonDocument rents an ArrayPool buffer.
        //    If we forget to dispose it, the buffer is never returned (pool exhaustion).
        using var doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        // 2. Reading a string property safely with TryGetProperty
        if (root.TryGetProperty("name", out JsonElement nameEl))
            Console.WriteLine($"name  = {nameEl.GetString()}");

        // 3. Missing key — TryGetProperty returns false
        if (!root.TryGetProperty("missing", out _))
            Console.WriteLine("'missing' key is absent (TryGetProperty returned false)");

        // 4. JSON null — key present but ValueKind is Null
        if (root.TryGetProperty("nickname", out JsonElement nickEl))
        {
            string? value = nickEl.ValueKind == JsonValueKind.Null
                ? null
                : nickEl.GetString();
            Console.WriteLine($"nickname = {value ?? "(null)"}");
        }

        // 5. Number
        if (root.TryGetProperty("age", out JsonElement ageEl) &&
            ageEl.ValueKind == JsonValueKind.Number)
            Console.WriteLine($"age   = {ageEl.GetDouble()}");

        // 6. Boolean — True and False are separate ValueKind values
        if (root.TryGetProperty("active", out JsonElement activeEl) &&
            (activeEl.ValueKind == JsonValueKind.True || activeEl.ValueKind == JsonValueKind.False))
            Console.WriteLine($"active = {activeEl.GetBoolean()}");

        // 7. Array enumeration
        if (root.TryGetProperty("tags", out JsonElement tagsEl) &&
            tagsEl.ValueKind == JsonValueKind.Array)
        {
            Console.Write("tags  = [");
            Console.Write(string.Join(", ", tagsEl.EnumerateArray().Select(e => e.GetString())));
            Console.WriteLine("]");
        }

        // 8. Nested object keys
        if (root.TryGetProperty("address", out JsonElement addrEl) &&
            addrEl.ValueKind == JsonValueKind.Object)
        {
            var keys = addrEl.EnumerateObject().Select(p => p.Name);
            Console.WriteLine($"address keys = [{string.Join(", ", keys)}]");
        }

        // 9. GetRawText vs GetString
        Console.WriteLine("\n--- GetRawText vs GetString ---");
        string escaped = """{"msg":"say \"hello\""}""";
        using var doc2 = JsonDocument.Parse(escaped);
        var msgEl = doc2.RootElement.GetProperty("msg");
        Console.WriteLine($"GetString()  = {msgEl.GetString()}");
        Console.WriteLine($"GetRawText() = {msgEl.GetRawText()}");
    }
}
