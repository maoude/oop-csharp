// 13 tests
using OopCsharp.Week10.Part1_TextStreams.Exercises;
using Xunit;

namespace OopCsharp.Week10.Tests.Part1_TextStreams;

public class StudentWeek10Part1_Ex1Tests : IDisposable
{
    private readonly string _tempDir;
    private readonly TextStreamProcessor _proc = new();

    public StudentWeek10Part1_Ex1Tests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "W10P1_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    private string TempFile(string name) => Path.Combine(_tempDir, name);

    // ── ReadAllText ───────────────────────────────────────────────────────────

    [Fact]
    public void ReadAllText_ExistingFile_ReturnsContent()
    {
        string path = TempFile("read.txt");
        File.WriteAllText(path, "hello streams");
        Assert.Equal("hello streams", _proc.ReadAllText(path));
    }

    [Fact]
    public void ReadAllText_MissingFile_ThrowsException()
    {
        Assert.ThrowsAny<Exception>(() => _proc.ReadAllText(TempFile("nope.txt")));
    }

    [Fact]
    public void ReadAllText_CalledTwiceSuccessively_SecondCallSucceeds()
    {
        string path = TempFile("twice.txt");
        File.WriteAllText(path, "data");
        _proc.ReadAllText(path);
        var ex = Record.Exception(() => _proc.ReadAllText(path));
        Assert.Null(ex);   // stream must be disposed — file must not be locked
    }

    // ── ReadLines ─────────────────────────────────────────────────────────────

    [Fact]
    public void ReadLines_FileWithThreeLines_ReturnsThreeElements()
    {
        string path = TempFile("lines.txt");
        File.WriteAllLines(path, new[] { "alpha", "beta", "gamma" });
        string[] lines = _proc.ReadLines(path);
        Assert.Equal(3, lines.Length);
        Assert.Equal("alpha", lines[0]);
        Assert.Equal("gamma", lines[2]);
    }

    [Fact]
    public void ReadLines_EmptyFile_ReturnsEmptyArray()
    {
        string path = TempFile("empty.txt");
        File.WriteAllText(path, "");
        Assert.Empty(_proc.ReadLines(path));
    }

    // ── WriteLines ────────────────────────────────────────────────────────────

    [Fact]
    public void WriteLines_WritesEachElementOnItsOwnLine()
    {
        string path = TempFile("write.txt");
        _proc.WriteLines(path, new[] { "one", "two", "three" });
        string[] lines = File.ReadAllLines(path);
        Assert.Equal(3, lines.Length);
        Assert.Equal("two", lines[1]);
    }

    [Fact]
    public void WriteLines_OverwritesExistingContent()
    {
        string path = TempFile("overwrite.txt");
        File.WriteAllText(path, "old content");
        _proc.WriteLines(path, new[] { "new" });
        string[] lines = File.ReadAllLines(path);
        Assert.Single(lines);
        Assert.Equal("new", lines[0]);
    }

    [Fact]
    public void WriteLines_EmptyEnumerable_CreatesEmptyFile()
    {
        string path = TempFile("empty_write.txt");
        _proc.WriteLines(path, Array.Empty<string>());
        Assert.Equal(0, new FileInfo(path).Length);
    }

    [Fact]
    public void WriteLines_CalledTwiceSuccessively_SecondCallSucceeds()
    {
        string path = TempFile("twice_write.txt");
        _proc.WriteLines(path, new[] { "first" });
        var ex = Record.Exception(() => _proc.WriteLines(path, new[] { "second" }));
        Assert.Null(ex);
    }

    // ── AppendLine ────────────────────────────────────────────────────────────

    [Fact]
    public void AppendLine_ExistingFile_AppendsAtEnd()
    {
        string path = TempFile("append.txt");
        File.WriteAllText(path, "first\n");
        _proc.AppendLine(path, "second");
        string[] lines = File.ReadAllLines(path);
        Assert.Contains("second", lines);
    }

    [Fact]
    public void AppendLine_MissingFile_CreatesFile()
    {
        string path = TempFile("new_append.txt");
        _proc.AppendLine(path, "entry");
        Assert.True(File.Exists(path));
        Assert.Contains("entry", File.ReadAllLines(path));
    }

    // ── CountLines ────────────────────────────────────────────────────────────

    [Fact]
    public void CountLines_FileWithSomeEmptyLines_SkipsEmptyLines()
    {
        string path = TempFile("count.txt");
        File.WriteAllLines(path, new[] { "a", "", "b", "   ", "c" });
        Assert.Equal(3, _proc.CountLines(path));
    }

    [Fact]
    public void CountLines_EmptyFile_ReturnsZero()
    {
        string path = TempFile("empty_count.txt");
        File.WriteAllText(path, "");
        Assert.Equal(0, _proc.CountLines(path));
    }
}
