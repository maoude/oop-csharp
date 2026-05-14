/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W1.P1.Ex1 — Greeting.
 *           Each [Fact] or [Theory] specifies one behaviour the student's
 *           implementation must satisfy.  Do NOT modify this file.
 */

// ─────────────────────────────────────────────────────────────────────────────
// HOW XUNIT WORKS (read once, understand forever)
//
// [Fact]   — a single test case with no parameters.
// [Theory] — a parameterised test; xUnit runs it once per [InlineData] row.
// [InlineData(arg1, arg2, …)] — one row of test arguments.
//
// Assert.Equal(expected, actual)
//   Passes if expected == actual (using .Equals for objects).
//   Fails with a clear message showing both values if they differ.
//
// The test class name StudentWeek1Part1_Ex1Tests is the CONTRACT:
//   dotnet test --filter "FullyQualifiedName~StudentWeek1Part1_Ex1"
//   runs every test in this class.
// ─────────────────────────────────────────────────────────────────────────────
namespace OopCsharp.Week1.Part1_HelloWorld.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="Greeting"/> (W1.P1.Ex1).</summary>
public class StudentWeek1Part1_Ex1Tests
{
    // ── Greet ────────────────────────────────────────────────────────

    // [Theory] + [InlineData] runs this test three times, once per row.
    // The parameters (name, expected) take the values from each InlineData.
    [Theory]
    [InlineData("Alice", "Hello, Alice!")]   // typical name
    [InlineData("Bob",   "Hello, Bob!")]     // different name — confirms no hard-coding
    [InlineData("",      "Hello, !")]        // empty string — punctuation must still appear
    public void Greet_returns_correct_string(string name, string expected)
    {
        // Arrange: `name` and `expected` come from [InlineData].
        // Act:     call the student's method.
        // Assert:  the return value must exactly match `expected`.
        Assert.Equal(expected, Greeting.Greet(name));
    }

    // ── GreetWithTitle ───────────────────────────────────────────────

    [Theory]
    [InlineData("Dr.",   "Aoude", "Dr. Aoude, welcome!")]    // primary use-case
    [InlineData("Prof.", "Smith", "Prof. Smith, welcome!")]   // different title and name
    [InlineData("Mr.",   "Jones", "Mr. Jones, welcome!")]     // confirms no hard-coding
    public void GreetWithTitle_returns_correct_string(string title, string name, string expected)
    {
        Assert.Equal(expected, Greeting.GreetWithTitle(title, name));
    }

    // An extra edge-case: a name that starts with a space.
    // The method must NOT trim whitespace — it should preserve the input as-is.
    [Fact]
    public void Greet_with_leading_space_in_name_preserves_space()
    {
        // " World" (space + World) → "Hello,  World!" (two spaces after comma)
        Assert.Equal("Hello,  World!", Greeting.Greet(" World"));
    }
}
