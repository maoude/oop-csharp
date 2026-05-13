/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Practice method overloading — using the same method name for
 *           operations that are conceptually identical but work on different
 *           types or different numbers of arguments.
 *           Key lesson: the compiler distinguishes overloads by SIGNATURE
 *           (parameter types + count), never by return type.
 */

// ─────────────────────────────────────────────────────────────────────────────
// EXERCISE W1.P2.Ex3 — Overloading
// ─────────────────────────────────────────────────────────────────────────────
// Goal:     Implement five overloaded methods that share meaningful names.
//
// Your tasks:
//   1) Repeat(string text, int times)
//      → return text concatenated `times` times.
//      → return "" if times ≤ 0.
//      Example: Repeat("ab", 3) → "ababab"
//
//   2) Repeat(char ch, int times)
//      → return the character repeated `times` times.
//      → return "" if times ≤ 0.
//      Example: Repeat('*', 4) → "****"
//
//   3) Max(int a, int b)
//      → return the larger of the two integers.
//
//   4) Max(double a, double b)
//      → return the larger of the two doubles.
//
//   5) Max(int a, int b, int c)
//      → return the largest of the three integers.
//      → CALL Max(int, int) internally — do not repeat the comparison logic.
//
// Pass when: StudentWeek1Part2_Ex3Tests is fully green.
// ─────────────────────────────────────────────────────────────────────────────
namespace OopCsharp.Week1.Part2_Methods.Exercises;

/// <summary>
/// Demonstrates method overloading (W1.P2.Ex3).
/// </summary>
/// <remarks>
/// <b>Overloading rule:</b> two methods in the same class may share a name
/// if and only if their parameter lists differ in type, count, or order.
/// The return type alone does NOT make two signatures distinct.
/// </remarks>
public static class Overloading
{
    /// <summary>
    /// Returns <paramref name="text"/> repeated <paramref name="times"/> times.
    /// </summary>
    /// <param name="text">The string to repeat.</param>
    /// <param name="times">How many times to repeat it.  Returns "" if ≤ 0.</param>
    public static string Repeat(string text, int times)
    {
        // ── Guard clause ──────────────────────────────────────────────
        // Returning early for invalid input is called a "guard clause".
        // It keeps the main logic un-indented and easy to read.
        //
        // TODO 1a: if (times <= 0) return string.Empty;

        // ── Efficient string building with StringBuilder ───────────────
        // Concatenating strings in a loop with + creates a new string
        // object on every iteration (strings are immutable in C#).
        // For N repetitions that is O(N²) time and memory.
        //
        // StringBuilder builds the string in a mutable internal buffer
        // and calls ToString() just once at the end — O(N) time.
        //
        // You may also try: return string.Concat(Enumerable.Repeat(text, times));
        // but the StringBuilder approach is good to practice now.
        //
        // TODO 1b: use a StringBuilder (or a loop) to build and return the result.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns <paramref name="ch"/> repeated <paramref name="times"/> times.
    /// </summary>
    /// <param name="ch">The character to repeat.</param>
    /// <param name="times">How many times to repeat it.  Returns "" if ≤ 0.</param>
    /// <remarks>
    /// This overload accepts a <c>char</c> instead of a <c>string</c>.
    /// The compiler picks this one when the caller passes a character literal
    /// like <c>'*'</c> or a <c>char</c> variable.
    /// </remarks>
    public static string Repeat(char ch, int times)
    {
        // ── new string(char, int) constructor ─────────────────────────
        // C# has a built-in string constructor that repeats a single
        // character: new string(ch, times) — no loop needed.
        //
        // This is more expressive than a manual loop and communicates
        // intent clearly: "a string of `times` copies of `ch`".
        //
        // TODO 2: guard for times ≤ 0, then return new string(ch, times).
        throw new NotImplementedException();
    }

    /// <summary>Returns the larger of two integers.</summary>
    public static int Max(int a, int b)
    {
        // ── Conditional expression (ternary) ──────────────────────────
        // condition ? value_if_true : value_if_false
        //
        // return a >= b ? a : b;   reads as: "if a ≥ b, return a; else return b."
        //
        // This is equivalent to:
        //   if (a >= b) return a;
        //   else        return b;
        //
        // TODO 3: implement with either a ternary or an if/else.
        throw new NotImplementedException();
    }

    /// <summary>Returns the larger of two doubles.</summary>
    /// <remarks>
    /// Same logic as <see cref="Max(int,int)"/> but for <c>double</c>.
    /// The compiler selects this overload when both arguments are doubles
    /// (or when an int is automatically widened to double).
    /// </remarks>
    public static double Max(double a, double b)
    {
        // TODO 4: same logic as Max(int, int) but with double type.
        throw new NotImplementedException();
    }

    /// <summary>Returns the largest of three integers.</summary>
    /// <remarks>
    /// <b>Reuse pattern:</b> delegate to the two-argument overload to avoid
    /// duplicating the comparison logic.
    /// <c>Max(a, Max(b, c))</c> or <c>Max(Max(a, b), c)</c> — both are correct.
    /// </remarks>
    public static int Max(int a, int b, int c)
    {
        // ── Calling an overload from within another overload ───────────
        // The compiler resolves Max(a, b) to the two-int overload above.
        // Then the result is compared with c using the same two-int overload.
        //
        //   Max(1, 2, 3)
        //     → Max(Max(1, 2), 3)
        //     → Max(2, 3)
        //     → 3   ✓
        //
        // This pattern — building a three-argument version by calling the
        // two-argument version — is called REUSE THROUGH OVERLOADING.
        // You write the comparison logic once and call it twice.
        //
        // TODO 5: return Max(Max(a, b), c);
        throw new NotImplementedException();
    }
}
