/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    2 — Arrays
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W2.P2.Ex2 — ForVsForeach.
 *          Do NOT share this file with students before the submission deadline.
 */
namespace OopCsharp.Week2.Part2_IterationAndOperations.Solutions;

/// <summary>Reference solution for ForVsForeach (W2.P2.Ex2).</summary>
public static class Sol2_ForVsForeach
{
    public static void MultiplyInPlace(int[] numbers, int factor)
    {
        if (numbers == null) return;

        // for required: we must WRITE back through the index.
        // foreach gives a read-only value copy — assignment to it is a no-op.
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] *= factor;
    }

    public static bool ContainsNegative(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0) return false;

        // foreach is fine: we only READ each value; no index needed.
        foreach (int n in numbers)
            if (n < 0) return true;   // early exit

        return false;
    }

    public static void ReplaceNegativesWithZero(int[] numbers)
    {
        if (numbers == null) return;

        // for required: we need the index to write the replacement value back.
        for (int i = 0; i < numbers.Length; i++)
            if (numbers[i] < 0)
                numbers[i] = 0;
    }

    public static int SumEvenIndexed(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0) return 0;

        // for required: we inspect the INDEX itself (i % 2 == 0).
        // foreach cannot tell us which position we are at.
        int total = 0;
        for (int i = 0; i < numbers.Length; i++)
            if (i % 2 == 0)
                total += numbers[i];

        return total;
    }

    public static bool AllPositive(int[] numbers)
    {
        if (numbers == null) return true;   // vacuously true: no counter-example

        // foreach is fine: we only READ each value.
        foreach (int n in numbers)
            if (n <= 0) return false;

        return true;
    }
}
