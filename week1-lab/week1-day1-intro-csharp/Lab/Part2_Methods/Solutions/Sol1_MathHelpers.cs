/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  [INSTRUCTOR ONLY] Reference solution for W1.P2.Ex1 — MathHelpers.
 *           Demonstrates idiomatic one-liner implementations and explains
 *           why each formula works the way it does.
 */
namespace OopCsharp.Week1.Part2_Methods.Solutions;

/// <summary>[INSTRUCTOR ONLY] Solution for W1.P2.Ex1 — MathHelpers.</summary>
public static class MathHelpers
{
    // a*a is preferred over Math.Pow(a, 2) for squaring — same result,
    // no method-call overhead, and reads clearly as "a squared".
    /// <summary>Returns √(a² + b²).</summary>
    public static double Hypotenuse(double a, double b) =>
        Math.Sqrt(a * a + b * b);

    // Math.PI is a double constant (~3.14159265358979).
    // Math.Pow(radius, 2) is equivalent to radius * radius.
    /// <summary>Returns π × radius².</summary>
    public static double CircleArea(double radius) =>
        Math.PI * Math.Pow(radius, 2);

    // Three explicit returns make the three cases crystal-clear.
    // No ternary nesting — clarity beats brevity here.
    /// <summary>Clamps value to [min, max].</summary>
    public static int Clamp(int value, int min, int max)
    {
        if (value < min) return min;   // below range → floor
        if (value > max) return max;   // above range → ceiling
        return value;                  // inside range → unchanged
    }

    // Math.Abs handles negative differences automatically.
    // AbsDiff(3, 10) → Math.Abs(3 - 10) = Math.Abs(-7) = 7.
    /// <summary>Returns |a − b|.</summary>
    public static int AbsDiff(int a, int b) => Math.Abs(a - b);
}
