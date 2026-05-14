# Week 10 — Files in C# (Part 2) · Streams and File I/O

**Course:** Introduction to OOP with C#
**Lab:** week10-day1-files-part2

## Learning objectives

- Explain the stream abstraction: a source and a destination connected by a channel of bytes
- Use `StreamReader` / `StreamWriter` for text I/O with `ReadLine`, `ReadToEnd`, `WriteLine`
- Apply the `using` statement (and C# 8+ `using var`) to guarantee stream disposal
- Use `FileStream` directly for byte-level access: `Read`, `Write`, `Seek`, `FileMode`, `FileAccess`
- Use `BinaryWriter` / `BinaryReader` to write and read typed primitives in binary format
- Explain why `Flush` must be called (or `Dispose` triggered) before a written file is read back
- Recognise when streams leave files locked and how `using` prevents that

## Structure

```
week10-day1-files-part2/
├── README.md
├── LAB_INSTRUCTIONS.md
├── EXERCISES.md
├── CHECKLIST.md
├── QUIZ_QUESTIONS.md
├── OOP_DESIGN_SCORECARD.md
├── TROUBLESHOOTING.md
├── Lab/
│   ├── Lab.csproj
│   ├── Part1_TextStreams/
│   │   ├── Demo01_TextStreams.cs
│   │   ├── Exercises/
│   │   │   └── Ex1_TextStreamProcessor.cs
│   │   └── Solutions/
│   │       └── Sol1_TextStreamProcessor.cs
│   ├── Part2_FileStream/
│   │   ├── Demo02_FileStream.cs
│   │   ├── Exercises/
│   │   │   └── Ex1_ByteStreamProcessor.cs
│   │   └── Solutions/
│   │       └── Sol1_ByteStreamProcessor.cs
│   └── Part3_BinaryIO/
│       ├── Demo03_BinaryIO.cs
│       ├── Exercises/
│       │   └── Ex1_BinaryRecordStore.cs
│       └── Solutions/
│           └── Sol1_BinaryRecordStore.cs
└── Lab.Tests/
    ├── Lab.Tests.csproj
    ├── Part1_TextStreams/
    │   └── StudentWeek10Part1_Ex1Tests.cs
    ├── Part2_FileStream/
    │   └── StudentWeek10Part2_Ex1Tests.cs
    └── Part3_BinaryIO/
        └── StudentWeek10Part3_Ex1Tests.cs
```

## Quick start

```bash
cd week10-day1-files-part2

# run all 39 tests (all should fail until you implement them)
dotnet test Lab.Tests/Lab.Tests.csproj

# run tests for one part only
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part1"

# watch mode — re-runs on every save
dotnet watch test --project Lab.Tests/Lab.Tests.csproj
```

> All tests create and clean up their own temporary files via `IDisposable`.
