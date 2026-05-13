# Checklist — Week 2 · Arrays

Tick each box only after ALL tests in that class are green.

---

## Part 1 — Array Fundamentals

- [ ] **W2.P1.Ex1 — ArrayBasics** · `StudentWeek2Part1_Ex1Tests` · 13 tests
  - [ ] `CreateAndFill` — creates and fills correctly, rejects negative size
  - [ ] `GetElement` — returns element or default without crashing on null/OOB
  - [ ] `ReverseArray` — returns new reversed array, does not mutate source
  - [ ] `CountOccurrences` — counts correctly, handles null/empty
  - [ ] `DefaultValues` — returns a zeroed array without writing zeros explicitly

---

## Part 2 — Iteration and Operations

- [ ] **W2.P2.Ex1 — ArrayOperations** · `StudentWeek2Part2_Ex1Tests` · 13 tests
  - [ ] `Sum` — accumulator pattern, handles null/empty
  - [ ] `Average` — double division (not integer), throws for null/empty
  - [ ] `Min` — seeded from `[0]`, throws for null/empty
  - [ ] `Max` — seeded from `[0]`, throws for null/empty
  - [ ] `BuildBarChart` — `new string('*', n)` rows joined by `\n`

- [ ] **W2.P2.Ex2 — ForVsForeach** · `StudentWeek2Part2_Ex2Tests` · 14 tests
  - [ ] `MultiplyInPlace` — uses `for`, mutates in place
  - [ ] `ContainsNegative` — uses `foreach`, early exit
  - [ ] `ReplaceNegativesWithZero` — uses `for`, mutates in place
  - [ ] `SumEvenIndexed` — uses `for`, checks `i % 2 == 0`
  - [ ] `AllPositive` — uses `foreach`, vacuously true for empty/null

---

## Part 3 — Array Methods and Multi-Dimensional Arrays

- [ ] **W2.P3.Ex1 — ArrayMethods** · `StudentWeek2Part3_Ex1Tests` · 14 tests
  - [ ] `SortedCopy` — copies first, then sorts copy, source unchanged
  - [ ] `LinearSearch` — `Array.IndexOf`, returns -1 when absent
  - [ ] `BinarySearchInSorted` — `Array.BinarySearch`, normalised to -1
  - [ ] `FirstEven` — uses `Exists` to distinguish "not found" from "found 0"
  - [ ] `CountEvens` — `Array.FindAll(...).Length`

- [ ] **W2.P3.Ex2 — MultiDimArrays** · `StudentWeek2Part3_Ex2Tests` · 14 tests
  - [ ] `CreateMultiplicationTable` — `int[,]`, nested loops, `(r+1)*(c+1)`
  - [ ] `SumRow` — `GetLength(0/1)`, out-of-range throws
  - [ ] `Transpose` — dimensions swapped, `result[c, r] = matrix[r, c]`
  - [ ] `CreateJaggedTriangle` — `int[][]`, row r has r+1 elements
  - [ ] `JaggedRowSum` — per-row accumulation, handles null rows

---

## Final check

- [ ] All 68 tests pass: `dotnet test Lab.Tests/`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in
- [ ] `QUIZ_QUESTIONS.md` read at least once
