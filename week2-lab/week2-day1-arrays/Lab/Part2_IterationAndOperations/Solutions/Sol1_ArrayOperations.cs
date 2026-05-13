/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W2.P2.Ex1 — ArrayOperations.
 *          Do NOT share this file with students before the submission deadline.
 */
namespace OopCsharp.Week2.Part2_IterationAndOperations.Solutions;

/// <summary>Reference solution for ArrayOperations (W2.P2.Ex1).</summary>
public static class Sol1_ArrayOperations
{
    public static int Sum(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0) return 0;

        int total = 0;
        foreach (int n in numbers)
            total += n;

        return total;
    }

    public static double Average(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("Array must not be null or empty.", nameof(numbers));

        int total = 0;
        foreach (int n in numbers)
            total += n;

        // Cast before dividing — integer division would truncate the result.
        return (double)total / numbers.Length;
    }

    public static int Min(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("Array must not be null or empty.", nameof(numbers));

        // Seed from the first element — never from 0 or int.MaxValue.
        // Seeding from 0 fails when all values are negative.
        int min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
            if (numbers[i] < min)
                min = numbers[i];

        return min;
    }

    public static int Max(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("Array must not be null or empty.", nameof(numbers));

        int max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
            if (numbers[i] > max)
                max = numbers[i];

        return max;
    }

    public static string BuildBarChart(int[] values)
    {
        if (values == null || values.Length == 0) return "";

        string[] rows = new string[values.Length];
        for (int i = 0; i < values.Length; i++)
            rows[i] = new string('*', values[i]);

        return string.Join("\n", rows);
    }
}
