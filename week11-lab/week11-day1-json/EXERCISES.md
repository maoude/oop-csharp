# Exercises — Week 11 · Tokenizers · Semi-Structured Data · JSON

## Part 1 · Tokenizer — `Ex1_JsonTokenizer.cs`

Implement a hand-rolled JSON tokenizer. The `TokenKind` enum and `Token` record are provided — implement the `Tokenize` method and its private helpers.

**TokenKind (provided)**

```
LeftBrace  RightBrace  LeftBracket  RightBracket
Colon  Comma
StringLiteral  NumberLiteral  BooleanLiteral  Null
```

**Token (provided)**

```csharp
public record Token(TokenKind Kind, string Value);
```

**JsonTokenizer**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `Tokenize` | `IReadOnlyList<Token> Tokenize(string input)` | Scan `input` left to right; skip whitespace; return all tokens in order; empty or whitespace-only input → empty list |
| `ReadString` *(private)* | `Token ReadString(string input, ref int i)` | Called when current char is `"`; advances `i` past the closing `"`; handles `\"` and `\\` escape sequences; returns a `StringLiteral` token whose `Value` is the content without surrounding quotes |
| `ReadNumber` *(private)* | `Token ReadNumber(string input, ref int i)` | Called when current char is `-` or a digit; reads the full number (integer or float); returns a `NumberLiteral` token |
| `ReadKeyword` *(private)* | `Token ReadKeyword(string input, ref int i)` | Called when current char is `t`, `f`, or `n`; matches `true`, `false`, `null`; returns `BooleanLiteral` or `Null` token |

Test class: `StudentWeek11Part1_Ex1Tests` · **13 tests**

---

## Part 2 · JsonDocument — `Ex1_JsonDocumentReader.cs`

Read JSON dynamically using `System.Text.Json.JsonDocument`. Every method must wrap `JsonDocument.Parse` in a `using` statement.

**JsonDocumentReader**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `ReadStringProperty` | `string? ReadStringProperty(string json, string key)` | Returns the string value of `key`; `null` if key missing or value is JSON `null`; throws `JsonException` for invalid JSON |
| `ReadNumberProperty` | `double? ReadNumberProperty(string json, string key)` | Returns the numeric value of `key` as `double`; `null` if key missing or not a number |
| `ReadBoolProperty` | `bool? ReadBoolProperty(string json, string key)` | Returns `true`/`false` for JSON booleans; `null` if key missing or not a boolean |
| `ReadStringArray` | `string[] ReadStringArray(string json, string key)` | Returns all string elements of the array at `key`; empty array if key missing |
| `GetArrayLength` | `int GetArrayLength(string json, string key)` | Returns element count of the array at `key`; `0` if key missing |
| `GetObjectKeys` | `string[] GetObjectKeys(string json)` | Returns all top-level property names of the JSON object |

Test class: `StudentWeek11Part2_Ex1Tests` · **13 tests**

---

## Part 3 · JsonSerializer — `Ex1_JsonSerializerHelper.cs`

Use `System.Text.Json.JsonSerializer` for typed serialisation and deserialisation. The model classes `PersonRecord` and `ProductRecord` are provided in the file.

**JsonSerializerHelper**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `Serialize<T>` | `string Serialize<T>(T obj)` | Returns compact JSON (no indentation) |
| `SerializeIndented<T>` | `string SerializeIndented<T>(T obj)` | Returns pretty-printed JSON with `WriteIndented = true` |
| `Deserialize<T>` | `T? Deserialize<T>(string json)` | Returns a typed object; throws `JsonException` for invalid JSON |
| `TryDeserialize<T>` | `bool TryDeserialize<T>(string json, out T? result)` | Returns `true` + result on success; `false` + `default` on any exception — must never throw |

**Model classes (provided — do not modify)**

```csharp
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
```

Test class: `StudentWeek11Part3_Ex1Tests` · **13 tests**
