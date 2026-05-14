/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     2 — Arrays
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W2.P2.Ex2 — ForVsForeach.
 *           Tests verify in-place mutation (MultiplyInPlace, ReplaceNegatives),
 *           read-only detection (ContainsNegative, AllPositive), and
 *           index-aware traversal (SumEvenIndexed).
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week2.Part2_IterationAndOperations.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="ForVsForeach"/> (W2.P2.Ex2).</summary>
public class StudentWeek2Part2_Ex2Tests
{
    // ── MultiplyInPlace ───────────────────────────────────────────────

    [Fact]
    public void MultiplyInPlace_doubles_all_elements()
    {
        int[] nums = { 1, 2, 3, 4 };
        ForVsForeach.MultiplyInPlace(nums, 2);
        Assert.Equal(new[] { 2, 4, 6, 8 }, nums);
    }

    [Fact]
    public void MultiplyInPlace_by_zero_zeroes_array()
    {
        int[] nums = { 5, 10, 15 };
        ForVsForeach.MultiplyInPlace(nums, 0);
        Assert.Equal(new[] { 0, 0, 0 }, nums);
    }

    [Fact]
    public void MultiplyInPlace_null_does_not_throw()
    {
        // Must silently ignore null rather than throw NullReferenceException.
        var ex = Record.Exception(() => ForVsForeach.MultiplyInPlace(null!, 3));
        Assert.Null(ex);
    }

    // ── ContainsNegative ──────────────────────────────────────────────

    [Theory]
    [InlineData(new[] {  1,  2, -3 }, true)]    // has a negative
    [InlineData(new[] {  0,  1,  2 }, false)]   // no negative (0 is not < 0)
    [InlineData(new[] { -1, -2, -3 }, true)]    // all negative
    [InlineData(new int[0],           false)]   // empty → false
    public void ContainsNegative_returns_correct_result(int[] nums, bool expected)
    {
        Assert.Equal(expected, ForVsForeach.ContainsNegative(nums));
    }

    [Fact]
    public void ContainsNegative_null_returns_false()
    {
        Assert.False(ForVsForeach.ContainsNegative(null!));
    }

    // ── ReplaceNegativesWithZero ──────────────────────────────────────

    [Fact]
    public void ReplaceNegativesWithZero_replaces_negatives()
    {
        int[] nums = { -3, 1, -5, 0, 4 };
        ForVsForeach.ReplaceNegativesWithZero(nums);
        Assert.Equal(new[] { 0, 1, 0, 0, 4 }, nums);
    }

    [Fact]
    public void ReplaceNegativesWithZero_no_negatives_unchanged()
    {
        int[] nums = { 1, 2, 3 };
        ForVsForeach.ReplaceNegativesWithZero(nums);
        Assert.Equal(new[] { 1, 2, 3 }, nums);
    }

    [Fact]
    public void ReplaceNegativesWithZero_null_does_not_throw()
    {
        var ex = Record.Exception(() => ForVsForeach.ReplaceNegativesWithZero(null!));
        Assert.Null(ex);
    }

    // ── SumEvenIndexed ────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 9)]    // indices 0,2,4 → 1+3+5
    [InlineData(new[] { 10, 20 },        10)]   // index 0 only
    [InlineData(new[] { 5 },              5)]    // single element at index 0
    [InlineData(new int[0],               0)]   // empty → 0
    public void SumEvenIndexed_returns_correct_sum(int[] nums, int expected)
    {
        Assert.Equal(expected, ForVsForeach.SumEvenIndexed(nums));
    }

    [Fact]
    public void SumEvenIndexed_null_returns_zero()
    {
        Assert.Equal(0, ForVsForeach.SumEvenIndexed(null!));
    }

    // ── AllPositive ───────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 1, 2, 3 },   true)]    // all > 0
    [InlineData(new[] { 1, 0, 3 },   false)]   // 0 is not > 0
    [InlineData(new[] { 1, -1, 3 },  false)]   // negative
    [InlineData(new int[0],          true)]    // empty → vacuously true
    public void AllPositive_returns_correct_result(int[] nums, bool expected)
    {
        Assert.Equal(expected, ForVsForeach.AllPositive(nums));
    }

    [Fact]
    public void AllPositive_null_returns_true()
    {
        // Null treated as empty → vacuously true.
        Assert.True(ForVsForeach.AllPositive(null!));
    }
}
