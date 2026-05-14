// 13 tests
using OopCsharp.Week10.Part2_FileStream.Exercises;
using Xunit;

namespace OopCsharp.Week10.Tests.Part2_FileStream;

public class StudentWeek10Part2_Ex1Tests : IDisposable
{
    private readonly string _tempDir;
    private readonly ByteStreamProcessor _proc = new();

    public StudentWeek10Part2_Ex1Tests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "W10P2_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    private string TempFile(string name) => Path.Combine(_tempDir, name);

    // ── ReadAllBytes ──────────────────────────────────────────────────────────

    [Fact]
    public void ReadAllBytes_FileWithContent_ReturnsByteArray()
    {
        string path = TempFile("data.bin");
        byte[] data = { 10, 20, 30, 40, 50 };
        File.WriteAllBytes(path, data);
        Assert.Equal(data, _proc.ReadAllBytes(path));
    }

    [Fact]
    public void ReadAllBytes_EmptyFile_ReturnsEmptyArray()
    {
        string path = TempFile("empty.bin");
        File.WriteAllBytes(path, Array.Empty<byte>());
        Assert.Empty(_proc.ReadAllBytes(path));
    }

    [Fact]
    public void ReadAllBytes_MissingFile_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() => _proc.ReadAllBytes(TempFile("nope.bin")));
    }

    // ── WriteAllBytes ─────────────────────────────────────────────────────────

    [Fact]
    public void WriteAllBytes_NewFile_CreatesFileWithCorrectBytes()
    {
        string path = TempFile("write.bin");
        byte[] data = { 1, 2, 3, 4, 5 };
        _proc.WriteAllBytes(path, data);
        Assert.Equal(data, File.ReadAllBytes(path));
    }

    [Fact]
    public void WriteAllBytes_ExistingFile_OverwritesContent()
    {
        string path = TempFile("overwrite.bin");
        File.WriteAllBytes(path, new byte[] { 99, 99, 99 });
        byte[] newData = { 1, 2 };
        _proc.WriteAllBytes(path, newData);
        Assert.Equal(newData, File.ReadAllBytes(path));
    }

    [Fact]
    public void WriteAllBytes_EmptyArray_CreatesEmptyFile()
    {
        string path = TempFile("empty_write.bin");
        _proc.WriteAllBytes(path, Array.Empty<byte>());
        Assert.Equal(0, new FileInfo(path).Length);
    }

    [Fact]
    public void WriteAllBytes_CalledTwiceSuccessively_SecondCallSucceeds()
    {
        string path = TempFile("twice.bin");
        _proc.WriteAllBytes(path, new byte[] { 1 });
        var ex = Record.Exception(() => _proc.WriteAllBytes(path, new byte[] { 2 }));
        Assert.Null(ex);
    }

    // ── ReadSegment ───────────────────────────────────────────────────────────

    [Fact]
    public void ReadSegment_MiddleOfFile_ReturnsCorrectBytes()
    {
        string path = TempFile("seg.bin");
        File.WriteAllBytes(path, new byte[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 });
        byte[] seg = _proc.ReadSegment(path, 3, 4);
        Assert.Equal(new byte[] { 40, 50, 60, 70 }, seg);
    }

    [Fact]
    public void ReadSegment_CountExceedsRemainingBytes_ReturnsAvailableOnly()
    {
        string path = TempFile("short.bin");
        File.WriteAllBytes(path, new byte[] { 1, 2, 3, 4, 5 });
        byte[] seg = _proc.ReadSegment(path, 3, 10);   // only 2 bytes remain after offset 3
        Assert.Equal(new byte[] { 4, 5 }, seg);
    }

    [Fact]
    public void ReadSegment_OffsetBeyondFileLength_ReturnsEmptyArray()
    {
        string path = TempFile("beyond.bin");
        File.WriteAllBytes(path, new byte[] { 1, 2, 3 });
        Assert.Empty(_proc.ReadSegment(path, 100, 4));
    }

    // ── AppendBytes ───────────────────────────────────────────────────────────

    [Fact]
    public void AppendBytes_ExistingFile_AppendsBytesToEnd()
    {
        string path = TempFile("append.bin");
        File.WriteAllBytes(path, new byte[] { 1, 2, 3 });
        _proc.AppendBytes(path, new byte[] { 4, 5 });
        Assert.Equal(new byte[] { 1, 2, 3, 4, 5 }, File.ReadAllBytes(path));
    }

    [Fact]
    public void AppendBytes_MissingFile_CreatesFile()
    {
        string path = TempFile("new_append.bin");
        _proc.AppendBytes(path, new byte[] { 7, 8, 9 });
        Assert.Equal(new byte[] { 7, 8, 9 }, File.ReadAllBytes(path));
    }

    // ── Round-trip ────────────────────────────────────────────────────────────

    [Fact]
    public void WriteAllBytes_ThenReadAllBytes_ContentMatches()
    {
        string path = TempFile("roundtrip.bin");
        byte[] original = { 0xDE, 0xAD, 0xBE, 0xEF };
        _proc.WriteAllBytes(path, original);
        byte[] loaded = _proc.ReadAllBytes(path);
        Assert.Equal(original, loaded);
    }
}
