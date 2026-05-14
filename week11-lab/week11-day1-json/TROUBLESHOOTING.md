# Troubleshooting — Week 11 · Tokenizers · Semi-Structured Data · JSON

## Part 1 — Tokenizer

**Q: My tokenizer hangs / loops forever on certain inputs.**  
`i` must always advance inside each branch. Check that `ReadString` advances past the closing `"`, `ReadNumber` stops when the character is not a number character, and each single-char branch does `i++` (or the outer loop increments `i` after the switch). A common mistake is forgetting `i++` at the end of the `switch` default block.

**Q: `ReadKeyword` throws `IndexOutOfRangeException`.**  
Use `input.Substring(i)` before calling `StartsWith`, which is safe, or guard with `i + keyword.Length <= input.Length` before accessing `input[i..]`.

**Q: The `ReadString` test for `\"` fails.**  
After seeing `\` at position `i`, the next character at `i+1` must be appended verbatim and `i` must advance by 2, not 1. Check your escape-handling branch.

**Q: `Tokenize` returns tokens for whitespace-only input instead of an empty list.**  
The outer loop must `continue` (or simply not add a token) when `char.IsWhiteSpace(input[i])` is true.

---

## Part 2 — JsonDocument

**Q: `ObjectDisposedException` in tests.**  
You accessed a `JsonElement` after the `using` block closed its `JsonDocument`. Extract the value (call `GetString()`, `GetDouble()`, etc.) inside the `using` block and return the C# value, not the `JsonElement`.

**Q: `InvalidOperationException: Cannot get the value of a token type 'Null' as a string.`**  
Check `element.ValueKind == JsonValueKind.Null` before calling `element.GetString()`. Return `null` in that branch.

**Q: `ReadStringProperty` returns a non-null value when the JSON key is absent.**  
`TryGetProperty` returns `false` when the key is absent — make sure you check the bool return value, not just `out var element`. `element` will be a default `JsonElement` when `TryGetProperty` returns `false`.

**Q: `ReadBoolProperty` returns `null` for `true` and `false`.**  
JSON booleans have `ValueKind == JsonValueKind.True` or `ValueKind == JsonValueKind.False`, not `JsonValueKind.String`. Call `element.GetBoolean()` only after confirming one of those two kinds.

**Q: `GetObjectKeys` throws on `{ }`.**  
`EnumerateObject()` on an empty object is valid and returns an empty enumerator. No special-casing needed — just convert with `.Select(p => p.Name).ToArray()`.

---

## Part 3 — JsonSerializer

**Q: `TryDeserialize` test fails because the method throws instead of returning `false`.**  
Wrap the entire body in `try { ... } catch (Exception) { result = default; return false; }`. Catch `Exception`, not just `JsonException`, because `ArgumentNullException` can also be thrown for null input.

**Q: `[JsonPropertyName]` test fails — property reads back as `null`.**  
The attribute must be on the property in the model class, not in your helper. The provided `ProductRecord.Name` already has `[JsonPropertyName("product_name")]` — do not modify the model class.

**Q: `SerializeIndented` test fails — no newlines found.**  
Pass `new JsonSerializerOptions { WriteIndented = true }` to `JsonSerializer.Serialize`. Compact and indented must be two separate calls, not the same options object.

**Q: `Deserialize<List<PersonRecord>>` returns `null`.**  
`JsonSerializer.Deserialize<T>` can return `null` for reference types when the JSON is `"null"`. The test passes a JSON array `[...]`, which should deserialize correctly. Check the generic type argument — `Deserialize<List<PersonRecord>>(json)` not `Deserialize<PersonRecord>(json)`.

---

## Build / Project

**Q: `dotnet test` reports "The project file could not be loaded."**  
Run `dotnet build Lab/Lab.csproj` first to confirm the library compiles. Then `dotnet build Lab.Tests/Lab.Tests.csproj`.

**Q: Implicit usings are enabled but `JsonDocument` / `JsonSerializer` are not found.**  
Add `using System.Text.Json;` explicitly at the top of the file. `System.Text.Json` types are not included in C#'s implicit using set.

**Q: `record Token` causes CS0246 — type not found in test file.**  
The test file references `OopCsharp.Week11.Part1_Tokenizer.Exercises` namespace. Make sure `TokenKind` and `Token` are declared in that namespace (or a nested one), and the test project references the Lab project.
