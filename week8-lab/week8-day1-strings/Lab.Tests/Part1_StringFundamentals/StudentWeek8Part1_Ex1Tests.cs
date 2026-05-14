/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for fundamental char and string operations (13 tests covering IsVowel, CountChars, ReverseString, IsPalindrome, IsAllDigits, CountWords).
 */

using OopCsharp.Week8.Part1_StringFundamentals.Exercises;
using Xunit;

namespace OopCsharp.Week8.Tests.Part1_StringFundamentals;

public class StudentWeek8Part1_Ex1Tests
{
    private readonly StringBasics _sb = new();

    // ── IsVowel ───────────────────────────────────────────────────────────────

    [Fact]
    public void IsVowel_LowercaseA_ReturnsTrue()
    {
        Assert.True(_sb.IsVowel('a'));
    }

    [Fact]
    public void IsVowel_UppercaseE_ReturnsTrue()
    {
        Assert.True(_sb.IsVowel('E'));
    }

    [Fact]
    public void IsVowel_Consonant_ReturnsFalse()
    {
        Assert.False(_sb.IsVowel('b'));
    }

    // ── CountChars ────────────────────────────────────────────────────────────

    [Fact]
    public void CountChars_TargetAppearsThreeTimes_ReturnsThree()
    {
        Assert.Equal(3, _sb.CountChars("banana", 'a'));
    }

    [Fact]
    public void CountChars_NullText_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _sb.CountChars(null!, 'a'));
    }

    // ── ReverseString ─────────────────────────────────────────────────────────

    [Fact]
    public void ReverseString_NormalString_ReturnsReversed()
    {
        Assert.Equal("olleh", _sb.ReverseString("hello"));
    }

    [Fact]
    public void ReverseString_NullText_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _sb.ReverseString(null!));
    }

    [Fact]
    public void ReverseString_EmptyString_ReturnsEmptyString()
    {
        Assert.Equal("", _sb.ReverseString(""));
    }

    // ── IsPalindrome ──────────────────────────────────────────────────────────

    [Fact]
    public void IsPalindrome_LowercasePalindrome_ReturnsTrue()
    {
        Assert.True(_sb.IsPalindrome("racecar"));
    }

    [Fact]
    public void IsPalindrome_MixedCasePalindrome_ReturnsTrue()
    {
        Assert.True(_sb.IsPalindrome("Racecar"));
    }

    [Fact]
    public void IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        Assert.False(_sb.IsPalindrome("hello"));
    }

    // ── IsAllDigits ───────────────────────────────────────────────────────────

    [Fact]
    public void IsAllDigits_AllDigitString_ReturnsTrue()
    {
        Assert.True(_sb.IsAllDigits("12345"));
    }

    // ── CountWords ────────────────────────────────────────────────────────────

    [Fact]
    public void CountWords_SpaceSeparatedWords_ReturnsCorrectCount()
    {
        Assert.Equal(3, _sb.CountWords("Hello World Again"));
    }
}
