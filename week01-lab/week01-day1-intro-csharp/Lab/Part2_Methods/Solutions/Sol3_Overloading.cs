/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  [INSTRUCTOR ONLY] Reference solution for W1.P2.Ex3 — Overloading.
 *           Shows concise overload implementations and highlights the reuse
 *           pattern in the three-argument Max.
 */
namespace OopCsharp.Week1.Part2_Methods.Solutions;

/// <summary>[INSTRUCTOR ONLY] Solution for W1.P2.Ex3 — Overloading.</summary>
public static class Overloading
{
    /// <summary>Returns <paramref name="text"/> repeated <paramref name="times"/> times.</summary>
    public static string Repeat(string text, int times)
    {
        // Guard: negative or zero repetitions → empty string.
        if (times <= 0) return string.Empty;

        // StringBuilder avoids O(n²) allocations from repeated string concatenation.
        // Capacity hint: text.Length * times pre-allocates the exact needed buffer.
        var sb = new System.Text.StringBuilder(text.Length * times);
        for (int i = 0; i < times; i++) sb.Append(text);
        return sb.ToString();
    }

    /// <summary>Returns <paramref name="ch"/> repeated <paramref name="times"/> times.</summary>
    public static string Repeat(char ch, int times) =>
        // new string(char, count) is a built-in constructor for exactly this purpose.
        // Guard and construct in one expression using the conditional operator.
        times <= 0 ? string.Empty : new string(ch, times);

    /// <summary>Returns the larger of two integers.</summary>
    public static int Max(int a, int b) =>
        // Ternary: condition ? value_if_true : value_if_false.
        // >= ensures we return `a` when they are equal (consistent with Math.Max).
        a >= b ? a : b;

    /// <summary>Returns the larger of two doubles.</summary>
    public static double Max(double a, double b) => a >= b ? a : b;

    /// <summary>Returns the largest of three integers.</summary>
    public static int Max(int a, int b, int c) =>
        // Delegate to the two-argument overload — write the comparison once, use it twice.
        // Max(a, b) picks the larger of the first two; then we compare that winner with c.
        Max(Max(a, b), c);
}
