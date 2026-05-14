/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Try / Catch / Finally
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for safe arithmetic operations using try/catch/finally.
 *           Students compare their implementation against this model answer.
 */
namespace OopCsharp.Week7.Part1_TryCatchFinally.Solutions;

public class SafeCalculator
{
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new ArgumentException("Cannot divide by zero.");
        return a / b;
    }

    public double ParseAndAdd(string a, string b)
    {
        if (!double.TryParse(a, System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out double va))
            throw new FormatException($"Not a valid number: '{a}'");

        if (!double.TryParse(b, System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out double vb))
            throw new FormatException($"Not a valid number: '{b}'");

        return va + vb;
    }

    public string? SafeRead(string[] data, int index)
    {
        try
        {
            return data[index];
        }
        catch (IndexOutOfRangeException)
        {
            return null;
        }
    }

    public int ParseWithFinally(string input, ref int attemptCount)
    {
        try
        {
            if (!int.TryParse(input, out int result))
                throw new FormatException($"Bad input: {input}");
            return result;
        }
        finally
        {
            attemptCount++;
        }
    }
}
