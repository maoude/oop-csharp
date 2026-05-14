/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Ex1_TextBuilder.
 *           Do not open until after submitting your own implementation.
 */
using System.Text;

namespace OopCsharp.Week8.Part3_StringBuilder.Solutions;

public class Sol1_TextBuilder
{
    /// <summary>Joins parts with separator using StringBuilder.</summary>
    public string Join(IEnumerable<string> parts, string separator)
    {
        ArgumentNullException.ThrowIfNull(parts);
        separator ??= "";
        var sb = new StringBuilder();
        bool first = true;
        foreach (string part in parts)
        {
            if (!first) sb.Append(separator);
            sb.Append(part);
            first = false;
        }
        return sb.ToString();
    }

    /// <summary>Returns text repeated times times.</summary>
    public string Repeat(string text, int times)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (times < 0)
            throw new ArgumentOutOfRangeException(nameof(times), "times must be non-negative.");
        if (times == 0) return "";
        var sb = new StringBuilder(text.Length * times);
        for (int i = 0; i < times; i++) sb.Append(text);
        return sb.ToString();
    }

    /// <summary>Returns the words of sentence in reverse order.</summary>
    public string ReverseWords(string sentence)
    {
        ArgumentNullException.ThrowIfNull(sentence);
        string[] words = sentence.Split(
            new char[]{ ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries);
        if (words.Length == 0) return "";
        var sb = new StringBuilder();
        for (int i = words.Length - 1; i >= 0; i--)
        {
            sb.Append(words[i]);
            if (i > 0) sb.Append(' ');
        }
        return sb.ToString();
    }

    /// <summary>Builds a numbered list with lines separated by '\n'. Empty array → "".</summary>
    public string BuildNumberedList(string[] items)
    {
        ArgumentNullException.ThrowIfNull(items);
        if (items.Length == 0) return "";
        var sb = new StringBuilder();
        for (int i = 0; i < items.Length; i++)
        {
            if (i > 0) sb.Append('\n');
            sb.Append(i + 1).Append(". ").Append(items[i]);
        }
        return sb.ToString();
    }
}
