# Exercises — Week 10 · Files in C# (Part 2) · Streams

## Part 1 · Text Streams — `Ex1_TextStreamProcessor.cs`

Read and write text files using `StreamReader` and `StreamWriter`. Every method must use `using` to dispose the stream.

**TextStreamProcessor**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `ReadAllText` | `string ReadAllText(string path)` | Open a `StreamReader`, call `ReadToEnd()`, return the result; throws `FileNotFoundException` if missing |
| `ReadLines` | `string[] ReadLines(string path)` | Read line by line with `ReadLine()` until null; return all lines as an array; empty file → empty array |
| `WriteLines` | `void WriteLines(string path, IEnumerable<string> lines)` | Create or overwrite the file; write each element with `WriteLine()` |
| `AppendLine` | `void AppendLine(string path, string line)` | Open `StreamWriter` in append mode; write `line` with `WriteLine()`; creates file if absent |
| `CountLines` | `int CountLines(string path)` | Count non-empty (non-whitespace-only) lines; returns `0` for empty file; throws `FileNotFoundException` if missing |

Test class: `StudentWeek10Part1_Ex1Tests` · **13 tests**

---

## Part 2 · FileStream — `Ex1_ByteStreamProcessor.cs`

Byte-level file access using `FileStream` directly.

**ByteStreamProcessor**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `ReadAllBytes` | `byte[] ReadAllBytes(string path)` | Open with `FileMode.Open` / `FileAccess.Read`; read entire file into a byte array; throws `FileNotFoundException` if missing |
| `WriteAllBytes` | `void WriteAllBytes(string path, byte[] data)` | Open with `FileMode.Create` / `FileAccess.Write`; write all bytes; creates or overwrites |
| `ReadSegment` | `byte[] ReadSegment(string path, long offset, int count)` | Seek to `offset` from start, read up to `count` bytes; return only the bytes actually read; `offset ≥ file length` → return empty array |
| `AppendBytes` | `void AppendBytes(string path, byte[] data)` | Open with `FileMode.Append` / `FileAccess.Write`; write bytes at end; creates file if absent |

Test class: `StudentWeek10Part2_Ex1Tests` · **13 tests**

---

## Part 3 · Binary I/O — `Ex1_BinaryRecordStore.cs`

Write and read typed records using `BinaryWriter` / `BinaryReader`.

**File format** (must be respected by all three methods):
```
[int32 — record count]
for each record:
    [string — name (length-prefixed UTF-8)]
    [int32  — age]
    [double — score]
```

**BinaryRecordStore**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `SaveRecords` | `void SaveRecords(string path, IEnumerable<(string Name, int Age, double Score)> records)` | Create or overwrite file; write count then each record |
| `LoadRecords` | `IReadOnlyList<(string Name, int Age, double Score)> LoadRecords(string path)` | Read count then each record; throws `FileNotFoundException` if missing |
| `CountRecords` | `int CountRecords(string path)` | Read just the first `int32` from the file; throws `FileNotFoundException` if missing |

Test class: `StudentWeek10Part3_Ex1Tests` · **13 tests**
