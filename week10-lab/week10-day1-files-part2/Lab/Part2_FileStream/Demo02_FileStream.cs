/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — FileStream: FileMode, FileAccess, Read, Write, Seek.
 *           Read this file before starting Exercise 1 of Part 2.
 */
namespace OopCsharp.Week10.Part2_FileStream;

public static class Demo02_FileStream
{
    public static void Run()
    {
        string dir  = Path.Combine(Path.GetTempPath(), "demo_week10_bytes");
        string path = Path.Combine(dir, "data.bin");
        Directory.CreateDirectory(dir);

        // ── 1. Write bytes with FileMode.Create ───────────────────────────────
        byte[] data = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            fs.Write(data, 0, data.Length);
        } // closed here

        // ── 2. Read ALL bytes with FileMode.Open ──────────────────────────────
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[fs.Length];
            int read = fs.Read(buffer, 0, buffer.Length);
            Console.WriteLine($"Read {read} bytes: [{string.Join(", ", buffer)}]");
        }

        // ── 3. Read a segment using Seek ──────────────────────────────────────
        // Read 3 bytes starting at offset 4 → {50, 60, 70}
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            fs.Seek(4, SeekOrigin.Begin);      // move to byte index 4
            byte[] seg = new byte[3];
            int bytesRead = fs.Read(seg, 0, 3);
            Console.WriteLine($"Segment ({bytesRead} bytes): [{string.Join(", ", seg[..bytesRead])}]");
        }

        // ── 4. Append bytes with FileMode.Append ─────────────────────────────
        byte[] extra = { 110, 120 };
        using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write))
        {
            fs.Write(extra, 0, extra.Length);
        }

        // Verify total size
        Console.WriteLine($"After append: {new FileInfo(path).Length} bytes");  // 12

        // ── 5. FileMode values summary ────────────────────────────────────────
        // FileMode.Create       → create new or truncate existing
        // FileMode.CreateNew    → create new; throws if exists
        // FileMode.Open         → open existing; throws if missing
        // FileMode.OpenOrCreate → open if exists, create if not; NO truncation
        // FileMode.Append       → open and seek to end; create if not exists
        // FileMode.Truncate     → open existing and truncate to 0 bytes

        Directory.Delete(dir, recursive: true);
    }
}
