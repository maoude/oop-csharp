/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     2 — Arrays
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W2.P1.Ex1 — ArrayBasics.
 *           Tests cover happy paths, null/empty guards, out-of-range indexing,
 *           and the C# zero-initialisation guarantee.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week2.Part1_ArrayFundamentals.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="ArrayBasics"/> (W2.P1.Ex1).</summary>
public class StudentWeek2Part1_Ex1Tests
{
    // ── CreateAndFill ─────────────────────────────────────────────────

    [Theory]
    [InlineData(3,  7, new[] { 7, 7, 7 })]
    [InlineData(5,  0, new[] { 0, 0, 0, 0, 0 })]
    [InlineData(1, -2, new[] { -2 })]
    public void CreateAndFill_returns_correct_array(int size, int fill, int[] expected)
    {
        Assert.Equal(expected, ArrayBasics.CreateAndFill(size, fill));
    }

    [Fact]
    public void CreateAndFill_size_zero_returns_empty_array()
    {
        Assert.Equal(Array.Empty<int>(), ArrayBasics.CreateAndFill(0, 99));
    }

    [Fact]
    public void CreateAndFill_negative_size_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ArrayBasics.CreateAndFill(-1, 0));
    }

    // ── GetElement ────────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 10, 20, 30 }, 0,  -1,  10)]   // first element
    [InlineData(new[] { 10, 20, 30 }, 2,  -1,  30)]   // last element
    [InlineData(new[] { 10, 20, 30 }, 1,  -1,  20)]   // middle element
    [InlineData(new[] { 10, 20, 30 }, 3,  -1,  -1)]   // index == length → default
    [InlineData(new[] { 10, 20, 30 }, -1, -1,  -1)]   // negative index → default
    public void GetElement_returns_element_or_default(int[] array, int index,
        int def, int expected)
    {
        Assert.Equal(expected, ArrayBasics.GetElement(array, index, def));
    }

    [Fact]
    public void GetElement_null_array_returns_default()
    {
        Assert.Equal(42, ArrayBasics.GetElement(null!, 0, 42));
    }

    // ── ReverseArray ──────────────────────────────────────────────────

    [Fact]
    public void ReverseArray_returns_reversed_elements()
    {
        int[] source = { 1, 2, 3, 4, 5 };
        int[] result = ArrayBasics.ReverseArray(source);
        Assert.Equal(new[] { 5, 4, 3, 2, 1 }, result);
    }

    [Fact]
    public void ReverseArray_does_not_modify_original()
    {
        int[] source = { 1, 2, 3 };
        ArrayBasics.ReverseArray(source);
        // Source must still be in original order.
        Assert.Equal(new[] { 1, 2, 3 }, source);
    }

    [Fact]
    public void ReverseArray_single_element_returns_same_value()
    {
        Assert.Equal(new[] { 7 }, ArrayBasics.ReverseArray(new[] { 7 }));
    }

    [Fact]
    public void ReverseArray_null_throws_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ArrayBasics.ReverseArray(null!));
    }

    // ── CountOccurrences ──────────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 1, 2, 3, 2, 2 }, 2, 3)]    // target appears 3 times
    [InlineData(new[] { 1, 2, 3 },       9, 0)]    // target absent
    [InlineData(new[] { 5, 5, 5, 5 },    5, 4)]    // all match
    [InlineData(new int[0],              1, 0)]    // empty array
    public void CountOccurrences_returns_correct_count(int[] array, int target, int expected)
    {
        Assert.Equal(expected, ArrayBasics.CountOccurrences(array, target));
    }

    [Fact]
    public void CountOccurrences_null_array_returns_zero()
    {
        Assert.Equal(0, ArrayBasics.CountOccurrences(null!, 5));
    }

    // ── DefaultValues ─────────────────────────────────────────────────

    [Fact]
    public void DefaultValues_all_elements_are_zero()
    {
        int[] result = ArrayBasics.DefaultValues(5);
        Assert.Equal(5, result.Length);
        Assert.All(result, v => Assert.Equal(0, v));
    }

    [Fact]
    public void DefaultValues_size_zero_returns_empty()
    {
        Assert.Equal(Array.Empty<int>(), ArrayBasics.DefaultValues(0));
    }
}
