/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: fundamental char and string operations.
 *           Practice: char methods, immutability, reversal, palindrome detection.
 */
namespace OopCsharp.Week8.Part1_StringFundamentals.Exercises;

// ============================================================
// Exercise 1 — StringBasics
//
// Implement six methods that cover char classification,
// character counting, string reversal, and word counting.
// Throw ArgumentNullException for any null string argument
// unless the method signature uses string? (CountWords).
// ============================================================

public class StringBasics
{
    // TODO 1a: IsVowel(char c)
    //   Return true when c is one of a, e, i, o, u (case-insensitive).
    //   Hint: "aeiouAEIOU".Contains(c) is one clean approach.
    public bool IsVowel(char c) => throw new NotImplementedException();

    // TODO 1b: CountChars(string text, char target)
    //   Return how many times target appears in text.
    //   Throw ArgumentNullException if text is null.
    public int CountChars(string text, char target) => throw new NotImplementedException();

    // TODO 1c: ReverseString(string text)
    //   Return the reversed string.
    //   Empty string → return "".
    //   Throw ArgumentNullException if text is null.
    //   Hint: ToCharArray() + Array.Reverse() + new string(chars).
    public string ReverseString(string text) => throw new NotImplementedException();

    // TODO 1d: IsPalindrome(string text)
    //   Return true when text reads the same forwards and backwards,
    //   ignoring case (e.g. "Racecar" → true).
    //   Throw ArgumentNullException if text is null.
    public bool IsPalindrome(string text) => throw new NotImplementedException();

    // TODO 1e: IsAllDigits(string text)
    //   Return true when every character in text satisfies char.IsDigit.
    //   Empty string → return false.
    //   Throw ArgumentNullException if text is null.
    public bool IsAllDigits(string text) => throw new NotImplementedException();

    // TODO 1f: CountWords(string? text)
    //   Return the number of whitespace-separated, non-empty tokens.
    //   Null or whitespace-only input → return 0 (do not throw).
    public int CountWords(string? text) => throw new NotImplementedException();
}
