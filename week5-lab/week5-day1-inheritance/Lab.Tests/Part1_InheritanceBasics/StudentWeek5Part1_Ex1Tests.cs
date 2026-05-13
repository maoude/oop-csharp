/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for Animal hierarchy exercises (14 tests covering inheritance, virtual methods, polymorphism).
 */

using OopCsharp.Week5.Part1_InheritanceBasics.Exercises;
using Xunit;

namespace OopCsharp.Week5.Tests.Part1_InheritanceBasics;

// 14 tests
public class StudentWeek5Part1_Ex1Tests
{
    // ── Animal (base class) ──────────────────────────────────────────────

    [Fact]
    public void Animal_Properties_AreSetByConstructor()
    {
        var a = new Animal("Leo", 3);
        Assert.Equal("Leo", a.Name);
        Assert.Equal(3, a.Age);
    }

    [Fact]
    public void Animal_ToString_ReturnsExpectedFormat()
    {
        var a = new Animal("Leo", 3);
        Assert.Equal("Animal: Leo, age 3", a.ToString());
    }

    [Fact]
    public void Animal_Speak_ReturnsDots()
    {
        var a = new Animal("Leo", 3);
        Assert.Equal("...", a.Speak());
    }

    [Theory]
    [InlineData(3,  true)]
    [InlineData(5,  true)]
    [InlineData(2,  false)]
    [InlineData(0,  false)]
    public void Animal_IsAdult_ThresholdIsThree(int age, bool expected)
    {
        var a = new Animal("Test", age);
        Assert.Equal(expected, a.IsAdult());
    }

    // ── Dog ─────────────────────────────────────────────────────────────

    [Fact]
    public void Dog_Properties_AreSetByConstructor()
    {
        var d = new Dog("Rex", 5, "Labrador");
        Assert.Equal("Rex",      d.Name);
        Assert.Equal(5,          d.Age);
        Assert.Equal("Labrador", d.Breed);
    }

    [Fact]
    public void Dog_Speak_ReturnsWoof()
    {
        var d = new Dog("Rex", 5, "Labrador");
        Assert.Equal("Woof!", d.Speak());
    }

    [Fact]
    public void Dog_ToString_ReturnsExpectedFormat()
    {
        var d = new Dog("Rex", 5, "Labrador");
        Assert.Equal("Dog: Rex (Labrador), age 5", d.ToString());
    }

    [Fact]
    public void Dog_IsAdult_InheritedFromAnimal()
    {
        var adult = new Dog("Rex",  5, "Labrador");
        var young = new Dog("Pup",  1, "Poodle");
        Assert.True(adult.IsAdult());
        Assert.False(young.IsAdult());
    }

    [Fact]
    public void Dog_IsAnimal_Upcast()
    {
        Animal a = new Dog("Rex", 5, "Labrador");
        Assert.IsAssignableFrom<Animal>(a);
        Assert.Equal("Woof!", a.Speak());  // polymorphism
    }

    // ── Cat ─────────────────────────────────────────────────────────────

    [Fact]
    public void Cat_Properties_AreSetByConstructor()
    {
        var c = new Cat("Whiskers", 2, true);
        Assert.Equal("Whiskers", c.Name);
        Assert.Equal(2,          c.Age);
        Assert.True(c.IsIndoor);
    }

    [Fact]
    public void Cat_Speak_ReturnsMeow()
    {
        var c = new Cat("Whiskers", 2, true);
        Assert.Equal("Meow!", c.Speak());
    }

    [Theory]
    [InlineData(true,  "Indoor cat")]
    [InlineData(false, "Outdoor cat")]
    public void Cat_Lifestyle_ReturnsCorrectString(bool indoor, string expected)
    {
        var c = new Cat("Kitty", 3, indoor);
        Assert.Equal(expected, c.Lifestyle());
    }

    [Fact]
    public void Cat_IsAnimal_Upcast_Polymorphism()
    {
        Animal a = new Cat("Kitty", 4, false);
        Assert.Equal("Meow!", a.Speak());
    }

    [Fact]
    public void Animal_PatternMatch_DowncastToDog()
    {
        Animal a = new Dog("Buddy", 3, "Poodle");
        Assert.True(a is Dog);
        if (a is Dog d)
            Assert.Equal("Poodle", d.Breed);
    }
}
