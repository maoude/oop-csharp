/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_DirectoryOperations.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week9.Part2_DirectoryAndPath.Solutions;

public class Sol1_DirectoryOperations
{
    /// <summary>Returns true when a directory exists at path.</summary>
    public bool DirectoryExists(string path) => Directory.Exists(path);

    /// <summary>Creates the directory (and any missing parents). Idempotent — safe to call when already exists.</summary>
    public void EnsureDirectory(string path) => Directory.CreateDirectory(path);

    /// <summary>Returns full paths of files matching searchPattern. Throws DirectoryNotFoundException if path missing.</summary>
    public string[] ListFiles(string path, string searchPattern) =>
        Directory.GetFiles(path, searchPattern);

    /// <summary>Returns full paths of immediate subdirectories. Throws DirectoryNotFoundException if path missing.</summary>
    public string[] ListSubdirectories(string path) => Directory.GetDirectories(path);
}
