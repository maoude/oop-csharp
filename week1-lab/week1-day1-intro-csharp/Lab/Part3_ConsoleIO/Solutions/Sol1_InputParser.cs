/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  [INSTRUCTOR ONLY] Reference solution for W1.P3.Ex1 — InputParser.
 *           Demonstrates idiomatic null-safe, exception-free parsing using
 *           TryParse, the null-coalescing operator, and RemoveEmptyEntries.
 */
namespace OopCsharp.Week1.Part3_ConsoleIO.Solutions;

/// <summary>[INSTRUCTOR ONLY] Solution for W1.P3.Ex1 — InputParser.</summary>
public static class InputParser
{
    // Ternary with TryParse is the idiomatic one-liner for safe parsing.
    // int.TryParse(null, out _) returns false — null is handled automatically.
    /// <summary>Parses an int or returns <paramref name="defaultValue"/>.</summary>
    public static int ParseInt(string? input, int defaultValue) =>
        int.TryParse(input, out int v) ? v : defaultValue;

    // Same pattern for double.
    /// <summary>Parses a double or returns <paramref name="defaultValue"/>.</summary>
    public static double ParseDouble(string? input, double defaultValue) =>
        double.TryParse(input, out double v) ? v : defaultValue;

    /// <summary>
    /// Returns true for "true", "yes", "1", "y" (case-insensitive); false otherwise.
    /// </summary>
    public static bool ParseBool(string? input)
    {
        // ?? "" guards against null before calling instance methods.
        // Trim removes accidental surrounding whitespace.
        // ToLowerInvariant normalises case without culture side-effects.
        string normalised = (input ?? "").Trim().ToLowerInvariant();

        // C# 9+ pattern: `is` with `or` matches any of the listed values.
        return normalised is "true" or "yes" or "1" or "y";
    }

    /// <summary>Splits on whitespace, skips bad tokens, returns the sum.</summary>
    public static int SplitAndSum(string? input)
    {
        // IsNullOrWhiteSpace handles null, "", and "   " in one call.
        if (string.IsNullOrWhiteSpace(input)) return 0;

        int sum = 0;
        // RemoveEmptyEntries collapses multiple consecutive spaces.
        foreach (string token in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            if (int.TryParse(token, out int n))
                sum += n;   // valid int → accumulate; invalid → skip silently
        return sum;
    }
}
