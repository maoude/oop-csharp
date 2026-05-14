# Lab Instructions — Week 11 · Tokenizers · Semi-Structured Data · JSON

## Step 1 — Open the demo files first

```
Lab/Part1_Tokenizer/Demo01_Tokenizer.cs
Lab/Part2_JsonDocument/Demo02_JsonDocument.cs
Lab/Part3_JsonSerializer/Demo03_JsonSerializer.cs
```

Pay attention to: how the tokenizer dispatches on the current character, how `JsonDocument` must be disposed, and how `[JsonPropertyName]` maps mismatched keys.

## Step 2 — Verify the baseline

```bash
dotnet test Lab.Tests/Lab.Tests.csproj
```

Expected: **39 failed, 0 passed.**

## Step 3 — Implement Part 1 · Tokenizer

Open `Lab/Part1_Tokenizer/Exercises/Ex1_JsonTokenizer.cs`.

Implement `Tokenize(string input)` using the private helper stubs (`ReadString`, `ReadNumber`, `ReadKeyword`). Build up a `List<Token>` by scanning left to right.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part1"
```

Target: **13 passed.**

Key rules:
- Skip whitespace characters silently.
- Single-character tokens (`{`, `}`, `[`, `]`, `:`, `,`) are dispatched in a `switch`.
- String literals start with `"` — read until the matching unescaped `"`.
- Number literals start with `-` or a digit — read digits, `.`, `e`, `E`.
- Keywords `true`, `false`, `null` start with `t`, `f`, `n`.

## Step 4 — Implement Part 2 · JsonDocument

Open `Lab/Part2_JsonDocument/Exercises/Ex1_JsonDocumentReader.cs`.

Every method must wrap `JsonDocument.Parse(json)` in a `using` statement.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part2"
```

Target: **13 passed.**

Key rules:
- Use `TryGetProperty(key, out var element)` to avoid `KeyNotFoundException`.
- Check `element.ValueKind` before calling typed getters (`GetString`, `GetDouble`, etc.).
- `EnumerateArray()` and `EnumerateObject()` iterate arrays and objects respectively.

## Step 5 — Implement Part 3 · JsonSerializer

Open `Lab/Part3_JsonSerializer/Exercises/Ex1_JsonSerializerHelper.cs`.

Model classes (`PersonRecord`, `ProductRecord`) are already provided in that file — do not change them.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part3"
```

Target: **13 tests passed.**

Key rules:
- Use `new JsonSerializerOptions { WriteIndented = true }` for pretty output.
- `TryDeserialize` must catch `JsonException` and return `false` — it must never throw.
- `[JsonPropertyName("snake_case")]` on a property tells the serializer which JSON key to use.

## Step 6 — Full suite green

```bash
dotnet test Lab.Tests/Lab.Tests.csproj
```

Expected: **39 passed, 0 failed.**

## Step 7 — Fill in the design scorecard

Open `OOP_DESIGN_SCORECARD.md` and score your own work honestly.

## Command reference

| Command | Purpose |
|---------|---------|
| `dotnet test Lab.Tests/Lab.Tests.csproj` | Run all 39 tests |
| `dotnet test --filter "Part3"` | Run Part 3 tests only |
| `dotnet build Lab/Lab.csproj` | Build without running tests |
| `dotnet watch test --project Lab.Tests/Lab.Tests.csproj` | Watch mode |
