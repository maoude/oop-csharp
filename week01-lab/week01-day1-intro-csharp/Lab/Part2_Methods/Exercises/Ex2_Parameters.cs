/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Explore the three parameter-passing modes in C#:
 *           pass-by-value (default), ref (read + write the caller's variable),
 *           and out (the method must write the caller's variable).
 *           Understanding these modes is essential before studying object
 *           references in Week 3.
 */

// ─────────────────────────────────────────────────────────────────────────────
// EXERCISE W1.P2.Ex2 — Parameters
// ─────────────────────────────────────────────────────────────────────────────
// Goal:     Implement four methods that demonstrate parameter-passing modes.
//
// Your tasks:
//   1) Increment(ref int value)
//      → add 1 to the caller's variable in place (no return value needed).
//
//   2) Swap(ref int a, ref int b)
//      → exchange the values of the two caller variables.
//      Use a temporary variable to hold one value during the swap.
//
//   3) MinMax(int[] numbers, out int min, out int max)
//      → set min to the smallest element and max to the largest.
//      → throw ArgumentException if numbers is null or empty.
//      Find both in a single pass through the array.
//
//   4) FormatTemperature(double celsius, out double fahrenheit)
//      → compute fahrenheit = celsius × 9/5 + 32 (store in the out param).
//      → return a formatted string like "22.0°C = 71.6°F".
//
// Pass when: StudentWeek1Part2_Ex2Tests is fully green.
// ─────────────────────────────────────────────────────────────────────────────
namespace OopCsharp.Week1.Part2_Methods.Exercises;

/// <summary>
/// Demonstrates ref and out parameter-passing modes (W1.P2.Ex2).
/// </summary>
public static class Parameters
{
    /// <summary>
    /// Increments <paramref name="value"/> by 1 in place.
    /// </summary>
    /// <param name="value">
    /// Passed by <c>ref</c>: the method writes directly to the caller's variable.
    /// </param>
    /// <remarks>
    /// Because this is <c>void</c> with a <c>ref</c> parameter, the change is
    /// visible in the caller after the method returns — no return value needed.
    /// </remarks>
    public static void Increment(ref int value)
    {
        // ── ref parameters ────────────────────────────────────────────
        // `value` here is an ALIAS for the caller's variable, not a copy.
        // Writing to it changes the original.
        //
        // value++  is shorthand for  value = value + 1
        // value += 1  is equivalent
        //
        // TODO 1: add 1 to value.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Swaps the values of <paramref name="a"/> and <paramref name="b"/>.
    /// </summary>
    /// <param name="a">First variable, passed by <c>ref</c>.</param>
    /// <param name="b">Second variable, passed by <c>ref</c>.</param>
    public static void Swap(ref int a, ref int b)
    {
        // ── Classic swap with a temporary variable ────────────────────
        // You cannot write  a = b; b = a;  — that loses the original `a`.
        // The correct three-step algorithm:
        //
        //   Step 1:  int temp = a;   // save a's value before overwriting
        //   Step 2:  a = b;          // overwrite a with b's value
        //   Step 3:  b = temp;       // overwrite b with saved value of a
        //
        // Both `a` and `b` are ref aliases, so steps 2 and 3 write
        // directly into the caller's storage locations.
        //
        // TODO 2: implement the three-step swap.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Finds the minimum and maximum values in <paramref name="numbers"/>
    /// in a single pass.
    /// </summary>
    /// <param name="numbers">The array to search.  Must be non-null and non-empty.</param>
    /// <param name="min">Receives the smallest element found.</param>
    /// <param name="max">Receives the largest element found.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="numbers"/> is <c>null</c> or empty.
    /// </exception>
    public static void MinMax(int[] numbers, out int min, out int max)
    {
        // ── Validate input FIRST ──────────────────────────────────────
        // Checking preconditions at the start of a method is called
        // "fail fast" — the method refuses to proceed with bad input
        // and gives a clear error message instead of crashing later with
        // an obscure NullReferenceException or IndexOutOfRangeException.
        //
        // `out` parameters MUST be assigned before the method returns.
        // If you throw an exception, the compiler accepts that the out
        // parameters were never assigned (because the method never returned).
        //
        // TODO 3a: check if numbers == null || numbers.Length == 0.
        //          If so, throw new ArgumentException("...message...", nameof(numbers));
        //          (nameof(numbers) gives the string "numbers" — avoids a magic string.)

        // ── Seed with the first element ───────────────────────────────
        // Before iterating, initialise both min and max to numbers[0].
        // This is the correct baseline: the smallest and largest so far
        // is the only element we have seen.
        //
        // TODO 3b: min = numbers[0];  max = numbers[0];

        // ── Single-pass scan ──────────────────────────────────────────
        // Walk through every element.  For each one:
        //   • if it is smaller than the current min, update min.
        //   • if it is larger than the current max, update max.
        //
        // Why start the loop from index 0 (not 1)?  It is fine — the
        // first element is compared against itself and nothing changes.
        // Starting from 1 is a micro-optimisation; clarity comes first.
        //
        // TODO 3c: foreach (int n in numbers) { compare and update min/max }

        // Satisfy the compiler until you implement the body:
        throw new NotImplementedException();
    }

    /// <summary>
    /// Converts a Celsius temperature to Fahrenheit and returns a
    /// formatted description string.
    /// </summary>
    /// <param name="celsius">Temperature in degrees Celsius.</param>
    /// <param name="fahrenheit">
    /// Receives the equivalent temperature in degrees Fahrenheit.
    /// </param>
    /// <returns>
    /// A string like "22.0°C = 71.6°F" (one decimal place each).
    /// </returns>
    public static string FormatTemperature(double celsius, out double fahrenheit)
    {
        // ── Conversion formula ────────────────────────────────────────
        // F = C × (9 / 5) + 32
        //
        // CAUTION: in C#, 9 / 5 uses INTEGER division and gives 1, not 1.8.
        // Write 9.0 / 5.0 (or 9.0 / 5) to force FLOATING-POINT division.
        //
        // TODO 4a: fahrenheit = celsius * 9.0 / 5.0 + 32.0;

        // ── Format specifier :F1 ──────────────────────────────────────
        // Inside an interpolated string, {value:F1} formats the number
        // to exactly 1 decimal place.
        //   22.0   stays  "22.0"
        //   71.6   stays  "71.6"
        //   100.0  stays  "100.0"
        //
        // TODO 4b: return $"{celsius:F1}°C = {fahrenheit:F1}°F";

        // Satisfy the compiler until you implement the body:
        throw new NotImplementedException();
    }
}
