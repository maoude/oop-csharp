/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     4 — Classes in C# (Part 2)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W4.P3.Ex1 — Weight.
 *           Tests verify implicit/explicit conversions, Pounds property,
 *           ToString format, Array.Sort ordering, and < / > operators.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week4.Part3_ConversionAndComparison.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="Weight"/> (W4.P3.Ex1).</summary>
public class StudentWeek4Part3_Ex1Tests
{
    // ── Implicit conversion double → Weight ───────────────────────────────────

    [Fact]
    public void Implicit_conversion_from_double_sets_kilograms()
    {
        Weight w = 70.5;   // implicit — no cast needed
        Assert.Equal(70.5, w.Kilograms, precision: 10);
    }

    [Fact]
    public void Implicit_conversion_zero_is_valid()
    {
        Weight w = 0.0;
        Assert.Equal(0.0, w.Kilograms, precision: 10);
    }

    // ── Explicit conversion Weight → double ───────────────────────────────────

    [Fact]
    public void Explicit_conversion_to_double_returns_kilograms()
    {
        Weight w = new Weight(55.0);
        double kg = (double)w;
        Assert.Equal(55.0, kg, precision: 10);
    }

    // ── Pounds property ───────────────────────────────────────────────────────

    [Theory]
    [InlineData(1.0,   2.20462)]
    [InlineData(0.0,   0.0)]
    [InlineData(10.0, 22.0462)]
    public void Pounds_converts_correctly(double kg, double expectedLbs)
    {
        Weight w = new Weight(kg);
        Assert.Equal(expectedLbs, w.Pounds, precision: 4);
    }

    // ── ToString ──────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(70.5,  "70.50 kg")]
    [InlineData(0.0,   "0.00 kg")]
    [InlineData(100.0, "100.00 kg")]
    public void ToString_returns_correct_format(double kg, string expected)
    {
        Assert.Equal(expected, new Weight(kg).ToString());
    }

    // ── IComparable / Array.Sort ──────────────────────────────────────────────

    [Fact]
    public void ArraySort_sorts_weights_ascending()
    {
        Weight[] weights = { new Weight(80), new Weight(50), new Weight(65) };
        Array.Sort(weights);
        Assert.Equal(50.0, weights[0].Kilograms, precision: 10);
        Assert.Equal(65.0, weights[1].Kilograms, precision: 10);
        Assert.Equal(80.0, weights[2].Kilograms, precision: 10);
    }

    [Fact]
    public void CompareTo_lighter_returns_negative()
    {
        Weight light = new Weight(50);
        Weight heavy = new Weight(80);
        Assert.True(light.CompareTo(heavy) < 0);
    }

    [Fact]
    public void CompareTo_same_weight_returns_zero()
    {
        Weight a = new Weight(60);
        Weight b = new Weight(60);
        Assert.Equal(0, a.CompareTo(b));
    }

    [Fact]
    public void CompareTo_null_returns_positive()
    {
        Assert.True(new Weight(1).CompareTo(null) > 0);
    }

    // ── < and > operators ─────────────────────────────────────────────────────

    [Fact]
    public void Less_than_operator_returns_true_for_lighter()
    {
        Assert.True(new Weight(50) < new Weight(80));
    }

    [Fact]
    public void Greater_than_operator_returns_true_for_heavier()
    {
        Assert.True(new Weight(80) > new Weight(50));
    }

    [Fact]
    public void Less_than_equal_weights_returns_false()
    {
        Assert.False(new Weight(60) < new Weight(60));
    }

    // ── Constructor validation ────────────────────────────────────────────────

    [Fact]
    public void Negative_weight_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Weight(-1));
    }
}
