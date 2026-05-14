# Exercises — Week 2 · Arrays

Complete these exercises in order. Each exercise builds on the concepts from the demo file of the same part.

---

## Part 1 — Array Fundamentals

### W2.P1.Ex1 — ArrayBasics `[Lab/Part1_ArrayFundamentals/Exercises/Ex1_ArrayBasics.cs]`

Implement five methods that cover array creation, safe element access, and basic traversal.

| # | Method | Signature |
|---|--------|-----------|
| 1 | CreateAndFill | `static int[] CreateAndFill(int size, int fillValue)` |
| 2 | GetElement | `static int GetElement(int[] array, int index, int defaultValue)` |
| 3 | ReverseArray | `static int[] ReverseArray(int[] source)` |
| 4 | CountOccurrences | `static int CountOccurrences(int[] array, int target)` |
| 5 | DefaultValues | `static int[] DefaultValues(int size)` |

Test class: `StudentWeek2Part1_Ex1Tests`

---

## Part 2 — Iteration and Operations

### W2.P2.Ex1 — ArrayOperations `[Lab/Part2_IterationAndOperations/Exercises/Ex1_ArrayOperations.cs]`

Implement five methods that apply the accumulator pattern to compute aggregate values from an array.

| # | Method | Signature |
|---|--------|-----------|
| 1 | Sum | `static int Sum(int[] numbers)` |
| 2 | Average | `static double Average(int[] numbers)` |
| 3 | Min | `static int Min(int[] numbers)` |
| 4 | Max | `static int Max(int[] numbers)` |
| 5 | BuildBarChart | `static string BuildBarChart(int[] values)` |

Test class: `StudentWeek2Part2_Ex1Tests`

---

### W2.P2.Ex2 — ForVsForeach `[Lab/Part2_IterationAndOperations/Exercises/Ex2_ForVsForeach.cs]`

Implement five methods. Each TODO tells you which loop to use — the choice is part of the exercise.

| # | Method | Loop | Signature |
|---|--------|------|-----------|
| 1 | MultiplyInPlace | `for` | `static void MultiplyInPlace(int[] numbers, int factor)` |
| 2 | ContainsNegative | `foreach` | `static bool ContainsNegative(int[] numbers)` |
| 3 | ReplaceNegativesWithZero | `for` | `static void ReplaceNegativesWithZero(int[] numbers)` |
| 4 | SumEvenIndexed | `for` | `static int SumEvenIndexed(int[] numbers)` |
| 5 | AllPositive | `foreach` | `static bool AllPositive(int[] numbers)` |

Test class: `StudentWeek2Part2_Ex2Tests`

---

## Part 3 — Array Methods and Multi-Dimensional Arrays

### W2.P3.Ex1 — ArrayMethods `[Lab/Part3_ArrayMethodsAndMultiDim/Exercises/Ex1_ArrayMethods.cs]`

Implement five methods using the standard `Array` class — no manual loops for sorting or searching.

| # | Method | Key API |
|---|--------|---------|
| 1 | SortedCopy | `Array.Copy` + `Array.Sort` |
| 2 | LinearSearch | `Array.IndexOf` |
| 3 | BinarySearchInSorted | `Array.BinarySearch` |
| 4 | FirstEven | `Array.Exists` + `Array.Find` |
| 5 | CountEvens | `Array.FindAll` |

Test class: `StudentWeek2Part3_Ex1Tests`

---

### W2.P3.Ex2 — MultiDimArrays `[Lab/Part3_ArrayMethodsAndMultiDim/Exercises/Ex2_MultiDimArrays.cs]`

Implement five methods that exercise both rectangular 2D arrays (`int[,]`) and jagged arrays (`int[][]`).

| # | Method | Array type |
|---|--------|-----------|
| 1 | CreateMultiplicationTable | `int[,]` |
| 2 | SumRow | `int[,]` |
| 3 | Transpose | `int[,]` |
| 4 | CreateJaggedTriangle | `int[][]` |
| 5 | JaggedRowSum | `int[][]` |

Test class: `StudentWeek2Part3_Ex2Tests`
