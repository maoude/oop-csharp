/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     9 — Files in C# (Part 1) · File and Directory Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for SafeFileReader defensive I/O exercises (13 tests covering TryReadText, TryWriteText, ReadTextOrDefault, CountLines, AppendLine).
 */

using OopCsharp.Week9.Part3_DefensiveIO.Exercises;
using Xunit;

namespace OopCsharp.Week9.Tests.Part3_DefensiveIO;

public class StudentWeek9Part3_Ex1Tests : IDisposable
{
    private readonly string _tempDir;
    private readonly SafeFileReader _reader = new();

    public StudentWeek9Part3_Ex1Tests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "W9P3_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    private string TempFile(string name) => Path.Combine(_tempDir, name);

    // ── TryReadText ───────────────────────────────────────────────────────────

    [Fact]
    public void TryReadText_ExistingFile_ReturnsContent()
    {
        string path = TempFile("read.txt");
        File.WriteAllText(path, "hello");
        Assert.Equal("hello", _reader.TryReadText(path));
    }

    [Fact]
    public void TryReadText_MissingFile_ReturnsNull()
    {
        Assert.Null(_reader.TryReadText(TempFile("missing.txt")));
    }

    [Fact]
    public void TryReadText_NullPath_ReturnsNull()
    {
        Assert.Null(_reader.TryReadText(null));
    }

    // ── TryWriteText ──────────────────────────────────────────────────────────

    [Fact]
    public void TryWriteText_ValidPath_WritesFileAndReturnsTrue()
    {
        string path = TempFile("write.txt");
        bool result = _reader.TryWriteText(path, "data");
        Assert.True(result);
        Assert.Equal("data", File.ReadAllText(path));
    }

    [Fact]
    public void TryWriteText_ParentDirectoryMissing_ReturnsFalse()
    {
        string path = Path.Combine(_tempDir, "nope", "file.txt");
        Assert.False(_reader.TryWriteText(path, "data"));
    }

    // ── ReadTextOrDefault ─────────────────────────────────────────────────────

    [Fact]
    public void ReadTextOrDefault_ExistingFile_ReturnsContent()
    {
        string path = TempFile("config.txt");
        File.WriteAllText(path, "real content");
        Assert.Equal("real content", _reader.ReadTextOrDefault(path, "default"));
    }

    [Fact]
    public void ReadTextOrDefault_MissingFile_ReturnsDefaultContent()
    {
        Assert.Equal("{}", _reader.ReadTextOrDefault(TempFile("missing.json"), "{}"));
    }

    // ── CountLines ────────────────────────────────────────────────────────────

    [Fact]
    public void CountLines_FileWithNonEmptyLines_ReturnsCorrectCount()
    {
        string path = TempFile("lines.txt");
        File.WriteAllLines(path, new[] { "alpha", "beta", "", "gamma" });
        Assert.Equal(3, _reader.CountLines(path));
    }

    [Fact]
    public void CountLines_EmptyFile_ReturnsZero()
    {
        string path = TempFile("empty.txt");
        File.WriteAllText(path, "");
        Assert.Equal(0, _reader.CountLines(path));
    }

    [Fact]
    public void CountLines_MissingFile_ReturnsZero()
    {
        Assert.Equal(0, _reader.CountLines(TempFile("missing.txt")));
    }

    // ── AppendLine ────────────────────────────────────────────────────────────

    [Fact]
    public void AppendLine_ExistingFile_AppendsLineAndReturnsTrue()
    {
        string path = TempFile("log.txt");
        File.WriteAllText(path, "first" + Environment.NewLine);
        bool result = _reader.AppendLine(path, "second");
        Assert.True(result);
        string[] lines = File.ReadAllLines(path);
        Assert.Contains("second", lines);
    }

    [Fact]
    public void AppendLine_MissingFile_CreatesFileAndReturnsTrue()
    {
        string path = TempFile("newlog.txt");
        bool result = _reader.AppendLine(path, "entry");
        Assert.True(result);
        Assert.True(File.Exists(path));
    }

    [Fact]
    public void AppendLine_ParentDirectoryMissing_ReturnsFalse()
    {
        string path = Path.Combine(_tempDir, "nope", "log.txt");
        Assert.False(_reader.AppendLine(path, "entry"));
    }
}
