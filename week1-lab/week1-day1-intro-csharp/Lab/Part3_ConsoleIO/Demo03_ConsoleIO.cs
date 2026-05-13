/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate how raw console input (always a string) is
 *           converted to typed data: safe parsing with TryParse,
 *           splitting multi-value input, and the rules of implicit
 *           vs explicit type conversion.
 *           Instructor: show the FormatException crash FIRST, then
 *           introduce TryParse as the fix.
 */
namespace OopCsharp.Week1.Part3_ConsoleIO;

/// <summary>
/// DEMO 03 — Console I/O, safe parsing, and type conversion.
/// </summary>
public static class Demo03_ConsoleIO
{
    /// <summary>Runs all sections of the demo.</summary>
    public static void Run()
    {
        RunSectionA_SafeParsing();
        RunSectionB_SplitAndParse();
        RunSectionC_TypeConversion();
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION A — Safe parsing with TryParse
    // ═════════════════════════════════════════════════════════════════

    private static void RunSectionA_SafeParsing()
    {
        Console.WriteLine("=== A: Safe Parsing ===");

        // Every value the user types arrives as a `string`.
        // To do arithmetic we must convert it to a numeric type.

        Console.Write("Enter an integer: ");
        string? raw = Console.ReadLine();

        // ── DANGEROUS path (commented out — show this first, then crash it) ──
        // int value = int.Parse(raw!);
        // int.Parse throws System.FormatException if `raw` is not a valid
        // integer (e.g. the user types "hello").  Unhandled, this crashes
        // the program.  This is NOT the preferred approach for console input.

        // ── SAFE path with TryParse ───────────────────────────────────
        // TryParse returns:
        //   true  — if parsing succeeded; `value` holds the parsed integer.
        //   false — if parsing failed;    `value` is set to 0 (default).
        // No exception is thrown either way.
        if (int.TryParse(raw, out int value))
        {
            Console.WriteLine($"You entered the integer: {value}");
        }
        else
        {
            // The input was not a valid integer.  We handle it gracefully.
            Console.WriteLine($"'{raw}' is not a valid integer. Please try again.");
        }

        // The Convert class is an alternative — Convert.ToInt32(raw) —
        // but it still throws FormatException on bad input, so TryParse
        // is generally preferred for user-facing code.
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION B — Splitting multi-value input
    // ═════════════════════════════════════════════════════════════════

    private static void RunSectionB_SplitAndParse()
    {
        Console.WriteLine("\n=== B: Split and Parse ===");

        // A common pattern: the user types multiple values on one line
        // separated by spaces.  We split the string into tokens, then
        // parse each token individually.
        Console.Write("Enter two numbers separated by a space: ");
        string line = Console.ReadLine() ?? "";

        // Split(' ') returns a string[] where each element is one token.
        // RemoveEmptyEntries handles multiple consecutive spaces gracefully.
        string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2
            && double.TryParse(parts[0], out double x)
            && double.TryParse(parts[1], out double y))
        {
            // Both tokens parsed successfully.
            Console.WriteLine($"Sum = {x + y:F2}");   // :F2 = 2 decimal places
        }
        else
        {
            Console.WriteLine("Could not read exactly two numbers. Please try again.");
        }
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION C — Implicit vs explicit type conversion
    // ═════════════════════════════════════════════════════════════════

    private static void RunSectionC_TypeConversion()
    {
        Console.WriteLine("\n=== C: Type Conversion ===");

        // ── Implicit (widening) conversion ────────────────────────────
        // An int fits inside a double with no data loss, so the compiler
        // allows the assignment without a cast.  No information is lost.
        int    i = 42;
        double d = i;         // int → double: always safe, no cast needed
        Console.WriteLine($"int {i} → double {d}");

        // ── Explicit (narrowing) cast ─────────────────────────────────
        // A double may have a fractional part that cannot be represented
        // as an int.  The compiler REQUIRES an explicit cast (int) to
        // show that you acknowledge the potential data loss.
        double pi        = 3.14159;
        int    truncated = (int)pi;   // fractional part is discarded (truncated, NOT rounded)
        Console.WriteLine($"double {pi} → int {truncated}  ← fractional part LOST");

        // ── Parsing is not the same as casting ───────────────────────
        // You cannot cast a string to an int:
        //   int bad = (int)"42";   ← compile error CS0030
        // You must parse:
        int parsed = int.Parse("42");   // safe here because we control the literal
        Console.WriteLine($"Parsed string \"42\" → int {parsed}");
    }
}
