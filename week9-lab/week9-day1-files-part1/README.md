# Week 9 — Files in C# (Part 1)

**Course:** Introduction to OOP with C#
**Lab:** week9-day1-files-part1

## Learning objectives

- Use `File` static methods to read, write, append, copy, move, and delete files
- Use `FileInfo` to query file metadata (size, timestamps)
- Use `Directory` static methods to create, list, and check directories
- Build platform-safe paths with `Path.Combine`, `Path.GetFileName`, `Path.GetExtension`
- Apply the TryXxx pattern to file I/O: catch exceptions, return null/false instead of propagating
- Distinguish recoverable errors (file not found) from unrecoverable ones (disk full)

## Structure

```
week9-day1-files-part1/
├── README.md
├── LAB_INSTRUCTIONS.md
├── EXERCISES.md
├── CHECKLIST.md
├── QUIZ_QUESTIONS.md
├── OOP_DESIGN_SCORECARD.md
├── TROUBLESHOOTING.md
├── Lab/
│   ├── Lab.csproj
│   ├── Part1_FileOperations/
│   │   ├── Demo01_FileOperations.cs
│   │   ├── Exercises/
│   │   │   └── Ex1_FileOperations.cs
│   │   └── Solutions/
│   │       └── Sol1_FileOperations.cs
│   ├── Part2_DirectoryAndPath/
│   │   ├── Demo02_DirectoryAndPath.cs
│   │   ├── Exercises/
│   │   │   ├── Ex1_DirectoryOperations.cs
│   │   │   └── Ex2_PathHelper.cs
│   │   └── Solutions/
│   │       ├── Sol1_DirectoryOperations.cs
│   │       └── Sol2_PathHelper.cs
│   └── Part3_DefensiveIO/
│       ├── Demo03_DefensiveIO.cs
│       ├── Exercises/
│       │   └── Ex1_SafeFileReader.cs
│       └── Solutions/
│           └── Sol1_SafeFileReader.cs
└── Lab.Tests/
    ├── Lab.Tests.csproj
    ├── Part1_FileOperations/
    │   └── StudentWeek9Part1_Ex1Tests.cs
    ├── Part2_DirectoryAndPath/
    │   ├── StudentWeek9Part2_Ex1Tests.cs
    │   └── StudentWeek9Part2_Ex2Tests.cs
    └── Part3_DefensiveIO/
        └── StudentWeek9Part3_Ex1Tests.cs
```

## Quick start

```bash
cd week9-day1-files-part1

# run all 39 tests (all should fail until you implement them)
dotnet test Lab.Tests/Lab.Tests.csproj

# run tests for one part only
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part1"

# watch mode — re-runs on every save
dotnet watch test --project Lab.Tests/Lab.Tests.csproj
```

> All tests create and clean up their own temporary files — no manual setup required.
