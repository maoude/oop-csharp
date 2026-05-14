// 7 tests
using OopCsharp.Week8.Part2_StringOperations.Exercises;
using Xunit;

namespace OopCsharp.Week8.Tests.Part2_StringOperations;

public class StudentWeek8Part2_Ex2Tests
{
    private readonly StringManipulator _manip = new();

    // ── TitleCase ─────────────────────────────────────────────────────────────

    [Fact]
    public void TitleCase_AllLowercase_CapitalisesEachWord()
    {
        Assert.Equal("Hello World", _manip.TitleCase("hello world"));
    }

    [Fact]
    public void TitleCase_AllUppercaseInput_NormalisesToTitleCase()
    {
        Assert.Equal("The Quick Fox", _manip.TitleCase("THE QUICK FOX"));
    }

    // ── Truncate ──────────────────────────────────────────────────────────────

    [Fact]
    public void Truncate_StringExceedsMaxLength_TruncatesWithEllipsis()
    {
        // maxLength=8 → keep 5 chars then "..."
        Assert.Equal("Hello...", _manip.Truncate("Hello, World!", 8));
    }

    [Fact]
    public void Truncate_StringWithinMaxLength_ReturnsUnchanged()
    {
        Assert.Equal("Hi", _manip.Truncate("Hi", 8));
    }

    // ── NormaliseWhitespace ───────────────────────────────────────────────────

    [Fact]
    public void NormaliseWhitespace_LeadingTrailingAndInternalSpaces_CollapseToOne()
    {
        Assert.Equal("Hello World", _manip.NormaliseWhitespace("  Hello   World  "));
    }

    // ── ExtractBetween ────────────────────────────────────────────────────────

    [Fact]
    public void ExtractBetween_BothDelimitersPresent_ReturnsInnerContent()
    {
        Assert.Equal("World", _manip.ExtractBetween("Hello (World)!", '(', ')'));
    }

    [Fact]
    public void ExtractBetween_OpenDelimiterAbsent_ReturnsNull()
    {
        Assert.Null(_manip.ExtractBetween("No brackets here", '(', ')'));
    }
}
