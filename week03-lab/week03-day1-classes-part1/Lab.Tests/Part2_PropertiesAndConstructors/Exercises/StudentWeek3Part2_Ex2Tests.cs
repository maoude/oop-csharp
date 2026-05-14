/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     3 — Classes in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W3.P2.Ex2 — Person.
 *           Tests verify auto-properties, computed FullName, constructor
 *           chaining, birthday increment, IsAdult threshold, and Greet.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week3.Part2_PropertiesAndConstructors.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="Person"/> (W3.P2.Ex2).</summary>
public class StudentWeek3Part2_Ex2Tests
{
    // ── Three-argument constructor ────────────────────────────────────────────

    [Fact]
    public void Constructor_sets_all_properties()
    {
        var p = new Person("Alice", "Jones", 25);
        Assert.Equal("Alice", p.FirstName);
        Assert.Equal("Jones", p.LastName);
        Assert.Equal(25,      p.Age);
    }

    [Fact]
    public void Constructor_negative_age_throws_ArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Person("Alice", "Jones", -1));
    }

    // ── Two-argument constructor (chaining) ───────────────────────────────────

    [Fact]
    public void Constructor_two_args_sets_age_to_zero()
    {
        var p = new Person("Bob", "Smith");
        Assert.Equal(0, p.Age);
        Assert.Equal("Bob",   p.FirstName);
        Assert.Equal("Smith", p.LastName);
    }

    // ── FullName computed property ────────────────────────────────────────────

    [Fact]
    public void FullName_concatenates_first_and_last()
    {
        var p = new Person("Carol", "White", 30);
        Assert.Equal("Carol White", p.FullName);
    }

    [Fact]
    public void FullName_updates_when_FirstName_changes()
    {
        var p = new Person("Dan", "Brown", 20);
        p.FirstName = "Daniel";
        Assert.Equal("Daniel Brown", p.FullName);
    }

    // ── HaveBirthday ─────────────────────────────────────────────────────────

    [Fact]
    public void HaveBirthday_increments_age()
    {
        var p = new Person("Eve", "Black", 17);
        p.HaveBirthday();
        Assert.Equal(18, p.Age);
    }

    [Fact]
    public void HaveBirthday_twice_increments_twice()
    {
        var p = new Person("Frank", "Grey", 10);
        p.HaveBirthday();
        p.HaveBirthday();
        Assert.Equal(12, p.Age);
    }

    // ── IsAdult ───────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(17, false)]
    [InlineData(18, true)]
    [InlineData(30, true)]
    [InlineData(0,  false)]
    public void IsAdult_returns_correct_result(int age, bool expected)
    {
        var p = new Person("X", "Y", age);
        Assert.Equal(expected, p.IsAdult);
    }

    // ── Greet ────────────────────────────────────────────────────────────────

    [Fact]
    public void Greet_returns_correct_string()
    {
        var alice = new Person("Alice", "Jones", 25);
        var bob   = new Person("Bob",   "Smith", 30);
        Assert.Equal("Hi Bob Smith, I'm Alice Jones!", alice.Greet(bob));
    }

    [Fact]
    public void Greet_uses_full_names()
    {
        var p1 = new Person("Maria", "Doe",  20);
        var p2 = new Person("John",  "Wick", 35);
        Assert.Equal("Hi John Wick, I'm Maria Doe!", p1.Greet(p2));
    }
}
