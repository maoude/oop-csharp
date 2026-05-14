# Troubleshooting — Week 10 · Files in C# (Part 2) · Streams

## Build errors

### CS0246 — The type or namespace 'StreamReader' does not exist

**Cause:** `System.IO` not imported.  
**Fix:** Add `using System.IO;` or rely on `<ImplicitUsings>enable</ImplicitUsings>` in the `.csproj`.

---

### CS0246 — 'BinaryWriter' / 'BinaryReader' does not exist

**Cause:** Same as above — both live in `System.IO`.  
**Fix:** `using System.IO;`

---

## Test failures

### "File is locked — IOException on second call"

**Cause:** You opened a `StreamReader`, `StreamWriter`, or `FileStream` but never disposed it. The file handle stays open, so the next call to the same path fails.  
**Fix:** Wrap every stream in a `using` statement:
```csharp
using var reader = new StreamReader(path);
// ... use reader ...
// disposed automatically here
```
Do NOT store the stream in a field; create it fresh in every method call.

---

### "WriteLines: file is empty after the call"

**Cause:** `StreamWriter` buffers output. If `Flush()` or `Dispose()` is never called, the buffer is never written to disk.  
**Fix:** Use `using` — `Dispose()` calls `Flush()` before closing.

---

### "ReadLines: expected 3 lines — got 4" (extra empty line at end)

**Cause:** Each `WriteLine` appends a newline. When `ReadLine` is called, it sees a blank line at the very end and adds `""` to the list.  
**Fix:** Filter out `null` and optionally empty lines, OR only add lines that are not null — `while ((line = reader.ReadLine()) != null)` already skips the null, but if the last line written had a trailing newline the loop won't add an extra entry. Verify your loop stops at `null`, not at `""`.

---

### "ReadAllBytes: expected 5 bytes — got 0 (empty array)"

**Cause:** Using `FileMode.Create` instead of `FileMode.Open` in `ReadAllBytes`. `FileMode.Create` truncates the file to zero bytes!  
**Fix:** Use `FileMode.Open` for reading.

---

### "WriteAllBytes: FileNotFoundException when path exists"

**Cause:** Using `FileMode.CreateNew` — it throws `IOException` if the file already exists.  
**Fix:** Use `FileMode.Create` (creates new or overwrites).

---

### "ReadSegment: returns wrong bytes"

**Cause (a):** Forgetting to call `fs.Seek(offset, SeekOrigin.Begin)` before `Read`. Without seeking, `Read` starts at position 0.  
**Fix:** Always call `Seek` before reading the segment.

**Cause (b):** Using the requested `count` as the array length instead of the actual bytes read. `fs.Read` may return fewer bytes than `count` if the segment extends past the end of the file.  
**Fix:**
```csharp
int bytesRead = fs.Read(buffer, 0, count);
if (bytesRead < count) Array.Resize(ref buffer, bytesRead);
return buffer;
```

---

### "AppendBytes: overwrites instead of appending"

**Cause:** Using `FileMode.Create` (truncates) or `FileMode.Open` with no seek to end.  
**Fix:** Use `FileMode.Append` — it opens and seeks to end automatically:
```csharp
using var fs = new FileStream(path, FileMode.Append, FileAccess.Write);
fs.Write(data, 0, data.Length);
```

---

### "BinaryRecordStore: LoadRecords reads wrong values"

**Cause:** Reading in a different order than you wrote. Binary streams are positional — every read advances the position.  
**Fix:** Write and read in exactly the same order:
```
Write: count → name → age → score (per record)
Read:  count → name → age → score (per record)
```

---

### "CountRecords: EndOfStreamException on an empty save file"

**Cause:** Calling `SaveRecords` with an empty list writes the integer `0` as the count — a 4-byte file. `CountRecords` opens it and reads that int back fine. If you're getting `EndOfStreamException`, you likely forgot to write the count at all (the file is actually 0 bytes).  
**Fix:** Ensure `SaveRecords` always writes `writer.Write(list.Count)` first, even when `list.Count == 0`.

---

## Runtime behaviour

### Tests pass individually but fail when run together

**Cause:** One test is leaving a file locked because a previous test threw an exception before `Dispose()` was called.  
**Fix:** Ensure `IDisposable.Dispose()` is implemented on the test class and deletes the temp directory recursively. xUnit calls `Dispose()` even after a failed test, so this should clean up reliably if the stream is disposed in the implementation.
