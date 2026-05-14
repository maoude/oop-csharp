/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     10 — Files in C# (Part 2) · Streams
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: StreamReader and StreamWriter.
 *           Practice: using statement, ReadLine loop, append mode.
 */
namespace OopCsharp.Week10.Part1_TextStreams.Exercises;

// ============================================================
// Exercise 1 — TextStreamProcessor
//
// Implement five methods using StreamReader and StreamWriter.
// EVERY stream MUST be wrapped in a 'using' statement.
// Failing to dispose will cause file-lock failures in tests.
// ============================================================

public class TextStreamProcessor
{
    // TODO 1a: ReadAllText(string path)
    //   Open a StreamReader, call ReadToEnd(), return the result.
    //   Throws FileNotFoundException when the file does not exist.
    public string ReadAllText(string path) => throw new NotImplementedException();

    // TODO 1b: ReadLines(string path)
    //   Read line by line with ReadLine() until it returns null.
    //   Return all lines as an array. Empty file → empty array.
    //   Throws FileNotFoundException when the file does not exist.
    public string[] ReadLines(string path) => throw new NotImplementedException();

    // TODO 1c: WriteLines(string path, IEnumerable<string> lines)
    //   Create or overwrite the file; write each element with WriteLine().
    //   Empty enumerable → creates an empty file.
    public void WriteLines(string path, IEnumerable<string> lines) =>
        throw new NotImplementedException();

    // TODO 1d: AppendLine(string path, string line)
    //   Open StreamWriter in append mode (new StreamWriter(path, append: true)).
    //   Write line with WriteLine(); creates the file if absent.
    public void AppendLine(string path, string line) => throw new NotImplementedException();

    // TODO 1e: CountLines(string path)
    //   Count non-empty (non-whitespace-only) lines.
    //   Returns 0 for an empty file.
    //   Throws FileNotFoundException when the file does not exist.
    public int CountLines(string path) => throw new NotImplementedException();
}
