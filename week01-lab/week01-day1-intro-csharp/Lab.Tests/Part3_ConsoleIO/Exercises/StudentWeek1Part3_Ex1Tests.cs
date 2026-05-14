/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W1.P3.Ex1 — InputParser.
 *           Tests verify both the happy path (valid input) and all failure
 *           modes (null, empty, non-numeric, mixed tokens).  The methods
 *           must never throw — failures must produce a default value.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week1.Part3_ConsoleIO.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="InputParser"/> (W1.P3.Ex1).</summary>
public class StudentWeek1Part3_Ex1Tests
{
    // ── ParseInt ─────────────────────────────────────────────────────

    [Theory]
    [InlineData("42",    0,  42)]    // valid positive integer
    [InlineData("-7",    0,  -7)]    // valid negative integer
    [InlineData("0",     5,   0)]    // valid zero — not the same as failure
    [InlineData("abc",   0,   0)]    // non-numeric → default
    [InlineData("",      9,   9)]    // empty string → default
    [InlineData(null,   -1,  -1)]    // null → default (must not throw NullReferenceException)
    [InlineData("3.14",  0,   0)]    // valid double but not int → default
    public void ParseInt_returns_parsed_value_or_default(string? input, int def, int expected)
    {
        Assert.Equal(expected, InputParser.ParseInt(input, def));
    }

    // ── ParseDouble ───────────────────────────────────────────────────

    [Theory]
    [InlineData("3.14",  0.0,  3.14)]   // standard decimal
    [InlineData("-2.5",  0.0, -2.5)]    // negative decimal
    [InlineData("hello", 0.0,  0.0)]    // non-numeric → default
    [InlineData("",      1.5,  1.5)]    // empty → default
    [InlineData(null,    9.9,  9.9)]    // null → default
    public void ParseDouble_returns_parsed_value_or_default(
        string? input, double def, double expected)
    {
        Assert.Equal(expected, InputParser.ParseDouble(input, def), precision: 10);
    }

    // ── ParseBool ────────────────────────────────────────────────────

    [Theory]
    // All accepted truthy values — case variations
    [InlineData("true",  true)]
    [InlineData("True",  true)]
    [InlineData("TRUE",  true)]
    [InlineData("yes",   true)]
    [InlineData("YES",   true)]
    [InlineData("Yes",   true)]
    [InlineData("1",     true)]
    [InlineData("y",     true)]
    [InlineData("Y",     true)]   // uppercase single char
    // Everything else → false
    [InlineData("false", false)]
    [InlineData("no",    false)]
    [InlineData("0",     false)]
    [InlineData("",      false)]
    [InlineData(null,    false)]   // null → false (no exception)
    [InlineData("maybe", false)]   // ambiguous input → false
    public void ParseBool_returns_correct_boolean(string? input, bool expected)
    {
        Assert.Equal(expected, InputParser.ParseBool(input));
    }

    // ── SplitAndSum ───────────────────────────────────────────────────

    [Theory]
    [InlineData("3 7 2",      12)]   // three valid tokens
    [InlineData("10",         10)]   // single token
    [InlineData("1 2 3 4 5",  15)]   // five tokens
    [InlineData("",            0)]   // empty string → 0
    [InlineData(null,          0)]   // null → 0 (no exception)
    [InlineData("1 abc 3",     4)]   // skips "abc", sums 1+3
    [InlineData("  5  5  ",   10)]   // extra whitespace — RemoveEmptyEntries handles it
    [InlineData("-3 3",         0)]   // negative + positive that sum to zero
    public void SplitAndSum_returns_correct_sum(string? input, int expected)
    {
        Assert.Equal(expected, InputParser.SplitAndSum(input));
    }

    [Fact]
    public void SplitAndSum_all_invalid_tokens_returns_zero()
    {
        // When every token fails to parse, the sum must be 0 — not an exception.
        Assert.Equal(0, InputParser.SplitAndSum("a b c"));
    }
}
