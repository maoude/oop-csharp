/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  [INSTRUCTOR ONLY] Reference solution for W1.P2.Ex2 — Parameters.
 *           Shows correct use of ref, out, guard clauses, single-pass
 *           min/max, and the :F1 format specifier.
 */
namespace OopCsharp.Week1.Part2_Methods.Solutions;

/// <summary>[INSTRUCTOR ONLY] Solution for W1.P2.Ex2 — Parameters.</summary>
public static class Parameters
{
    // value++ is the most concise way to add 1 in place.
    // Because `value` is ref, this writes directly to the caller's variable.
    /// <summary>Adds 1 to <paramref name="value"/> in place.</summary>
    public static void Increment(ref int value) => value++;

    // Classic three-step swap using a temporary variable.
    // Without `temp`, one value would be overwritten before it is saved.
    /// <summary>Swaps <paramref name="a"/> and <paramref name="b"/> in place.</summary>
    public static void Swap(ref int a, ref int b)
    {
        int temp = a;   // save a
        a = b;          // overwrite a with b
        b = temp;       // restore b from saved a
    }

    /// <summary>Finds the minimum and maximum of a non-empty array in one pass.</summary>
    /// <exception cref="ArgumentException">Thrown for null or empty input.</exception>
    public static void MinMax(int[] numbers, out int min, out int max)
    {
        // Fail fast: validate preconditions before touching the data.
        // nameof(numbers) avoids a magic string — if the parameter is renamed,
        // the compiler catches the stale nameof automatically.
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException(
                "Array must be non-null and non-empty.", nameof(numbers));

        // Seed both extremes with the first element.
        // After the loop, min and max are guaranteed to be assigned.
        min = numbers[0];
        max = numbers[0];

        // Single pass: O(n) time, O(1) extra space.
        foreach (int n in numbers)
        {
            if (n < min) min = n;   // found a new minimum
            if (n > max) max = n;   // found a new maximum
        }
    }

    /// <summary>Converts Celsius to Fahrenheit and returns a formatted string.</summary>
    public static string FormatTemperature(double celsius, out double fahrenheit)
    {
        // 9.0 / 5.0 forces floating-point division (= 1.8).
        // Writing 9 / 5 would give integer division (= 1) — a classic bug.
        fahrenheit = celsius * 9.0 / 5.0 + 32.0;

        // :F1 formats to exactly one decimal place.
        // The degree symbol ° is a Unicode character — paste or type °.
        return $"{celsius:F1}°C = {fahrenheit:F1}°F";
    }
}
