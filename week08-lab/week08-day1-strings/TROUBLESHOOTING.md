# Troubleshooting — Week 8 · Strings and StringBuilder

## Build errors

### CS0103 — The name 'StringBuilder' does not exist in the current context

**Cause:** `System.Text` namespace not imported.  
**Fix:** Add `using System.Text;` at the top of the file, or rely on `ImplicitUsings` — ensure your `.csproj` has `<ImplicitUsings>enable</ImplicitUsings>`.

---

### CS8600 — Converting null literal or possible null value to non-nullable type

**Cause:** Returning `null` from a method declared as `string` (non-nullable).  
**Fix:** Change the return type to `string?` for methods that can legitimately return null (e.g., `ExtractBetween`), or ensure the method never returns null if the return type is `string`.

---

### CS1503 — Argument type mismatch on Split

**Cause:** Calling `text.Split(null, ...)` — the compiler cannot infer which overload to use.  
**Fix:** Be explicit: `text.Split(new char[]{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)` or `text.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)`.

---

### CS0019 — Operator '+=' cannot be applied to string in a loop

**Cause:** Not an error — this compiles. The issue is performance. See test failures below.  
**Note:** If a test that checks the result of `Repeat` or `BuildNumberedList` passes but is slow, you are likely using `+=` in a loop instead of `StringBuilder`.

---

## Test failures

### "Expected: 'Hello World' — Actual: 'Hello  World'" (double space)

**Cause:** `TitleCase` uses `Split(' ')` which preserves empty strings between consecutive spaces, then re-joins without collapsing.  
**Fix:** Use `Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)` to discard empty segments, then `string.Join(' ', words)`.

---

### "Expected: 3 — Actual: 0" in CountSubstringOccurrences

**Cause:** Forgetting to advance `index` by `pattern.Length` after each match. If you advance by `1`, you may find overlapping matches (overcounting) or miss the next boundary.  
**Fix:** `index += pattern.Length;` inside the loop.

---

### "IsPalindrome: Expected True — Actual False" for `"Racecar"`

**Cause:** Comparing the original string against its reverse without normalising case first.  
**Fix:** Apply `.ToLowerInvariant()` (or `.ToLower()`) to both sides before comparing.

---

### "NullReferenceException in CountWords when passed null"

**Cause:** Calling `text.Split(...)` directly when `text` could be null.  
**Fix:** Guard with `if (string.IsNullOrWhiteSpace(text)) return 0;` at the top of the method.

---

### "ArgumentNullException not thrown — test expected exception"

**Cause:** The method silently returns a default value (e.g., `""` or `0`) instead of throwing.  
**Fix:** Add `ArgumentNullException.ThrowIfNull(text)` (C# 10+) or `if (text is null) throw new ArgumentNullException(nameof(text));` before any processing.

---

### "Expected: 'He...' — Actual: 'Hello...'" for Truncate("Hello, World!", 5)

**Cause:** Using `text[..maxLength]` instead of `text[..(maxLength - 3)]` before appending `"..."`.  
**Fix:** The truncated portion must be `maxLength - 3` characters so that the result with `"..."` appended is exactly `maxLength` characters long.

---

### "Expected: 'World! Hello' — Actual: 'Hello World!'" in ReverseWords

**Cause:** Reversing the characters of the string instead of the order of the words.  
**Fix:** Split into words, iterate from the last word to the first, and append each to a `StringBuilder`.

---

## Runtime behaviour

### `StringBuilder.ToString()` called inside the loop

**Symptom:** Correct output, but each call allocates a full new string on every iteration.  
**Fix:** Call `.ToString()` exactly once, after the loop completes.

---

### `IndexOf` returns `-1` unexpectedly when the string is there

**Cause:** A `StringComparison` mismatch — the text contains `"HELLO"` but you search for `"hello"` without `OrdinalIgnoreCase`.  
**Fix:** Pass `StringComparison.OrdinalIgnoreCase` as the third argument to `IndexOf`.

---

### `Split` on an empty string returns one element, not zero

**Cause:** `"".Split(' ')` returns `[""]` (an array with one empty string), not `[]`.  
**Fix:** Combine with `StringSplitOptions.RemoveEmptyEntries`, or guard with `string.IsNullOrWhiteSpace` first.
