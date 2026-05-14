/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — TryXxx pattern and defensive file I/O.
 *           Read this file before starting Exercise 1 of Part 3.
 */
namespace OopCsharp.Week9.Part3_DefensiveIO;

public static class Demo03_DefensiveIO
{
    public static void Run()
    {
        // ── 1. The problem: File.Exists before Read is a TOCTOU race ──────────
        //
        // BAD: between Exists returning true and ReadAllText running,
        //      another process can delete the file. This is the
        //      time-of-check / time-of-use (TOCTOU) bug.
        //
        // string path = "data.txt";
        // if (File.Exists(path))
        //     return File.ReadAllText(path);   // can STILL throw!

        // ── 2. Good pattern: attempt the operation, catch on failure ──────────
        static string? TryReadText(string? path)
        {
            if (path is null) return null;
            try
            {
                return File.ReadAllText(path);
            }
            catch
            {
                return null;
            }
        }

        Console.WriteLine(TryReadText("missing.txt") ?? "(null)");   // "(null)"

        // ── 3. ReadOrDefault ─────────────────────────────────────────────────
        static string ReadOrDefault(string path, string defaultValue)
        {
            try   { return File.ReadAllText(path); }
            catch { return defaultValue; }
        }

        Console.WriteLine(ReadOrDefault("config.json", "{}"));   // "{}"

        // ── 4. TryWrite ───────────────────────────────────────────────────────
        static bool TryWriteText(string path, string content)
        {
            try   { File.WriteAllText(path, content); return true; }
            catch { return false; }
        }

        string tmp = Path.Combine(Path.GetTempPath(), "demo9.txt");
        Console.WriteLine(TryWriteText(tmp, "hello"));          // True
        Console.WriteLine(TryWriteText("/root/no-access", "x")); // False (access denied)
        File.Delete(tmp);

        // ── 5. CountLines — zero for both missing and empty ───────────────────
        static int CountLines(string path)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                int count = 0;
                foreach (string line in lines)
                    if (!string.IsNullOrWhiteSpace(line)) count++;
                return count;
            }
            catch
            {
                return 0;
            }
        }

        Console.WriteLine(CountLines("missing.txt"));   // 0

        // ── 6. AppendLine — create-or-append, never throw ────────────────────
        static bool AppendLine(string path, string line)
        {
            try
            {
                File.AppendAllText(path, line + Environment.NewLine);
                return true;
            }
            catch
            {
                return false;
            }
        }

        string log = Path.Combine(Path.GetTempPath(), "demo9_log.txt");
        AppendLine(log, "First entry");
        AppendLine(log, "Second entry");
        Console.WriteLine(File.ReadAllText(log));
        File.Delete(log);
    }
}
