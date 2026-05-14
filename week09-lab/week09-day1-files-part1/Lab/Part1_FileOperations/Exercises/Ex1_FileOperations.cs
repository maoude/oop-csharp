/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: File static methods and FileInfo.
 *           Practice: which method to call, what it throws, and when.
 */
namespace OopCsharp.Week9.Part1_FileOperations.Exercises;

// ============================================================
// Exercise 1 — FileOperations
//
// Implement seven methods that wrap System.IO.File and FileInfo.
// Let the framework throw its natural exceptions — do NOT catch
// them here. Each method is a correct, thin delegation.
// ============================================================

public class FileOperations
{
    // TODO 1a: FileExists(string path)
    //   Return true when a file exists at path, false otherwise.
    public bool FileExists(string path) => throw new NotImplementedException();

    // TODO 1b: ReadText(string path)
    //   Return the entire file content as a string.
    //   Throws FileNotFoundException when the file does not exist.
    public string ReadText(string path) => throw new NotImplementedException();

    // TODO 1c: WriteText(string path, string content)
    //   Create or overwrite the file at path with content.
    public void WriteText(string path, string content) => throw new NotImplementedException();

    // TODO 1d: AppendText(string path, string content)
    //   Append content to the file; create the file if it does not exist.
    public void AppendText(string path, string content) => throw new NotImplementedException();

    // TODO 1e: ReadLines(string path)
    //   Return all lines of the file as an array (newlines stripped).
    //   Throws FileNotFoundException when the file does not exist.
    public string[] ReadLines(string path) => throw new NotImplementedException();

    // TODO 1f: CopyFile(string source, string destination)
    //   Copy source to destination WITHOUT overwriting.
    //   Throws FileNotFoundException when source does not exist.
    //   Throws IOException when destination already exists.
    //   Hint: File.Copy has a three-argument overload with an overwrite flag.
    public void CopyFile(string source, string destination) => throw new NotImplementedException();

    // TODO 1g: GetFileSize(string path)
    //   Return the file size in bytes using FileInfo.
    //   Throws FileNotFoundException when the file does not exist.
    public long GetFileSize(string path) => throw new NotImplementedException();
}
