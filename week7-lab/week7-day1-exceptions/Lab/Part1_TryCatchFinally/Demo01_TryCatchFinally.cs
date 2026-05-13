/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Try / Catch / Finally
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate exception handling fundamentals: try/catch/finally blocks,
 *           the exception hierarchy, multiple catch clauses, when filters, and
 *           re-throwing exceptions without losing the original stack trace.
 *           Run live during lecture and show console output for each section.
 */
namespace OopCsharp.Week7.Part1_TryCatchFinally;

// ============================================================
// DEMO 01 — try / catch / finally
// Topics: try block, catch block, finally block, exception
//         hierarchy, multiple catch clauses, when clause,
//         re-throwing exceptions
// ============================================================

// ----------------------------------------------------------
// Section 1: Basic try / catch
// ----------------------------------------------------------
// Code that might fail goes inside try { }.
// If an exception is thrown, control jumps to the matching catch.
// Code after the throw point inside try is NOT executed.

internal static class Section1
{
    internal static void BasicTryCatch()
    {
        int[] numbers = { 1, 2, 3 };

        try
        {
            Console.WriteLine(numbers[5]);   // IndexOutOfRangeException
            Console.WriteLine("This line never runs");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }

        Console.WriteLine("Execution continues here");
    }
}

// ----------------------------------------------------------
// Section 2: Multiple catch clauses
// ----------------------------------------------------------
// Catch clauses are tested top-to-bottom.
// Always put the most specific type first.
// Catching 'Exception' last catches everything else.

internal static class Section2
{
    internal static void ParseAndDivide(string input, int divisor)
    {
        try
        {
            int value = int.Parse(input);   // FormatException if not a number
            int result = value / divisor;   // DivideByZeroException if divisor == 0
            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{input}' is not a valid integer.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.GetType().Name}");
        }
    }
}

// ----------------------------------------------------------
// Section 3: finally
// ----------------------------------------------------------
// The finally block ALWAYS runs — whether an exception was thrown
// or not, and even if the catch re-throws.
// Use it to release resources (close files, database connections, etc.)

internal static class Section3
{
    internal static void WithFinally()
    {
        Console.WriteLine("Entering try");
        try
        {
            Console.WriteLine("Inside try");
            throw new InvalidOperationException("Something went wrong");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }
        finally
        {
            // This runs regardless — clean up resources here
            Console.WriteLine("Finally block: clean up");
        }
        Console.WriteLine("After try/catch/finally");
    }
}

// ----------------------------------------------------------
// Section 4: when clause (exception filter)
// ----------------------------------------------------------
// A 'when' clause adds a condition to a catch.
// The catch only activates if the condition is true.
// If false, the exception continues up the call stack.

internal static class Section4
{
    internal static void WithWhenClause(int code)
    {
        try
        {
            throw new InvalidOperationException($"Error code: {code}");
        }
        catch (InvalidOperationException ex) when (code == 404)
        {
            Console.WriteLine($"Not found error: {ex.Message}");
        }
        catch (InvalidOperationException ex) when (code == 500)
        {
            Console.WriteLine($"Server error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Other error: {ex.Message}");
        }
    }
}

// ----------------------------------------------------------
// Section 5: Re-throwing exceptions
// ----------------------------------------------------------
// 'throw;'      — re-throws the same exception, PRESERVING the stack trace.
// 'throw ex;'   — re-throws but RESETS the stack trace to this point.
// Prefer bare 'throw;' when you want the original call location visible.

internal static class Section5
{
    internal static void LogAndRethrow()
    {
        try
        {
            int.Parse("not a number");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"[LOG] FormatException caught: {ex.Message}");
            throw;   // re-throws with original stack trace preserved
        }
    }
}

// ----------------------------------------------------------
// Section 6: Exception hierarchy
// ----------------------------------------------------------
// System.Exception
//   ├─ SystemException
//   │   ├─ IndexOutOfRangeException
//   │   ├─ NullReferenceException
//   │   ├─ InvalidCastException
//   │   ├─ OverflowException
//   │   └─ ArithmeticException
//   │       └─ DivideByZeroException
//   └─ ApplicationException  (rarely used directly)
//
// Custom exceptions should inherit from Exception (or a more
// specific base) — demonstrated in Demo 02.

internal static class Demo01Runner
{
    internal static void Run()
    {
        Section1.BasicTryCatch();
        Console.WriteLine();

        Section2.ParseAndDivide("abc", 2);
        Section2.ParseAndDivide("10", 0);
        Section2.ParseAndDivide("10", 2);
        Console.WriteLine();

        Section3.WithFinally();
        Console.WriteLine();

        Section4.WithWhenClause(404);
        Section4.WithWhenClause(500);
        Section4.WithWhenClause(999);
    }
}
