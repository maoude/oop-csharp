/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_SafeFileReader.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week9.Part3_DefensiveIO.Solutions;

public class Sol1_SafeFileReader
{
    /// <summary>Returns file content on success; null on any error.</summary>
    public string? TryReadText(string? path)
    {
        if (path is null) return null;
        try   { return File.ReadAllText(path); }
        catch { return null; }
    }

    /// <summary>Writes content to path; returns true on success, false on error.</summary>
    public bool TryWriteText(string path, string content)
    {
        try   { File.WriteAllText(path, content); return true; }
        catch { return false; }
    }

    /// <summary>Returns file content if readable, defaultContent otherwise.</summary>
    public string ReadTextOrDefault(string path, string defaultContent)
    {
        try   { return File.ReadAllText(path); }
        catch { return defaultContent; }
    }

    /// <summary>Counts non-empty lines. Returns 0 for missing, empty, or unreadable files.</summary>
    public int CountLines(string path)
    {
        try
        {
            int count = 0;
            foreach (string line in File.ReadAllLines(path))
                if (!string.IsNullOrWhiteSpace(line)) count++;
            return count;
        }
        catch { return 0; }
    }

    /// <summary>Appends line + newline; creates file if absent. Returns false on error.</summary>
    public bool AppendLine(string path, string line)
    {
        try   { File.AppendAllText(path, line + Environment.NewLine); return true; }
        catch { return false; }
    }
}
