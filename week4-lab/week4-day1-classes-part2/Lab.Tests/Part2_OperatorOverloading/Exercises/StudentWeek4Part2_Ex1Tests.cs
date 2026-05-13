/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     4 — Classes in C# (Part 2)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W4.P2.Ex1 — Fraction.
 *           Tests verify arithmetic operators, reduction to lowest terms,
 *           equality, unary negation, division-by-zero, and ToString.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week4.Part2_OperatorOverloading.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="Fraction"/> (W4.P2.Ex1).</summary>
public class StudentWeek4Part2_Ex1Tests
{
    // Helper: shorthand constructor
    private static Fraction F(int n, int d) => new Fraction(n, d);

    // ── ToString ──────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(1, 2, "1/2")]
    [InlineData(3, 1, "3")]      // whole number — no slash
    [InlineData(-1, 3, "-1/3")]
    [InlineData(2, 4, "1/2")]    // reduced
    public void ToString_returns_correct_string(int n, int d, string expected)
    {
        Assert.Equal(expected, F(n, d).ToString());
    }

    // ── Reduction ─────────────────────────────────────────────────────────────

    [Fact]
    public void Constructor_reduces_to_lowest_terms()
    {
        var f = F(6, 4);
        Assert.Equal(3, f.Numerator);
        Assert.Equal(2, f.Denominator);
    }

    [Fact]
    public void Constructor_keeps_sign_in_numerator()
    {
        var f = F(1, -2);
        Assert.Equal(-1, f.Numerator);
        Assert.Equal(2,  f.Denominator);
    }

    // ── Addition ──────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(1, 2,  1, 3,  5, 6)]   // 1/2 + 1/3 = 5/6
    [InlineData(1, 4,  3, 4,  1, 1)]   // 1/4 + 3/4 = 1
    [InlineData(1, 3,  1, 3,  2, 3)]   // same denominator
    public void Addition_returns_correct_result(int n1,int d1, int n2,int d2, int rn,int rd)
    {
        Assert.Equal(F(rn, rd), F(n1, d1) + F(n2, d2));
    }

    // ── Subtraction ───────────────────────────────────────────────────────────

    [Fact]
    public void Subtraction_returns_correct_result()
    {
        Assert.Equal(F(1, 6), F(1, 2) - F(1, 3));   // 1/2 - 1/3 = 1/6
    }

    [Fact]
    public void Subtraction_same_fraction_gives_zero()
    {
        Assert.Equal(F(0, 1), F(3, 4) - F(3, 4));
    }

    // ── Multiplication ────────────────────────────────────────────────────────

    [Theory]
    [InlineData(2, 3,  3, 4,  1, 2)]   // 2/3 * 3/4 = 6/12 = 1/2
    [InlineData(1, 2,  2, 1,  1, 1)]   // 1/2 * 2 = 1
    public void Multiplication_returns_correct_result(int n1,int d1,int n2,int d2,int rn,int rd)
    {
        Assert.Equal(F(rn, rd), F(n1, d1) * F(n2, d2));
    }

    // ── Division ──────────────────────────────────────────────────────────────

    [Fact]
    public void Division_returns_correct_result()
    {
        Assert.Equal(F(2, 3), F(1, 2) / F(3, 4));   // (1/2) / (3/4) = 2/3
    }

    [Fact]
    public void Division_by_zero_fraction_throws_DivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => F(1, 2) / F(0, 1));
    }

    // ── Unary negation ────────────────────────────────────────────────────────

    [Fact]
    public void Unary_minus_negates_numerator()
    {
        Assert.Equal(F(-1, 2), -F(1, 2));
    }

    [Fact]
    public void Unary_minus_of_negative_gives_positive()
    {
        Assert.Equal(F(1, 3), -F(-1, 3));
    }

    // ── Equality ──────────────────────────────────────────────────────────────

    [Fact]
    public void Equal_fractions_return_true()
    {
        Assert.True(F(1, 2) == F(2, 4));   // both reduce to 1/2
    }

    [Fact]
    public void Unequal_fractions_return_true_for_not_equal()
    {
        Assert.True(F(1, 2) != F(1, 3));
    }

    // ── Constructor guards ────────────────────────────────────────────────────

    [Fact]
    public void Zero_denominator_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => F(1, 0));
    }
}
