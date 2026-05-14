/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — File static methods and FileInfo.
 *           Read this file before starting Exercise 1.
 */
namespace OopCsharp.Week9.Part1_FileOperations;

public static class Demo01_FileOperations
{
    public static void Run()
    {
        string tempDir  = Path.Combine(Path.GetTempPath(), "demo_week9");
        string filePath = Path.Combine(tempDir, "notes.txt");
        Directory.CreateDirectory(tempDir);

        // ── 1. Write and read ─────────────────────────────────────────────────
        File.WriteAllText(filePath, "Hello, Files!");
        string content = File.ReadAllText(filePath);
        Console.WriteLine(content);   // "Hello, Files!"

        // ── 2. Append ─────────────────────────────────────────────────────────
        File.AppendAllText(filePath, "\nSecond line.");
        Console.WriteLine(File.ReadAllText(filePath));
        // "Hello, Files!
        //  Second line."

        // ── 3. ReadAllLines vs ReadAllText ────────────────────────────────────
        string[] lines = File.ReadAllLines(filePath);
        Console.WriteLine($"{lines.Length} lines");   // 2 lines
        foreach (string line in lines)
            Console.WriteLine($"  [{line}]");

        // ── 4. Exists, Copy, Move, Delete ─────────────────────────────────────
        string copyPath = Path.Combine(tempDir, "notes_copy.txt");
        Console.WriteLine(File.Exists(filePath));      // True
        File.Copy(filePath, copyPath, overwrite: true);
        Console.WriteLine(File.Exists(copyPath));      // True

        string movedPath = Path.Combine(tempDir, "notes_moved.txt");
        File.Move(copyPath, movedPath);
        Console.WriteLine(File.Exists(copyPath));      // False (moved away)

        File.Delete(movedPath);
        Console.WriteLine(File.Exists(movedPath));     // False (deleted)

        // ── 5. FileInfo — query metadata without multiple File.* calls ────────
        var info = new FileInfo(filePath);
        Console.WriteLine($"Name:      {info.Name}");
        Console.WriteLine($"Size:      {info.Length} bytes");
        Console.WriteLine($"Directory: {info.DirectoryName}");
        Console.WriteLine($"Extension: {info.Extension}");
        Console.WriteLine($"ReadOnly:  {info.IsReadOnly}");
        Console.WriteLine($"Modified:  {info.LastWriteTime}");

        // ── 6. WriteAllLines ──────────────────────────────────────────────────
        string csvPath = Path.Combine(tempDir, "data.csv");
        File.WriteAllLines(csvPath, new[] { "name,age", "Alice,30", "Bob,25" });
        foreach (string row in File.ReadAllLines(csvPath))
            Console.WriteLine(row);

        // Clean up
        Directory.Delete(tempDir, recursive: true);
    }
}
