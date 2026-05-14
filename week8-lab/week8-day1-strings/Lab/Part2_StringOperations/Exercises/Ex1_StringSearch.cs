/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: locating and counting patterns inside strings.
 *           Practice: StringComparison, IndexOf loop, prefix matching.
 */
namespace OopCsharp.Week8.Part2_StringOperations.Exercises;

// ============================================================
// Exercise 1 — StringSearch
//
// Implement four search methods. Always pass StringComparison
// when calling IndexOf / Contains — never call .ToLower() first.
// Throw ArgumentNullException for any null string argument.
// ============================================================

public class StringSearch
{
    // TODO 1a: ContainsIgnoreCase(string text, string pattern)
    //   Return true when pattern appears anywhere in text, ignoring case.
    //   Use string.Contains with StringComparison.OrdinalIgnoreCase.
    //   Throw ArgumentNullException if either argument is null.
    public bool ContainsIgnoreCase(string text, string pattern) =>
        throw new NotImplementedException();

    // TODO 1b: IndexOfIgnoreCase(string text, string pattern)
    //   Return the zero-based index of the first occurrence of pattern in text,
    //   ignoring case. Return -1 if not found.
    //   Throw ArgumentNullException if either argument is null.
    public int IndexOfIgnoreCase(string text, string pattern) =>
        throw new NotImplementedException();

    // TODO 1c: CountSubstringOccurrences(string text, string pattern)
    //   Count non-overlapping occurrences of pattern in text.
    //   Return 0 if not found or if pattern is empty.
    //   Throw ArgumentNullException if either argument is null.
    //   Hint: use an IndexOf loop, advancing by pattern.Length each iteration.
    public int CountSubstringOccurrences(string text, string pattern) =>
        throw new NotImplementedException();

    // TODO 1d: StartsWithAny(string text, string[] prefixes)
    //   Return true if text starts with at least one string in prefixes.
    //   Return false if prefixes is null or empty.
    //   Throw ArgumentNullException if text is null.
    public bool StartsWithAny(string text, string[] prefixes) =>
        throw new NotImplementedException();
}
