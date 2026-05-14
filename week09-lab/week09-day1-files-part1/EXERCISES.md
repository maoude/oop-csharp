# Exercises — Week 9 · Files in C# (Part 1)

## Part 1 · File Operations — `Ex1_FileOperations.cs`

Thin, correct wrappers around `System.IO.File` and `FileInfo`. The goal is to learn which method to call and what it throws.

**FileOperations**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `FileExists` | `bool FileExists(string path)` | Returns `true` when the file exists at `path` |
| `ReadText` | `string ReadText(string path)` | Returns the entire file as a string; throws `FileNotFoundException` if missing |
| `WriteText` | `void WriteText(string path, string content)` | Creates or overwrites the file with `content` |
| `AppendText` | `void AppendText(string path, string content)` | Appends `content` to the file; creates the file if it does not exist |
| `ReadLines` | `string[] ReadLines(string path)` | Returns all lines as an array; throws `FileNotFoundException` if missing |
| `CopyFile` | `void CopyFile(string source, string destination)` | Copies `source` to `destination`; throws `FileNotFoundException` if source missing; throws `IOException` if destination already exists |
| `GetFileSize` | `long GetFileSize(string path)` | Returns file size in bytes via `FileInfo`; throws `FileNotFoundException` if missing |

Test class: `StudentWeek9Part1_Ex1Tests` · **13 tests**

---

## Part 2 · Directory and Path

### Exercise 1 — `Ex1_DirectoryOperations.cs`

**DirectoryOperations**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `DirectoryExists` | `bool DirectoryExists(string path)` | Returns `true` when the directory exists |
| `EnsureDirectory` | `void EnsureDirectory(string path)` | Creates the directory (and any missing parents); idempotent — no throw if already exists |
| `ListFiles` | `string[] ListFiles(string path, string searchPattern)` | Returns full paths of files matching `searchPattern`; throws `DirectoryNotFoundException` if directory missing |
| `ListSubdirectories` | `string[] ListSubdirectories(string path)` | Returns full paths of immediate subdirectories; throws `DirectoryNotFoundException` if directory missing |

Test class: `StudentWeek9Part2_Ex1Tests` · **7 tests**

### Exercise 2 — `Ex2_PathHelper.cs`

Path manipulation without touching the filesystem.

**PathHelper**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `Combine` | `string Combine(string directory, string fileName)` | Returns `Path.Combine(directory, fileName)` |
| `GetFileName` | `string GetFileName(string path)` | Returns the file name and extension from `path` |
| `GetExtension` | `string GetExtension(string path)` | Returns the extension including the leading dot (e.g. `".txt"`) |
| `GetDirectory` | `string? GetDirectory(string path)` | Returns the directory part of `path`; `null` if path has no directory component |
| `HasExtension` | `bool HasExtension(string path, string extension)` | Returns `true` when the file's extension matches `extension` (case-insensitive; caller may or may not include the leading dot) |

Test class: `StudentWeek9Part2_Ex2Tests` · **6 tests**

---

## Part 3 · Defensive I/O — `Ex1_SafeFileReader.cs`

Apply the TryXxx pattern: catch exceptions internally, never propagate to the caller.

**SafeFileReader**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `TryReadText` | `string? TryReadText(string path)` | Returns file content on success; `null` on any error (file missing, access denied, etc.) |
| `TryWriteText` | `bool TryWriteText(string path, string content)` | Writes content; returns `true` on success, `false` on any error |
| `ReadTextOrDefault` | `string ReadTextOrDefault(string path, string defaultContent)` | Returns file content if readable, `defaultContent` otherwise |
| `CountLines` | `int CountLines(string path)` | Counts non-empty lines; returns `0` if file missing or unreadable |
| `AppendLine` | `bool AppendLine(string path, string line)` | Appends `line + Environment.NewLine`; creates file if absent; returns `false` on any error |

Test class: `StudentWeek9Part3_Ex1Tests` · **13 tests**
