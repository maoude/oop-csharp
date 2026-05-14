// 6 tests
using OopCsharp.Week9.Part2_DirectoryAndPath.Exercises;
using Xunit;

namespace OopCsharp.Week9.Tests.Part2_DirectoryAndPath;

public class StudentWeek9Part2_Ex2Tests
{
    private readonly PathHelper _helper = new();

    // ── Combine ───────────────────────────────────────────────────────────────

    [Fact]
    public void Combine_DirectoryAndFileName_ReturnsCombinedPath()
    {
        string result = _helper.Combine(@"C:\Users\Alice", "notes.txt");
        Assert.Equal(Path.Combine(@"C:\Users\Alice", "notes.txt"), result);
    }

    // ── GetFileName ───────────────────────────────────────────────────────────

    [Fact]
    public void GetFileName_FullPath_ReturnsFileNameWithExtension()
    {
        Assert.Equal("report.pdf", _helper.GetFileName(@"C:\docs\report.pdf"));
    }

    // ── GetExtension ──────────────────────────────────────────────────────────

    [Fact]
    public void GetExtension_PathWithExtension_ReturnsExtensionWithDot()
    {
        Assert.Equal(".txt", _helper.GetExtension("notes.txt"));
    }

    // ── GetDirectory ──────────────────────────────────────────────────────────

    [Fact]
    public void GetDirectory_FullPath_ReturnsDirectoryPart()
    {
        string? dir = _helper.GetDirectory(@"C:\Users\Alice\notes.txt");
        Assert.Equal(@"C:\Users\Alice", dir);
    }

    // ── HasExtension ──────────────────────────────────────────────────────────

    [Fact]
    public void HasExtension_MatchingExtensionWithoutDot_ReturnsTrue()
    {
        Assert.True(_helper.HasExtension("report.PDF", "pdf"));
    }

    [Fact]
    public void HasExtension_DifferentExtension_ReturnsFalse()
    {
        Assert.False(_helper.HasExtension("image.png", ".txt"));
    }
}
