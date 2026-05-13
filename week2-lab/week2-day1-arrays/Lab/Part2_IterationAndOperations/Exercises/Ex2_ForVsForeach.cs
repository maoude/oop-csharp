/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W2.P2.Ex2 — ForVsForeach.
 *          Understand WHEN to use for (index needed) vs foreach (value only).
 *          Practise in-place mutation with for and read-only traversal with
 *          foreach, and learn why foreach cannot modify value-type elements.
 */
namespace OopCsharp.Week2.Part2_IterationAndOperations.Exercises;

/// <summary>
/// Exercise W2.P2.Ex2 — ForVsForeach.
///
/// Replace every  throw new NotImplementedException();
/// with working code.  Pay attention to WHICH loop you are told to use —
/// the choice is part of what is being tested.
/// </summary>
public static class ForVsForeach
{
    // ────────────────────────────────────────────────────────────────────────
    //  Method 1 — MultiplyInPlace  (use for)
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Multiplies every element of <paramref name="numbers"/> by
    /// <paramref name="factor"/> in place (modifies the original array).
    /// </summary>
    ///
    /// TODO — You MUST use a for loop here, not foreach.
    ///   WHY: foreach gives you a read-only copy of each element.
    ///   Writing to that copy has no effect on the array.
    ///   Only a for loop with an index lets you write back:
    ///     numbers[i] = numbers[i] * factor;
    ///
    ///   Guard: if numbers is null, return immediately without crashing.
    ///
    ///   for (int i = 0; i < numbers.Length; i++)
    ///       numbers[i] *= factor;
    public static void MultiplyInPlace(int[] numbers, int factor)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 2 — ContainsNegative  (use foreach)
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns <c>true</c> if any element in <paramref name="numbers"/> is
    /// strictly negative; <c>false</c> otherwise (including null / empty).
    /// </summary>
    ///
    /// TODO — You MUST use foreach here, not for.
    ///   WHY: we only need to READ each value — no index required.
    ///   foreach is cleaner and less error-prone when the index is irrelevant.
    ///
    ///   Guard: if numbers is null or empty, return false immediately.
    ///
    ///   foreach (int n in numbers)
    ///       if (n < 0)
    ///           return true;   // early exit — no need to keep going
    ///   return false;
    public static bool ContainsNegative(int[] numbers)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 3 — ReplaceNegativesWithZero  (use for)
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Replaces every negative element in <paramref name="numbers"/> with 0,
    /// modifying the array in place.
    /// Non-negative elements are left unchanged.
    /// </summary>
    ///
    /// TODO — Use for (need the index to write back to the array).
    ///   Guard: if numbers is null, return without doing anything.
    ///
    ///   for (int i = 0; i < numbers.Length; i++)
    ///       if (numbers[i] < 0)
    ///           numbers[i] = 0;
    public static void ReplaceNegativesWithZero(int[] numbers)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 4 — SumEvenIndexed  (use for)
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns the sum of all elements at even indices (0, 2, 4, …).
    /// Returns 0 for null or empty input.
    /// </summary>
    ///
    /// TODO — Use for because you need to CHECK the index itself.
    ///   foreach gives you values without indices — you cannot ask
    ///   "is this the even-indexed element?"
    ///
    ///   int total = 0;
    ///   for (int i = 0; i < numbers.Length; i++)
    ///       if (i % 2 == 0)      // i % 2 == 0 means i is even
    ///           total += numbers[i];
    ///   return total;
    public static int SumEvenIndexed(int[] numbers)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 5 — AllPositive  (use foreach)
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns <c>true</c> if every element in <paramref name="numbers"/> is
    /// strictly greater than zero.
    /// Returns <c>true</c> for an empty or null array (vacuously true —
    /// there are no counter-examples).
    /// </summary>
    ///
    /// TODO — Use foreach (values only, no index needed).
    ///
    ///   if (numbers == null) return true;
    ///
    ///   foreach (int n in numbers)
    ///       if (n <= 0)
    ///           return false;   // found a counter-example → stop immediately
    ///   return true;
    ///
    /// This "assume true, bail on first failure" pattern is idiomatic C#.
    /// It is both efficient (early exit) and readable.
    public static bool AllPositive(int[] numbers)
    {
        throw new NotImplementedException();
    }
}
