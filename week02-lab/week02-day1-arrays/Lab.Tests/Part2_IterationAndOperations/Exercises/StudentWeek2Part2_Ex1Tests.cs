/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     2 — Arrays
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W2.P2.Ex1 — ArrayOperations.
 *           Tests verify the accumulator pattern, correct double average,
 *           min/max seeded from element [0], and bar-chart string format.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week2.Part2_IterationAndOperations.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="ArrayOperations"/> (W2.P2.Ex1).</summary>
public class StudentWeek2Part2_Ex1Tests
{
    // ── Sum ───────────────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 15)]
    [InlineData(new[] { -3, 3 },          0)]
    [InlineData(new[] { 7 },              7)]
    [InlineData(new int[0],               0)]
    public void Sum_returns_correct_total(int[] numbers, int expected)
    {
        Assert.Equal(expected, ArrayOperations.Sum(numbers));
    }

    [Fact]
    public void Sum_null_returns_zero()
    {
        Assert.Equal(0, ArrayOperations.Sum(null!));
    }

    // ── Average ───────────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] { 1, 2, 3 },    2.0)]   // exact integer average
    [InlineData(new[] { 1, 2 },       1.5)]   // fractional — tests double division
    [InlineData(new[] { -3, 3, 0 },   0.0)]   // mixed signs
    public void Average_returns_correct_double(int[] numbers, double expected)
    {
        Assert.Equal(expected, ArrayOperations.Average(numbers), precision: 10);
    }

    [Fact]
    public void Average_empty_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ArrayOperations.Average(Array.Empty<int>()));
    }

    [Fact]
    public void Average_null_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ArrayOperations.Average(null!));
    }

    // ── Min ───────────────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] {  3,  1,  7,  2 },  1)]
    [InlineData(new[] { -5, -1, -8, -3 }, -8)]   // all negative
    [InlineData(new[] { 42 },             42)]    // single element
    public void Min_returns_smallest_element(int[] numbers, int expected)
    {
        Assert.Equal(expected, ArrayOperations.Min(numbers));
    }

    [Fact]
    public void Min_null_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ArrayOperations.Min(null!));
    }

    // ── Max ───────────────────────────────────────────────────────────

    [Theory]
    [InlineData(new[] {  3,  1,  7,  2 },  7)]
    [InlineData(new[] { -5, -1, -8, -3 }, -1)]   // all negative: -1 is the largest
    [InlineData(new[] { 42 },             42)]
    public void Max_returns_largest_element(int[] numbers, int expected)
    {
        Assert.Equal(expected, ArrayOperations.Max(numbers));
    }

    [Fact]
    public void Max_null_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => ArrayOperations.Max(null!));
    }

    // ── BuildBarChart ─────────────────────────────────────────────────

    [Fact]
    public void BuildBarChart_returns_correct_rows()
    {
        // Each value becomes a row of '*' characters, joined by newline.
        string result = ArrayOperations.BuildBarChart(new[] { 3, 1, 4 });
        Assert.Equal("***\n*\n****", result);
    }

    [Fact]
    public void BuildBarChart_single_row()
    {
        Assert.Equal("**", ArrayOperations.BuildBarChart(new[] { 2 }));
    }

    [Fact]
    public void BuildBarChart_zero_value_produces_empty_row()
    {
        // A value of 0 → empty string row (new string('*', 0) == "")
        Assert.Equal("\n**", ArrayOperations.BuildBarChart(new[] { 0, 2 }));
    }

    [Fact]
    public void BuildBarChart_null_returns_empty_string()
    {
        Assert.Equal("", ArrayOperations.BuildBarChart(null!));
    }
}
