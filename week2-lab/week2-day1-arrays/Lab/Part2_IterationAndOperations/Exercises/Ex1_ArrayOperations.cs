/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W2.P2.Ex1 — ArrayOperations.
 *          Practise the accumulator pattern: summing, averaging, finding the
 *          minimum and maximum, and building simple visualisations from array
 *          data.  Every method uses a single pass through the array.
 */
namespace OopCsharp.Week2.Part2_IterationAndOperations.Exercises;

/// <summary>
/// Exercise W2.P2.Ex1 — ArrayOperations.
///
/// Replace every  throw new NotImplementedException();
/// with working code.  Read the TODO comment above each method carefully.
/// </summary>
public static class ArrayOperations
{
    // ────────────────────────────────────────────────────────────────────────
    //  Method 1 — Sum
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>Returns the sum of all elements in <paramref name="numbers"/>.</summary>
    /// <returns>0 when the array is null or empty.</returns>
    ///
    /// TODO Step 1 — Guard clause.
    ///   if (numbers == null || numbers.Length == 0) return 0;
    ///
    /// TODO Step 2 — Accumulator pattern.
    ///   int total = 0;
    ///   foreach (int n in numbers)
    ///       total += n;
    ///   return total;
    ///
    /// Note: foreach is fine here because we only need the value,
    /// not the index.
    public static int Sum(int[] numbers)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 2 — Average
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns the arithmetic mean of all elements as a <c>double</c>.
    /// </summary>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="numbers"/> is null or empty (no mean exists).
    /// </exception>
    ///
    /// TODO Step 1 — Guard clause (null OR empty → throw, not return 0).
    ///   if (numbers == null || numbers.Length == 0)
    ///       throw new ArgumentException("Array must not be null or empty.",
    ///                                   nameof(numbers));
    ///
    /// TODO Step 2 — Sum all elements (reuse your Sum logic or method).
    ///
    /// TODO Step 3 — Divide by count, casting to double FIRST.
    ///   The dangerous version:  total / numbers.Length
    ///     This is integer division — it truncates!  e.g. 7 / 2 → 3, not 3.5
    ///   The correct version:    (double)total / numbers.Length
    ///     Cast one operand to double; the other is promoted automatically.
    ///
    /// TODO Step 4 — Return the double result.
    public static double Average(int[] numbers)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 3 — Min
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>Returns the smallest element in <paramref name="numbers"/>.</summary>
    /// <exception cref="ArgumentException">Thrown when null or empty.</exception>
    ///
    /// TODO Step 1 — Guard clause.
    ///
    /// TODO Step 2 — Seed the running minimum from index 0.
    ///   int min = numbers[0];
    ///   WHY [0] and not 0?  Because if all values are negative (e.g. -5, -8)
    ///   starting from 0 would incorrectly report 0 as the minimum.
    ///   Seeding from numbers[0] always picks a real element.
    ///
    /// TODO Step 3 — Walk the rest of the array (start at index 1).
    ///   for (int i = 1; i < numbers.Length; i++)
    ///       if (numbers[i] < min)
    ///           min = numbers[i];
    ///
    /// TODO Step 4 — Return min.
    public static int Min(int[] numbers)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 4 — Max
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>Returns the largest element in <paramref name="numbers"/>.</summary>
    /// <exception cref="ArgumentException">Thrown when null or empty.</exception>
    ///
    /// TODO — Mirror of Min. Seed from numbers[0], update when numbers[i] > max.
    public static int Max(int[] numbers)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 5 — BuildBarChart
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Converts an array of non-negative integers into a string where each
    /// value is represented as a row of asterisks, separated by newlines.
    /// </summary>
    /// <example>
    /// BuildBarChart(new[] { 3, 1, 4 }) returns:
    ///   "***\n*\n****"
    /// </example>
    /// <returns>Empty string when <paramref name="values"/> is null or empty.</returns>
    ///
    /// TODO Step 1 — Guard clause: return "" for null or empty input.
    ///
    /// TODO Step 2 — Build each row.
    ///   Use a string[] rows = new string[values.Length];
    ///   Inside a for loop:
    ///     rows[i] = new string('*', values[i]);
    ///   new string('*', n) creates a string of n asterisks.
    ///   new string('*', 0) gives "", which is correct for a value of 0.
    ///
    /// TODO Step 3 — Join with newline and return.
    ///   return string.Join("\n", rows);
    ///
    /// Note: negative values would cause an exception in new string('*', n).
    /// The tests only pass non-negative values, so no guard is needed for that.
    public static string BuildBarChart(int[] values)
    {
        throw new NotImplementedException();
    }
}
