# Checklist — Week 11 · Tokenizers · Semi-Structured Data · JSON

## Part 1 — Tokenizer

- [ ] **W11.P1.Ex1 — JsonTokenizer** · `StudentWeek11Part1_Ex1Tests` · 13 tests
  - [ ] `Tokenize()` returns `LeftBrace` token for `{`
  - [ ] `Tokenize()` returns `RightBrace` token for `}`
  - [ ] `Tokenize()` returns `Colon` and `Comma` tokens
  - [ ] `Tokenize()` returns `LeftBracket` and `RightBracket` tokens
  - [ ] `Tokenize()` produces a `StringLiteral` token with the unquoted value
  - [ ] `Tokenize()` handles escaped quote `\"` inside a string
  - [ ] `Tokenize()` produces `NumberLiteral` for an integer
  - [ ] `Tokenize()` produces `NumberLiteral` for a floating-point number
  - [ ] `Tokenize()` produces `BooleanLiteral` for `true` and `false`
  - [ ] `Tokenize()` produces `Null` token for `null`
  - [ ] `Tokenize()` produces the correct sequence for a simple JSON object
  - [ ] `Tokenize()` produces the correct sequence for a JSON array
  - [ ] `Tokenize()` returns an empty list for whitespace-only input

## Part 2 — JsonDocument

- [ ] **W11.P2.Ex1 — JsonDocumentReader** · `StudentWeek11Part2_Ex1Tests` · 13 tests
  - [ ] `ReadStringProperty()` returns value for existing string key
  - [ ] `ReadStringProperty()` returns `null` for missing key
  - [ ] `ReadStringProperty()` returns `null` when value is JSON `null`
  - [ ] `ReadNumberProperty()` returns correct `double` value
  - [ ] `ReadNumberProperty()` returns `null` for missing key
  - [ ] `ReadBoolProperty()` returns `true` for JSON `true`
  - [ ] `ReadBoolProperty()` returns `false` for JSON `false`
  - [ ] `ReadStringArray()` returns all elements of a string array
  - [ ] `ReadStringArray()` returns empty array for missing key
  - [ ] `GetArrayLength()` returns correct element count
  - [ ] `GetObjectKeys()` returns all top-level property names
  - [ ] `GetObjectKeys()` returns empty array for empty JSON object
  - [ ] `ReadStringProperty()` throws `JsonException` for invalid JSON

## Part 3 — JsonSerializer

- [ ] **W11.P3.Ex1 — JsonSerializerHelper** · `StudentWeek11Part3_Ex1Tests` · 13 tests
  - [ ] `Serialize()` output contains the object's property values
  - [ ] `Serialize()` produces valid JSON (re-deserialises without error)
  - [ ] `SerializeIndented()` output contains newlines
  - [ ] `SerializeIndented()` round-trips back to the same object
  - [ ] `Deserialize()` returns object with correct string property
  - [ ] `Deserialize()` returns object with correct int property
  - [ ] `Deserialize()` round-trips a list of objects
  - [ ] `Deserialize()` maps `[JsonPropertyName]` snake_case key correctly
  - [ ] `TryDeserialize()` returns `true` and result for valid JSON
  - [ ] `TryDeserialize()` returns `false` and null for invalid JSON
  - [ ] `TryDeserialize()` never throws — no exception propagates
  - [ ] `Serialize()` then `Deserialize()` — values match the original
  - [ ] `Deserialize()` handles JSON array into `List<PersonRecord>`

## Final check

- [ ] All **39 tests** pass: `dotnet test Lab.Tests/Lab.Tests.csproj`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in with honest self-assessment
- [ ] `QUIZ_QUESTIONS.md` read at least once
