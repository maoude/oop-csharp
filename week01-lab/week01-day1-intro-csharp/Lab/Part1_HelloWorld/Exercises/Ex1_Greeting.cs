/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  First student exercise — writing value-returning static methods
 *           that build greeting strings using string interpolation.
 *           Key idea: a method returns a result; the caller decides what to
 *           do with it (print it, store it, pass it on).  Returning ≠ printing.
 */

// ─────────────────────────────────────────────────────────────────────────────
// EXERCISE W1.P1.Ex1 — Greeting
// ─────────────────────────────────────────────────────────────────────────────
// Goal:     Implement two static methods that build and RETURN greeting strings.
//           Do NOT call Console.WriteLine inside the methods — the tests check
//           the returned string directly.
//
// Your tasks:
//   1) Greet(string name)
//      → return "Hello, <name>!"
//      Example: Greet("Alice") → "Hello, Alice!"
//
//   2) GreetWithTitle(string title, string name)
//      → return "<title> <name>, welcome!"
//      Example: GreetWithTitle("Dr.", "Aoude") → "Dr. Aoude, welcome!"
//
// Pass when: StudentWeek1Part1_Ex1Tests is fully green.
// Hint:      String interpolation: $"Hello, {name}!"
// ─────────────────────────────────────────────────────────────────────────────
namespace OopCsharp.Week1.Part1_HelloWorld.Exercises;

/// <summary>
/// Provides static greeting methods (W1.P1.Ex1).
/// </summary>
/// <remarks>
/// <b>Design note — pure functions:</b>
/// Both methods are <i>pure functions</i>: they take inputs, compute a result,
/// and return it — with no side effects (no printing, no file writes, no state
/// changes).  Pure functions are the easiest code to test and reason about.
/// This property is why the grading tests can check the return value directly
/// without redirecting the console.
/// </remarks>
public static class Greeting
{
    /// <summary>
    /// Returns a greeting string for the given name.
    /// </summary>
    /// <param name="name">The person's name (any non-null string).</param>
    /// <returns>"Hello, &lt;name&gt;!" — e.g. "Hello, Alice!"</returns>
    public static string Greet(string name)
    {
        // ── What is string interpolation? ────────────────────────────
        // Prefix the string literal with $ to embed expressions.
        // Anything inside { } is evaluated and converted to a string.
        //
        //   string city = "Beirut";
        //   $"Welcome to {city}!"   evaluates to   "Welcome to Beirut!"
        //
        // This is more readable and less error-prone than concatenation:
        //   "Welcome to " + city + "!"
        //
        // TODO 1: replace the line below with a one-line return statement
        //         using $"Hello, {name}!"
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a formal greeting that includes an honorific title.
    /// </summary>
    /// <param name="title">Honorific, e.g. "Dr.", "Prof.", "Mr.", "Ms."</param>
    /// <param name="name">The person's family name.</param>
    /// <returns>"&lt;title&gt; &lt;name&gt;, welcome!" — e.g. "Dr. Aoude, welcome!"</returns>
    public static string GreetWithTitle(string title, string name)
    {
        // ── Multiple parameters in one interpolation ──────────────────
        // Both `title` and `name` are in scope here.
        // The space between them in the output must come from your template:
        //   $"{title} {name}, welcome!"
        //            ↑ this space is part of the string literal, not the data.
        //
        // TODO 2: implement and return the formatted string.
        throw new NotImplementedException();
    }
}
