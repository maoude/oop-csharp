// 12 tests
using OopCsharp.Week8.Part3_StringBuilder.Exercises;
using Xunit;

namespace OopCsharp.Week8.Tests.Part3_StringBuilder;

public class StudentWeek8Part3_Ex1Tests
{
    private readonly TextBuilder _builder = new();

    // ── Join ──────────────────────────────────────────────────────────────────

    [Fact]
    public void Join_MultipleParts_JoinsWithSeparator()
    {
        Assert.Equal("a, b, c", _builder.Join(new[] { "a", "b", "c" }, ", "));
    }

    [Fact]
    public void Join_EmptySequence_ReturnsEmptyString()
    {
        Assert.Equal("", _builder.Join(Array.Empty<string>(), ", "));
    }

    [Fact]
    public void Join_NullParts_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _builder.Join(null!, ", "));
    }

    // ── Repeat ────────────────────────────────────────────────────────────────

    [Fact]
    public void Repeat_PositiveTimes_RepeatsText()
    {
        Assert.Equal("ababab", _builder.Repeat("ab", 3));
    }

    [Fact]
    public void Repeat_ZeroTimes_ReturnsEmptyString()
    {
        Assert.Equal("", _builder.Repeat("ab", 0));
    }

    [Fact]
    public void Repeat_NegativeTimes_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _builder.Repeat("ab", -1));
    }

    // ── ReverseWords ──────────────────────────────────────────────────────────

    [Fact]
    public void ReverseWords_MultipleWords_ReversesOrder()
    {
        Assert.Equal("World! Hello", _builder.ReverseWords("Hello World!"));
    }

    [Fact]
    public void ReverseWords_SingleWord_ReturnsSameWord()
    {
        Assert.Equal("Hello", _builder.ReverseWords("Hello"));
    }

    [Fact]
    public void ReverseWords_WhitespaceOnly_ReturnsEmptyString()
    {
        Assert.Equal("", _builder.ReverseWords("   "));
    }

    // ── BuildNumberedList ─────────────────────────────────────────────────────

    [Fact]
    public void BuildNumberedList_MultipleItems_FormatsEachWithIndex()
    {
        string result = _builder.BuildNumberedList(new[] { "Alpha", "Beta", "Gamma" });
        string[] lines = result.Split('\n');
        Assert.Equal(3, lines.Length);
        Assert.Equal("1. Alpha", lines[0]);
        Assert.Equal("2. Beta",  lines[1]);
        Assert.Equal("3. Gamma", lines[2]);
    }

    [Fact]
    public void BuildNumberedList_SingleItem_FormatsWithIndexOne()
    {
        Assert.Equal("1. Only", _builder.BuildNumberedList(new[] { "Only" }));
    }

    [Fact]
    public void BuildNumberedList_EmptyArray_ReturnsEmptyString()
    {
        Assert.Equal("", _builder.BuildNumberedList(Array.Empty<string>()));
    }
}
