/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Best Practices
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate exception handling best practices: fail-fast validation,
 *           the TryXxx pattern (no-throw API), using vs try/finally for resource
 *           cleanup, anti-patterns (swallowing exceptions, control flow), and
 *           when to catch specific vs general exceptions.
 *           Emphasize readability and maintainability.
 */
namespace OopCsharp.Week7.Part3_BestPractices;

// ============================================================
// DEMO 03 — Exception Best Practices
// Topics: when to throw vs return, ArgumentException family,
//         using statements (IDisposable), TryXxx pattern,
//         guidelines: don't swallow, don't use for control flow
// ============================================================

// ----------------------------------------------------------
// Section 1: ArgumentException family — the right exception
//            for bad inputs
// ----------------------------------------------------------
// ArgumentException           — wrong value (general)
// ArgumentNullException       — null argument where not allowed
// ArgumentOutOfRangeException — number outside acceptable range

public static class ArgDemo
{
    public static void SetAge(int age)
    {
        if (age < 0 || age > 150)
            throw new ArgumentOutOfRangeException(nameof(age),
                age, "Age must be between 0 and 150.");
    }

    public static void SetName(string? name)
    {
        ArgumentNullException.ThrowIfNull(name);            // C# 10+ helper
        if (name.Trim().Length == 0)
            throw new ArgumentException("Name cannot be blank.", nameof(name));
    }
}

// ----------------------------------------------------------
// Section 2: InvalidOperationException — wrong state
// ----------------------------------------------------------
// Use when the object's current state makes the operation impossible,
// regardless of whether the arguments are valid.

public class Stack<T>
{
    private readonly List<T> _items = new();

    public void Push(T item) => _items.Add(item);

    public T Pop()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Cannot pop from an empty stack.");
        var last = _items[^1];
        _items.RemoveAt(_items.Count - 1);
        return last;
    }
}

// ----------------------------------------------------------
// Section 3: TryXxx pattern — when failure is expected
// ----------------------------------------------------------
// If failure is common and not exceptional, a TryXxx bool method
// is cleaner than try/catch at every call site.

public static class SafeParser
{
    // Throwing version (use when invalid input is truly exceptional)
    public static int Parse(string s)
    {
        if (!int.TryParse(s, out int result))
            throw new FormatException($"'{s}' is not a valid integer.");
        return result;
    }

    // TryXxx version (use when invalid input is common / expected)
    public static bool TryParse(string s, out int result)
        => int.TryParse(s, out result);
}

// ----------------------------------------------------------
// Section 4: Don't swallow exceptions
// ----------------------------------------------------------

internal static class AntiPatterns
{
    // BAD — silently discards all errors
    internal static int BadDivide(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (Exception)
        {
            return 0;   // caller has no idea something went wrong
        }
    }

    // GOOD — let it propagate OR handle meaningfully
    internal static int GoodDivide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Divisor must not be zero.");
        return a / b;
    }

    // BAD — exceptions as control flow (expensive + hard to read)
    internal static bool IsInteger_Bad(string s)
    {
        try { int.Parse(s); return true; }
        catch { return false; }
    }

    // GOOD — use TryParse
    internal static bool IsInteger_Good(string s) => int.TryParse(s, out _);
}

// ----------------------------------------------------------
// Section 5: IDisposable and the using statement
// ----------------------------------------------------------
// Objects that hold unmanaged resources implement IDisposable.
// 'using' guarantees Dispose() is called even if an exception occurs.

internal static class UsingDemo
{
    internal static void UsingStatement()
    {
        // using statement — Dispose() called at the closing brace
        using (var writer = new System.IO.StringWriter())
        {
            writer.WriteLine("Hello");
            // Even if we throw here, writer.Dispose() is called
        }   // ← Dispose() called here

        // Modern form — no braces, disposed at end of scope
        using var reader = new System.IO.StringReader("data");
        string? line = reader.ReadLine();
        Console.WriteLine(line);
    }   // ← reader.Dispose() called here
}

// ----------------------------------------------------------
// Section 6: Exception guidelines summary
// ----------------------------------------------------------
//
// DO:
//   • Throw the most specific exception type available
//   • Include a useful message (what went wrong, not just the type)
//   • Use the innerException when wrapping
//   • Use TryXxx for expected failures
//   • Use 'finally' or 'using' for cleanup
//
// DON'T:
//   • Catch (Exception) unless you re-throw or log and crash
//   • Swallow exceptions silently
//   • Use throw/catch for normal control flow
//   • Throw Exception or ApplicationException directly

internal static class Demo03Runner
{
    internal static void Run()
    {
        // ArgumentOutOfRangeException
        try { ArgDemo.SetAge(-1); }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"ArgumentOutOfRange: {ex.Message}");
        }

        // TryXxx pattern
        string input = "42x";
        if (SafeParser.TryParse(input, out int parsed))
            Console.WriteLine($"Parsed: {parsed}");
        else
            Console.WriteLine($"Could not parse '{input}'");

        // InvalidOperationException from empty stack
        var stack = new Stack<int>();
        try { stack.Pop(); }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"InvalidOperation: {ex.Message}");
        }
    }
}
