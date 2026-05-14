/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: efficient string assembly with StringBuilder.
 *           Practice: Append, separator logic, word reversal, numbered lists.
 */
using System.Text;

namespace OopCsharp.Week8.Part3_StringBuilder.Exercises;

// ============================================================
// Exercise 1 — TextBuilder
//
// Implement four methods that build strings with StringBuilder.
// Do NOT use string += inside any loop.
// ============================================================

public class TextBuilder
{
    // TODO 1a: Join(IEnumerable<string> parts, string separator)
    //   Concatenate parts with separator between adjacent items, using StringBuilder.
    //   Empty sequence → return "".
    //   Throw ArgumentNullException if parts is null.
    //   Hint: use a bool first flag to avoid a leading separator.
    public string Join(IEnumerable<string> parts, string separator) =>
        throw new NotImplementedException();

    // TODO 1b: Repeat(string text, int times)
    //   Return text concatenated times times (e.g. Repeat("ab", 3) → "ababab").
    //   times = 0 → return "".
    //   Throw ArgumentNullException if text is null.
    //   Throw ArgumentOutOfRangeException if times < 0.
    //   Hint: new StringBuilder(text.Length * times) avoids all re-allocations.
    public string Repeat(string text, int times) => throw new NotImplementedException();

    // TODO 1c: ReverseWords(string sentence)
    //   Return the words of sentence in reverse order, separated by a single space.
    //   Whitespace-only or empty input → return "".
    //   Throw ArgumentNullException if sentence is null.
    //   Example: "Hello World!" → "World! Hello"
    public string ReverseWords(string sentence) => throw new NotImplementedException();

    // TODO 1d: BuildNumberedList(string[] items)
    //   Return a numbered list where each line has the format "N. item",
    //   with lines separated by '\n' (no trailing newline).
    //   Empty array → return "".
    //   Throw ArgumentNullException if items is null.
    //   Example: ["Alpha", "Beta"] → "1. Alpha\n2. Beta"
    public string BuildNumberedList(string[] items) => throw new NotImplementedException();
}
