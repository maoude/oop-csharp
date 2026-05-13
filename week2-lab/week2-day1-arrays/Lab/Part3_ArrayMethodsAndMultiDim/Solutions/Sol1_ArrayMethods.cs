/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W2.P3.Ex1 — ArrayMethods.
 *          Do NOT share this file with students before the submission deadline.
 */
namespace OopCsharp.Week2.Part3_ArrayMethodsAndMultiDim.Solutions;

/// <summary>Reference solution for ArrayMethods (W2.P3.Ex1).</summary>
public static class Sol1_ArrayMethods
{
    public static int[] SortedCopy(int[] source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        // Copy first — Array.Sort is in-place; sorting source would destroy it.
        int[] copy = new int[source.Length];
        Array.Copy(source, copy, source.Length);
        Array.Sort(copy);

        return copy;
    }

    public static int LinearSearch(int[] array, int target)
    {
        // Array.IndexOf handles null arrays gracefully, returning -1.
        return Array.IndexOf(array, target);
    }

    public static int BinarySearchInSorted(int[] sortedArray, int target)
    {
        if (sortedArray == null || sortedArray.Length == 0) return -1;

        // Array.BinarySearch returns a negative value when not found.
        // We normalise any negative result to -1 for a consistent API.
        int index = Array.BinarySearch(sortedArray, target);
        return index >= 0 ? index : -1;
    }

    public static int? FirstEven(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0) return null;

        // Array.Find returns 0 (default(int)) when no match exists.
        // That is ambiguous — 0 itself is even.  Use Array.Exists first.
        if (!Array.Exists(numbers, n => n % 2 == 0)) return null;
        return Array.Find(numbers, n => n % 2 == 0);
    }

    public static int CountEvens(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0) return 0;

        // Array.FindAll returns a new array of all matching elements.
        return Array.FindAll(numbers, n => n % 2 == 0).Length;
    }
}
