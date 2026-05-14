/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: Directory static methods.
 *           Practice: creating, listing, and checking directories.
 */
namespace OopCsharp.Week9.Part2_DirectoryAndPath.Exercises;

// ============================================================
// Exercise 1 — DirectoryOperations
//
// Implement four methods that wrap System.IO.Directory.
// Let the framework throw its natural exceptions — do NOT catch
// them here.
// ============================================================

public class DirectoryOperations
{
    // TODO 1a: DirectoryExists(string path)
    //   Return true when a directory exists at path, false otherwise.
    public bool DirectoryExists(string path) => throw new NotImplementedException();

    // TODO 1b: EnsureDirectory(string path)
    //   Create the directory at path (and any missing parent directories).
    //   Must NOT throw if the directory already exists — this method is idempotent.
    public void EnsureDirectory(string path) => throw new NotImplementedException();

    // TODO 1c: ListFiles(string path, string searchPattern)
    //   Return the full paths of all files in path that match searchPattern
    //   (e.g. "*.txt"). Non-recursive (top directory only).
    //   Throws DirectoryNotFoundException when path does not exist.
    public string[] ListFiles(string path, string searchPattern) =>
        throw new NotImplementedException();

    // TODO 1d: ListSubdirectories(string path)
    //   Return the full paths of all immediate subdirectories of path.
    //   Throws DirectoryNotFoundException when path does not exist.
    public string[] ListSubdirectories(string path) => throw new NotImplementedException();
}
