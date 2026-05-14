/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: System.IO.Path helpers.
 *           Practice: safe path construction and decomposition.
 *           These methods do NOT access the filesystem.
 */
namespace OopCsharp.Week9.Part2_DirectoryAndPath.Exercises;

// ============================================================
// Exercise 2 — PathHelper
//
// Implement five pure path-manipulation methods using System.IO.Path.
// None of these methods should read, write, or check the filesystem.
// ============================================================

public class PathHelper
{
    // TODO 2a: Combine(string directory, string fileName)
    //   Return Path.Combine(directory, fileName).
    //   Use Path.Combine — never string concatenation.
    public string Combine(string directory, string fileName) =>
        throw new NotImplementedException();

    // TODO 2b: GetFileName(string path)
    //   Return the file name and extension from path
    //   (e.g. "C:\Users\Alice\notes.txt" → "notes.txt").
    public string GetFileName(string path) => throw new NotImplementedException();

    // TODO 2c: GetExtension(string path)
    //   Return the extension including the leading dot
    //   (e.g. "report.pdf" → ".pdf").
    public string GetExtension(string path) => throw new NotImplementedException();

    // TODO 2d: GetDirectory(string path)
    //   Return the directory portion of path, or null if path has no directory component.
    //   (e.g. "C:\Users\Alice\notes.txt" → "C:\Users\Alice").
    public string? GetDirectory(string path) => throw new NotImplementedException();

    // TODO 2e: HasExtension(string path, string extension)
    //   Return true when the file's extension matches extension, case-insensitively.
    //   The caller may supply extension with or without a leading dot
    //   (both "txt" and ".txt" should match "notes.txt").
    public bool HasExtension(string path, string extension) =>
        throw new NotImplementedException();
}
