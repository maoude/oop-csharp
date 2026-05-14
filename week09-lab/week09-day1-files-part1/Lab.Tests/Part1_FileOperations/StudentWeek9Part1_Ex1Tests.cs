/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1) · File and Directory Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for FileOperations exercises (13 tests covering FileExists, ReadText, WriteText, AppendText, ReadLines, CopyFile, GetFileSize).
 */

using OopCsharp.Week9.Part1_FileOperations.Exercises;
using Xunit;

namespace OopCsharp.Week9.Tests.Part1_FileOperations;

public class StudentWeek9Part1_Ex1Tests : IDisposable
{
    private readonly string _tempDir;
    private readonly FileOperations _ops = new();

    public StudentWeek9Part1_Ex1Tests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "W9P1_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    private string TempFile(string name) => Path.Combine(_tempDir, name);

    // ── FileExists ────────────────────────────────────────────────────────────

    [Fact]
    public void FileExists_ExistingFile_ReturnsTrue()
    {
        string path = TempFile("exists.txt");
        File.WriteAllText(path, "data");
        Assert.True(_ops.FileExists(path));
    }

    [Fact]
    public void FileExists_MissingFile_ReturnsFalse()
    {
        Assert.False(_ops.FileExists(TempFile("missing.txt")));
    }

    // ── ReadText ──────────────────────────────────────────────────────────────

    [Fact]
    public void ReadText_ExistingFile_ReturnsContent()
    {
        string path = TempFile("read.txt");
        File.WriteAllText(path, "Hello, Files!");
        Assert.Equal("Hello, Files!", _ops.ReadText(path));
    }

    [Fact]
    public void ReadText_MissingFile_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() => _ops.ReadText(TempFile("nope.txt")));
    }

    // ── WriteText ─────────────────────────────────────────────────────────────

    [Fact]
    public void WriteText_NewFile_CreatesFileWithContent()
    {
        string path = TempFile("write.txt");
        _ops.WriteText(path, "written");
        Assert.Equal("written", File.ReadAllText(path));
    }

    [Fact]
    public void WriteText_ExistingFile_OverwritesContent()
    {
        string path = TempFile("overwrite.txt");
        File.WriteAllText(path, "old");
        _ops.WriteText(path, "new");
        Assert.Equal("new", File.ReadAllText(path));
    }

    // ── AppendText ────────────────────────────────────────────────────────────

    [Fact]
    public void AppendText_ExistingFile_AppendsContent()
    {
        string path = TempFile("append.txt");
        File.WriteAllText(path, "first");
        _ops.AppendText(path, " second");
        Assert.Equal("first second", File.ReadAllText(path));
    }

    // ── ReadLines ─────────────────────────────────────────────────────────────

    [Fact]
    public void ReadLines_FileWithLines_ReturnsAllLines()
    {
        string path = TempFile("lines.txt");
        File.WriteAllLines(path, new[] { "alpha", "beta", "gamma" });
        string[] lines = _ops.ReadLines(path);
        Assert.Equal(3, lines.Length);
        Assert.Equal("alpha", lines[0]);
        Assert.Equal("gamma", lines[2]);
    }

    [Fact]
    public void ReadLines_MissingFile_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() => _ops.ReadLines(TempFile("nope.txt")));
    }

    // ── CopyFile ──────────────────────────────────────────────────────────────

    [Fact]
    public void CopyFile_ValidSource_CopiesContentToDestination()
    {
        string src  = TempFile("src.txt");
        string dest = TempFile("dest.txt");
        File.WriteAllText(src, "copy me");
        _ops.CopyFile(src, dest);
        Assert.Equal("copy me", File.ReadAllText(dest));
    }

    [Fact]
    public void CopyFile_MissingSource_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(
            () => _ops.CopyFile(TempFile("nope.txt"), TempFile("dest.txt")));
    }

    // ── GetFileSize ───────────────────────────────────────────────────────────

    [Fact]
    public void GetFileSize_ExistingFile_ReturnsCorrectByteCount()
    {
        string path = TempFile("size.txt");
        byte[] content = new byte[] { 1, 2, 3, 4, 5 };
        File.WriteAllBytes(path, content);
        Assert.Equal(5L, _ops.GetFileSize(path));
    }

    [Fact]
    public void GetFileSize_MissingFile_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() => _ops.GetFileSize(TempFile("nope.txt")));
    }
}
