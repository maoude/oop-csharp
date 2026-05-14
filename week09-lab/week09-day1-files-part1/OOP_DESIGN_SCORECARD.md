# OOP Design Scorecard — Submission Template

## Lab Identification

| Field | Value |
|-------|-------|
| **Course** | Introduction to OOP with C# |
| **Week** | 9 — Files in C# (Part 1) |
| **Student name** | _(fill in)_ |
| **Submission date** | _(fill in)_ |

---

## Scoring Rubric (10 points total)

### 1. **Encapsulation** (2 points)

Private state is only accessible through well-defined public members.  
For this lab: any cached metadata (`FileInfo` instances, path strings) must be private; the public surface is exactly what the tests exercise.

| Score | Evidence |
|-------|----------|
| 2 | No unnecessary public members; internal helpers are private |
| 1 | One helper or field is needlessly public |
| 0 | Multiple public members with no justification |

**Your score:** ___  
**Evidence:** ___

---

### 2. **Single Responsibility** (2 points)

`FileOperations` handles file content; `DirectoryOperations` handles directory structure; `PathHelper` handles string manipulation only (no filesystem access); `SafeFileReader` handles defensive wrappers.

| Score | Evidence |
|-------|----------|
| 2 | Each class stays within its stated domain; no method crosses responsibilities |
| 1 | One method has scope creep (e.g., a path helper that also checks the filesystem) |
| 0 | Classes are catch-all bags |

**Your score:** ___  
**Evidence:** ___

---

### 3. **Clear Naming** (2 points)

Method names describe the operation without naming the implementation.

| Score | Evidence |
|-------|----------|
| 2 | All names are self-documenting; a reader can predict behaviour from the name alone |
| 1 | One or two names are vague (e.g., `Process`, `Handle`, `DoFile`) |
| 0 | Multiple confusing names |

**Your score:** ___  
**Evidence:** ___

---

### 4. **Testability** (2 points)

All 39 tests pass. Tests use temporary directories and clean up after themselves — no test pollutes another.

| Score | Evidence |
|-------|----------|
| 2 | All 39 tests pass; test isolation verified (no leftover temp files) |
| 1 | Fewer than 5 tests failing; failures are known gaps |
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

`PathHelper` methods are pure string transformations with no side effects.  
`FileOperations` and `DirectoryOperations` mutate the filesystem only when the method contract requires it.

| Score | Evidence |
|-------|----------|
| 1 | No unnecessary mutation; `PathHelper` has no fields |
| 0 | A class stores mutable state that is not required by the contract |

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

> **Poor:** "I used try/catch in TryReadText."  
> **Good:** "I used try/catch so the caller doesn't have to handle file errors."  
> **Excellent:** "`TryReadText` returns `null` (not `""`) because the two meanings are distinct: `null` means 'the file was not accessible' while `""` means 'the file exists and is empty'. Conflating them forces the caller to do a separate `File.Exists` check to tell them apart — which reintroduces the TOCTOU race condition the TryXxx pattern was meant to eliminate. The catch block catches `Exception` rather than `FileNotFoundException` alone because `UnauthorizedAccessException` (which does not extend `IOException`) is equally unrecoverable from the caller's perspective. Trade-off: catching `Exception` can silently swallow programming errors like a null `path`; I mitigate this by testing that a null path returns null rather than throwing."

**Your explanation:**

_(write here)_

---

## Visual Deliverables

Draw a class diagram for the four classes in this lab. Label each with its responsibility and note whether it accesses the filesystem.

```
┌────────────────────────┐   ┌──────────────────────────┐
│    FileOperations      │   │   DirectoryOperations    │
│  (filesystem: read/   │   │   (filesystem: dirs)     │
│   write/copy files)   │   │──────────────────────────│
│────────────────────────│   │ + DirectoryExists()      │
│ + FileExists()         │   │ + EnsureDirectory()      │
│ + ReadText()           │   │ + ListFiles()            │
│ + WriteText()          │   │ + ListSubdirectories()   │
│ + AppendText()         │   └──────────────────────────┘
│ + ReadLines()          │
│ + CopyFile()           │   ┌──────────────────────────┐
│ + GetFileSize()        │   │      PathHelper          │
└────────────────────────┘   │   (NO filesystem access) │
                             │──────────────────────────│
┌────────────────────────┐   │ + Combine()              │
│    SafeFileReader      │   │ + GetFileName()          │
│  (TryXxx wrappers —   │   │ + GetExtension()         │
│   never throws)        │   │ + GetDirectory()         │
│────────────────────────│   │ + HasExtension()         │
│ + TryReadText()        │   └──────────────────────────┘
│ + TryWriteText()       │
│ + ReadTextOrDefault()  │
│ + CountLines()         │
│ + AppendLine()         │
└────────────────────────┘
```

---

## Instructor Feedback

_(left blank for instructor use)_
