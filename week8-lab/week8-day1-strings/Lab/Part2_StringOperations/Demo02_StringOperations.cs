/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     8 — Strings and StringBuilder
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Instructor demo — search methods and StringComparison, manipulation.
 *           Read this file before starting Exercises 1 and 2 of Part 2.
 */
namespace OopCsharp.Week8.Part2_StringOperations;

public static class Demo02_StringOperations
{
    public static void Run()
    {
        // ── 1. Search: always specify StringComparison ────────────────────────
        string text = "Hello, World!";

        // BAD: locale-sensitive, allocates a new string
        bool badContains = text.ToLower().Contains("world");

        // GOOD: locale-independent, no extra allocation
        bool goodContains = text.Contains("world", StringComparison.OrdinalIgnoreCase);
        int  index        = text.IndexOf("World", StringComparison.OrdinalIgnoreCase);
        bool starts       = text.StartsWith("hello", StringComparison.OrdinalIgnoreCase);
        bool ends         = text.EndsWith("WORLD!", StringComparison.OrdinalIgnoreCase);

        Console.WriteLine($"contains={goodContains}  index={index}  starts={starts}  ends={ends}");

        // ── 2. Counting non-overlapping occurrences ───────────────────────────
        static int CountOccurrences(string haystack, string needle)
        {
            int count = 0, pos = 0;
            while ((pos = haystack.IndexOf(needle, pos, StringComparison.Ordinal)) >= 0)
            {
                count++;
                pos += needle.Length;   // advance past the found match
            }
            return count;
        }
        Console.WriteLine(CountOccurrences("banana", "an"));  // 2

        // ── 3. Split with multiple delimiters and options ─────────────────────
        string line = "\tAlice  42  Engineer  ";
        string[] tokens = line.Split(
            new char[]{ ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        // ["Alice", "42", "Engineer"]

        foreach (string tok in tokens)
            Console.Write($"[{tok}] ");
        Console.WriteLine();

        // ── 4. TitleCase manually ─────────────────────────────────────────────
        static string TitleCase(string input)
        {
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
                words[i] = char.ToUpper(words[i][0]) + words[i][1..].ToLower();
            return string.Join(' ', words);
        }
        Console.WriteLine(TitleCase("the QUICK brown FOX"));  // "The Quick Brown Fox"

        // ── 5. Truncating with ellipsis ───────────────────────────────────────
        static string Truncate(string s, int maxLen)
        {
            if (s.Length <= maxLen) return s;
            return s[..(maxLen - 3)] + "...";
        }
        Console.WriteLine(Truncate("Hello, World!", 8));   // "Hello..."
        Console.WriteLine(Truncate("Hi", 8));              // "Hi"

        // ── 6. Extracting content between delimiters ──────────────────────────
        string tagged = "Name: <Alice> — Age: <30>";
        int open  = tagged.IndexOf('<');
        int close = tagged.IndexOf('>', open + 1);
        if (open >= 0 && close > open)
            Console.WriteLine(tagged[(open + 1)..close]);  // "Alice"
    }
}
