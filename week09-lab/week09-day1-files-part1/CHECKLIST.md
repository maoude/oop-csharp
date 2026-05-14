# Checklist — Week 9 · Files in C# (Part 1)

## Part 1 — File Operations

- [ ] **W9.P1.Ex1 — FileOperations** · `StudentWeek9Part1_Ex1Tests` · 13 tests
  - [ ] `FileExists()` returns `true` for an existing file
  - [ ] `FileExists()` returns `false` for a missing file
  - [ ] `ReadText()` returns the file's content
  - [ ] `ReadText()` throws `FileNotFoundException` for a missing file
  - [ ] `WriteText()` creates the file with the given content
  - [ ] `WriteText()` overwrites an existing file
  - [ ] `AppendText()` appends content to an existing file
  - [ ] `ReadLines()` returns all lines as an array
  - [ ] `ReadLines()` throws `FileNotFoundException` for a missing file
  - [ ] `CopyFile()` copies content to the destination
  - [ ] `CopyFile()` throws `FileNotFoundException` when source is missing
  - [ ] `GetFileSize()` returns the correct byte count
  - [ ] `GetFileSize()` throws `FileNotFoundException` for a missing file

## Part 2 — Directory and Path

- [ ] **W9.P2.Ex1 — DirectoryOperations** · `StudentWeek9Part2_Ex1Tests` · 7 tests
  - [ ] `DirectoryExists()` returns `true` for an existing directory
  - [ ] `DirectoryExists()` returns `false` for a missing directory
  - [ ] `EnsureDirectory()` creates a directory that did not exist
  - [ ] `EnsureDirectory()` does not throw when directory already exists
  - [ ] `ListFiles()` returns paths of files matching the search pattern
  - [ ] `ListFiles()` throws `DirectoryNotFoundException` for a missing directory
  - [ ] `ListSubdirectories()` returns paths of immediate subdirectories

- [ ] **W9.P2.Ex2 — PathHelper** · `StudentWeek9Part2_Ex2Tests` · 6 tests
  - [ ] `Combine()` joins a directory and file name with the platform separator
  - [ ] `GetFileName()` returns the file name with extension
  - [ ] `GetExtension()` returns the extension including the leading dot
  - [ ] `GetDirectory()` returns the directory portion of the path
  - [ ] `HasExtension()` returns `true` for a matching extension (case-insensitive)
  - [ ] `HasExtension()` returns `false` for a different extension

## Part 3 — Defensive I/O

- [ ] **W9.P3.Ex1 — SafeFileReader** · `StudentWeek9Part3_Ex1Tests` · 13 tests
  - [ ] `TryReadText()` returns content for an existing file
  - [ ] `TryReadText()` returns `null` for a missing file
  - [ ] `TryWriteText()` writes successfully and returns `true`
  - [ ] `TryWriteText()` returns `false` when the parent directory does not exist
  - [ ] `ReadTextOrDefault()` returns file content when file exists
  - [ ] `ReadTextOrDefault()` returns the default when file is missing
  - [ ] `CountLines()` returns the correct count for a file with content
  - [ ] `CountLines()` returns `0` for an empty file
  - [ ] `CountLines()` returns `0` for a missing file
  - [ ] `AppendLine()` appends a line to an existing file and returns `true`
  - [ ] `AppendLine()` creates a new file when it does not exist and returns `true`
  - [ ] `AppendLine()` returns `false` when the parent directory does not exist
  - [ ] `TryReadText()` returns `null` for a null path (no throw)

## Final check

- [ ] All **39 tests** pass: `dotnet test Lab.Tests/Lab.Tests.csproj`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in with honest self-assessment
- [ ] `QUIZ_QUESTIONS.md` read at least once
