/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     2 — Arrays
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W2.P3.Ex1 — ArrayMethods.
 *           Tests verify that SortedCopy does not mutate the source, that
 *           LinearSearch and BinarySearch return -1 on failure, and that
 *           FirstEven correctly distinguishes "not found" from "found 0".
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week2.Part3_ArrayMethodsAndMultiDim.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="ArrayMethods"/> (W2.P3.Ex1).</summary>
public class StudentWeek2Part3_Ex1Tests
{
    // ── SortedCopy ────────────────────────────────────────────────────

    [Fact]
    public void SortedCopy_returns_sorted_elements()
    {
        int[] result = ArrayMethods.SortedCopy(new[] { 5, 3, 8, 1, 9, 2 });
        Assert.Equal(new[] { 1, 2, 3, 5, 8, 9 }, result);
    }

    [Fact]
    public void SortedCopy_does_not_modify_source()
    {
        int[] source = { 5, 3, 1 };
        ArrayMethods.SortedCopy(source);
        Assert.Equal(new[] { 5, 3, 1 }, source);   // original untouched
    }

    [Fact]
    public void SortedCopy_already_sorted_stays_sorted()
    {
        Assert.Equal(new[] { 1, 2, 3 }, ArrayMethods.SortedCopy(new[] { 1, 2, 3 }));
    }

    [Fact]
    public void SortedCopy_null_throws_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ArrayMethods.SortedCopy(null!));
    }

    // ── LinearSearch ─────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 10, 20, 30, 40 }, 30,  2)]   // found at index 2
    [InlineData(new[] { 10, 20, 30, 40 }, 10,  0)]   // found at index 0
    [InlineData(new[] { 10, 20, 30, 40 }, 99, -1)]   // not found
    [InlineData(new int[0],               1,  -1)]   // empty array
    public void LinearSearch_returns_correct_index(int[] array, int target, int expected)
    {
        Assert.Equal(expected, ArrayMethods.LinearSearch(array, target));
    }

    // ── BinarySearchInSorted ──────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 1, 3, 5, 7, 9 }, 5,  2)]   // found in middle
    [InlineData(new[] { 1, 3, 5, 7, 9 }, 1,  0)]   // found at start
    [InlineData(new[] { 1, 3, 5, 7, 9 }, 9,  4)]   // found at end
    [InlineData(new[] { 1, 3, 5, 7, 9 }, 4, -1)]   // not found
    [InlineData(new int[0],              1, -1)]   // empty
    public void BinarySearch_returns_correct_index(int[] sorted, int target, int expected)
    {
        Assert.Equal(expected, ArrayMethods.BinarySearchInSorted(sorted, target));
    }

    // ── FirstEven ─────────────────────────────────────────────────────

    [Fact]
    public void FirstEven_returns_first_even_number()
    {
        Assert.Equal(4, ArrayMethods.FirstEven(new[] { 1, 3, 4, 6, 8 }));
    }

    [Fact]
    public void FirstEven_returns_zero_when_zero_is_the_first_even()
    {
        // 0 is even; must return 0, not null.
        Assert.Equal(0, ArrayMethods.FirstEven(new[] { 1, 3, 0, 5 }));
    }

    [Fact]
    public void FirstEven_returns_null_when_no_even_exists()
    {
        Assert.Null(ArrayMethods.FirstEven(new[] { 1, 3, 5, 7 }));
    }

    [Fact]
    public void FirstEven_null_returns_null()
    {
        Assert.Null(ArrayMethods.FirstEven(null!));
    }

    // ── CountEvens ────────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 3)]   // three evens
    [InlineData(new[] { 1, 3, 5 },           0)]   // no evens
    [InlineData(new[] { 2, 4, 6 },           3)]   // all even
    [InlineData(new[] { 0 },                 1)]   // 0 is even
    [InlineData(new int[0],                  0)]   // empty
    public void CountEvens_returns_correct_count(int[] numbers, int expected)
    {
        Assert.Equal(expected, ArrayMethods.CountEvens(numbers));
    }

    [Fact]
    public void CountEvens_null_returns_zero()
    {
        Assert.Equal(0, ArrayMethods.CountEvens(null!));
    }
}
