/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: byte-level access with FileStream.
 *           Practice: FileMode, FileAccess, Read/Write/Seek.
 */
namespace OopCsharp.Week10.Part2_FileStream.Exercises;

// ============================================================
// Exercise 1 — ByteStreamProcessor
//
// Implement four methods using FileStream directly.
// Always use 'using' and choose FileMode / FileAccess carefully.
// Remember: fs.Read() returns the number of bytes ACTUALLY read.
// ============================================================

public class ByteStreamProcessor
{
    // TODO 1a: ReadAllBytes(string path)
    //   Open with FileMode.Open / FileAccess.Read.
    //   Allocate a buffer of fs.Length bytes, read into it, return it.
    //   Throws FileNotFoundException when the file does not exist.
    public byte[] ReadAllBytes(string path) => throw new NotImplementedException();

    // TODO 1b: WriteAllBytes(string path, byte[] data)
    //   Open with FileMode.Create / FileAccess.Write (creates or overwrites).
    //   Write all bytes in data.
    public void WriteAllBytes(string path, byte[] data) => throw new NotImplementedException();

    // TODO 1c: ReadSegment(string path, long offset, int count)
    //   Open with FileMode.Open / FileAccess.Read.
    //   If offset >= file length, return an empty array.
    //   Otherwise: Seek to offset from SeekOrigin.Begin, read up to count bytes.
    //   Return only the bytes actually read (resize the buffer if necessary).
    public byte[] ReadSegment(string path, long offset, int count) =>
        throw new NotImplementedException();

    // TODO 1d: AppendBytes(string path, byte[] data)
    //   Open with FileMode.Append / FileAccess.Write.
    //   Write all bytes in data at the end of the file.
    //   Creates the file if it does not exist.
    public void AppendBytes(string path, byte[] data) => throw new NotImplementedException();
}
