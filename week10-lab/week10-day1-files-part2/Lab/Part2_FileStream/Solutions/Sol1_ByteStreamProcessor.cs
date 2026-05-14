/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_ByteStreamProcessor.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week10.Part2_FileStream.Solutions;

public class Sol1_ByteStreamProcessor
{
    /// <summary>Reads the entire file into a byte array.</summary>
    public byte[] ReadAllBytes(string path)
    {
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        byte[] buffer = new byte[fs.Length];
        fs.Read(buffer, 0, buffer.Length);
        return buffer;
    }

    /// <summary>Creates or overwrites the file with the given bytes.</summary>
    public void WriteAllBytes(string path, byte[] data)
    {
        using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        fs.Write(data, 0, data.Length);
    }

    /// <summary>Reads up to count bytes starting at offset. Returns only bytes actually read.</summary>
    public byte[] ReadSegment(string path, long offset, int count)
    {
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        if (offset >= fs.Length) return Array.Empty<byte>();
        fs.Seek(offset, SeekOrigin.Begin);
        byte[] buffer   = new byte[count];
        int bytesRead   = fs.Read(buffer, 0, count);
        if (bytesRead < count) Array.Resize(ref buffer, bytesRead);
        return buffer;
    }

    /// <summary>Appends bytes to the end of the file (creates if absent).</summary>
    public void AppendBytes(string path, byte[] data)
    {
        using var fs = new FileStream(path, FileMode.Append, FileAccess.Write);
        fs.Write(data, 0, data.Length);
    }
}
