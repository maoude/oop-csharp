/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W2.P3.Ex1 — ArrayMethods.
 *          Use the standard Array class methods — Sort, Reverse, Copy,
 *          IndexOf, BinarySearch, Exists, Find — instead of writing the
 *          algorithms from scratch.  Know WHEN each method is appropriate
 *          and what preconditions it requires.
 */
namespace OopCsharp.Week2.Part3_ArrayMethodsAndMultiDim.Exercises;

/// <summary>
/// Exercise W2.P3.Ex1 — ArrayMethods.
///
/// Replace every  throw new NotImplementedException();
/// with working code.  Read the TODO comment above each method carefully.
/// </summary>
public static class ArrayMethods
{
    // ────────────────────────────────────────────────────────────────────────
    //  Method 1 — SortedCopy
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns a NEW array that contains the same elements as
    /// <paramref name="source"/> but sorted in ascending order.
    /// The original array must NOT be modified.
    /// </summary>
    /// <exception cref="ArgumentNullException">When source is null.</exception>
    ///
    /// TODO Step 1 — Null guard.
    ///   throw new ArgumentNullException(nameof(source));
    ///
    /// TODO Step 2 — Copy the array.
    ///   int[] copy = new int[source.Length];
    ///   Array.Copy(source, copy, source.Length);
    ///   WHY copy first: Array.Sort operates IN PLACE on the array you pass.
    ///   If you sorted source directly, you would destroy the original.
    ///
    /// TODO Step 3 — Sort the copy (not source).
    ///   Array.Sort(copy);
    ///
    /// TODO Step 4 — Return copy.
    public static int[] SortedCopy(int[] source)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 2 — LinearSearch
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Searches for <paramref name="target"/> in <paramref name="array"/>
    /// using a linear search (Array.IndexOf) and returns its index, or -1
    /// if not found.  The array does NOT need to be sorted.
    /// </summary>
    ///
    /// TODO — One line:
    ///   return Array.IndexOf(array, target);
    ///
    ///   Array.IndexOf scans left-to-right in O(n) time.
    ///   It returns -1 when the value is not found — the same convention
    ///   used by string.IndexOf, List<T>.IndexOf, etc.
    ///   Pass null safely: Array.IndexOf returns -1 for a null array.
    public static int LinearSearch(int[] array, int target)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 3 — BinarySearchInSorted
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Searches for <paramref name="target"/> in an ALREADY SORTED
    /// <paramref name="sortedArray"/> using binary search.
    /// Returns the index if found, -1 if not found.
    /// </summary>
    ///
    /// TODO Step 1 — Guard: return -1 for null or empty.
    ///
    /// TODO Step 2 — Binary search.
    ///   int index = Array.BinarySearch(sortedArray, target);
    ///
    ///   Array.BinarySearch returns:
    ///     ≥ 0   → the element was found at that index
    ///     < 0   → not found (the value is the bitwise complement of the
    ///             insertion point — you don't need to use it)
    ///
    /// TODO Step 3 — Normalise the result.
    ///   return (index >= 0) ? index : -1;
    ///
    ///   WHY: if you pass an UNSORTED array to BinarySearch the result is
    ///   undefined.  The method name signals that the caller is responsible
    ///   for sorting first.
    public static int BinarySearchInSorted(int[] sortedArray, int target)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 4 — FirstEven
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns the first even number in <paramref name="numbers"/>, or
    /// <c>null</c> if there is no even number (or the array is null / empty).
    /// The return type is <c>int?</c> (nullable int) to represent "not found".
    /// </summary>
    ///
    /// TODO Step 1 — Guard: return null for null or empty.
    ///
    /// TODO Step 2 — Use Array.Find with a lambda predicate.
    ///   int result = Array.Find(numbers, n => n % 2 == 0);
    ///
    ///   Array.Find returns the FIRST element that satisfies the predicate,
    ///   or the DEFAULT VALUE OF THE TYPE (0 for int) if none match.
    ///
    /// TODO Step 3 — Distinguish "found 0" from "not found" (both give 0).
    ///   Use Array.Exists first to decide whether any even number exists:
    ///     if (!Array.Exists(numbers, n => n % 2 == 0))
    ///         return null;
    ///     return Array.Find(numbers, n => n % 2 == 0);
    ///
    ///   This is the safe pattern: Exists tells you IF there is a match;
    ///   Find tells you WHAT it is.
    public static int? FirstEven(int[] numbers)
    {
        throw new NotImplementedException();
    }

    // ────────────────────────────────────────────────────────────────────────
    //  Method 5 — CountEvens
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Returns the count of even numbers in <paramref name="numbers"/>.
    /// Returns 0 for null or empty input.
    /// </summary>
    ///
    /// TODO Step 1 — Guard: return 0 for null or empty.
    ///
    /// TODO Step 2 — Use Array.FindAll.
    ///   int[] evens = Array.FindAll(numbers, n => n % 2 == 0);
    ///   Array.FindAll returns a new array containing ALL matching elements.
    ///
    /// TODO Step 3 — Return evens.Length.
    ///
    /// Alternative (without FindAll): a foreach loop with a counter works too,
    /// but Array.FindAll is more expressive when you just need the count.
    public static int CountEvens(int[] numbers)
    {
        throw new NotImplementedException();
    }
}
