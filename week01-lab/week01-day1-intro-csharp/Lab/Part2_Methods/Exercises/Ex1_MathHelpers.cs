/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Practice calling Math class methods and writing simple
 *           computational methods.  Students learn that static utility
 *           methods are the building blocks of larger programs, and that
 *           each method should do exactly ONE thing (Single Responsibility).
 */

// ─────────────────────────────────────────────────────────────────────────────
// EXERCISE W1.P2.Ex1 — MathHelpers
// ─────────────────────────────────────────────────────────────────────────────
// Goal:     Implement four small mathematical helper methods.
//
// Your tasks:
//   1) Hypotenuse(double a, double b)
//      → return √(a² + b²)   (Pythagoras' theorem)
//      Use Math.Sqrt.  Example: Hypotenuse(3, 4) → 5.0
//
//   2) CircleArea(double radius)
//      → return π × radius²
//      Use Math.PI and Math.Pow.  Example: CircleArea(1) → 3.14159…
//
//   3) Clamp(int value, int min, int max)
//      → return value if min ≤ value ≤ max
//         return min  if value < min
//         return max  if value > max
//      Write the logic yourself — do NOT use Math.Clamp.
//      Example: Clamp(15, 1, 10) → 10
//
//   4) AbsDiff(int a, int b)
//      → return |a - b|  (always non-negative)
//      Use Math.Abs.  Example: AbsDiff(3, 10) → 7
//
// Pass when: StudentWeek1Part2_Ex1Tests is fully green.
// ─────────────────────────────────────────────────────────────────────────────
namespace OopCsharp.Week1.Part2_Methods.Exercises;

/// <summary>
/// Mathematical helper methods (W1.P2.Ex1).
/// </summary>
/// <remarks>
/// Every method here is a <i>pure function</i>: it depends only on its
/// parameters and the mathematical constants in <see cref="Math"/>.
/// No side effects, no mutable state.
/// </remarks>
public static class MathHelpers
{
    /// <summary>
    /// Returns the length of the hypotenuse of a right triangle
    /// whose legs have lengths <paramref name="a"/> and <paramref name="b"/>.
    /// </summary>
    /// <param name="a">Length of the first leg (must be ≥ 0 for a physical triangle).</param>
    /// <param name="b">Length of the second leg.</param>
    /// <returns>√(a² + b²)</returns>
    public static double Hypotenuse(double a, double b)
    {
        // ── Math.Sqrt ────────────────────────────────────────────────
        // Math.Sqrt(x) returns the non-negative square root of x.
        // It always returns a double regardless of the input type.
        //
        // Pythagoras: c = √(a² + b²)
        // In C#:      Math.Sqrt(a * a + b * b)
        //   or equivalently using Pow:  Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2))
        //   The first form (a * a) is slightly faster — no function call overhead.
        //
        // TODO 1: return Math.Sqrt(a * a + b * b)
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the area of a circle with the given <paramref name="radius"/>.
    /// </summary>
    /// <param name="radius">The radius of the circle (≥ 0).</param>
    /// <returns>π × radius²</returns>
    public static double CircleArea(double radius)
    {
        // ── Math.PI and Math.Pow ──────────────────────────────────────
        // Math.PI  is a constant (3.14159265358979…) — not a method call.
        // Math.Pow(base, exponent) raises base to the given power.
        //   Math.Pow(radius, 2)  is the same as  radius * radius
        //   but expresses "squaring" more explicitly.
        //
        // Formula: A = π × r²
        //
        // TODO 2: return Math.PI * Math.Pow(radius, 2)
        throw new NotImplementedException();
    }

    /// <summary>
    /// Clamps <paramref name="value"/> to the inclusive range
    /// [<paramref name="min"/>, <paramref name="max"/>].
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The lower bound (inclusive).</param>
    /// <param name="max">The upper bound (inclusive).</param>
    /// <returns>
    /// <paramref name="min"/> if value &lt; min;
    /// <paramref name="max"/> if value &gt; max;
    /// <paramref name="value"/> otherwise.
    /// </returns>
    public static int Clamp(int value, int min, int max)
    {
        // ── Writing the logic yourself ────────────────────────────────
        // Although Math.Clamp exists in .NET 5+, the goal here is to
        // practice writing conditional logic with if statements.
        //
        // Think about it as three cases:
        //   Case 1: value is below the allowed range  → return min
        //   Case 2: value is above the allowed range  → return max
        //   Case 3: value is inside the range         → return value
        //
        // TODO 3: implement the three-case logic using if / else if / return.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the absolute difference between <paramref name="a"/> and
    /// <paramref name="b"/> — always a non-negative value.
    /// </summary>
    /// <returns>|a − b|</returns>
    public static int AbsDiff(int a, int b)
    {
        // ── Math.Abs ──────────────────────────────────────────────────
        // Math.Abs(x) removes the sign of x.
        //   Math.Abs(-7)  → 7
        //   Math.Abs( 7)  → 7
        //   Math.Abs( 0)  → 0
        //
        // The absolute difference |a - b| is always ≥ 0 regardless of
        // which value is larger.  For example:
        //   AbsDiff(10, 3)  →  Math.Abs(10 - 3)  =  Math.Abs(7)  = 7
        //   AbsDiff(3, 10)  →  Math.Abs(3 - 10)  =  Math.Abs(-7) = 7
        //
        // TODO 4: return Math.Abs(a - b)
        throw new NotImplementedException();
    }
}
