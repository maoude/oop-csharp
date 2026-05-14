/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_FileOperations.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week9.Part1_FileOperations.Solutions;

public class Sol1_FileOperations
{
    /// <summary>Returns true when a file exists at path.</summary>
    public bool FileExists(string path) => File.Exists(path);

    /// <summary>Returns the entire file as a string. Throws FileNotFoundException if missing.</summary>
    public string ReadText(string path) => File.ReadAllText(path);

    /// <summary>Creates or overwrites the file with content.</summary>
    public void WriteText(string path, string content) => File.WriteAllText(path, content);

    /// <summary>Appends content to the file; creates the file if absent.</summary>
    public void AppendText(string path, string content) => File.AppendAllText(path, content);

    /// <summary>Returns all lines as an array. Throws FileNotFoundException if missing.</summary>
    public string[] ReadLines(string path) => File.ReadAllLines(path);

    /// <summary>Copies source to destination without overwriting. Throws on missing source or existing destination.</summary>
    public void CopyFile(string source, string destination) =>
        File.Copy(source, destination, overwrite: false);

    /// <summary>Returns file size in bytes. Throws FileNotFoundException if missing.</summary>
    public long GetFileSize(string path) => new FileInfo(path).Length;
}
