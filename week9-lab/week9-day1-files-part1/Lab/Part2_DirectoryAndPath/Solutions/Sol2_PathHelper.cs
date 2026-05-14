/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex2_PathHelper.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week9.Part2_DirectoryAndPath.Solutions;

public class Sol2_PathHelper
{
    /// <summary>Joins a directory and file name using the platform separator.</summary>
    public string Combine(string directory, string fileName) =>
        Path.Combine(directory, fileName);

    /// <summary>Returns the file name and extension from path.</summary>
    public string GetFileName(string path) => Path.GetFileName(path);

    /// <summary>Returns the extension including the leading dot.</summary>
    public string GetExtension(string path) => Path.GetExtension(path);

    /// <summary>Returns the directory portion of path, or null if there is none.</summary>
    public string? GetDirectory(string path) => Path.GetDirectoryName(path);

    /// <summary>Returns true when the file's extension matches extension, case-insensitively.</summary>
    public bool HasExtension(string path, string extension)
    {
        string fileExt = Path.GetExtension(path);
        string target  = extension.StartsWith('.') ? extension : "." + extension;
        return fileExt.Equals(target, StringComparison.OrdinalIgnoreCase);
    }
}
