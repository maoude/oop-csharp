# OOP Design Scorecard — Submission Template

## Lab Identification

| Field | Value |
|-------|-------|
| **Course** | Introduction to OOP with C# |
| **Week** | 8 — Strings and StringBuilder |
| **Student name** | _(fill in)_ |
| **Submission date** | _(fill in)_ |

---

## Scoring Rubric (10 points total)

### 1. **Encapsulation** (2 points)

Private state is only readable or modifiable through well-defined public members.  
For this lab: no mutable instance state is required, but any helper fields or caches you introduce must be private.

| Score | Evidence |
|-------|----------|
| 2 | All helpers and intermediate state are private; public surface is exactly what the tests exercise |
| 1 | One helper is unnecessarily public, or a method exposes more than it should |
| 0 | Several public members with no justification |

**Your score:** ___  
**Evidence (quote the member or line):** ___

---

### 2. **Single Responsibility** (2 points)

Each class has one reason to change: `StringBasics` handles char/string primitives, `StringSearch` handles locating patterns, `StringManipulator` handles reshaping strings, `TextBuilder` handles efficient assembly.

| Score | Evidence |
|-------|----------|
| 2 | Each class stays inside its stated responsibility; no method belongs in a different class |
| 1 | One method has scope creep (e.g., a search method also formats output) |
| 0 | Classes are catch-all bags of unrelated utilities |

**Your score:** ___  
**Evidence:** ___

---

### 3. **Clear Naming** (2 points)

Method and parameter names describe what the method does, not how it does it.

| Score | Evidence |
|-------|----------|
| 2 | All public names are self-documenting; a reader can predict behaviour from the name alone |
| 1 | One or two names are vague or abbreviated (e.g., `proc`, `str2`, `idx`) |
| 0 | Multiple confusing names |

**Your score:** ___  
**Evidence:** ___

---

### 4. **Testability** (2 points)

Every public method is exercised by the provided test suite and returns a value (or throws a documented exception) — no side-effects that tests cannot observe.

| Score | Evidence |
|-------|----------|
| 2 | All 39 tests pass; no test is skipped |
| 1 | Fewer than 5 tests failing; all failures are known gaps |
| 0 | More than 5 tests failing or test project does not compile |

**Your score:** ___  
**Evidence (paste `dotnet test` summary line):** ___

---

### 5. **Documentation** (1 point)

XML doc comments on every public method (`///`).

| Score | Evidence |
|-------|----------|
| 1 | Every public method has at least a `<summary>` tag |
| 0 | One or more public methods lack `<summary>` |

**Your score:** ___  
**Evidence:** ___

---

### 6. **Immutability Where Possible** (1 point)

String processing methods return new values; they do not mutate any shared state.  
Any `readonly` fields or `init`-only properties are used where appropriate.

| Score | Evidence |
|-------|----------|
| 1 | All methods are pure (input in, output out, no shared mutable state) |
| 0 | A method modifies a field or a passed-in collection as a side-effect |

**Your score:** ___  
**Evidence:** ___

---

## Self-Assessment (Honest Reflection)

| Criterion | Rating (Strong / Adequate / Needs Work) | Justification |
|-----------|-----------------------------------------|---------------|
| Encapsulation | | |
| Single Responsibility | | |
| Clear Naming | | |
| Testability | | |
| Documentation | | |
| Immutability | | |
| **Total / 10** | | |

---

## Required Explanation (4–8 sentences)

Choose **one** design decision from this lab and justify it at the "Excellent" level from the Explanation Quality Rubric.

> **Poor:** "I used StringBuilder for the Join method."  
> **Good:** "I used StringBuilder in Join because string concatenation in a loop is O(n²)."  
> **Excellent:** "`Join` uses `StringBuilder` with no pre-set capacity because the number of parts and their lengths are unknown at construction time. The separator is appended before each part except the first, guarded by a `bool first` flag rather than a post-trim, to avoid an extra allocation. The method is pure: it reads from the enumerable and returns a new `string`; the caller's collection is never mutated. Trade-off: for very short sequences (< 4 items) `string.Concat` would allocate less, but the code complexity is not worth it for a general-purpose utility."

**Your explanation:**

_(write here)_

---

## Visual Deliverables

Draw a class diagram for the four classes in this lab. Label each class with its responsibility and show which methods it exposes. No inheritance is required; focus on cohesion.

```
┌─────────────────────┐    ┌─────────────────────┐
│    StringBasics     │    │    StringSearch     │
│─────────────────────│    │─────────────────────│
│ + IsVowel()         │    │ + ContainsIgnoreCase│
│ + CountChars()      │    │ + IndexOfIgnoreCase │
│ + ReverseString()   │    │ + CountSubstring... │
│ + IsPalindrome()    │    │ + StartsWithAny()   │
│ + IsAllDigits()     │    └─────────────────────┘
│ + CountWords()      │
└─────────────────────┘

┌─────────────────────┐    ┌─────────────────────┐
│  StringManipulator  │    │    TextBuilder      │
│─────────────────────│    │─────────────────────│
│ + TitleCase()       │    │ + Join()            │
│ + Truncate()        │    │ + Repeat()          │
│ + NormaliseWhitespac│    │ + ReverseWords()    │
│ + ExtractBetween()  │    │ + BuildNumberedList │
└─────────────────────┘    └─────────────────────┘
```

---

## Instructor Feedback

_(left blank for instructor use)_
