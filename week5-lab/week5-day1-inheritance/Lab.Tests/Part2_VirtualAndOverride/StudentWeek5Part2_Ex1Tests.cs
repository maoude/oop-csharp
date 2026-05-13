/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for Shape hierarchy exercises (16 tests covering virtual methods, polymorphism, sealed override).
 */

using OopCsharp.Week5.Part2_VirtualAndOverride.Exercises;
using Xunit;

namespace OopCsharp.Week5.Tests.Part2_VirtualAndOverride;

// 16 tests
public class StudentWeek5Part2_Ex1Tests
{
    private const double Tol = 1e-9;

    // ── Shape (base) ────────────────────────────────────────────────────

    [Fact]
    public void Shape_DefaultColor_IsBlack()
    {
        var s = new Shape();
        Assert.Equal("Black", s.Color);
    }

    [Fact]
    public void Shape_AreaAndPerimeter_DefaultZero()
    {
        var s = new Shape();
        Assert.Equal(0.0, s.Area());
        Assert.Equal(0.0, s.Perimeter());
    }

    // ── Circle ───────────────────────────────────────────────────────────

    [Fact]
    public void Circle_Area_IsCorrect()
    {
        var c = new Circle(5);
        Assert.Equal(Math.PI * 25, c.Area(), precision: 10);
    }

    [Fact]
    public void Circle_Perimeter_IsCorrect()
    {
        var c = new Circle(5);
        Assert.Equal(2 * Math.PI * 5, c.Perimeter(), precision: 10);
    }

    [Fact]
    public void Circle_ToString_ReturnsExpectedFormat()
    {
        var c = new Circle(5) { Color = "Red" };
        // "Circle: color=Red, area=78.54, perimeter=31.42"
        Assert.StartsWith("Circle:", c.ToString());
        Assert.Contains("color=Red", c.ToString());
        Assert.Contains("area=78.54", c.ToString());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Circle_NegativeOrZeroRadius_Throws(double r)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(r));
    }

    // ── Rectangle ────────────────────────────────────────────────────────

    [Fact]
    public void Rectangle_Area_IsCorrect()
    {
        var r = new Rectangle(4, 6);
        Assert.Equal(24.0, r.Area(), Tol);
    }

    [Fact]
    public void Rectangle_Perimeter_IsCorrect()
    {
        var r = new Rectangle(4, 6);
        Assert.Equal(20.0, r.Perimeter(), Tol);
    }

    [Theory]
    [InlineData(0, 5)]
    [InlineData(5, 0)]
    [InlineData(-1, 5)]
    public void Rectangle_InvalidDimension_Throws(double w, double h)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(w, h));
    }

    [Fact]
    public void Rectangle_ColorCanBeChanged()
    {
        var r = new Rectangle(3, 4) { Color = "Blue" };
        Assert.Contains("color=Blue", r.ToString());
    }

    // ── Square ───────────────────────────────────────────────────────────

    [Fact]
    public void Square_IsRectangle()
    {
        var sq = new Square(5);
        Assert.IsAssignableFrom<Rectangle>(sq);
    }

    [Fact]
    public void Square_Area_IsCorrect()
    {
        var sq = new Square(5);
        Assert.Equal(25.0, sq.Area(), Tol);
    }

    [Fact]
    public void Square_Perimeter_IsCorrect()
    {
        var sq = new Square(5);
        Assert.Equal(20.0, sq.Perimeter(), Tol);
    }

    [Fact]
    public void Square_WidthEqualsHeight()
    {
        var sq = new Square(7);
        Assert.Equal(sq.Width, sq.Height);
    }

    // ── Polymorphism ─────────────────────────────────────────────────────

    [Fact]
    public void Polymorphism_TotalArea_UsesCorrectOverrides()
    {
        var shapes = new List<Shape>
        {
            new Circle(1),
            new Rectangle(2, 3),
            new Square(4),
        };
        double expected = Math.PI * 1 + 6.0 + 16.0;
        double actual   = shapes.Sum(s => s.Area());
        Assert.Equal(expected, actual, precision: 10);
    }
}
