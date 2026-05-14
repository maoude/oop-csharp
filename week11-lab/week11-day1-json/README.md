# Week 11 — Tokenizers · Semi-Structured Data · JSON

**Course:** Introduction to OOP with C#
**Lab:** week11-day1-json

## Learning objectives

- Explain what a tokenizer (lexer) does and implement a simple one for JSON
- Categorise data as structured, semi-structured, or unstructured
- Navigate a parsed JSON tree with `JsonDocument`, `JsonElement`, and `ValueKind`
- Read typed values with `GetString()`, `GetInt32()`, `GetDouble()`, `GetBoolean()`
- Deserialise JSON into strongly-typed C# classes with `JsonSerializer.Deserialize<T>`
- Serialise C# objects to JSON with `JsonSerializer.Serialize`
- Map mismatched JSON keys to C# properties with `[JsonPropertyName]`
- Dispose `JsonDocument` correctly (it owns pooled memory)

## Structure

```
week11-day1-json/
├── README.md
├── LAB_INSTRUCTIONS.md
├── EXERCISES.md
├── CHECKLIST.md
├── QUIZ_QUESTIONS.md
├── OOP_DESIGN_SCORECARD.md
├── TROUBLESHOOTING.md
├── Lab/
│   ├── Lab.csproj
│   ├── Part1_Tokenizer/
│   │   ├── Demo01_Tokenizer.cs
│   │   ├── Exercises/
│   │   │   └── Ex1_JsonTokenizer.cs
│   │   └── Solutions/
│   │       └── Sol1_JsonTokenizer.cs
│   ├── Part2_JsonDocument/
│   │   ├── Demo02_JsonDocument.cs
│   │   ├── Exercises/
│   │   │   └── Ex1_JsonDocumentReader.cs
│   │   └── Solutions/
│   │       └── Sol1_JsonDocumentReader.cs
│   └── Part3_JsonSerializer/
│       ├── Demo03_JsonSerializer.cs
│       ├── Exercises/
│       │   └── Ex1_JsonSerializerHelper.cs
│       └── Solutions/
│           └── Sol1_JsonSerializerHelper.cs
└── Lab.Tests/
    ├── Lab.Tests.csproj
    ├── Part1_Tokenizer/
    │   └── StudentWeek11Part1_Ex1Tests.cs
    ├── Part2_JsonDocument/
    │   └── StudentWeek11Part2_Ex1Tests.cs
    └── Part3_JsonSerializer/
        └── StudentWeek11Part3_Ex1Tests.cs
```

## Quick start

```bash
cd week11-day1-json

# run all 39 tests (all should fail until you implement them)
dotnet test Lab.Tests/Lab.Tests.csproj

# run tests for one part only
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part1"

# watch mode
dotnet watch test --project Lab.Tests/Lab.Tests.csproj
```
