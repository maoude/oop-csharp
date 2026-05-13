/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W2.P1.Ex1 — ArrayBasics.
 *          Practise creating arrays, reading and writing elements by index,
 *          returning computed values without modifying the source, and
 *          detecting out-of-range conditions instead of crashing.
 */
namespace OopCsharp.Week2.Part1_ArrayFundamentals.Exercises;

/// <summary>
/// Exercise W2.P1.Ex1 — ArrayBasics.
///
/// Replace every  throw new NotImplementedException();
/// with working code.  Read the TODO comment above each method carefully —
/// it describes exactly what to implement and which edge cases to handle.
/// </summary>
public static class ArrayBasics
{
    // ────────────────────────────────────────────────────────────────────────
    //  Method 1 — CreateAndFill
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Creates a new integer array of length <paramref name="size"/> and fills
    /// every slot with <paramref name="fillValue"/>.
    /// </summary>
    /// <param name="size">Number of elements.  Must be ≥ 0.</param>
    /// <param name="fillValue">The value written into every element.</param>
    /// <returns>The filled array.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="size"/> is negative.
    /// </exception>
    ///
    /// TODO Step 1 — Guard clause.
    ///   If size is negative, throw:
    ///     throw new ArgumentException("Size must be non-negative.", nameof(size));
    ///
    /// TODO Step 2 — Create the array.
    ///   int[] result = new int[size];
    ///   A fresh int array always starts with all zeros — you still need to
    ///   overwrite each element if fillValue is not zero.
    ///
    /// TODO Step 3 — Fill it.
    ///   Use a for loop:
    ///     for (int i = 0; i < result.Length; i++)
    ///         result[i] = fillValue;
    ///
    /// TODO Step 4 — Return result.
    public static int[] CreateAndFill(int size, int fillValue)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 2 — GetElement
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns the element at position <paramref name="index"/> in
    /// <paramref name="array"/>, or <paramref name="defaultValue"/> if the
    /// index is out of range (instead of throwing).
    /// </summary>
    ///
    /// TODO Step 1 — Null guard.
    ///   If array is null, return defaultValue immediately.
    ///   This prevents a NullReferenceException before you even check length.
    ///
    /// TODO Step 2 — Bounds check.
    ///   A valid index satisfies: 0 <= index < array.Length
    ///   If the index is outside that range, return defaultValue.
    ///   You must check BOTH sides:  index < 0  and  index >= array.Length
    ///
    /// TODO Step 3 — Return the element.
    ///   return array[index];
    ///
    /// Key insight: by checking bounds first, you never hit
    /// IndexOutOfRangeException — the method is always safe to call.
    public static int GetElement(int[] array, int index, int defaultValue)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 3 — ReverseArray
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns a NEW array that contains the elements of
    /// <paramref name="source"/> in reverse order.
    /// The original array must NOT be modified.
    /// </summary>
    ///
    /// TODO Step 1 — Guard against null.
    ///   If source is null, throw:
    ///     throw new ArgumentNullException(nameof(source));
    ///
    /// TODO Step 2 — Create a result array of the same length.
    ///   int[] result = new int[source.Length];
    ///
    /// TODO Step 3 — Fill result in reverse order.
    ///   The element at source[0] goes to result[n-1],
    ///   source[1] goes to result[n-2], and so on.
    ///   One clean way:
    ///     for (int i = 0; i < source.Length; i++)
    ///         result[source.Length - 1 - i] = source[i];
    ///
    /// TODO Step 4 — Return result.
    ///   Do NOT call Array.Reverse on source — that would modify the original.
    public static int[] ReverseArray(int[] source)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 4 — CountOccurrences
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Counts how many times <paramref name="target"/> appears in
    /// <paramref name="array"/>.
    /// Returns 0 if the array is null or empty.
    /// </summary>
    ///
    /// TODO Step 1 — Handle null or empty input gracefully.
    ///   if (array == null || array.Length == 0) return 0;
    ///
    /// TODO Step 2 — Declare a counter variable.
    ///   int count = 0;
    ///
    /// TODO Step 3 — Loop through every element.
    ///   foreach (int element in array)
    ///       if (element == target)
    ///           count++;
    ///
    /// TODO Step 4 — Return count.
    public static int CountOccurrences(int[] array, int target)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 5 — DefaultValues
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Creates a fresh int array of the given <paramref name="size"/> and
    /// returns it without writing anything into it.
    /// This lets the caller observe the C# default value for int (zero).
    /// </summary>
    ///
    /// TODO — One line only:
    ///   return new int[size];
    ///
    /// No loops needed.  C# always zero-initialises value-type arrays
    /// at creation time — you do not have to write the zeros yourself.
    ///
    /// The test will verify that every element is 0 before you touch it.
    public static int[] DefaultValues(int size)
    {
        throw new NotImplementedException();
    }
}
