// 13 tests
using OopCsharp.Week10.Part3_BinaryIO.Exercises;
using Xunit;

namespace OopCsharp.Week10.Tests.Part3_BinaryIO;

public class StudentWeek10Part3_Ex1Tests : IDisposable
{
    private readonly string _tempDir;
    private readonly BinaryRecordStore _store = new();

    public StudentWeek10Part3_Ex1Tests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "W10P3_" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    private string TempFile(string name) => Path.Combine(_tempDir, name);

    // ── SaveRecords / LoadRecords — single record round-trip ─────────────────

    [Fact]
    public void SaveRecords_SingleRecord_NameRoundTripsCorrectly()
    {
        string path = TempFile("single.bin");
        _store.SaveRecords(path, new[] { ("Alice", 30, 95.5) });
        var records = _store.LoadRecords(path);
        Assert.Equal("Alice", records[0].Name);
    }

    [Fact]
    public void SaveRecords_SingleRecord_AgeRoundTripsCorrectly()
    {
        string path = TempFile("age.bin");
        _store.SaveRecords(path, new[] { ("Alice", 30, 95.5) });
        Assert.Equal(30, _store.LoadRecords(path)[0].Age);
    }

    [Fact]
    public void SaveRecords_SingleRecord_ScoreRoundTripsCorrectly()
    {
        string path = TempFile("score.bin");
        _store.SaveRecords(path, new[] { ("Alice", 30, 95.5) });
        Assert.Equal(95.5, _store.LoadRecords(path)[0].Score);
    }

    // ── Multiple records ──────────────────────────────────────────────────────

    [Fact]
    public void SaveRecords_ThreeRecords_AllLoadBackCorrectly()
    {
        string path = TempFile("three.bin");
        var input = new (string, int, double)[]
        {
            ("Alice", 30, 95.5),
            ("Bob",   25, 88.0),
            ("Carol", 35, 72.3),
        };
        _store.SaveRecords(path, input);
        var records = _store.LoadRecords(path);

        Assert.Equal(3,       records.Count);
        Assert.Equal("Bob",   records[1].Name);
        Assert.Equal(35,      records[2].Age);
        Assert.Equal(72.3,    records[2].Score);
    }

    // ── Empty list ────────────────────────────────────────────────────────────

    [Fact]
    public void SaveRecords_EmptyList_CountRecordsReturnsZero()
    {
        string path = TempFile("empty.bin");
        _store.SaveRecords(path, Array.Empty<(string, int, double)>());
        Assert.Equal(0, _store.CountRecords(path));
    }

    [Fact]
    public void SaveRecords_EmptyList_LoadRecordsReturnsEmptyList()
    {
        string path = TempFile("empty2.bin");
        _store.SaveRecords(path, Array.Empty<(string, int, double)>());
        Assert.Empty(_store.LoadRecords(path));
    }

    // ── CountRecords ──────────────────────────────────────────────────────────

    [Fact]
    public void CountRecords_OneRecord_ReturnsOne()
    {
        string path = TempFile("count1.bin");
        _store.SaveRecords(path, new[] { ("X", 1, 1.0) });
        Assert.Equal(1, _store.CountRecords(path));
    }

    [Fact]
    public void CountRecords_ThreeRecords_ReturnsThree()
    {
        string path = TempFile("count3.bin");
        _store.SaveRecords(path, new[]
        {
            ("A", 1, 1.0), ("B", 2, 2.0), ("C", 3, 3.0)
        });
        Assert.Equal(3, _store.CountRecords(path));
    }

    [Fact]
    public void CountRecords_MatchesLoadRecordsCount()
    {
        string path = TempFile("match.bin");
        _store.SaveRecords(path, new[] { ("P", 10, 5.5), ("Q", 20, 6.6) });
        Assert.Equal(_store.CountRecords(path), _store.LoadRecords(path).Count);
    }

    // ── Error cases ───────────────────────────────────────────────────────────

    [Fact]
    public void LoadRecords_MissingFile_ThrowsFileNotFoundException()
    {
        Assert.Throws<FileNotFoundException>(() => _store.LoadRecords(TempFile("nope.bin")));
    }

    // ── Overwrite and file-lock ───────────────────────────────────────────────

    [Fact]
    public void SaveRecords_OverwritesExistingFile()
    {
        string path = TempFile("overwrite.bin");
        _store.SaveRecords(path, new[] { ("Old", 1, 1.0) });
        _store.SaveRecords(path, new[] { ("New", 2, 2.0) });
        var records = _store.LoadRecords(path);
        Assert.Single(records);
        Assert.Equal("New", records[0].Name);
    }

    [Fact]
    public void SaveRecords_CalledTwiceSuccessively_SecondCallSucceeds()
    {
        string path = TempFile("twice.bin");
        _store.SaveRecords(path, new[] { ("A", 1, 1.0) });
        var ex = Record.Exception(() => _store.SaveRecords(path, new[] { ("B", 2, 2.0) }));
        Assert.Null(ex);
    }
}
