# Quiz Questions — Week 9 · Files in C# (Part 1)

## Part 1 — File Operations

**Q1.** What is the difference between `File` and `FileInfo`? Give a concrete example of when you would prefer `FileInfo` over `File`.

**Q2.** `File.WriteAllText(path, content)` creates the file if it does not exist, and overwrites it if it does. How do you add content to the end of an existing file without destroying what is already there?

**Q3.** What does `File.ReadAllLines` return for a file that contains exactly three lines? What does it return for a completely empty file?

**Q4.** You call `File.Copy("source.txt", "dest.txt")` but `dest.txt` already exists. What happens? How do you copy and allow overwriting?

**Q5.** What exception does `new FileInfo("missing.txt").Length` throw, and why can you not avoid it simply by calling `File.Exists` first?

## Part 2 — Directory and Path

**Q6.** Why is `Path.Combine("C:\\Users", "Alice", "notes.txt")` safer than `"C:\\Users\\" + "Alice\\" + "notes.txt"`? Give one scenario where string concatenation produces a wrong path.

**Q7.** What is the difference between `Path.GetFileName` and `Path.GetFileNameWithoutExtension`? Which one would you use when renaming a file to change its extension?

**Q8.** `Directory.GetFiles(path, "*.txt")` — what does it return? Does it search subdirectories by default?

**Q9.** What is the difference between `Directory.Delete(path)` and `Directory.Delete(path, recursive: true)`? Which one is safer and why?

**Q10.** `Directory.CreateDirectory` does not throw if the directory already exists. Name one other `System.IO` method that is similarly idempotent and one that is NOT idempotent.

## Part 3 — Defensive I/O

**Q11.** Explain the TOCTOU (time-of-check-time-of-use) problem in this code:
```csharp
if (File.Exists(path))
    return File.ReadAllText(path);
```
How does the TryXxx pattern solve it?

**Q12.** `TryReadText` returns `null` for a missing file rather than `""`. Why is this distinction important to the caller?

**Q13.** You implement `TryWriteText` by catching `Exception`. A colleague says you should only catch `IOException`. Who is right, and why?

**Q14.** `CountLines` returns `0` for both a missing file and an empty file. Is this a good design? What would you change if callers needed to distinguish the two cases?

**Q15.** `File.AppendAllText` creates the file if it does not exist. Given that, why do you still need a `try/catch` in `AppendLine`?

---

## Answers (instructor key)

> Remove or hide this section before distributing to students.

1. `File` offers static convenience methods for one-shot operations. `FileInfo` is an instance that caches metadata (name, size, timestamps) and is efficient when you need multiple properties of the same file — it only hits the filesystem once at construction time. Prefer `FileInfo` when checking size and last-modified date together.

2. Use `File.AppendAllText(path, content)`. It creates the file if absent and appends if present. Alternatively, open a `StreamWriter` in append mode (`new StreamWriter(path, append: true)`).

3. `ReadAllLines` returns an array of three strings, one per line (newline delimiters are stripped). For an empty file it returns an empty array `string[0]` — not null, not an array with one empty string.

4. `File.Copy("source.txt", "dest.txt")` (two-argument overload) throws `IOException` with message "The file exists." To allow overwriting, use the three-argument overload: `File.Copy("source.txt", "dest.txt", overwrite: true)`.

5. `FileNotFoundException`. Checking `File.Exists` before accessing `Length` is a TOCTOU race: another process can delete the file between the check and the access. The only safe approach is to attempt the operation and catch the exception.

6. If `"Alice"` begins with a path separator (`"/Alice"`), string concatenation produces a double separator or an absolute path override (`"C:\\Users\\/Alice\\notes.txt"`). `Path.Combine` handles this correctly on all platforms — and uses the platform's separator character automatically.

7. `Path.GetFileName("report.pdf")` → `"report.pdf"` (with extension). `Path.GetFileNameWithoutExtension("report.pdf")` → `"report"`. When renaming to change the extension, use `Path.GetFileNameWithoutExtension` to strip the old one, then append the new one.

8. It returns an array of full file paths in `path` whose names match the `"*.txt"` pattern. By default it does NOT search subdirectories — pass `SearchOption.AllDirectories` as a third argument to recurse.

9. `Directory.Delete(path)` only works on empty directories and throws `IOException` if any files exist inside. `Directory.Delete(path, true)` deletes recursively. The recursive form is more powerful but also more destructive — it should only be used when you own the directory and its contents.

10. Idempotent: `Directory.CreateDirectory`. Not idempotent: `File.Copy` (two-argument form) — calling it twice when the destination exists throws `IOException`.

11. Between `File.Exists` returning `true` and `File.ReadAllText` executing, another thread or process can delete the file, causing `FileNotFoundException` despite the check. The TryXxx pattern wraps the actual operation in `try/catch`, eliminating the gap entirely.

12. `null` signals "the file was not accessible" — the caller can decide whether to use a default, log a warning, or prompt the user. `""` would be ambiguous: it could mean the file exists but is empty, or it could mean "file not found" — the caller cannot tell.

13. The colleague is partially right. You should catch the most specific type that covers the expected failure domain: `IOException` (covers `FileNotFoundException`, `DirectoryNotFoundException`, `UnauthorizedAccessException` is a separate hierarchy). However, `ArgumentException` can be thrown for invalid path characters, and `UnauthorizedAccessException` (which does NOT extend `IOException`) can be thrown for permission failures. A pragmatic defensive wrapper catches `Exception` at the outer boundary; a more principled one catches `IOException` and `UnauthorizedAccessException` separately.

14. It is a reasonable simplification for a utility method. If callers need to distinguish, the method signature should return `int?` (null = missing, 0 = empty) or throw for the missing case and return 0 for empty.

15. `File.AppendAllText` can still throw for: insufficient disk space (`IOException`), access denied (`UnauthorizedAccessException`), or a parent directory that does not exist (`DirectoryNotFoundException`). The try/catch is necessary to satisfy the TryXxx contract of never propagating exceptions.
