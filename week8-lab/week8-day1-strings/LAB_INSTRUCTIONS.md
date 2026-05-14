# Lab Instructions — Week 8 · Strings and StringBuilder

## Step 1 — Open the demo files first

Each part ships with a read-only instructor demo. Read it before touching any exercise file.

```
Lab/Part1_StringFundamentals/Demo01_StringFundamentals.cs
Lab/Part2_StringOperations/Demo02_StringOperations.cs
Lab/Part3_StringBuilder/Demo03_StringBuilder.cs
```

Observe the patterns: how `char` methods differ from `string` methods, how `StringComparison` prevents locale bugs, and when `StringBuilder` is preferred over `+`.

## Step 2 — Verify the baseline

Run the tests once before writing any code. Every test should fail with `NotImplementedException`.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj
```

Expected output: **39 failed, 0 passed.**

## Step 3 — Implement Part 1 · String Fundamentals

Open `Lab/Part1_StringFundamentals/Exercises/Ex1_StringBasics.cs`.  
Replace each `throw new NotImplementedException()` with a working implementation.

Run your tests after each method:

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part1"
```

Target: **13 passed.**

Key questions to answer before you code:
- What does `char.IsDigit` check vs `c >= '0' && c <= '9'`?
- Why is reversing a string done through a `char[]`, not character-by-character `+=`?

## Step 4 — Implement Part 2 · String Operations

Open the two exercise files in order:

1. `Lab/Part2_StringOperations/Exercises/Ex1_StringSearch.cs`
2. `Lab/Part2_StringOperations/Exercises/Ex2_StringManipulator.cs`

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part2"
```

Target: **14 passed** (7 per exercise).

Key questions:
- Why pass `StringComparison.OrdinalIgnoreCase` to `Contains` / `IndexOf` instead of calling `.ToLower()` first?
- How does `text.Split(new char[]{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)` differ from `text.Split(' ')`?

## Step 5 — Implement Part 3 · StringBuilder

Open `Lab/Part3_StringBuilder/Exercises/Ex1_TextBuilder.cs`.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part3"
```

Target: **12 passed.**

Key question before coding:
- When is `new StringBuilder(initialCapacity)` worth specifying?

## Step 6 — Full suite green

```bash
dotnet test Lab.Tests/Lab.Tests.csproj
```

Expected: **39 passed, 0 failed.**

## Step 7 — Fill in the design scorecard

Open `OOP_DESIGN_SCORECARD.md` and score your own work honestly.  
Write 4–8 sentences for the required explanation section.

## Command reference

| Command | Purpose |
|---------|---------|
| `dotnet test Lab.Tests/Lab.Tests.csproj` | Run all 39 tests |
| `dotnet test --filter "ClassName"` | Run tests for one class |
| `dotnet test --filter "Part1"` | Run all Part 1 tests |
| `dotnet build Lab/Lab.csproj` | Build without running tests |
| `dotnet watch test --project Lab.Tests/Lab.Tests.csproj` | Watch mode |
