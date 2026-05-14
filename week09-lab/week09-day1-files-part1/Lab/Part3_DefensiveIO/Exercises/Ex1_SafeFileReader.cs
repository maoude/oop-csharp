/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: TryXxx pattern for file I/O.
 *           Practice: catch exceptions internally, return null/false/default.
 */
namespace OopCsharp.Week9.Part3_DefensiveIO.Exercises;

// ============================================================
// Exercise 1 — SafeFileReader
//
// Implement five defensive file methods.
// NONE of these methods may throw an exception to the caller.
// Catch internally and return null, false, 0, or a default value.
// ============================================================

public class SafeFileReader
{
    // TODO 1a: TryReadText(string? path)
    //   Return file content as a string on success.
    //   Return null for any error (file missing, null path, access denied, etc.).
    //   Must NOT throw.
    public string? TryReadText(string? path) => throw new NotImplementedException();

    // TODO 1b: TryWriteText(string path, string content)
    //   Write content to path; return true on success, false on any error.
    //   Must NOT throw.
    public bool TryWriteText(string path, string content) => throw new NotImplementedException();

    // TODO 1c: ReadTextOrDefault(string path, string defaultContent)
    //   Return file content if the file is readable, defaultContent otherwise.
    //   Must NOT throw.
    public string ReadTextOrDefault(string path, string defaultContent) =>
        throw new NotImplementedException();

    // TODO 1d: CountLines(string path)
    //   Count non-empty (non-whitespace-only) lines in the file.
    //   Return 0 for a missing file, empty file, or any error.
    //   Must NOT throw.
    public int CountLines(string path) => throw new NotImplementedException();

    // TODO 1e: AppendLine(string path, string line)
    //   Append line + Environment.NewLine to the file.
    //   Create the file if it does not exist.
    //   Return true on success, false on any error (e.g. parent dir missing).
    //   Must NOT throw.
    public bool AppendLine(string path, string line) => throw new NotImplementedException();
}
