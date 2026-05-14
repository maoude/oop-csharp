# Quiz Questions — Week 8 · Strings and StringBuilder

## Part 1 — String Fundamentals

**Q1.** Strings in C# are immutable. What does that mean in practice, and why does writing `s += "!"` inside a loop with 1 000 iterations waste memory?

**Q2.** What is the difference between `char.IsDigit('٣')` and checking `c >= '0' && c <= '9'`? Which is more correct for parsing user-entered ASCII numbers, and why?

**Q3.** `string` is a reference type, yet `string a = "hello"; string b = "hello"; Console.WriteLine(a == b);` prints `True`. How is this possible given that `==` on reference types usually compares references?

**Q4.** What is string interning? Give one scenario where it helps performance and one where relying on it would be a bug.

**Q5.** You have `string text = null;`. Which of the following throws a `NullReferenceException`, and which does not? (a) `text.Length`, (b) `string.IsNullOrEmpty(text)`, (c) `text == ""`.

## Part 2 — String Operations

**Q6.** Explain why `text.IndexOf("hello", StringComparison.OrdinalIgnoreCase)` is preferred over `text.ToLower().IndexOf("hello")` in production code. Name one correctness risk and one performance concern.

**Q7.** `"banana".Split('a')` returns `["b", "n", "n", ""]`. Where does the trailing empty string come from? How do you suppress it?

**Q8.** What does `StringSplitOptions.TrimEntries` (C# 8+) do, and when is it useful?

**Q9.** A colleague writes `if (s.Trim().Length == 0)` to check for blank input. What is the idiomatic C# replacement, and why is it safer?

**Q10.** What does the range indexer `text[2..5]` return for `"Hello"`, and what happens if the range goes out of bounds?

## Part 3 — StringBuilder

**Q11.** Describe the internal structure of `StringBuilder`. Why does appending to it not produce a new allocation on every call (most of the time)?

**Q12.** You must concatenate 500 strings. Give the rule of thumb for when `string.Join` is sufficient versus when you should reach for `StringBuilder` with a pre-set capacity.

**Q13.** What do `StringBuilder.Insert`, `StringBuilder.Remove`, and `StringBuilder.Replace` each do? Write a one-line example of each.

**Q14.** `StringBuilder sb = new(64);` — what does `64` mean, and what happens when the builder exceeds that capacity?

**Q15.** After building a string with `StringBuilder`, calling `.ToString()` produces a new `string` object. Is this a problem in a method that builds one result and returns it? When would it be a problem?

---

## Answers (instructor key)

> Remove or hide this section before distributing to students.

1. Immutability means every modification returns a new string object; the old one becomes garbage. In a loop, `s += "!"` allocates a new string on every iteration — O(n²) allocations for n iterations. Use `StringBuilder` for loops.

2. `char.IsDigit` accepts Unicode digits from any script (Arabic-Indic, Devanagari, etc.). For ASCII-only input, `c >= '0' && c <= '9'` is correct. For user-entered form data that must be purely numeric, the explicit ASCII check is more restrictive and usually intended. For locale-aware input, `char.IsDigit` is correct.

3. C# overloads `==` for `string` to call `string.Equals`, which does character-by-character comparison. It is NOT a reference comparison. Additionally, string interning may cause both literals to point to the same object in memory, but the overloaded `==` would be equal either way.

4. String interning stores one copy of each unique literal in a pool. Benefit: identical literal strings share memory. Risk: `object.ReferenceEquals(s1, s2)` returning `true` for two independently created strings with the same content could mask logic bugs if the developer expects reference inequality.

5. (a) throws NullReferenceException — `Length` is an instance member; (b) does NOT throw — `IsNullOrEmpty` is a null-safe static method designed for this; (c) does NOT throw — `==` on `string` handles null safely (returns `false` here).

6. Correctness: calling `.ToLower()` first creates a new string allocation and can produce wrong results for locale-specific case folding (e.g., Turkish `i`/`İ`). `OrdinalIgnoreCase` is locale-independent. Performance: `.ToLower()` allocates a new string even if the match is not found.

7. The trailing empty string comes from the final `'a'` in `"banana"` — there are no characters after it, so the last segment is empty. Suppress with `StringSplitOptions.RemoveEmptyEntries`.

8. `TrimEntries` removes leading/trailing whitespace from each split segment. Useful when parsing CSV or user-entered delimited lists where users may insert extra spaces around delimiters.

9. `string.IsNullOrWhiteSpace(s)` — it handles null, empty, and all-whitespace in one call, avoiding a `NullReferenceException` that `s.Trim().Length == 0` would throw when `s` is null.

10. `text[2..5]` returns `"llo"` (characters at indices 2, 3, 4). If the range exceeds the string length, an `ArgumentOutOfRangeException` is thrown at runtime.

11. `StringBuilder` holds a `char[]` buffer. When you `Append`, it writes into the buffer. If capacity is exceeded, it doubles (or grows to fit), copying the old buffer into a new larger one — amortized O(1) per append. No new string is allocated per append.

12. Rule of thumb: use `string.Join` for a fixed list known at compile time or up to ~50 items where clarity matters. Use `StringBuilder` with a pre-set capacity when you are concatenating in a loop, building a large document, or concatenating more than ~50 strings where performance is measurable.

13. `Insert(2, "X")` — inserts `"X"` at position 2; `Remove(2, 1)` — removes 1 character starting at position 2; `Replace("foo", "bar")` — replaces all occurrences of `"foo"` with `"bar"`.

14. `64` is the initial buffer capacity in characters. When the content grows past 64 characters, `StringBuilder` automatically allocates a larger internal buffer (typically doubling). Starting with a good estimate avoids early re-allocations.

15. Calling `.ToString()` once at the end is not a problem — that is the intended usage pattern. It would be a problem if you called `.ToString()` in a tight loop and then kept appending, because each call produces a new immutable string while the builder continues accumulating.
