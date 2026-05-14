/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: transforming and reshaping strings.
 *           Practice: TitleCase, truncation, whitespace normalisation,
 *           delimiter-based extraction.
 */
namespace OopCsharp.Week8.Part2_StringOperations.Exercises;

// ============================================================
// Exercise 2 — StringManipulator
//
// Implement four transformation methods.
// All methods throw ArgumentNullException when text is null.
// ============================================================

public class StringManipulator
{
    // TODO 2a: TitleCase(string text)
    //   Return text with the first letter of every word upper-cased and
    //   the remaining letters lower-cased (e.g. "the QUICK fox" → "The Quick Fox").
    //   Throw ArgumentNullException if text is null.
    //   Hint: Split on spaces (RemoveEmptyEntries), transform each word, then Join.
    public string TitleCase(string text) => throw new NotImplementedException();

    // TODO 2b: Truncate(string text, int maxLength)
    //   If text.Length > maxLength, return the first (maxLength - 3) characters
    //   followed by "..." so the result is exactly maxLength characters long.
    //   If text.Length <= maxLength, return text unchanged.
    //   Throw ArgumentNullException if text is null.
    //   Throw ArgumentOutOfRangeException if maxLength < 3.
    public string Truncate(string text, int maxLength) => throw new NotImplementedException();

    // TODO 2c: NormaliseWhitespace(string text)
    //   Trim leading/trailing whitespace, then collapse any run of internal
    //   whitespace characters to a single space
    //   (e.g. "  Hello   World  " → "Hello World").
    //   Throw ArgumentNullException if text is null.
    public string NormaliseWhitespace(string text) => throw new NotImplementedException();

    // TODO 2d: ExtractBetween(string text, char open, char close)
    //   Return the substring between the first occurrence of open and the
    //   first occurrence of close that follows it.
    //   Return null if open is not found, or if no close follows open.
    //   Throw ArgumentNullException if text is null.
    //   Example: ExtractBetween("Hello (World)!", '(', ')') → "World"
    public string? ExtractBetween(string text, char open, char close) =>
        throw new NotImplementedException();
}
