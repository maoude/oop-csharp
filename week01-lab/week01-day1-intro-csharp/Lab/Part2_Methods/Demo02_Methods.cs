/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate the full method feature set introduced in Lecture 01:
 *           value-returning vs void methods, optional parameters, ref and out
 *           parameters, the Math class, and method overloading.
 *           Each section is self-contained and can be shown independently.
 */
namespace OopCsharp.Week1.Part2_Methods;

/// <summary>
/// DEMO 02 — Methods: declaration, parameters, return values,
/// optional parameters, ref/out, Math class, and overloading.
/// </summary>
/// <remarks>
/// Instructor tip: before running each section, ask students to predict
/// the output.  The mismatch between prediction and reality is the
/// learning moment.
/// </remarks>
public static class Demo02_Methods
{
    /// <summary>Runs all demo sections in order.</summary>
    public static void Run()
    {
        RunSectionA_ReturnTypes();
        RunSectionB_OptionalParameters();
        RunSectionC_RefAndOut();
        RunSectionD_MathClass();
        RunSectionE_Overloading();
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION A — Value-returning vs void methods
    // ═════════════════════════════════════════════════════════════════

    private static void RunSectionA_ReturnTypes()
    {
        Console.WriteLine("=== A: Return Types ===");

        // Square() is a VALUE-RETURNING method: it computes something
        // and hands the result back to the caller via `return`.
        // The caller stores the result in a local variable.
        int sq = Square(5);                  // sq receives 25
        Console.WriteLine($"Square(5) = {sq}");

        // PrintLine() is a VOID method: it performs an action (writing
        // to the console) but produces no value.  You cannot write:
        //   int x = PrintLine("hello");   ← compile error CS0029
        PrintLine("Hello from a void method");
    }

    // ─────────────────────────────────────────────────────────────────
    // METHOD ANATOMY
    //
    //   public static int Square( int n )
    //   ──────┬───── ─┬─ ──────  ──┬── ─┬─
    //         │       │    name    type  param name
    //         │       └── return type: what the method hands back
    //         └── modifiers: access (public) + binding (static)
    //
    // The expression body `=> n * n` is shorthand for { return n * n; }
    // Both forms are equivalent; use whichever is clearer.
    // ─────────────────────────────────────────────────────────────────

    /// <summary>Returns the square of <paramref name="n"/>.</summary>
    public static int Square(int n) => n * n;

    /// <summary>Writes <paramref name="message"/> followed by a newline.</summary>
    public static void PrintLine(string message) => Console.WriteLine(message);

    // ═════════════════════════════════════════════════════════════════
    // SECTION B — Optional parameters
    // ═════════════════════════════════════════════════════════════════

    private static void RunSectionB_OptionalParameters()
    {
        Console.WriteLine("\n=== B: Optional Parameters ===");

        // When a parameter has a default value (= 18), callers may omit it.
        // The compiler substitutes the default at the call site — at compile
        // time, not at runtime.  No magic happens inside the method body.
        Console.WriteLine(Describe("Alice"));        // age → default 18
        Console.WriteLine(Describe("Bob", 30));      // age → explicitly 30
    }

    /// <summary>Builds a human-readable description of a person.</summary>
    /// <param name="name">The person's name (required).</param>
    /// <param name="age">
    /// Age in years.  Optional — defaults to 18 if the caller omits it.
    /// </param>
    // RULE: optional parameters must appear AFTER all required parameters.
    //   Describe(int age = 18, string name)  ← compile error CS1737
    public static string Describe(string name, int age = 18) =>
        $"{name} is {age} years old.";

    // ═════════════════════════════════════════════════════════════════
    // SECTION C — ref and out parameters
    // ═════════════════════════════════════════════════════════════════

    private static void RunSectionC_RefAndOut()
    {
        Console.WriteLine("\n=== C: ref and out ===");

        // ── ref: the method shares the caller's storage location ──────
        // By default C# passes value types BY VALUE — a copy is made.
        // The original variable is untouched.  `ref` breaks that rule:
        // the method receives a direct alias to the caller's variable.
        int x = 10;
        Double(ref x);                               // x is now 20
        Console.WriteLine($"After Double(ref x): x = {x}");

        // ── out: the method GUARANTEES to write the variable ──────────
        // `out` is like `ref` but the caller does NOT need to initialise
        // the variable.  The compiler enforces that every code path in
        // the method assigns the out parameter before returning.
        bool ok = TryDivide(10, 3, out double result);
        if (ok)
            Console.WriteLine($"10 / 3 = {result:F4}");   // 4 decimal places

        // The discard `_` signals "I know there is an out parameter
        // but I intentionally do not need its value."
        bool fail = TryDivide(10, 0, out double _);
        Console.WriteLine($"Divide by zero succeeded? {fail}");   // False
    }

    /// <summary>Doubles <paramref name="value"/> in place via <c>ref</c>.</summary>
    public static void Double(ref int value)
    {
        // Because `value` is a ref alias, this writes directly into
        // the caller's variable — no return statement needed.
        value *= 2;   // shorthand for: value = value * 2;
    }

    /// <summary>
    /// Attempts to divide two integers using the TryX pattern.
    /// </summary>
    /// <param name="numerator">The dividend.</param>
    /// <param name="denominator">The divisor.  Division by zero returns false.</param>
    /// <param name="quotient">
    /// Receives the result on success, or 0 on failure.
    /// Declared as <c>out</c> because the caller supplies an uninitialised variable.
    /// </param>
    /// <returns><c>true</c> if division succeeded; <c>false</c> if denominator is 0.</returns>
    // DESIGN NOTE: the "TryX" pattern (bool return + out result) is the
    // idiomatic C# way to express "this operation might fail for a normal
    // reason."  It avoids exceptions for predictable, non-exceptional failures.
    // See also: int.TryParse, Dictionary<K,V>.TryGetValue.
    public static bool TryDivide(int numerator, int denominator, out double quotient)
    {
        if (denominator == 0)
        {
            // We MUST assign `quotient` on every path — the compiler
            // will refuse to compile the method otherwise.
            quotient = 0;
            return false;
        }

        // Without the cast, integer division would truncate: 10/3 → 3.
        // (double)numerator promotes the value to a double first, so
        // the division uses floating-point arithmetic: 10.0/3 → 3.333…
        quotient = (double)numerator / denominator;
        return true;
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION D — The Math class
    // ═════════════════════════════════════════════════════════════════

    private static void RunSectionD_MathClass()
    {
        Console.WriteLine("\n=== D: Math Methods ===");

        // System.Math is a static class — all members are called directly
        // on the class name.  You never write `new Math()`.

        Console.WriteLine($"Math.Sqrt(2)         = {Math.Sqrt(2):F6}");
        // Sqrt — square root.  Result is always double.

        Console.WriteLine($"Math.Pow(2, 10)      = {Math.Pow(2, 10)}");
        // Pow(base, exponent) — 2^10 = 1 024.

        Console.WriteLine($"Math.Abs(-42)        = {Math.Abs(-42)}");
        // Abs — absolute value (removes the sign).

        Console.WriteLine($"Math.Round(3.567, 2) = {Math.Round(3.567, 2)}");
        // Round(value, digits) — rounds to `digits` decimal places.

        Console.WriteLine($"Math.Max(7, 13)      = {Math.Max(7, 13)}");
        // Max — returns the larger of two values.
        // Related: Math.Min, Math.Floor, Math.Ceiling, Math.Truncate.
    }

    // ═════════════════════════════════════════════════════════════════
    // SECTION E — Method overloading
    // ═════════════════════════════════════════════════════════════════

    private static void RunSectionE_Overloading()
    {
        Console.WriteLine("\n=== E: Overloading ===");

        // The compiler selects the overload by matching argument TYPES
        // and COUNT at compile time.  There is no runtime overhead.
        Console.WriteLine(Add(2, 3));        // both ints      → int    overload → 5
        Console.WriteLine(Add(2.5, 3.1));    // both doubles   → double overload → 5.6
        Console.WriteLine(Add(1, 2, 3));     // three ints     → 3-arg  overload → 6
    }

    // Three overloads of Add — identical name, different signatures.
    // The compiler guarantees that call sites are unambiguous.

    /// <summary>Adds two integers.</summary>
    public static int    Add(int a, int b)        => a + b;

    /// <summary>Adds two doubles.</summary>
    public static double Add(double a, double b)  => a + b;

    /// <summary>Adds three integers by delegating to the two-argument overload.</summary>
    // Calling Add(a, b) from within another overload is a first example
    // of reuse — avoid writing the same logic twice.
    public static int    Add(int a, int b, int c) => Add(a, b) + c;
}
