/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_StringBasics.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week8.Part1_StringFundamentals.Solutions;

public class Sol1_StringBasics
{
    /// <summary>Returns true when c is a vowel (a, e, i, o, u), case-insensitive.</summary>
    public bool IsVowel(char c) => "aeiouAEIOU".Contains(c);

    /// <summary>Counts occurrences of target in text.</summary>
    public int CountChars(string text, char target)
    {
        ArgumentNullException.ThrowIfNull(text);
        int count = 0;
        foreach (char c in text)
            if (c == target) count++;
        return count;
    }

    /// <summary>Returns the reversed string. Empty string returns "".</summary>
    public string ReverseString(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (text.Length == 0) return text;
        char[] chars = text.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    /// <summary>Returns true when text reads the same forwards and backwards, ignoring case.</summary>
    public bool IsPalindrome(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        string lower    = text.ToLowerInvariant();
        char[] chars    = lower.ToCharArray();
        Array.Reverse(chars);
        string reversed = new string(chars);
        return lower == reversed;
    }

    /// <summary>Returns true when every character satisfies char.IsDigit. Empty → false.</summary>
    public bool IsAllDigits(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (text.Length == 0) return false;
        foreach (char c in text)
            if (!char.IsDigit(c)) return false;
        return true;
    }

    /// <summary>Counts whitespace-separated tokens. Null or whitespace-only → 0.</summary>
    public int CountWords(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Split(new char[]{ ' ', '\t', '\n', '\r' },
                          StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
