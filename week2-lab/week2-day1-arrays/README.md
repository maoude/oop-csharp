# Lab 2 — Arrays in C#

**Course:** Introduction to Object-Oriented Programming with C#  
**Instructor:** Dr. Mohamad Aoude · Lebanese University, Faculty of Engineering  
**Week:** 2  
**Assessment weight:** Ungraded practice — Checkpoint 1 is in Week 5

---

## What you will learn in this lab

By the time you finish every exercise in this lab, you will be able to:

- Declare, create, and initialise arrays using all common syntactic forms
- Explain why C# zero-initialises all value-type arrays at creation time
- Read and write elements by index, and guard against `IndexOutOfRangeException`
- Choose between `for` (when you need the index) and `foreach` (when you only need the value)
- Apply the accumulator pattern: sum, average, min, max in a single pass
- Seed min/max from `array[0]` rather than from zero or `int.MaxValue` — and explain why
- Use standard `Array` class methods: `Sort`, `Copy`, `Reverse`, `IndexOf`, `BinarySearch`, `Find`, `FindAll`, `Exists`
- Know when `BinarySearch` is faster than `IndexOf` and what precondition it requires
- Use `int?` (nullable int) to represent "not found" without a magic number
- Declare, create, and traverse rectangular 2D arrays (`int[,]`)
- Declare, create, and traverse jagged arrays (`int[][]`)
- Explain the indexing syntax differences: `matrix[r, c]` vs `jagged[r][c]`

These are not isolated facts. Every one of these skills will reappear when we reach collections, LINQ, and class design in later weeks.

---

## Before you start — setup checklist

Open a terminal and verify:

```powershell
dotnet --version   # must start with 8.
code --version     # VS Code must be installed
```

Inside VS Code, confirm the **C# Dev Kit** extension is active (Extensions panel).

---

## Lab structure — what each folder contains

```
week2-day1-arrays/
│
├── README.md                  ← you are here
├── EXERCISES.md               ← numbered list of all exercises
├── CHECKLIST.md               ← tick each box as you pass a test class
├── QUIZ_QUESTIONS.md          ← 8 questions your instructor may ask orally
├── TROUBLESHOOTING.md         ← solutions to the most common errors
├── LAB_INSTRUCTIONS.md        ← step-by-step workflow
├── OOP_DESIGN_SCORECARD.md    ← rubric used to evaluate your code style
│
├── Lab/                       ← the C# library project (your code lives here)
│   ├── Part1_ArrayFundamentals/
│   │   ├── Demo01_ArrayFundamentals.cs    ← READ THIS FIRST
│   │   ├── Exercises/
│   │   │   └── Ex1_ArrayBasics.cs         ← YOUR CODE GOES HERE
│   │   └── Solutions/                     ← locked until after submission
│   │
│   ├── Part2_IterationAndOperations/
│   │   ├── Demo02_IterationAndOperations.cs  ← READ THIS FIRST
│   │   ├── Exercises/
│   │   │   ├── Ex1_ArrayOperations.cs        ← YOUR CODE GOES HERE
│   │   │   └── Ex2_ForVsForeach.cs           ← YOUR CODE GOES HERE
│   │   └── Solutions/
│   │
│   └── Part3_ArrayMethodsAndMultiDim/
│       ├── Demo03_ArrayMethodsAndMultiDim.cs ← READ THIS FIRST
│       ├── Exercises/
│       │   ├── Ex1_ArrayMethods.cs            ← YOUR CODE GOES HERE
│       │   └── Ex2_MultiDimArrays.cs          ← YOUR CODE GOES HERE
│       └── Solutions/
│
└── Lab.Tests/                 ← xUnit test project — DO NOT EDIT
    ├── Part1_ArrayFundamentals/Exercises/StudentWeek2Part1_Ex1Tests.cs
    ├── Part2_IterationAndOperations/Exercises/StudentWeek2Part2_Ex1Tests.cs
    ├── Part2_IterationAndOperations/Exercises/StudentWeek2Part2_Ex2Tests.cs
    ├── Part3_ArrayMethodsAndMultiDim/Exercises/StudentWeek2Part3_Ex1Tests.cs
    └── Part3_ArrayMethodsAndMultiDim/Exercises/StudentWeek2Part3_Ex2Tests.cs
```

**The only files you should ever edit are the ones inside `Lab/PartN_*/Exercises/`.**

---

## How to work through the lab

```
1. Open the demo file for the current part and READ it completely.
   The comments explain every concept before you need to use it.

2. Open the exercise file (Ex*.cs).
   Read the header block — it tells you exactly what to implement.
   Read the TODO comments — they guide you step by step.

3. Replace  throw new NotImplementedException();  with your code.

4. Run the tests for that exercise (see commands below).

5. Read the failure message carefully — it tells you what was expected
   vs what you actually returned.

6. Fix the issue. Re-run. Repeat until all tests are green.

7. Tick the box in CHECKLIST.md and move to the next exercise.
```

> **Golden rule:** a method that is not yet implemented throws `NotImplementedException`.
> Your job is to replace every one with real code.

---

## Running the tests

Open a terminal **inside `week2-day1-arrays/`** and run:

```powershell
# All tests:
dotnet test Lab.Tests/

# Only Week 2:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2"

# Only Part 1:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part2"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part3"

# Only one exercise:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part1_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part2_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part2_Ex2"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part3_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part3_Ex2"
```

---

## The exercises — what you need to implement

### Part 1 — Array Fundamentals

#### Exercise W2.P1.Ex1 — ArrayBasics `[Ex1_ArrayBasics.cs]`

| Method | What it does | Edge cases handled |
|--------|--------------|--------------------|
| `CreateAndFill(int size, int fillValue)` | Creates an array of `size` elements all set to `fillValue` | Negative size → `ArgumentException` |
| `GetElement(int[] array, int index, int defaultValue)` | Returns element at `index`, or `defaultValue` if out of range | null array → `defaultValue` |
| `ReverseArray(int[] source)` | Returns a NEW reversed array; source unchanged | null → `ArgumentNullException` |
| `CountOccurrences(int[] array, int target)` | Counts how many times `target` appears | null/empty → 0 |
| `DefaultValues(int size)` | Returns a new zeroed array of `size` | Demonstrates C# zero-init |

**Key concepts:**
- `new int[size]` always produces an array of zeros — you do not need to clear it yourself
- The bounds check for `GetElement` must test BOTH `index < 0` and `index >= array.Length`
- `ReverseArray` must return a new array, never sort or reverse `source` in place

Test class: `StudentWeek2Part1_Ex1Tests`

---

### Part 2 — Iteration and Operations

#### Exercise W2.P2.Ex1 — ArrayOperations `[Ex1_ArrayOperations.cs]`

| Method | Computes | Edge cases |
|--------|----------|------------|
| `Sum(int[] numbers)` | Sum of all elements | null/empty → 0 |
| `Average(int[] numbers)` | Arithmetic mean as `double` | null/empty → `ArgumentException` |
| `Min(int[] numbers)` | Smallest element | null/empty → `ArgumentException` |
| `Max(int[] numbers)` | Largest element | null/empty → `ArgumentException` |
| `BuildBarChart(int[] values)` | String of `*`-rows joined by `\n` | null/empty → `""` |

**Key concepts:**
- `(double)total / numbers.Length` — cast BEFORE dividing to avoid integer truncation
- Seed `min` and `max` from `numbers[0]`, never from `0` or `int.MaxValue`
- `new string('*', n)` builds a string of `n` asterisks in one call
- `string.Join("\n", rows)` joins an array of strings with a separator

Test class: `StudentWeek2Part2_Ex1Tests`

---

#### Exercise W2.P2.Ex2 — ForVsForeach `[Ex2_ForVsForeach.cs]`

| Method | Loop to use | Why |
|--------|-------------|-----|
| `MultiplyInPlace(int[] numbers, int factor)` | `for` | Must write back through the index |
| `ContainsNegative(int[] numbers)` | `foreach` | Read-only scan; index not needed |
| `ReplaceNegativesWithZero(int[] numbers)` | `for` | Must write back through the index |
| `SumEvenIndexed(int[] numbers)` | `for` | Must inspect the index itself (`i % 2 == 0`) |
| `AllPositive(int[] numbers)` | `foreach` | Read-only scan; early exit on first failure |

**Key concept — the foreach limitation:**

```csharp
// This has NO effect on the array — n is a copy of each element:
foreach (int n in numbers)
    n = n * 2;   // compiler error or no-op for value types

// This WORKS — uses the index to write back:
for (int i = 0; i < numbers.Length; i++)
    numbers[i] = numbers[i] * 2;
```

Test class: `StudentWeek2Part2_Ex2Tests`

---

### Part 3 — Array Methods and Multi-Dimensional Arrays

#### Exercise W2.P3.Ex1 — ArrayMethods `[Ex1_ArrayMethods.cs]`

| Method | Uses | Returns when not found |
|--------|------|------------------------|
| `SortedCopy(int[] source)` | `Array.Copy` + `Array.Sort` | n/a |
| `LinearSearch(int[] array, int target)` | `Array.IndexOf` | -1 |
| `BinarySearchInSorted(int[] sortedArray, int target)` | `Array.BinarySearch` | -1 |
| `FirstEven(int[] numbers)` | `Array.Exists` + `Array.Find` | `null` (nullable `int?`) |
| `CountEvens(int[] numbers)` | `Array.FindAll` | 0 |

**Key concepts:**

`Array.BinarySearch` requires a sorted array — calling it on unsorted data gives undefined results. Always sort first or use `LinearSearch` if you cannot guarantee order.

`Array.Find` returns `default(T)` (which is `0` for `int`) when no match exists. Use `Array.Exists` first to distinguish "found 0" from "not found":

```csharp
if (!Array.Exists(numbers, n => n % 2 == 0)) return null;
return Array.Find(numbers, n => n % 2 == 0);
```

Test class: `StudentWeek2Part3_Ex1Tests`

---

#### Exercise W2.P3.Ex2 — MultiDimArrays `[Ex2_MultiDimArrays.cs]`

| Method | Array type | Key syntax |
|--------|-----------|------------|
| `CreateMultiplicationTable(int rows, int cols)` | `int[,]` | `new int[rows, cols]`, `table[r, c]` |
| `SumRow(int[,] matrix, int rowIndex)` | `int[,]` | `matrix.GetLength(0/1)` |
| `Transpose(int[,] matrix)` | `int[,]` | `result[c, r] = matrix[r, c]` |
| `CreateJaggedTriangle(int rows)` | `int[][]` | `triangle[r] = new int[r + 1]` |
| `JaggedRowSum(int[][] jagged)` | `int[][]` | `jagged[r][c]` |

**Key concept — rectangular vs jagged:**

```csharp
// Rectangular — all rows have the same number of columns:
int[,] rect = new int[3, 4];      // 3 rows, 4 columns each
int x = rect[1, 2];               // row 1, column 2 — comma inside brackets

// Jagged — each row is a separate array with its own length:
int[][] jag = new int[3][];
jag[0] = new int[2];              // row 0 has 2 columns
jag[1] = new int[5];              // row 1 has 5 columns
int y = jag[1][3];                // separate brackets for row and column
```

Test class: `StudentWeek2Part3_Ex2Tests`

---

## Progress summary

| Exercise | File | Test class | Tests |
|----------|------|------------|-------|
| W2.P1.Ex1 — ArrayBasics | `Ex1_ArrayBasics.cs` | `StudentWeek2Part1_Ex1Tests` | 13 |
| W2.P2.Ex1 — ArrayOperations | `Ex1_ArrayOperations.cs` | `StudentWeek2Part2_Ex1Tests` | 13 |
| W2.P2.Ex2 — ForVsForeach | `Ex2_ForVsForeach.cs` | `StudentWeek2Part2_Ex2Tests` | 14 |
| W2.P3.Ex1 — ArrayMethods | `Ex1_ArrayMethods.cs` | `StudentWeek2Part3_Ex1Tests` | 14 |
| W2.P3.Ex2 — MultiDimArrays | `Ex2_MultiDimArrays.cs` | `StudentWeek2Part3_Ex2Tests` | 14 |
| **Total** | | | **68 test cases** |

---

## Common mistakes and how to fix them

### "My average is always a whole number"

You are doing integer division. Both `total` and `numbers.Length` are `int`, so `total / numbers.Length` truncates.

```csharp
// WRONG — truncates 7/2 to 3:
return total / numbers.Length;

// CORRECT — cast one operand to double first:
return (double)total / numbers.Length;
```

### "My Min/Max returns 0 even for arrays of negative numbers"

You seeded from `0` instead of from `numbers[0]`.

```csharp
// WRONG — 0 is not in the array but ends up as the result:
int min = 0;

// CORRECT — always real data:
int min = numbers[0];
```

### "Multiplying in place with foreach had no effect"

`foreach` gives you a copy of each value. Assigning to that copy does not change the array.

```csharp
// NO EFFECT — n is a local copy:
foreach (int n in numbers)
    n *= factor;   // compile-time error in recent C# versions

// CORRECT — write back through the index:
for (int i = 0; i < numbers.Length; i++)
    numbers[i] *= factor;
```

### "SortedCopy sorted my original array too"

You sorted `source` directly. Copy it first.

```csharp
// WRONG — destroys the original:
Array.Sort(source);
return source;

// CORRECT — sort the copy:
int[] copy = new int[source.Length];
Array.Copy(source, copy, source.Length);
Array.Sort(copy);
return copy;
```

### "FirstEven returns null even when 0 is in the array"

`Array.Find` returns `0` when no match exists AND when the matched element is `0`. Use `Array.Exists` to disambiguate.

```csharp
// WRONG — returns null when element is 0:
int found = Array.Find(numbers, n => n % 2 == 0);
return found == 0 ? null : found;

// CORRECT — ask if any even element exists first:
if (!Array.Exists(numbers, n => n % 2 == 0)) return null;
return Array.Find(numbers, n => n % 2 == 0);
```

### "BinarySearch returned a strange negative number"

`Array.BinarySearch` returns a bitwise-complement of the insertion point when the value is not found. Normalise it to -1.

```csharp
int index = Array.BinarySearch(sortedArray, target);
return index >= 0 ? index : -1;
```

### "I get IndexOutOfRangeException in Transpose"

The result array must have its dimensions SWAPPED. A 3×2 matrix transposes to 2×3.

```csharp
// WRONG — same dimensions:
int[,] result = new int[rows, cols];

// CORRECT — swap rows and cols:
int[,] result = new int[cols, rows];
```

---

## What makes good code this week

Before submitting, ask yourself about each method:

- Is it doing **one thing**? (`SumAndPrint` does two — split it.)
- Does it handle **all edge cases** gracefully? (null, empty, out-of-range, all-negative)
- Does it use the **right loop**? (`for` when index matters, `foreach` when value-only)
- Does it use **library methods** where appropriate? (Don't re-implement `Array.Sort`.)
- Does it **not mutate inputs** unless the contract explicitly says to? (`SortedCopy` must not change `source`.)

Fill in `OOP_DESIGN_SCORECARD.md` before finishing — two minutes now saves embarrassment during the oral quiz.

---

## After the lab — oral quiz

Your instructor may ask any of the eight questions in `QUIZ_QUESTIONS.md` at the start of the next session. Spend five minutes reading them — you already know the answers from doing the exercises.

---

## Need help?

1. Read `TROUBLESHOOTING.md` — covers the most common errors.
2. Re-read the demo file for the part you are working on — the answer is almost always there.
3. Read the test file — it shows the exact inputs and expected outputs.
4. Ask a classmate to review your code (discussing is allowed; copying is not).
5. Bring the failing test name and your current code to the next session.
