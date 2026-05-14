/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W2.P1.Ex1 — ArrayBasics.
 *          Do NOT share this file with students before the submission deadline.
 */
namespace OopCsharp.Week2.Part1_ArrayFundamentals.Solutions;

/// <summary>Reference solution for ArrayBasics (W2.P1.Ex1).</summary>
public static class Sol1_ArrayBasics
{
    public static int[] CreateAndFill(int size, int fillValue)
    {
        if (size < 0)
            throw new ArgumentException("Size must be non-negative.", nameof(size));

        int[] result = new int[size];
        for (int i = 0; i < result.Length; i++)
            result[i] = fillValue;

        return result;
    }

    public static int GetElement(int[] array, int index, int defaultValue)
    {
        // Null check first — avoids NullReferenceException on array.Length
        if (array == null) return defaultValue;
        // Bounds check — both below-zero and at-or-beyond-Length are invalid
        if (index < 0 || index >= array.Length) return defaultValue;
        return array[index];
    }

    public static int[] ReverseArray(int[] source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        int[] result = new int[source.Length];
        for (int i = 0; i < source.Length; i++)
            result[source.Length - 1 - i] = source[i];

        return result;
        // Note: Array.Reverse(source) would work in-place but would mutate the
        // original, violating the "do not modify source" contract.
    }

    public static int CountOccurrences(int[] array, int target)
    {
        if (array == null || array.Length == 0) return 0;

        int count = 0;
        foreach (int element in array)
            if (element == target)
                count++;

        return count;
    }

    public static int[] DefaultValues(int size)
    {
        // C# zero-initialises all value-type arrays; no loop needed.
        return new int[size];
    }
}
