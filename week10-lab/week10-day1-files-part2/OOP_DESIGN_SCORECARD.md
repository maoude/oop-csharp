# OOP Design Scorecard — Submission Template

## Lab Identification

| Field | Value |
|-------|-------|
| **Course** | Introduction to OOP with C# |
| **Week** | 10 — Files in C# (Part 2) · Streams |
| **Student name** | _(fill in)_ |
| **Submission date** | _(fill in)_ |

---

## Scoring Rubric (10 points total)

### 1. **Encapsulation** (2 points)

All stream objects are created and disposed inside each method — no stream is stored as a field.

| Score | Evidence |
|-------|----------|
| 2 | No stream fields; every stream is local to the method that uses it |
| 1 | One stream stored as a field unnecessarily |
| 0 | Streams leak out of methods or are stored as class state |

**Your score:** ___  
**Evidence:** ___

---

### 2. **Single Responsibility** (2 points)

`TextStreamProcessor` handles text; `ByteStreamProcessor` handles raw bytes; `BinaryRecordStore` handles a specific typed record format.

| Score | Evidence |
|-------|----------|
| 2 | Each class has one reason to change |
| 1 | One method crosses into another class's domain |
| 0 | Classes are mixed-purpose |

**Your score:** ___  
**Evidence:** ___

---

### 3. **Clear Naming** (2 points)

| Score | Evidence |
|-------|----------|
| 2 | All names clearly describe the operation |
| 1 | One or two names are vague or misleading |
| 0 | Multiple confusing names |

**Your score:** ___  
**Evidence:** ___

---

### 4. **Testability** (2 points)

All 39 tests pass; tests use isolated temp directories and clean up after themselves.

| Score | Evidence |
|-------|----------|
| 2 | All 39 tests pass; no file-lock failures across repeated runs |
| 1 | Fewer than 5 tests failing |
| 0 | More than 5 tests failing or project does not compile |

**Your score:** ___  
**Evidence (paste `dotnet test` summary line):** ___

---

### 5. **Documentation** (1 point)

XML doc comments on every public method.

| Score | Evidence |
|-------|----------|
| 1 | Every public method has at least a `<summary>` tag |
| 0 | One or more public methods lack `<summary>` |

**Your score:** ___  
**Evidence:** ___

---

### 6. **Immutability Where Possible** (1 point)

`ReadAllText`, `ReadLines`, `ReadAllBytes`, `ReadSegment`, `LoadRecords`, `CountRecords` do not modify the file on disk.

| Score | Evidence |
|-------|----------|
| 1 | Read methods leave files unchanged; no unintended side-effects |
| 0 | A read method accidentally truncates or modifies the file |

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

> **Poor:** "I used `using` in every method."  
> **Good:** "I used `using` so the stream is always closed, even if an exception is thrown."  
> **Excellent:** "`ReadSegment` checks `offset >= fs.Length` before calling `Seek` and returns an empty array rather than throwing, because requesting a segment beyond the file end is a valid caller scenario (e.g., pagination past the last page) — not a programming error. The method uses `fs.Read`'s return value (not the requested `count`) to slice the buffer, because `Read` may return fewer bytes than requested even within a valid range (partial reads are permitted by the `Stream` contract). `FileMode.Open` / `FileAccess.Read` is used because `ReadSegment` must not create or modify the file. Trade-off: for very large offsets on large files, `Seek` is O(1) but pre-allocating `new byte[count]` when fewer bytes exist wastes memory; a production implementation would query `Math.Min(count, fs.Length - offset)` first."

**Your explanation:**

_(write here)_

---

## Visual Deliverables

Draw a class diagram showing the three classes and their key method groups. Annotate whether each class opens streams for **Read**, **Write**, or **Both**.

```
┌──────────────────────────┐
│   TextStreamProcessor    │
│   (StreamReader/Writer)  │
│──────────────────────────│
│ + ReadAllText()   [R]    │
│ + ReadLines()     [R]    │
│ + WriteLines()    [W]    │
│ + AppendLine()    [W]    │
│ + CountLines()    [R]    │
└──────────────────────────┘

┌──────────────────────────┐
│   ByteStreamProcessor    │
│   (FileStream)           │
│──────────────────────────│
│ + ReadAllBytes()  [R]    │
│ + WriteAllBytes() [W]    │
│ + ReadSegment()   [R]    │
│ + AppendBytes()   [W]    │
└──────────────────────────┘

┌──────────────────────────┐
│   BinaryRecordStore      │
│   (BinaryWriter/Reader)  │
│──────────────────────────│
│ + SaveRecords()   [W]    │
│ + LoadRecords()   [R]    │
│ + CountRecords()  [R]    │
└──────────────────────────┘
```

---

## Instructor Feedback

_(left blank for instructor use)_
