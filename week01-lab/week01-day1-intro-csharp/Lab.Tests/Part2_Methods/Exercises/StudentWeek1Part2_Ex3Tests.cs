/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W1.P2.Ex3 — Overloading.
 *           Tests confirm that each overload produces the correct result and
 *           that edge cases (zero/negative repetitions, equal values) are
 *           handled correctly.  Do NOT modify this file.
 */
namespace OopCsharp.Week1.Part2_Methods.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="Overloading"/> (W1.P2.Ex3).</summary>
public class StudentWeek1Part2_Ex3Tests
{
    // ── Repeat(string, int) ──────────────────────────────────────────

    [Theory]
    [InlineData("ab",  3, "ababab")]  // normal case: 3 repetitions
    [InlineData("x",   5, "xxxxx")]   // single character string
    [InlineData("hi",  1, "hi")]      // 1 repetition → original string
    [InlineData("hi",  0, "")]        // 0 repetitions → empty string
    [InlineData("hi", -1, "")]        // negative → empty string (guard clause)
    public void Repeat_string_returns_correct_result(string text, int times, string expected)
    {
        Assert.Equal(expected, Overloading.Repeat(text, times));
    }

    // ── Repeat(char, int) ────────────────────────────────────────────

    // The compiler picks this overload because the first argument is a char literal.
    [Theory]
    [InlineData('*', 4, "****")]   // normal case
    [InlineData('-', 3, "---")]    // different character
    [InlineData('A', 1, "A")]      // 1 repetition
    [InlineData('Z', 0, "")]       // 0 repetitions → empty string
    public void Repeat_char_returns_correct_result(char ch, int times, string expected)
    {
        Assert.Equal(expected, Overloading.Repeat(ch, times));
    }

    // ── Max(int, int) ────────────────────────────────────────────────

    [Theory]
    [InlineData(3,   7,  7)]    // b > a
    [InlineData(7,   3,  7)]    // a > b  (symmetry check)
    [InlineData(5,   5,  5)]    // equal  (must return one of them, not crash)
    [InlineData(-2,  1,  1)]    // mixed signs
    [InlineData(-5, -1, -1)]    // both negative: -1 is the larger (closer to 0)
    public void Max_int_two_args_returns_larger(int a, int b, int expected)
    {
        Assert.Equal(expected, Overloading.Max(a, b));
    }

    // ── Max(double, double) ──────────────────────────────────────────

    [Theory]
    [InlineData(1.5,  2.5,  2.5)]
    [InlineData(9.9,  0.1,  9.9)]
    [InlineData(-3.3, -1.1, -1.1)]   // both negative doubles
    public void Max_double_two_args_returns_larger(double a, double b, double expected)
    {
        // precision: 10 — floating-point equality to 10 decimal places.
        Assert.Equal(expected, Overloading.Max(a, b), precision: 10);
    }

    // ── Max(int, int, int) ───────────────────────────────────────────

    [Theory]
    [InlineData(1,  2,  3,  3)]    // ascending:  last is largest
    [InlineData(3,  2,  1,  3)]    // descending: first is largest
    [InlineData(2,  3,  1,  3)]    // middle is largest
    [InlineData(-1, -2, -3, -1)]   // all negative
    [InlineData(5,  5,  5,  5)]    // all equal
    public void Max_int_three_args_returns_largest(int a, int b, int c, int expected)
    {
        Assert.Equal(expected, Overloading.Max(a, b, c));
    }
}
