/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W1.P2.Ex1 — MathHelpers.
 *           Tests cover typical values, edge cases (zero, negatives),
 *           and floating-point precision.  Do NOT modify this file.
 */
namespace OopCsharp.Week1.Part2_Methods.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="MathHelpers"/> (W1.P2.Ex1).</summary>
public class StudentWeek1Part2_Ex1Tests
{
    // ── Hypotenuse ───────────────────────────────────────────────────

    // precision: 10 means the result must match to 10 decimal places.
    // This is stricter than visual inspection but lenient enough for
    // floating-point rounding differences across platforms.
    [Theory]
    [InlineData(3.0,  4.0,  5.0)]                 // classic 3-4-5 Pythagorean triple
    [InlineData(5.0,  12.0, 13.0)]                // 5-12-13 triple
    [InlineData(1.0,  1.0,  1.4142135623730951)]  // √2 — irrational result
    public void Hypotenuse_returns_correct_value(double a, double b, double expected)
    {
        Assert.Equal(expected, MathHelpers.Hypotenuse(a, b), precision: 10);
    }

    [Fact]
    public void Hypotenuse_of_zero_legs_is_zero()
    {
        // √(0² + 0²) = √0 = 0 — verifies no division or special case is broken.
        Assert.Equal(0.0, MathHelpers.Hypotenuse(0, 0), precision: 10);
    }

    // ── CircleArea ───────────────────────────────────────────────────

    // [InlineData] cannot use Math.PI (it is not a compile-time constant),
    // so we use [MemberData] pointing to a static property that returns
    // a TheoryData<double, double> built at runtime.
    public static TheoryData<double, double> CircleAreaCases => new()
    {
        { 1.0, Math.PI },           // radius 1 → exactly π
        { 2.0, 4.0 * Math.PI },     // radius 2 → 4π  (area scales with r²)
        { 0.0, 0.0 },               // radius 0 → zero area (no crash)
    };

    [Theory]
    [MemberData(nameof(CircleAreaCases))]
    public void CircleArea_returns_correct_value(double radius, double expected)
    {
        Assert.Equal(expected, MathHelpers.CircleArea(radius), precision: 10);
    }

    // ── Clamp ────────────────────────────────────────────────────────

    [Theory]
    [InlineData(5,  1, 10,  5)]    // inside range          → unchanged
    [InlineData(0,  1, 10,  1)]    // below min             → floored to min
    [InlineData(15, 1, 10, 10)]    // above max             → capped at max
    [InlineData(1,  1, 10,  1)]    // exactly at min        → min (inclusive)
    [InlineData(10, 1, 10, 10)]    // exactly at max        → max (inclusive)
    public void Clamp_returns_correct_value(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, MathHelpers.Clamp(value, min, max));
    }

    // ── AbsDiff ──────────────────────────────────────────────────────

    [Theory]
    [InlineData(10,  3,  7)]    // a > b:  |10-3|  = 7
    [InlineData(3,  10,  7)]    // b > a:  |3-10|  = 7  (symmetry check)
    [InlineData(0,   0,  0)]    // equal:  |0-0|   = 0
    [InlineData(-5,  5, 10)]    // negatives: |-5-5| = 10
    public void AbsDiff_returns_absolute_difference(int a, int b, int expected)
    {
        Assert.Equal(expected, MathHelpers.AbsDiff(a, b));
    }
}
