/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — Directory static methods and Path helpers.
 *           Read this file before starting Exercises 1 and 2 of Part 2.
 */
namespace OopCsharp.Week9.Part2_DirectoryAndPath;

public static class Demo02_DirectoryAndPath
{
    public static void Run()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), "demo_week9_dir");

        // ── 1. Directory: Exists, CreateDirectory ─────────────────────────────
        Console.WriteLine(Directory.Exists(tempDir));   // False

        Directory.CreateDirectory(tempDir);             // idempotent — safe to call again
        Directory.CreateDirectory(tempDir);             // no exception
        Console.WriteLine(Directory.Exists(tempDir));   // True

        // ── 2. Create files and subdirectories ───────────────────────────────
        string subA = Path.Combine(tempDir, "subA");
        string subB = Path.Combine(tempDir, "subB");
        Directory.CreateDirectory(subA);
        Directory.CreateDirectory(subB);
        File.WriteAllText(Path.Combine(tempDir, "file1.txt"), "one");
        File.WriteAllText(Path.Combine(tempDir, "file2.txt"), "two");
        File.WriteAllText(Path.Combine(tempDir, "image.png"), "data");

        // ── 3. GetFiles and GetDirectories ────────────────────────────────────
        string[] allFiles  = Directory.GetFiles(tempDir);           // non-recursive
        string[] txtFiles  = Directory.GetFiles(tempDir, "*.txt");
        string[] subDirs   = Directory.GetDirectories(tempDir);

        Console.WriteLine($"All files: {allFiles.Length}");    // 3
        Console.WriteLine($"Txt files: {txtFiles.Length}");    // 2
        Console.WriteLine($"Subdirs:   {subDirs.Length}");     // 2

        // ── 4. Recursive search ───────────────────────────────────────────────
        File.WriteAllText(Path.Combine(subA, "nested.txt"), "deep");
        string[] allTxt = Directory.GetFiles(tempDir, "*.txt", SearchOption.AllDirectories);
        Console.WriteLine($"All .txt (recursive): {allTxt.Length}");  // 3

        // ── 5. Path helpers — NO filesystem access ───────────────────────────
        string path = @"C:\Users\Alice\documents\report.pdf";

        Console.WriteLine(Path.GetFileName(path));              // "report.pdf"
        Console.WriteLine(Path.GetFileNameWithoutExtension(path)); // "report"
        Console.WriteLine(Path.GetExtension(path));             // ".pdf"
        Console.WriteLine(Path.GetDirectoryName(path));         // "C:\Users\Alice\documents"

        // ── 6. Path.Combine — always use this, never string + ─────────────────
        string safe = Path.Combine("C:\\Users", "Alice", "notes.txt");
        Console.WriteLine(safe);   // "C:\Users\Alice\notes.txt"

        // Danger with concatenation: if a segment starts with separator it
        // resets to root. Path.Combine handles this correctly.
        string root = Path.GetPathRoot(safe)!;
        Console.WriteLine(root);   // "C:\"

        // ── 7. Current and special directories ───────────────────────────────
        Console.WriteLine(Directory.GetCurrentDirectory());
        Console.WriteLine(Path.GetTempPath());

        // Clean up
        Directory.Delete(tempDir, recursive: true);
    }
}
