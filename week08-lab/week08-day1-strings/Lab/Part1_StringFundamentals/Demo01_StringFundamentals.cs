/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — string immutability, char methods, basic operations.
 *           Read this file before starting Exercise 1.
 */
namespace OopCsharp.Week8.Part1_StringFundamentals;

public static class Demo01_StringFundamentals
{
    public static void Run()
    {
        // ── 1. char is a value type ───────────────────────────────────────────
        char letter = 'A';
        char lower  = char.ToLower(letter);       // 'a'
        bool isVowel   = "aeiouAEIOU".Contains(letter);
        bool isLetter  = char.IsLetter(letter);   // true
        bool isDigit   = char.IsDigit('7');        // true
        bool isWhite   = char.IsWhiteSpace('\t');  // true

        Console.WriteLine($"letter={letter}  lower={lower}  isVowel={isVowel}");
        Console.WriteLine($"IsLetter={isLetter}  IsDigit={isDigit}  IsWhiteSpace={isWhite}");

        // ── 2. Strings are immutable ──────────────────────────────────────────
        string s = "Hello";
        string t = s;         // both point to the SAME object in memory
        s = s + ", World!";   // s now points to a NEW object; t is unchanged

        Console.WriteLine($"s={s}");   // "Hello, World!"
        Console.WriteLine($"t={t}");   // "Hello"  ← unchanged

        // Implication: s += "!" in a loop with 1000 iterations allocates
        // 1000 new string objects.  Prefer StringBuilder for that case.

        // ── 3. Basic string properties and methods ────────────────────────────
        string word = "  Hello, World!  ";
        Console.WriteLine(word.Length);                   // 18 (includes spaces)
        Console.WriteLine(word.Trim());                   // "Hello, World!"
        Console.WriteLine(word.ToUpper());                // "  HELLO, WORLD!  "
        Console.WriteLine(word.ToLowerInvariant());       // "  hello, world!  "
        Console.WriteLine(word.Replace("World", "C#"));   // "  Hello, C#!  "
        Console.WriteLine(word.Contains("World"));        // True
        Console.WriteLine(word.IndexOf("World"));         // 9

        // ── 4. Substring and range indexers ──────────────────────────────────
        string sentence = "The quick brown fox";
        Console.WriteLine(sentence.Substring(4, 5));      // "quick"
        Console.WriteLine(sentence[4..9]);                // "quick"  (C# 8 range)
        Console.WriteLine(sentence[^3..]);                // "fox"    (from end)

        // ── 5. Splitting and joining ──────────────────────────────────────────
        string csv = "Alice, Bob,  Charlie  , Dana";
        string[] names = csv.Split(',', StringSplitOptions.TrimEntries
                                      | StringSplitOptions.RemoveEmptyEntries);
        foreach (string name in names)
            Console.WriteLine($"  [{name}]");  // each trimmed

        string rejoined = string.Join(" | ", names);
        Console.WriteLine(rejoined);   // "Alice | Bob | Charlie | Dana"

        // ── 6. Null-safe checks ───────────────────────────────────────────────
        string? input = null;
        Console.WriteLine(string.IsNullOrEmpty(input));       // True
        Console.WriteLine(string.IsNullOrWhiteSpace("   ")); // True
        // input.Length  ← would throw NullReferenceException

        // ── 7. Reversing a string (must go through char[]) ───────────────────
        string original = "abcde";
        char[] chars = original.ToCharArray();
        Array.Reverse(chars);
        string reversed = new string(chars);
        Console.WriteLine(reversed);  // "edcba"
    }
}
