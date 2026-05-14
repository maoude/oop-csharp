# Lab Instructions — Week 9 · Files in C# (Part 1)

## Step 1 — Open the demo files first

Read each demo before touching its exercise file.

```
Lab/Part1_FileOperations/Demo01_FileOperations.cs
Lab/Part2_DirectoryAndPath/Demo02_DirectoryAndPath.cs
Lab/Part3_DefensiveIO/Demo03_DefensiveIO.cs
```

Pay attention to: which methods are static (`File`, `Directory`, `Path`) vs instance (`FileInfo`, `DirectoryInfo`), and when to use each.

## Step 2 — Verify the baseline

```bash
dotnet test Lab.Tests/Lab.Tests.csproj
```

Expected: **39 failed, 0 passed.** Every test should throw `NotImplementedException`.

## Step 3 — Implement Part 1 · File Operations

Open `Lab/Part1_FileOperations/Exercises/Ex1_FileOperations.cs`.

Each method is a thin, correct wrapper around a `System.IO.File` or `FileInfo` call.  
The goal is to learn **which method to call** and **what it throws** naturally.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part1"
```

Target: **13 passed.**

Key questions:
- `File.Copy` has two overloads — which parameter controls whether an existing destination is overwritten?
- Why does `new FileInfo(path).Length` throw when the file does not exist?

## Step 4 — Implement Part 2 · Directory and Path

Open the two exercise files:

1. `Lab/Part2_DirectoryAndPath/Exercises/Ex1_DirectoryOperations.cs`
2. `Lab/Part2_DirectoryAndPath/Exercises/Ex2_PathHelper.cs`

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part2"
```

Target: **13 passed** (7 + 6).

Key questions:
- Why is `Path.Combine` safer than string concatenation for building paths?
- What makes `Directory.CreateDirectory` safe to call even when the directory already exists?

## Step 5 — Implement Part 3 · Defensive I/O

Open `Lab/Part3_DefensiveIO/Exercises/Ex1_SafeFileReader.cs`.

The TryXxx pattern: catch exceptions internally and return `null`/`false`/a default — never propagate.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part3"
```

Target: **13 passed.**

Key questions:
- Why does `TryReadText` return `null` instead of `""` for missing files?
- What is wrong with checking `File.Exists` before `File.ReadAllText` in a multithreaded context?

## Step 6 — Full suite green

```bash
dotnet test Lab.Tests/Lab.Tests.csproj
```

Expected: **39 passed, 0 failed.**

## Step 7 — Fill in the design scorecard

Open `OOP_DESIGN_SCORECARD.md` and score your own work.  
Write 4–8 sentences for the required explanation section.

## Command reference

| Command | Purpose |
|---------|---------|
| `dotnet test Lab.Tests/Lab.Tests.csproj` | Run all 39 tests |
| `dotnet test --filter "Part1"` | Run Part 1 tests only |
| `dotnet test --filter "StudentWeek9Part3"` | Run a single test class |
| `dotnet build Lab/Lab.csproj` | Build without running tests |
| `dotnet watch test --project Lab.Tests/Lab.Tests.csproj` | Watch mode |
