# Checklist — Week 10 · Files in C# (Part 2) · Streams

## Part 1 — Text Streams

- [ ] **W10.P1.Ex1 — TextStreamProcessor** · `StudentWeek10Part1_Ex1Tests` · 13 tests
  - [ ] `ReadAllText()` returns the full file content
  - [ ] `ReadAllText()` throws when file is missing
  - [ ] `ReadAllText()` releases the file after the call (can be called twice)
  - [ ] `ReadLines()` returns all lines for a non-empty file
  - [ ] `ReadLines()` returns an empty array for an empty file
  - [ ] `WriteLines()` writes each element on its own line
  - [ ] `WriteLines()` overwrites existing content
  - [ ] `WriteLines()` with empty enumerable creates an empty file
  - [ ] `WriteLines()` releases the file after the call (can be called twice)
  - [ ] `AppendLine()` appends to an existing file
  - [ ] `AppendLine()` creates the file when it does not exist
  - [ ] `CountLines()` counts only non-empty lines
  - [ ] `CountLines()` returns `0` for an empty file

## Part 2 — FileStream

- [ ] **W10.P2.Ex1 — ByteStreamProcessor** · `StudentWeek10Part2_Ex1Tests` · 13 tests
  - [ ] `ReadAllBytes()` returns the correct byte array
  - [ ] `ReadAllBytes()` returns an empty array for an empty file
  - [ ] `ReadAllBytes()` throws `FileNotFoundException` for a missing file
  - [ ] `WriteAllBytes()` creates the file with the correct bytes
  - [ ] `WriteAllBytes()` overwrites an existing file
  - [ ] `WriteAllBytes()` with empty array creates an empty file
  - [ ] `WriteAllBytes()` releases the file after the call
  - [ ] `ReadSegment()` returns the correct slice from the middle of a file
  - [ ] `ReadSegment()` returns only available bytes when count exceeds remaining
  - [ ] `ReadSegment()` returns empty array when offset is beyond file length
  - [ ] `AppendBytes()` appends bytes to an existing file
  - [ ] `AppendBytes()` creates the file when it does not exist
  - [ ] `WriteAllBytes()` then `ReadAllBytes()` round-trip matches

## Part 3 — Binary I/O

- [ ] **W10.P3.Ex1 — BinaryRecordStore** · `StudentWeek10Part3_Ex1Tests` · 13 tests
  - [ ] `SaveRecords()` then `LoadRecords()` — name round-trips correctly
  - [ ] `SaveRecords()` then `LoadRecords()` — age round-trips correctly
  - [ ] `SaveRecords()` then `LoadRecords()` — score round-trips correctly
  - [ ] `SaveRecords()` with multiple records — all load back correctly
  - [ ] `SaveRecords()` with empty list — `CountRecords` returns `0`
  - [ ] `SaveRecords()` with empty list — `LoadRecords` returns empty list
  - [ ] `CountRecords()` returns the correct count for one record
  - [ ] `CountRecords()` returns the correct count for three records
  - [ ] `LoadRecords()` throws `FileNotFoundException` for a missing file
  - [ ] `SaveRecords()` overwrites an existing file
  - [ ] `SaveRecords()` releases the file after the call (can be called twice)
  - [ ] `LoadRecords()` after saving three records — list has three elements
  - [ ] `CountRecords()` matches `LoadRecords().Count` for any input

## Final check

- [ ] All **39 tests** pass: `dotnet test Lab.Tests/Lab.Tests.csproj`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in with honest self-assessment
- [ ] `QUIZ_QUESTIONS.md` read at least once
