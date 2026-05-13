/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     1 — Introduction to C# · Methods · Console I/O
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate the anatomy of a minimal C# program:
 *           console output, console input, string interpolation,
 *           and calling a private helper method.
 *           Run this file live during the lecture and narrate each line.
 */

// ─────────────────────────────────────────────────────────────────────────────
// FILE-SCOPED NAMESPACE (C# 10+)
// A namespace groups related types so their names don't clash with types
// in other libraries.  The file-scoped form (ending with ;) avoids one
// level of indentation compared to the classic block form.
// ─────────────────────────────────────────────────────────────────────────────
namespace OopCsharp.Week1.Part1_HelloWorld;

/// <summary>
/// DEMO 01 — Hello World and Program Anatomy.
/// Shows the minimum code needed to write output, read input, and
/// call a helper method in C#.
/// </summary>
/// <remarks>
/// Instructor: call <see cref="Run"/> from a top-level statement or a test
/// harness so the class itself is free of a <c>Main</c> entry point.
/// This keeps the demo reusable across contexts.
/// </remarks>
public static class Demo01_HelloWorld
{
    // ─────────────────────────────────────────────────────────────────
    // STATIC CLASS
    // The `static` modifier means this class cannot be instantiated.
    // It is used here because every method is a utility — there is no
    // object "state" to maintain.  Compare with Week 3 where we add
    // fields and create instances with `new`.
    // ─────────────────────────────────────────────────────────────────

    /// <summary>
    /// Entry point for the demo.  Illustrates console output/input and
    /// string interpolation step by step.
    /// </summary>
    public static void Run()
    {
        // ── STEP 1: Writing to the console ───────────────────────────
        // Console.WriteLine  writes the text AND moves the cursor to the
        //                    next line (like pressing Enter).
        // Console.Write      writes the text and STAYS on the same line,
        //                    so the user's input appears right after the prompt.
        Console.WriteLine("Hello, World!");
        Console.Write("Enter your name: ");

        // ── STEP 2: Reading a line of text ───────────────────────────
        // Console.ReadLine() returns a `string?` (nullable string).
        // It returns null only when the input stream is redirected and
        // reaches its end — which never happens in normal console use.
        // The null-coalescing operator `??` provides a fallback value so
        // the rest of the code never has to deal with null.
        //
        //   left ?? right  →  returns left if left is not null,
        //                     otherwise returns right.
        string name = Console.ReadLine() ?? "Student";

        // ── STEP 3: String interpolation ($"...") ────────────────────
        // Placing $ before the opening quote turns the string into a
        // *template*.  Anything inside { } is evaluated as C# code and
        // converted to a string automatically via ToString().
        // This is more readable than concatenation ("Hello, " + name + "!").
        Console.WriteLine($"Hello, {name}! Welcome to OOP with C#.");

        // ── STEP 4: Variables and arithmetic ─────────────────────────
        // `int` is a 32-bit signed integer — the default choice for
        // whole-number values.  Variables must be declared before use.
        int a = 7;
        int b = 3;

        // Arithmetic expressions inside { } are evaluated at runtime.
        // The result is then converted to string for display.
        Console.WriteLine($"{a} + {b} = {a + b}");   // 7 + 3 = 10
        Console.WriteLine($"{a} * {b} = {a * b}");   // 7 * 3 = 21

        // ── STEP 5: Calling a helper method ──────────────────────────
        // Decomposing a task into named methods is the first step toward
        // readable code.  `PrintSeparator` says *what* happens; the
        // caller does not need to know *how* the separator is built.
        PrintSeparator();
        Console.WriteLine("Demo complete.");
    }

    // ─────────────────────────────────────────────────────────────────
    // PRIVATE METHOD
    // `private` means this method is only visible inside this class.
    // Callers (including students) cannot call it directly — they can
    // only observe its effect through Run().
    // This is the first hint at *access control*, which becomes central
    // in Week 3 when we discuss encapsulation.
    // ─────────────────────────────────────────────────────────────────

    /// <summary>
    /// Prints a horizontal separator line of 40 dashes.
    /// </summary>
    private static void PrintSeparator()
    {
        // `new string(char, count)` is a constructor that creates a
        // string by repeating a single character `count` times.
        // This avoids a loop and reads as a clear statement of intent.
        Console.WriteLine(new string('-', 40));
    }
}
