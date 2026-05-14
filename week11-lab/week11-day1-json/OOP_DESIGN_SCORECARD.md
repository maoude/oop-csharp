# OOP Design Scorecard — Submission Template

## Lab Identification

| Field | Value |
|-------|-------|
| **Course** | Introduction to OOP with C# |
| **Week** | 11 — Tokenizers · Semi-Structured Data · JSON |
| **Student name** | _(fill in)_ |
| **Submission date** | _(fill in)_ |

---

## Scoring Rubric (10 points total)

### 1. **Encapsulation** (2 points)

`JsonTokenizer` private helpers (`ReadString`, `ReadNumber`, `ReadKeyword`) are `private` — callers only see `Tokenize`. `JsonDocumentReader` does not expose `JsonDocument` instances outside method scope.

| Score | Evidence |
|-------|----------|
| 2 | Helper methods are private; no internal state leaks out |
| 1 | One helper is unnecessarily `public` |
| 0 | Internal details exposed through the public surface |

**Your score:** ___  
**Evidence:** ___

---

### 2. **Single Responsibility** (2 points)

`JsonTokenizer` only tokenises. `JsonDocumentReader` only reads dynamically. `JsonSerializerHelper` only wraps typed serialisation.

| Score | Evidence |
|-------|----------|
| 2 | Each class stays within its domain |
| 1 | One method crosses into another class's responsibility |
| 0 | Classes are mixed-purpose |

**Your score:** ___  
**Evidence:** ___

---

### 3. **Clear Naming** (2 points)

| Score | Evidence |
|-------|----------|
| 2 | All names describe the operation; `ReadString` vs `ReadNumber` vs `ReadKeyword` are clearly distinct |
| 1 | One or two names are vague |
| 0 | Multiple confusing names |

**Your score:** ___  
**Evidence:** ___

---

### 4. **Testability** (2 points)

| Score | Evidence |
|-------|----------|
| 2 | All 39 tests pass |
| 1 | Fewer than 5 tests failing |
| 0 | More than 5 tests failing or project does not compile |

**Your score:** ___  
**Evidence (paste `dotnet test` summary line):** ___

---

### 5. **Documentation** (1 point)

| Score | Evidence |
|-------|----------|
| 1 | Every public method has at least a `<summary>` XML doc comment |
| 0 | One or more public methods lack `<summary>` |

**Your score:** ___  
**Evidence:** ___

---

### 6. **Immutability Where Possible** (1 point)

`Tokenize` returns a new `IReadOnlyList<Token>` on every call — it does not mutate the input string or any shared state. `Token` is a `record` (immutable by default).

| Score | Evidence |
|-------|----------|
| 1 | No mutable shared state; `Token` records are immutable |
| 0 | A method stores intermediate state in a field |

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

Choose **one** design decision from this lab and justify it at the "Excellent" level.

> **Poor:** "I used TryGetProperty to avoid exceptions."  
> **Good:** "I used TryGetProperty because GetProperty throws if the key is missing."  
> **Excellent:** "`ReadStringProperty` uses `TryGetProperty` rather than `GetProperty` because a missing key is a normal caller scenario (optional fields in JSON), not a programming error — so throwing would be the wrong signal. When the key is present but the value is JSON `null`, `element.ValueKind == JsonValueKind.Null` is checked explicitly before calling `GetString()`, because `GetString()` on a null-kind element throws `InvalidOperationException` rather than returning `null`. The whole method is wrapped in `using var doc = JsonDocument.Parse(json)` to return the pooled buffer immediately after the value is extracted. Trade-off: calling `Parse` on every method call re-allocates on every query; a production design would parse once and cache the document for the duration of a request."

**Your explanation:**

_(write here)_

---

## Visual Deliverables

Draw a class diagram for the three classes. For `JsonTokenizer`, show the public/private split.

```
┌──────────────────────────────────┐
│          JsonTokenizer           │
│──────────────────────────────────│
│ + Tokenize(input) : IReadOnly... │
│ - ReadString(input, ref i)       │
│ - ReadNumber(input, ref i)       │
│ - ReadKeyword(input, ref i)      │
└──────────────────────────────────┘

     uses ──► Token(Kind, Value)  [record]
               TokenKind          [enum]

┌──────────────────────────────────┐
│        JsonDocumentReader        │
│   (wraps System.Text.Json)       │
│──────────────────────────────────│
│ + ReadStringProperty()           │
│ + ReadNumberProperty()           │
│ + ReadBoolProperty()             │
│ + ReadStringArray()              │
│ + GetArrayLength()               │
│ + GetObjectKeys()                │
└──────────────────────────────────┘

┌──────────────────────────────────┐
│       JsonSerializerHelper       │
│   (wraps JsonSerializer)         │
│──────────────────────────────────│
│ + Serialize<T>()                 │
│ + SerializeIndented<T>()         │
│ + Deserialize<T>()               │
│ + TryDeserialize<T>()            │
└──────────────────────────────────┘
```

---

## Instructor Feedback

_(left blank for instructor use)_
