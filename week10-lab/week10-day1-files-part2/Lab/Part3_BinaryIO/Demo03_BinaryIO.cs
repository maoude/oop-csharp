/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — BinaryWriter and BinaryReader for typed I/O.
 *           Read this file before starting Exercise 1 of Part 3.
 */
namespace OopCsharp.Week10.Part3_BinaryIO;

public static class Demo03_BinaryIO
{
    public static void Run()
    {
        string dir  = Path.Combine(Path.GetTempPath(), "demo_week10_bin");
        string path = Path.Combine(dir, "records.bin");
        Directory.CreateDirectory(dir);

        // ── 1. Write a single record ──────────────────────────────────────────
        // Format: [string name][int32 age][double score]
        using (var writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            writer.Write("Alice");   // length-prefixed UTF-8: 1 byte len + 5 bytes = 6 bytes
            writer.Write(30);        // 4 bytes (little-endian int32)
            writer.Write(95.5);      // 8 bytes (IEEE 754 double)
        }

        Console.WriteLine($"File size: {new FileInfo(path).Length} bytes");  // 18 bytes

        // ── 2. Read the record back ───────────────────────────────────────────
        using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            string name  = reader.ReadString();  // reads length prefix first
            int    age   = reader.ReadInt32();
            double score = reader.ReadDouble();
            Console.WriteLine($"{name}, age {age}, score {score}");
        }

        // ── 3. Multiple records with a count prefix ───────────────────────────
        // Format: [int32 count][records...]
        var people = new (string, int, double)[]
        {
            ("Alice", 30, 95.5),
            ("Bob",   25, 88.0),
            ("Carol", 35, 72.3),
        };

        using (var writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            writer.Write(people.Length);   // count = 3
            foreach (var (name, age, score) in people)
            {
                writer.Write(name);
                writer.Write(age);
                writer.Write(score);
            }
        }

        // ── 4. Read them all back ─────────────────────────────────────────────
        using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            int count = reader.ReadInt32();
            Console.WriteLine($"Record count: {count}");
            for (int i = 0; i < count; i++)
            {
                string name  = reader.ReadString();
                int    age   = reader.ReadInt32();
                double score = reader.ReadDouble();
                Console.WriteLine($"  {name}, {age}, {score}");
            }
        }

        // ── 5. Peek at count only ─────────────────────────────────────────────
        using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            int count = reader.ReadInt32();
            Console.WriteLine($"Peeked count: {count}");
            // stream is disposed here — no need to read the rest
        }

        Directory.Delete(dir, recursive: true);
    }
}
