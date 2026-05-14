/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W1.P2.Ex2 — Parameters.
 *           Tests verify that ref parameters mutate the caller's variable,
 *           that out parameters are assigned on all code paths, that bad
 *           input is rejected, and that numeric formatting is exact.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week1.Part2_Methods.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="Parameters"/> (W1.P2.Ex2).</summary>
public class StudentWeek1Part2_Ex2Tests
{
    // ── Increment ────────────────────────────────────────────────────

    [Fact]
    public void Increment_adds_one_to_positive_variable()
    {
        int x = 5;
        Parameters.Increment(ref x);
        Assert.Equal(6, x);   // ref: the change must be visible in the caller
    }

    [Fact]
    public void Increment_adds_one_to_zero()
    {
        int x = 0;
        Parameters.Increment(ref x);
        Assert.Equal(1, x);
    }

    [Fact]
    public void Increment_adds_one_to_negative_crossing_zero()
    {
        // -1 + 1 = 0 — tests the boundary where sign changes.
        int x = -1;
        Parameters.Increment(ref x);
        Assert.Equal(0, x);
    }

    // ── Swap ─────────────────────────────────────────────────────────

    [Fact]
    public void Swap_exchanges_two_different_values()
    {
        int a = 3, b = 9;
        Parameters.Swap(ref a, ref b);
        // Both values must have moved to the other variable.
        Assert.Equal(9, a);
        Assert.Equal(3, b);
    }

    [Fact]
    public void Swap_of_equal_values_leaves_them_equal()
    {
        // Swapping identical values should be a no-op (not crash).
        int a = 7, b = 7;
        Parameters.Swap(ref a, ref b);
        Assert.Equal(7, a);
        Assert.Equal(7, b);
    }

    // ── MinMax ───────────────────────────────────────────────────────

    [Fact]
    public void MinMax_finds_correct_extremes_in_unsorted_array()
    {
        Parameters.MinMax(new[] { 3, 1, 7, 2, 9, 4 }, out int min, out int max);
        Assert.Equal(1, min);
        Assert.Equal(9, max);
    }

    [Fact]
    public void MinMax_single_element_returns_same_value_for_both()
    {
        // A one-element array: min and max are the same element.
        Parameters.MinMax(new[] { 42 }, out int min, out int max);
        Assert.Equal(42, min);
        Assert.Equal(42, max);
    }

    [Fact]
    public void MinMax_throws_ArgumentException_for_empty_array()
    {
        // The method must validate its precondition and throw — not silently return.
        Assert.Throws<ArgumentException>(() =>
            Parameters.MinMax(Array.Empty<int>(), out _, out _));
    }

    [Fact]
    public void MinMax_throws_ArgumentException_for_null_array()
    {
        Assert.Throws<ArgumentException>(() =>
            Parameters.MinMax(null!, out _, out _));
    }

    [Fact]
    public void MinMax_handles_all_negative_values()
    {
        Parameters.MinMax(new[] { -5, -1, -8, -3 }, out int min, out int max);
        Assert.Equal(-8, min);
        Assert.Equal(-1, max);
    }

    // ── FormatTemperature ─────────────────────────────────────────────

    [Fact]
    public void FormatTemperature_converts_zero_celsius_to_32_fahrenheit()
    {
        string result = Parameters.FormatTemperature(0.0, out double f);
        // The out parameter must hold the correct numeric value.
        Assert.Equal(32.0, f, precision: 5);
        // The returned string must use the exact format "X.X°C = Y.Y°F".
        Assert.Equal("0.0°C = 32.0°F", result);
    }

    [Fact]
    public void FormatTemperature_converts_100_celsius_to_212_fahrenheit()
    {
        string result = Parameters.FormatTemperature(100.0, out double f);
        Assert.Equal(212.0, f, precision: 5);
        Assert.Equal("100.0°C = 212.0°F", result);
    }

    [Fact]
    public void FormatTemperature_minus40_is_same_in_both_scales()
    {
        // -40°C = -40°F is the unique crossing point of both scales.
        Parameters.FormatTemperature(-40.0, out double f);
        Assert.Equal(-40.0, f, precision: 5);
    }
}
