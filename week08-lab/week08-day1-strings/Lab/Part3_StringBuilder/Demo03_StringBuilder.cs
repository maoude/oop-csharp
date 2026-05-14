/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — why StringBuilder exists and how to use it.
 *           Read this file before starting Exercise 1 of Part 3.
 */
using System.Text;

namespace OopCsharp.Week8.Part3_StringBuilder;

public static class Demo03_StringBuilder
{
    public static void Run()
    {
        // ── 1. The problem: string += in a loop is O(n²) ─────────────────────
        // Each += allocates a brand-new string and copies all previous content.
        // For 1 000 iterations that is ~500 000 character copies.

        string slow = "";
        for (int i = 0; i < 5; i++)
            slow += $"item{i} ";   // 5 allocations — fine here, disastrous at scale

        Console.WriteLine(slow.Trim());

        // ── 2. StringBuilder: amortised O(1) append ──────────────────────────
        var sb = new StringBuilder();          // default initial capacity: 16
        for (int i = 0; i < 5; i++)
            sb.Append($"item{i} ");            // writes into internal char[] buffer

        string fast = sb.ToString();           // ONE allocation at the end
        Console.WriteLine(fast.Trim());

        // ── 3. Pre-set capacity to avoid re-allocations ───────────────────────
        // If you know the approximate final length, hint the constructor.
        var sb2 = new StringBuilder(256);
        sb2.Append("Hello");
        sb2.Append(", ");
        sb2.Append("World!");
        Console.WriteLine(sb2);               // implicit ToString()

        // ── 4. Other StringBuilder methods ───────────────────────────────────
        var sb3 = new StringBuilder("Hello World");

        sb3.Insert(5, ",");                   // "Hello, World"
        Console.WriteLine(sb3);

        sb3.Replace("World", "C#");           // "Hello, C#"
        Console.WriteLine(sb3);

        sb3.Remove(5, 1);                     // remove the comma → "Hello C#"
        Console.WriteLine(sb3);

        sb3.AppendLine();                     // append + newline
        sb3.AppendFormat("Length was {0}", sb3.Length);
        Console.WriteLine(sb3);

        // ── 5. Building a separator-joined list ──────────────────────────────
        string[] fruits = { "apple", "banana", "cherry" };
        var joined = new StringBuilder();
        for (int i = 0; i < fruits.Length; i++)
        {
            if (i > 0) joined.Append(", ");
            joined.Append(fruits[i]);
        }
        Console.WriteLine(joined);   // "apple, banana, cherry"

        // ── 6. Reversing word order ────────────────────────────────────────────
        string sentence = "Hello beautiful World";
        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var reversed = new StringBuilder();
        for (int i = words.Length - 1; i >= 0; i--)
        {
            reversed.Append(words[i]);
            if (i > 0) reversed.Append(' ');
        }
        Console.WriteLine(reversed);  // "World beautiful Hello"
    }
}
