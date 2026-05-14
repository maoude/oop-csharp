# Checklist — Week 8 · Strings and StringBuilder

## Part 1 — String Fundamentals

- [ ] **W8.P1.Ex1 — StringBasics** · `StudentWeek8Part1_Ex1Tests` · 13 tests
  - [ ] `IsVowel()` returns `true` for lowercase vowels
  - [ ] `IsVowel()` returns `true` for uppercase vowels
  - [ ] `IsVowel()` returns `false` for consonants
  - [ ] `CountChars()` returns correct count when target appears multiple times
  - [ ] `CountChars()` throws `ArgumentNullException` for null text
  - [ ] `ReverseString()` reverses a normal string
  - [ ] `ReverseString()` throws `ArgumentNullException` for null
  - [ ] `ReverseString()` returns `""` for empty input
  - [ ] `IsPalindrome()` returns `true` for a lowercase palindrome
  - [ ] `IsPalindrome()` returns `true` for a mixed-case palindrome (case-insensitive)
  - [ ] `IsPalindrome()` returns `false` for a non-palindrome
  - [ ] `IsAllDigits()` returns `true` for an all-digit string
  - [ ] `CountWords()` returns correct word count for space-separated input

## Part 2 — String Operations

- [ ] **W8.P2.Ex1 — StringSearch** · `StudentWeek8Part2_Ex1Tests` · 7 tests
  - [ ] `ContainsIgnoreCase()` returns `true` when case differs
  - [ ] `ContainsIgnoreCase()` returns `false` when pattern is absent
  - [ ] `IndexOfIgnoreCase()` returns correct index on match
  - [ ] `IndexOfIgnoreCase()` returns `-1` when not found
  - [ ] `CountSubstringOccurrences()` counts multiple non-overlapping matches
  - [ ] `CountSubstringOccurrences()` returns `0` when no match
  - [ ] `StartsWithAny()` returns `true` when one prefix matches

- [ ] **W8.P2.Ex2 — StringManipulator** · `StudentWeek8Part2_Ex2Tests` · 7 tests
  - [ ] `TitleCase()` capitalises first letter and lower-cases rest of each word
  - [ ] `TitleCase()` normalises ALL-CAPS words to title case
  - [ ] `Truncate()` appends `"..."` when string exceeds `maxLength`
  - [ ] `Truncate()` returns unchanged string when within `maxLength`
  - [ ] `NormaliseWhitespace()` collapses interior spaces and trims edges
  - [ ] `ExtractBetween()` returns inner content when both delimiters found
  - [ ] `ExtractBetween()` returns `null` when open delimiter is missing

## Part 3 — StringBuilder

- [ ] **W8.P3.Ex1 — TextBuilder** · `StudentWeek8Part3_Ex1Tests` · 12 tests
  - [ ] `Join()` joins multiple parts with separator
  - [ ] `Join()` returns `""` for empty sequence
  - [ ] `Join()` throws `ArgumentNullException` for null parts
  - [ ] `Repeat()` repeats text the correct number of times
  - [ ] `Repeat()` returns `""` for `times = 0`
  - [ ] `Repeat()` throws `ArgumentOutOfRangeException` for negative `times`
  - [ ] `ReverseWords()` reverses word order for multiple words
  - [ ] `ReverseWords()` returns same single word unchanged
  - [ ] `ReverseWords()` returns `""` for whitespace-only input
  - [ ] `BuildNumberedList()` formats each item with its 1-based index
  - [ ] `BuildNumberedList()` formats a single item correctly
  - [ ] `BuildNumberedList()` returns `""` for empty array

## Final check

- [ ] All **39 tests** pass: `dotnet test Lab.Tests/Lab.Tests.csproj`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in with honest self-assessment
- [ ] `QUIZ_QUESTIONS.md` read at least once
