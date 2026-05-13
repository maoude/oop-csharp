using OopCsharp.Week7.Part1_TryCatchFinally.Exercises;
using Xunit;

namespace OopCsharp.Week7.Tests.Part1_TryCatchFinally;

// 12 tests
public class StudentWeek7Part1_Ex1Tests
{
    private readonly SafeCalculator _calc = new();

    // ── Divide ───────────────────────────────────────────────────────────

    [Fact]
    public void Divide_ValidInputs_ReturnsQuotient()
    {
        Assert.Equal(5, _calc.Divide(10, 2));
    }

    [Fact]
    public void Divide_ByZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _calc.Divide(10, 0));
    }

    [Fact]
    public void Divide_ByZero_MessageContainsKeyword()
    {
        var ex = Assert.Throws<ArgumentException>(() => _calc.Divide(1, 0));
        Assert.Contains("zero", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    // ── ParseAndAdd ───────────────────────────────────────────────────────

    [Fact]
    public void ParseAndAdd_ValidInputs_ReturnsSum()
    {
        Assert.Equal(7.5, _calc.ParseAndAdd("3", "4.5"), precision: 9);
    }

    [Theory]
    [InlineData("abc", "4")]
    [InlineData("3",   "xyz")]
    public void ParseAndAdd_InvalidInput_ThrowsFormatException(string a, string b)
    {
        Assert.Throws<FormatException>(() => _calc.ParseAndAdd(a, b));
    }

    [Fact]
    public void ParseAndAdd_InvalidA_MessageContainsValue()
    {
        var ex = Assert.Throws<FormatException>(() => _calc.ParseAndAdd("bad", "1"));
        Assert.Contains("bad", ex.Message);
    }

    // ── SafeRead ──────────────────────────────────────────────────────────

    [Fact]
    public void SafeRead_ValidIndex_ReturnsElement()
    {
        string[] data = { "alpha", "beta", "gamma" };
        Assert.Equal("beta", _calc.SafeRead(data, 1));
    }

    [Fact]
    public void SafeRead_OutOfRange_ReturnsNull()
    {
        string[] data = { "alpha" };
        Assert.Null(_calc.SafeRead(data, 99));
    }

    // ── ParseWithFinally ──────────────────────────────────────────────────

    [Fact]
    public void ParseWithFinally_ValidInput_ReturnsInt_AndIncrementsCount()
    {
        int count = 0;
        int result = _calc.ParseWithFinally("42", ref count);
        Assert.Equal(42, result);
        Assert.Equal(1, count);
    }

    [Fact]
    public void ParseWithFinally_InvalidInput_ThrowsFormatException()
    {
        int count = 0;
        Assert.Throws<FormatException>(() => _calc.ParseWithFinally("oops", ref count));
    }

    [Fact]
    public void ParseWithFinally_InvalidInput_StillIncrementsCount()
    {
        int count = 0;
        try { _calc.ParseWithFinally("oops", ref count); } catch { /* expected */ }
        Assert.Equal(1, count);
    }

    [Fact]
    public void ParseWithFinally_MultipleCalls_CountAccumulates()
    {
        int count = 0;
        _calc.ParseWithFinally("1", ref count);
        _calc.ParseWithFinally("2", ref count);
        try { _calc.ParseWithFinally("bad", ref count); } catch { /* expected */ }
        Assert.Equal(3, count);
    }
}
