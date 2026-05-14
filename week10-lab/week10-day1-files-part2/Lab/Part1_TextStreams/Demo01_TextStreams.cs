/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — StreamReader, StreamWriter, and the using statement.
 *           Read this file before starting Exercise 1.
 */
namespace OopCsharp.Week10.Part1_TextStreams;

public static class Demo01_TextStreams
{
    public static void Run()
    {
        string dir  = Path.Combine(Path.GetTempPath(), "demo_week10_text");
        string path = Path.Combine(dir, "notes.txt");
        Directory.CreateDirectory(dir);

        // ── 1. StreamWriter — create / overwrite ──────────────────────────────
        // 'using var' disposes at end of scope — Flush() is called automatically.
        using (var writer = new StreamWriter(path))
        {
            writer.WriteLine("Line one");
            writer.WriteLine("Line two");
            writer.WriteLine("Line three");
        } // ← Dispose() called here: buffer flushed, handle closed

        // ── 2. StreamReader — ReadToEnd ───────────────────────────────────────
        using (var reader = new StreamReader(path))
        {
            string all = reader.ReadToEnd();
            Console.WriteLine(all);
        }

        // ── 3. StreamReader — ReadLine loop ───────────────────────────────────
        // ReadLine() returns null at end-of-stream (not "").
        using (var reader = new StreamReader(path))
        {
            string? line;
            int n = 0;
            while ((line = reader.ReadLine()) != null)
                Console.WriteLine($"  [{++n}] {line}");
        }

        // ── 4. C# 8+ using var — no braces needed ────────────────────────────
        using var writer2 = new StreamWriter(path);   // disposed at end of this method
        writer2.WriteLine("Rewritten");
        // writer2.Dispose() called when the method returns (or on exception)

        // ── 5. StreamWriter append mode ───────────────────────────────────────
        // Note: writer2 is still open here, so flush it first.
        writer2.Flush();
        writer2.Dispose();

        using var appender = new StreamWriter(path, append: true);
        appender.WriteLine("Appended line");
        appender.Flush();   // explicit flush before reading the same file

        using var verifyReader = new StreamReader(path);
        Console.WriteLine(verifyReader.ReadToEnd());

        Directory.Delete(dir, recursive: true);
    }
}
