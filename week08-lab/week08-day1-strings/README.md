# Week 8 — Strings and StringBuilder

**Course:** Introduction to OOP with C#
**Lab:** week8-day1-strings

## Learning objectives

- Distinguish `char` (value type) from `string` (reference type) and apply `System.Char` static methods
- Explain string immutability and why `s += "!"` in a loop is expensive
- Use `IndexOf`, `Contains`, `StartsWith`, `EndsWith` with `StringComparison` overloads
- Extract and transform substrings with `Split`, `ToUpper`, `Trim`, `Replace`, and range indexers
- Build strings efficiently using `StringBuilder` (`Append`, `Insert`, `Remove`, `Replace`)
- Choose between `string` and `StringBuilder` based on the number of concatenation operations
- Handle null and empty strings defensively with `string.IsNullOrWhiteSpace`

## Structure

```
week8-day1-strings/
├── README.md
├── LAB_INSTRUCTIONS.md
├── EXERCISES.md
├── CHECKLIST.md
├── QUIZ_QUESTIONS.md
├── OOP_DESIGN_SCORECARD.md
├── TROUBLESHOOTING.md
├── Lab/
│   ├── Lab.csproj
│   ├── Part1_StringFundamentals/
│   │   ├── Demo01_StringFundamentals.cs
│   │   ├── Exercises/
│   │   │   └── Ex1_StringBasics.cs
│   │   └── Solutions/
│   │       └── Sol1_StringBasics.cs
│   ├── Part2_StringOperations/
│   │   ├── Demo02_StringOperations.cs
│   │   ├── Exercises/
│   │   │   ├── Ex1_StringSearch.cs
│   │   │   └── Ex2_StringManipulator.cs
│   │   └── Solutions/
│   │       ├── Sol1_StringSearch.cs
│   │       └── Sol2_StringManipulator.cs
│   └── Part3_StringBuilder/
│       ├── Demo03_StringBuilder.cs
│       ├── Exercises/
│       │   └── Ex1_TextBuilder.cs
│       └── Solutions/
│           └── Sol1_TextBuilder.cs
└── Lab.Tests/
    ├── Lab.Tests.csproj
    ├── Part1_StringFundamentals/
    │   └── StudentWeek8Part1_Ex1Tests.cs
    ├── Part2_StringOperations/
    │   ├── StudentWeek8Part2_Ex1Tests.cs
    │   └── StudentWeek8Part2_Ex2Tests.cs
    └── Part3_StringBuilder/
        └── StudentWeek8Part3_Ex1Tests.cs
```

## Quick start

```bash
cd week8-day1-strings

# run all 39 tests (all should fail until you implement them)
dotnet test Lab.Tests/Lab.Tests.csproj

# run tests for one part only
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part1"

# watch mode — re-runs on every save
dotnet watch test --project Lab.Tests/Lab.Tests.csproj
```
