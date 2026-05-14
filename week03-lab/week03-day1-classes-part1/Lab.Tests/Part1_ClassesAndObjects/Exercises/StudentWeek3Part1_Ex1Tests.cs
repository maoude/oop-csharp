/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     3 — Classes in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W3.P1.Ex1 — Rectangle.
 *           Tests verify that fields, instance methods, and mutation work
 *           correctly, and that two separate objects do not share state.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week3.Part1_ClassesAndObjects.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="Rectangle"/> (W3.P1.Ex1).</summary>
public class StudentWeek3Part1_Ex1Tests
{
    // ── Field assignment and Area ─────────────────────────────────────────────

    [Fact]
    public void Area_returns_width_times_height()
    {
        var r = new Rectangle { Width = 4.0, Height = 5.0 };
        Assert.Equal(20.0, r.Area(), precision: 10);
    }

    [Fact]
    public void Area_with_non_integer_dimensions()
    {
        var r = new Rectangle { Width = 2.5, Height = 4.0 };
        Assert.Equal(10.0, r.Area(), precision: 10);
    }

    [Fact]
    public void Area_zero_dimension_returns_zero()
    {
        var r = new Rectangle { Width = 0, Height = 5 };
        Assert.Equal(0.0, r.Area(), precision: 10);
    }

    // ── Perimeter ────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(4.0, 5.0, 18.0)]
    [InlineData(3.0, 3.0, 12.0)]
    [InlineData(1.0, 0.0,  2.0)]
    public void Perimeter_returns_correct_value(double w, double h, double expected)
    {
        var r = new Rectangle { Width = w, Height = h };
        Assert.Equal(expected, r.Perimeter(), precision: 10);
    }

    // ── IsSquare ──────────────────────────────────────────────────────────────

    [Fact]
    public void IsSquare_returns_true_when_equal_sides()
    {
        var r = new Rectangle { Width = 5, Height = 5 };
        Assert.True(r.IsSquare());
    }

    [Fact]
    public void IsSquare_returns_false_when_unequal_sides()
    {
        var r = new Rectangle { Width = 4, Height = 5 };
        Assert.False(r.IsSquare());
    }

    // ── Scale ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Scale_multiplies_both_dimensions()
    {
        var r = new Rectangle { Width = 3.0, Height = 4.0 };
        r.Scale(2.0);
        Assert.Equal(6.0, r.Width,  precision: 10);
        Assert.Equal(8.0, r.Height, precision: 10);
    }

    [Fact]
    public void Scale_by_one_leaves_dimensions_unchanged()
    {
        var r = new Rectangle { Width = 7.0, Height = 2.0 };
        r.Scale(1.0);
        Assert.Equal(7.0, r.Width,  precision: 10);
        Assert.Equal(2.0, r.Height, precision: 10);
    }

    // ── Describe ──────────────────────────────────────────────────────────────

    [Fact]
    public void Describe_returns_correct_format()
    {
        var r = new Rectangle { Width = 4.0, Height = 5.0 };
        Assert.Equal("Rectangle 4.0 x 5.0, area=20.0", r.Describe());
    }

    // ── Two objects do not share state ────────────────────────────────────────

    [Fact]
    public void Two_rectangles_have_independent_fields()
    {
        var r1 = new Rectangle { Width = 2.0, Height = 3.0 };
        var r2 = new Rectangle { Width = 10.0, Height = 10.0 };

        // Changing r2 must not affect r1.
        r2.Width = 99.0;
        Assert.Equal(2.0, r1.Width, precision: 10);
    }
}
