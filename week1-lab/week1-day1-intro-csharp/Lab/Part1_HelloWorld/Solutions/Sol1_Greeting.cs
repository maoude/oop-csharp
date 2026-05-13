/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  [INSTRUCTOR ONLY] Reference solution for W1.P1.Ex1 — Greeting.
 *           Shows the minimal, idiomatic implementation using expression bodies
 *           and string interpolation.  Share only after students have submitted.
 */
namespace OopCsharp.Week1.Part1_HelloWorld.Solutions;

/// <summary>[INSTRUCTOR ONLY] Solution for W1.P1.Ex1 — Greeting.</summary>
public static class Greeting
{
    // Expression-body syntax (=> …) is the most concise form for a method
    // whose entire body is a single return statement.
    // Equivalent to: public static string Greet(string name) { return $"Hello, {name}!"; }

    /// <summary>Returns "Hello, &lt;name&gt;!"</summary>
    public static string Greet(string name) => $"Hello, {name}!";

    // Two parameters are embedded in a single interpolated string.
    // The space between title and name is part of the string literal — not a bug.

    /// <summary>Returns "&lt;title&gt; &lt;name&gt;, welcome!"</summary>
    public static string GreetWithTitle(string title, string name) =>
        $"{title} {name}, welcome!";
}
