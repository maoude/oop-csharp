# Quiz Questions — Week 11 · Tokenizers · Semi-Structured Data · JSON

## Part 1 — Tokenizer

**Q1.** What is a token in the context of lexical analysis? How does a token differ from a single character, and why is tokenisation a useful first step before parsing?

**Q2.** The tokenizer must handle the escape sequence `\"` inside a JSON string. What would happen if it did not — i.e., if it stopped reading at the first `"` it encountered regardless of backslash?

**Q3.** What is the difference between structured, semi-structured, and unstructured data? Classify a CSV file, a JSON file, and a plain text email.

**Q4.** JSON requires all keys to be quoted strings. What does your tokenizer produce for the input `{name: "Alice"}`? Is that valid JSON?

**Q5.** A number tokenizer reads until it hits a character that is not a digit, `.`, `e`, `E`, `+`, or `-`. What does it produce for the input `"42abc"`? Is `"42abc"` valid JSON?

## Part 2 — JsonDocument

**Q6.** `JsonDocument` implements `IDisposable`. What resource does it manage, and what happens if you forget to call `Dispose()`?

**Q7.** What does `TryGetProperty(key, out var element)` return if the key exists but its value is JSON `null`? How is this different from the key being absent?

**Q8.** What is the difference between `JsonElement.GetString()` and `JsonElement.GetRawText()`? Give an example where they return different values.

**Q9.** `JsonElement.ValueKind` can be `String`, `Number`, `True`, `False`, `Null`, `Object`, or `Array`. Why do `True` and `False` have separate enum values rather than a single `Boolean`?

**Q10.** You call `doc.RootElement.GetProperty("tags").EnumerateArray()` but `"tags"` contains a JSON object, not an array. What exception is thrown?

## Part 3 — JsonSerializer

**Q11.** By default, `JsonSerializer.Deserialize<Person>` matches JSON keys to C# property names **case-sensitively**. What option do you set to make matching case-insensitive?

**Q12.** `JsonSerializer.Serialize(obj)` writes property names exactly as declared in C# (PascalCase by default). How do you configure it to write `camelCase` keys instead?

**Q13.** You add a property to `PersonRecord` but the old JSON files do not have that key. What does `Deserialize` do with the missing key?

**Q14.** What does `[JsonPropertyName("product_name")]` do? Why would you use it instead of renaming the C# property?

**Q15.** `JsonSerializer.Serialize(null)` — what string does it return? What does `JsonSerializer.Deserialize<PersonRecord>("null")` return?

---

## Answers (instructor key)

> Remove or hide this section before distributing to students.

1. A token is a meaningful unit of text: a single-character punctuation mark (`{`, `:`), a quoted string, a number, or a keyword (`true`, `null`). A character is a single code point. Tokenisation groups characters into tokens so the parser can reason about grammar rules (e.g., "a key is a string followed by a colon") rather than individual characters.

2. The tokenizer would end the string at the `"` inside `\"`, producing a truncated string token and then likely failing on the characters that follow. For example, `"say \"hello\""` would be tokenised as string `say \`, then garbage.

3. Structured: CSV — fixed columns with a defined schema. Semi-structured: JSON — flexible schema described inline with the data. Unstructured: plain text email — no machine-readable schema; meaning must be inferred.

4. The tokenizer would encounter `n` at the start of `name`, call `ReadKeyword`, and try to match `null`. Since `name` doesn't match any keyword, it would throw. `{name: "Alice"}` is NOT valid JSON — keys must be quoted strings.

5. The tokenizer reads `4`, `2` (digits), then hits `a` which is not a valid number character and stops. It produces a `NumberLiteral` token with value `"42"`, leaving `abc"` to be processed next (which would fail as an unknown keyword starting with `a`). `"42abc"` is not valid JSON.

6. `JsonDocument` uses a pooled `ArrayPool<byte>` buffer internally to avoid allocations. If not disposed, the rented array is never returned to the pool, causing pool exhaustion under load. In short: `JsonDocument` is a case where `using` is correctness-critical, not just a style preference.

7. `TryGetProperty` returns `true` (the key exists) and `element.ValueKind` is `JsonValueKind.Null`. When the key is absent, `TryGetProperty` returns `false`. The distinction matters: a present-but-null property might mean "explicitly cleared" while an absent property might mean "not provided yet."

8. `GetString()` returns the decoded string value (escape sequences expanded, surrounding quotes removed). `GetRawText()` returns the raw JSON text of the element, including surrounding quotes and escape sequences. For the JSON `"hel\"lo"`, `GetString()` returns `hel"lo` while `GetRawText()` returns `"hel\"lo"`.

9. In the JSON spec, `true` and `false` are two distinct literal tokens. Giving them separate `ValueKind` values allows code to check `if (element.ValueKind == JsonValueKind.True)` rather than `element.GetBoolean() == true`, avoiding an exception if the kind is not a boolean at all.

10. `InvalidOperationException` — `EnumerateArray()` requires the element to have `ValueKind == Array`. If the value is an object, this invariant is violated and an exception is thrown at runtime.

11. Set `JsonSerializerOptions.PropertyNameCaseInsensitive = true`. Example: `JsonSerializer.Deserialize<Person>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })`.

12. Set `JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase`. This converts `FirstName` → `firstName`, `IsActive` → `isActive`, etc.

13. The property gets its default value (e.g., `null` for a string, `0` for an int). `Deserialize` does not throw for missing keys by default — it silently leaves unmapped properties at their C# default.

14. `[JsonPropertyName("product_name")]` maps the C# property `Name` to the JSON key `"product_name"`. You use it when the JSON schema uses a naming convention (snake_case, camelCase) that differs from your C# convention (PascalCase), or when you cannot rename the C# property because it would break other code.

15. `JsonSerializer.Serialize(null)` returns the string `"null"`. `JsonSerializer.Deserialize<PersonRecord>("null")` returns `null` (the C# null reference) — deserialising the JSON null literal into a reference type yields `null`.
