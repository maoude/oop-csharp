# Quiz Questions — Week 10 · Files in C# (Part 2) · Streams

## Part 1 — Text Streams

**Q1.** What is the practical difference between `StreamReader.ReadToEnd()` and `File.ReadAllText()`? When would you choose `StreamReader` over the static `File` method?

**Q2.** You create a `StreamWriter` and write lines to a file, but the file is empty when you open it in Notepad afterwards. What most likely went wrong?

**Q3.** What does `new StreamWriter(path, append: true)` do when the file does not exist yet?

**Q4.** Why must every `StreamReader` and `StreamWriter` be wrapped in a `using` statement? What can go wrong if you forget?

**Q5.** `StreamReader.ReadLine()` returns `null` when it reaches the end of the file. What does it return for a blank line in the middle of the file?

## Part 2 — FileStream

**Q6.** Explain the difference between `FileMode.Create`, `FileMode.CreateNew`, and `FileMode.OpenOrCreate`. When would each be the right choice?

**Q7.** `fs.Read(buffer, 0, 10)` is called on a `FileStream` backed by a 3-byte file. What integer does `Read` return, and what is the state of the remaining 7 bytes in `buffer`?

**Q8.** What does `fs.Seek(0, SeekOrigin.End)` do? Give a scenario where this is useful.

**Q9.** You open a `FileStream` with `FileAccess.Read` and call `fs.Write(...)`. What happens?

**Q10.** `FileMode.Append` vs opening with `FileMode.OpenOrCreate` and manually seeking to the end — what is the difference in terms of thread safety?

## Part 3 — Binary I/O

**Q11.** `BinaryWriter.Write("hello")` writes more than 5 bytes to the stream. How many bytes does it write, and why?

**Q12.** You write an `int` with `BinaryWriter.Write(42)`, then a `double` with `BinaryWriter.Write(3.14)`, then try to read back the `double` first. What happens?

**Q13.** What is the advantage of the count-prefix format (write the record count first) over scanning for `EndOfStreamException` to detect the end of records?

**Q14.** You write a binary file on a Windows machine and read it on a Linux machine. `BinaryWriter` uses little-endian byte order. Is this a problem? How would you handle it if you needed big-endian?

**Q15.** When would you use `MemoryStream` instead of `FileStream`? Give one concrete example.

---

## Answers (instructor key)

> Remove or hide this section before distributing to students.

1. Both read an entire file into a string. `StreamReader` is useful when: (a) you need to read a large file line-by-line without loading it all at once, (b) you want control over the `Encoding`, (c) you are reading from a network stream or other non-file stream. For simple file reads, `File.ReadAllText` is cleaner.

2. The `StreamWriter` was not disposed (or `Flush` was not called). `StreamWriter` buffers writes; the buffer is only flushed to disk when `Flush()` is called or when `Dispose()` is triggered by the `using` statement.

3. It creates a new empty file and then opens it for appending. `StreamWriter(path, append: true)` behaves like `File.AppendAllText` — it creates if absent, appends if present.

4. If `Dispose()` is never called, the file handle stays open — the OS considers the file locked. Another process (or the same process) cannot open it for writing. On .NET, the GC may eventually finalise it, but there is no timing guarantee. The `using` statement calls `Dispose()` deterministically at the closing brace, even if an exception is thrown.

5. `ReadLine()` returns `""` (empty string) for a blank line. It returns `null` only at the end of the stream. This is why the loop condition is `(line = reader.ReadLine()) != null`, not `line != ""`.

6. `FileMode.Create` — creates a new file; if it exists, truncates it to zero length. `FileMode.CreateNew` — creates a new file; throws `IOException` if it already exists (useful when duplicates are an error). `FileMode.OpenOrCreate` — opens if exists, creates if absent; does NOT truncate — use with `Write` to overwrite or `Append` to add.

7. `Read` returns `3` (the number of bytes actually read). The first 3 bytes of `buffer` contain the file data; the remaining 7 bytes are whatever was in `buffer` before the call (typically zeros if the array was just allocated). Always check the return value — never assume `buffer` was fully filled.

8. `Seek(0, SeekOrigin.End)` moves the position to the very end of the file (position = `Length`). Useful for getting the file size (`fs.Position` after the seek), or for manually implementing an append operation without `FileMode.Append`.

9. An `UnauthorizedAccessException` (or `NotSupportedException` depending on the overload) is thrown at runtime. `FileAccess.Read` sets the stream as read-only; writing to it is not permitted.

10. `FileMode.Append` uses an OS-level append lock: if two processes open the same file with `FileMode.Append` and write concurrently, the OS guarantees their writes do not interleave (each write is atomic at the OS level). Manually seeking to the end and writing has a TOCTOU race: another process can write between your seek and your write.

11. `BinaryWriter.Write("hello")` writes a length-prefixed string: first a variable-length integer encoding the byte count of the UTF-8 string (1 byte for lengths 0–127), then the UTF-8 bytes. For "hello" that is 1 + 5 = 6 bytes total.

12. The read will return garbage or throw. `BinaryReader` reads in a stream-sequential manner — it does not seek. Reading a `double` where an `int` was written first means reading the 4 bytes of the int plus the first 4 bytes of the double and reinterpreting them as a `double`. The result is meaningless.

13. The count-prefix format is simpler and avoids using exceptions for control flow (catching `EndOfStreamException` to detect EOF is widely considered a code smell). It also allows pre-allocating the correct list capacity upfront. The trade-off is that writing requires knowing the count before writing (must materialise the enumerable).

14. `BinaryWriter` always writes in little-endian on all platforms in .NET — this is consistent regardless of the OS. So a file written on Windows reads correctly on Linux. If you need big-endian (e.g., for a network protocol), use `BinaryPrimitives` from `System.Buffers.Binary` or manually reverse bytes with `BitConverter`.

15. `MemoryStream` is used when you need a stream-based API but want to keep data in RAM rather than on disk — for example: (a) unit-testing a method that accepts a `Stream` without touching the filesystem, (b) building a byte array in-memory step by step using `BinaryWriter`, then calling `ms.ToArray()` to get the result, (c) decompressing a byte array using `GZipStream(memoryStream, CompressionMode.Decompress)`.
