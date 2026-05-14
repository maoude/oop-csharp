/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex2_StringManipulator.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week8.Part2_StringOperations.Solutions;

public class Sol2_StringManipulator
{
    /// <summary>Returns text in title case: first letter upper, rest lower, for every word.</summary>
    public string TitleCase(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
            words[i] = char.ToUpper(words[i][0]) + words[i][1..].ToLower();
        return string.Join(' ', words);
    }

    /// <summary>Truncates text to maxLength characters, appending "..." if truncated.</summary>
    public string Truncate(string text, int maxLength)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (maxLength < 3)
            throw new ArgumentOutOfRangeException(nameof(maxLength), "maxLength must be at least 3.");
        if (text.Length <= maxLength) return text;
        return text[..(maxLength - 3)] + "...";
    }

    /// <summary>Trims edges and collapses interior whitespace runs to a single space.</summary>
    public string NormaliseWhitespace(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        string[] tokens = text.Split(
            new char[]{ ' ', '\t', '\n', '\r' },
            StringSplitOptions.RemoveEmptyEntries);
        return string.Join(' ', tokens);
    }

    /// <summary>Returns content between the first open and the first close that follows it, or null.</summary>
    public string? ExtractBetween(string text, char open, char close)
    {
        ArgumentNullException.ThrowIfNull(text);
        int start = text.IndexOf(open);
        if (start < 0) return null;
        int end = text.IndexOf(close, start + 1);
        if (end < 0) return null;
        return text[(start + 1)..end];
    }
}
