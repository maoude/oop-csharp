/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1) · File and Directory Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for DirectoryOperations exercises (7 tests covering DirectoryExists, EnsureDirectory, ListFiles, ListSubdirectories).
 */

using OopCsharp.Week9.Part2_DirectoryAndPath.Exercises;
using Xunit;

namespace OopCsharp.Week9.Tests.Part2_DirectoryAndPath;

public class StudentWeek9Part2_Ex1Tests : IDisposable
{
    private readonly string _tempDir;
    private readonly DirectoryOperations _ops = new();

    public StudentWeek9Part2_Ex1Tests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "W9P2_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    private string Sub(string name) => Path.Combine(_tempDir, name);

    // ── DirectoryExists ───────────────────────────────────────────────────────

    [Fact]
    public void DirectoryExists_ExistingDirectory_ReturnsTrue()
    {
        Assert.True(_ops.DirectoryExists(_tempDir));
    }

    [Fact]
    public void DirectoryExists_MissingDirectory_ReturnsFalse()
    {
        Assert.False(_ops.DirectoryExists(Sub("nonexistent")));
    }

    // ── EnsureDirectory ───────────────────────────────────────────────────────

    [Fact]
    public void EnsureDirectory_MissingDirectory_CreatesIt()
    {
        string path = Sub("newdir");
        _ops.EnsureDirectory(path);
        Assert.True(Directory.Exists(path));
    }

    [Fact]
    public void EnsureDirectory_AlreadyExists_DoesNotThrow()
    {
        // Must not throw even when called on an existing directory
        var ex = Record.Exception(() => _ops.EnsureDirectory(_tempDir));
        Assert.Null(ex);
    }

    // ── ListFiles ─────────────────────────────────────────────────────────────

    [Fact]
    public void ListFiles_DirectoryWithTxtFiles_ReturnsTxtFilesOnly()
    {
        File.WriteAllText(Sub("a.txt"), "");
        File.WriteAllText(Sub("b.txt"), "");
        File.WriteAllText(Sub("c.png"), "");

        string[] files = _ops.ListFiles(_tempDir, "*.txt");
        Assert.Equal(2, files.Length);
    }

    [Fact]
    public void ListFiles_MissingDirectory_ThrowsDirectoryNotFoundException()
    {
        Assert.Throws<DirectoryNotFoundException>(
            () => _ops.ListFiles(Sub("nope"), "*.*"));
    }

    // ── ListSubdirectories ────────────────────────────────────────────────────

    [Fact]
    public void ListSubdirectories_DirectoryWithSubdirs_ReturnsTheirPaths()
    {
        Directory.CreateDirectory(Sub("sub1"));
        Directory.CreateDirectory(Sub("sub2"));

        string[] subs = _ops.ListSubdirectories(_tempDir);
        Assert.Equal(2, subs.Length);
    }
}
