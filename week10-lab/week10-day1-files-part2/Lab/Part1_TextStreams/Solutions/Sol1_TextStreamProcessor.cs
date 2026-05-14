/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_TextStreamProcessor.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week10.Part1_TextStreams.Solutions;

public class Sol1_TextStreamProcessor
{
    /// <summary>Opens a StreamReader and returns the full file content.</summary>
    public string ReadAllText(string path)
    {
        using var reader = new StreamReader(path);
        return reader.ReadToEnd();
    }

    /// <summary>Reads all lines via a ReadLine loop. Empty file returns empty array.</summary>
    public string[] ReadLines(string path)
    {
        var lines = new List<string>();
        using var reader = new StreamReader(path);
        string? line;
        while ((line = reader.ReadLine()) != null)
            lines.Add(line);
        return lines.ToArray();
    }

    /// <summary>Creates or overwrites the file, writing each element on its own line.</summary>
    public void WriteLines(string path, IEnumerable<string> lines)
    {
        using var writer = new StreamWriter(path);
        foreach (string line in lines)
            writer.WriteLine(line);
    }

    /// <summary>Appends line to the file (creates if absent) using append mode.</summary>
    public void AppendLine(string path, string line)
    {
        using var writer = new StreamWriter(path, append: true);
        writer.WriteLine(line);
    }

    /// <summary>Counts non-whitespace-only lines. Returns 0 for empty files.</summary>
    public int CountLines(string path)
    {
        int count = 0;
        using var reader = new StreamReader(path);
        string? line;
        while ((line = reader.ReadLine()) != null)
            if (!string.IsNullOrWhiteSpace(line)) count++;
        return count;
    }
}
