/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_StringSearch.
 *           Do not open until after submitting your own implementation.
 */
namespace OopCsharp.Week8.Part2_StringOperations.Solutions;

public class Sol1_StringSearch
{
    /// <summary>Case-insensitive Contains using OrdinalIgnoreCase.</summary>
    public bool ContainsIgnoreCase(string text, string pattern)
    {
        ArgumentNullException.ThrowIfNull(text);
        ArgumentNullException.ThrowIfNull(pattern);
        return text.Contains(pattern, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>Returns the index of the first case-insensitive match, or -1.</summary>
    public int IndexOfIgnoreCase(string text, string pattern)
    {
        ArgumentNullException.ThrowIfNull(text);
        ArgumentNullException.ThrowIfNull(pattern);
        return text.IndexOf(pattern, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>Counts non-overlapping occurrences of pattern in text.</summary>
    public int CountSubstringOccurrences(string text, string pattern)
    {
        ArgumentNullException.ThrowIfNull(text);
        ArgumentNullException.ThrowIfNull(pattern);
        if (pattern.Length == 0) return 0;

        int count = 0, pos = 0;
        while ((pos = text.IndexOf(pattern, pos, StringComparison.Ordinal)) >= 0)
        {
            count++;
            pos += pattern.Length;
        }
        return count;
    }

    /// <summary>Returns true if text starts with at least one of the supplied prefixes.</summary>
    public bool StartsWithAny(string text, string[] prefixes)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (prefixes == null || prefixes.Length == 0) return false;
        foreach (string prefix in prefixes)
            if (text.StartsWith(prefix)) return true;
        return false;
    }
}
