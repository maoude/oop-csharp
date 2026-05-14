# Exercises — Week 8 · Strings and StringBuilder

## Part 1 · String Fundamentals — `Ex1_StringBasics.cs`

Core string and `char` operations. All methods live in the `StringBasics` class.

**StringBasics**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `IsVowel` | `bool IsVowel(char c)` | Returns `true` for a, e, i, o, u (case-insensitive) |
| `CountChars` | `int CountChars(string text, char target)` | Count occurrences of `target` in `text`; throws `ArgumentNullException` if `text` is null |
| `ReverseString` | `string ReverseString(string text)` | Returns the reversed string; empty → `""`; throws `ArgumentNullException` if null |
| `IsPalindrome` | `bool IsPalindrome(string text)` | `true` when the string reads the same forwards and backwards (case-insensitive); throws `ArgumentNullException` if null |
| `IsAllDigits` | `bool IsAllDigits(string text)` | `true` when every character satisfies `char.IsDigit`; empty string → `false`; throws `ArgumentNullException` if null |
| `CountWords` | `int CountWords(string? text)` | Count whitespace-separated tokens; null or whitespace-only → `0` |

Test class: `StudentWeek8Part1_Ex1Tests` · **13 tests**

---

## Part 2 · String Operations

### Exercise 1 — `Ex1_StringSearch.cs`

Search and locate patterns inside strings. All methods live in the `StringSearch` class.

**StringSearch**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `ContainsIgnoreCase` | `bool ContainsIgnoreCase(string text, string pattern)` | Case-insensitive `Contains`; throws `ArgumentNullException` for null args |
| `IndexOfIgnoreCase` | `int IndexOfIgnoreCase(string text, string pattern)` | Returns index of first match (case-insensitive); `-1` if not found; throws on null |
| `CountSubstringOccurrences` | `int CountSubstringOccurrences(string text, string pattern)` | Count non-overlapping occurrences; `0` if none; `0` for empty pattern; throws on null |
| `StartsWithAny` | `bool StartsWithAny(string text, string[] prefixes)` | `true` if text starts with at least one prefix; null or empty `prefixes` → `false`; throws if `text` is null |

Test class: `StudentWeek8Part2_Ex1Tests` · **7 tests**

### Exercise 2 — `Ex2_StringManipulator.cs`

Transform and reshape strings. All methods live in the `StringManipulator` class.

**StringManipulator**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `TitleCase` | `string TitleCase(string text)` | First letter of every word upper-cased, rest lower-cased; throws `ArgumentNullException` if null |
| `Truncate` | `string Truncate(string text, int maxLength)` | If `text.Length > maxLength`, return the first `maxLength − 3` characters followed by `"..."`; otherwise return unchanged; throws `ArgumentNullException` if null; throws `ArgumentOutOfRangeException` if `maxLength < 3` |
| `NormaliseWhitespace` | `string NormaliseWhitespace(string text)` | Trim leading/trailing whitespace and collapse interior runs to a single space; throws `ArgumentNullException` if null |
| `ExtractBetween` | `string? ExtractBetween(string text, char open, char close)` | Returns the content between the first `open` and the first `close` that follows it; `null` if either delimiter is missing; throws `ArgumentNullException` if `text` is null |

Test class: `StudentWeek8Part2_Ex2Tests` · **7 tests**

---

## Part 3 · StringBuilder — `Ex1_TextBuilder.cs`

Build strings efficiently using `System.Text.StringBuilder`. All methods live in the `TextBuilder` class.

**TextBuilder**

| Method | Signature | Behaviour |
|--------|-----------|-----------|
| `Join` | `string Join(IEnumerable<string> parts, string separator)` | Concatenate `parts` with `separator` between each adjacent pair using `StringBuilder`; empty sequence → `""`; throws `ArgumentNullException` if `parts` is null |
| `Repeat` | `string Repeat(string text, int times)` | Return `text` concatenated `times` times; `0` → `""`; throws `ArgumentNullException` if `text` is null; throws `ArgumentOutOfRangeException` if `times < 0` |
| `ReverseWords` | `string ReverseWords(string sentence)` | Reverse the order of words (whitespace-separated tokens); whitespace-only or empty → `""`; throws `ArgumentNullException` if null |
| `BuildNumberedList` | `string BuildNumberedList(string[] items)` | Build a numbered list where each line is `"N. item"`, lines separated by `\n`; empty array → `""`; throws `ArgumentNullException` if null |

Test class: `StudentWeek8Part3_Ex1Tests` · **12 tests**
