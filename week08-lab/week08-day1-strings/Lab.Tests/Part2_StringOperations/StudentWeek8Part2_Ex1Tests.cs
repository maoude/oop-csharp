/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for StringSearch exercises (7 tests covering ContainsIgnoreCase, IndexOfIgnoreCase, CountSubstringOccurrences, StartsWithAny).
 */

using OopCsharp.Week8.Part2_StringOperations.Exercises;
using Xunit;

namespace OopCsharp.Week8.Tests.Part2_StringOperations;

public class StudentWeek8Part2_Ex1Tests
{
    private readonly StringSearch _search = new();

    // ── ContainsIgnoreCase ────────────────────────────────────────────────────

    [Fact]
    public void ContainsIgnoreCase_PatternInDifferentCase_ReturnsTrue()
    {
        Assert.True(_search.ContainsIgnoreCase("Hello, World!", "world"));
    }

    [Fact]
    public void ContainsIgnoreCase_PatternAbsent_ReturnsFalse()
    {
        Assert.False(_search.ContainsIgnoreCase("Hello, World!", "xyz"));
    }

    // ── IndexOfIgnoreCase ─────────────────────────────────────────────────────

    [Fact]
    public void IndexOfIgnoreCase_PatternPresent_ReturnsCorrectIndex()
    {
        // "Hello, World!" — "World" starts at index 7
        Assert.Equal(7, _search.IndexOfIgnoreCase("Hello, World!", "WORLD"));
    }

    [Fact]
    public void IndexOfIgnoreCase_PatternAbsent_ReturnsNegativeOne()
    {
        Assert.Equal(-1, _search.IndexOfIgnoreCase("Hello, World!", "xyz"));
    }

    // ── CountSubstringOccurrences ─────────────────────────────────────────────

    [Fact]
    public void CountSubstringOccurrences_MultipleMatches_ReturnsCount()
    {
        // "banana" contains "an" at positions 1 and 3
        Assert.Equal(2, _search.CountSubstringOccurrences("banana", "an"));
    }

    [Fact]
    public void CountSubstringOccurrences_NoMatch_ReturnsZero()
    {
        Assert.Equal(0, _search.CountSubstringOccurrences("hello", "xyz"));
    }

    // ── StartsWithAny ─────────────────────────────────────────────────────────

    [Fact]
    public void StartsWithAny_OneMatchingPrefix_ReturnsTrue()
    {
        string[] prefixes = { "http://", "https://", "ftp://" };
        Assert.True(_search.StartsWithAny("https://example.com", prefixes));
    }
}
