/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Try / Catch / Finally
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: implement safe arithmetic operations using try/catch/finally.
 *           Practice: throw specific exceptions, use finally for cleanup, and distinguish
 *           between recoverable and unrecoverable errors.
 */
namespace OopCsharp.Week7.Part1_TryCatchFinally.Exercises;

// ============================================================
// Exercise 1 — SafeCalculator
//
// Build a class that wraps arithmetic operations with proper
// exception handling.  Use try / catch / finally — not defensive
// conditional checks — where noted.
// ============================================================

public class SafeCalculator
{
    // TODO 1a: int Divide(int a, int b)
    //   If b == 0, throw ArgumentException("Cannot divide by zero.").
    //   Otherwise return a / b.
    public int Divide(int a, int b) => throw new NotImplementedException();

    // TODO 1b: double ParseAndAdd(string a, string b)
    //   Parse both strings as double.
    //   If a cannot be parsed, throw FormatException($"Not a valid number: '{a}'").
    //   If b cannot be parsed, throw FormatException($"Not a valid number: '{b}'").
    //   Otherwise return their sum.
    //   Hint: double.TryParse is cleaner than try/catch here.
    public double ParseAndAdd(string a, string b) => throw new NotImplementedException();

    // TODO 1c: string? SafeRead(string[] data, int index)
    //   Try to access data[index].
    //   Catch IndexOutOfRangeException and return null.
    //   If the index is valid, return data[index].
    //   RULE: use try / catch — not a bounds check.
    public string? SafeRead(string[] data, int index) => throw new NotImplementedException();

    // TODO 1d: int ParseWithFinally(string input, ref int attemptCount)
    //   ALWAYS increment attemptCount (use a finally block for this).
    //   Try to parse input as int.
    //   If it fails, throw FormatException($"Bad input: {input}").
    //   If it succeeds, return the parsed int.
    public int ParseWithFinally(string input, ref int attemptCount)
        => throw new NotImplementedException();
}
