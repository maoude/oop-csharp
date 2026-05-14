# Lab Instructions — Week 10 · Files in C# (Part 2)

## Step 1 — Open the demo files first

```
Lab/Part1_TextStreams/Demo01_TextStreams.cs
Lab/Part2_FileStream/Demo02_FileStream.cs
Lab/Part3_BinaryIO/Demo03_BinaryIO.cs
```

Pay attention to: the `using` statement pattern, `FileMode` vs `FileAccess`, and how `BinaryWriter.Write(string)` differs from writing raw bytes.

## Step 2 — Verify the baseline

```bash
dotnet test Lab.Tests/Lab.Tests.csproj
```

Expected: **39 failed, 0 passed.**

## Step 3 — Implement Part 1 · Text Streams

Open `Lab/Part1_TextStreams/Exercises/Ex1_TextStreamProcessor.cs`.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part1"
```

Target: **13 passed.**

Key rules before you code:
- Every `StreamReader` and `StreamWriter` must be wrapped in `using` — if you forget, tests that call the method twice will fail with a file-locked error.
- Use `new StreamWriter(path, append: true)` to append; the default `new StreamWriter(path)` overwrites.

## Step 4 — Implement Part 2 · FileStream

Open `Lab/Part2_FileStream/Exercises/Ex1_ByteStreamProcessor.cs`.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part2"
```

Target: **13 passed.**

Key rules:
- `FileMode.Create` → creates or overwrites. `FileMode.Open` → must exist (throws otherwise). `FileMode.Append` → seeks to end.
- `fs.Read(buffer, 0, count)` returns the number of bytes ACTUALLY read — which can be less than `count` if the file is shorter. Always use the return value.
- Call `fs.Seek(offset, SeekOrigin.Begin)` before reading a segment.

## Step 5 — Implement Part 3 · Binary I/O

Open `Lab/Part3_BinaryIO/Exercises/Ex1_BinaryRecordStore.cs`.

```bash
dotnet test Lab.Tests/Lab.Tests.csproj --filter "Part3"
```

Target: **13 passed.**

File format for this exercise:
```
[int32: record count]
[string name][int32 age][double score]   ← repeated record-count times
```

Key rules:
- Write and read in the SAME order. `BinaryWriter.Write(string)` writes a length-prefixed UTF-8 string — `BinaryReader.ReadString()` reads it back correctly.
- `BinaryWriter.Write(int)` → 4 bytes. `BinaryWriter.Write(double)` → 8 bytes.

## Step 6 — Full suite green

```bash
dotnet test Lab.Tests/Lab.Tests.csproj
```

Expected: **39 passed, 0 failed.**

## Step 7 — Fill in the design scorecard

Open `OOP_DESIGN_SCORECARD.md` and score your own work.

## Command reference

| Command | Purpose |
|---------|---------|
| `dotnet test Lab.Tests/Lab.Tests.csproj` | Run all 39 tests |
| `dotnet test --filter "Part2"` | Run Part 2 tests only |
| `dotnet build Lab/Lab.csproj` | Build without running tests |
| `dotnet watch test --project Lab.Tests/Lab.Tests.csproj` | Watch mode |
