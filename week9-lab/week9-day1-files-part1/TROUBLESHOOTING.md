# Troubleshooting — Week 9 · Files in C# (Part 1)

## Build errors

### CS0234 — The type or namespace 'IO' does not exist

**Cause:** Missing `using System.IO;`.  
**Fix:** Add `using System.IO;` at the top of the file, or rely on `ImplicitUsings` (check your `.csproj` has `<ImplicitUsings>enable</ImplicitUsings>`).

---

### CS0103 — The name 'Path' does not exist

**Cause:** `System.IO.Path` is not imported.  
**Fix:** Same as above — `using System.IO;` brings in `Path`, `File`, `Directory`, `FileInfo`, and `DirectoryInfo`.

---

### CS1501 — No overload for method 'Copy' takes 2 arguments

**Cause:** Using `File.Copy(source, dest)` works (2 arguments), but you may have confused it with `File.Copy(source, dest, overwrite)`.  
**Fix:** `File.Copy` has both a 2-argument overload (no overwrite) and a 3-argument overload (with overwrite bool). Use the right one for the test case.

---

## Test failures

### "FileNotFoundException not thrown — expected exception"

**Cause:** Calling `File.Exists` before the operation and returning early with a default instead of letting the natural exception propagate.  
**Fix:** Remove the `File.Exists` guard. Let `File.ReadAllText` (or `File.ReadAllLines`) throw `FileNotFoundException` naturally — that is the expected behaviour.

---

### "CopyFile: IOException not thrown for existing destination"

**Cause:** Using the 3-argument overload `File.Copy(source, dest, true)` (overwrite = true).  
**Fix:** Use `File.Copy(source, dest, false)` or the 2-argument overload `File.Copy(source, dest)` — both throw `IOException` when the destination already exists.

---

### "GetFileSize: FileNotFoundException not thrown for missing file"

**Cause:** Using `File.Exists` and returning `0` instead of letting `FileInfo` throw.  
**Fix:** Construct `new FileInfo(path)` and access `.Length` directly. The `FileNotFoundException` is thrown automatically when the file does not exist.

---

### "EnsureDirectory: DirectoryNotFoundException" (unexpected throw)

**Cause:** Calling `Directory.CreateDirectory` on an already-existing path, expecting an exception that never comes — but the test passes the other way.  
**Note:** `Directory.CreateDirectory` is intentionally idempotent. If you are getting an unexpected exception, you may have used `Directory.CreateDirectory` on a FILE path rather than a directory path. Check path construction in your test setup.

---

### "ListFiles: expected 2 files, got 0"

**Cause:** Wrong search pattern, or the temp files were created with a different extension than the pattern.  
**Fix:** Verify that the `searchPattern` argument is passed correctly to `Directory.GetFiles(path, searchPattern)`. Also check that the test's temp files use the extension the pattern expects (e.g. `"*.txt"`).

---

### "HasExtension: expected True — got False" for matching extension

**Cause:** `Path.GetExtension` returns the extension WITH the leading dot (e.g. `".txt"`), but the caller passed `"txt"` (without dot) as the `extension` argument, and you compared them without normalising.  
**Fix:** Normalise both sides: prepend `"."` if the input extension does not already start with one, then compare with `StringComparison.OrdinalIgnoreCase`.

---

### TryReadText returns "" instead of null for missing file

**Cause:** Catching the exception and returning `""` (empty string) instead of `null`.  
**Fix:** The catch block must `return null;` not `return "";`. The two values have different meanings: null = inaccessible, "" = file exists but is empty.

---

### TryWriteText returns true when parent directory does not exist

**Cause:** Not wrapping the write in a `try/catch` — `File.WriteAllText` throws `DirectoryNotFoundException` when the parent directory is absent, and the exception is propagating uncaught.  
**Fix:** Wrap the `File.WriteAllText` call in `try { ... return true; } catch { return false; }`.

---

## Runtime behaviour

### Tests leave temp files behind after a failure

**Cause:** The test's `Dispose()` method is not being called because the test class does not implement `IDisposable`.  
**Note:** The provided test classes implement `IDisposable` and xUnit calls `Dispose()` even after a failed test. If you see leftover files, check that you have not modified the test cleanup code.

---

### "Access to the path is denied" on Windows

**Cause:** Attempting to write to a path outside the user's temp directory (e.g., `C:\Windows\...`).  
**Fix:** Always use `Path.GetTempPath()` as the base for test files. The test infrastructure already does this — do not hardcode absolute paths in your implementation.
