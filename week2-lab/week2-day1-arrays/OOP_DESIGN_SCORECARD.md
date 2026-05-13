# OOP Design Scorecard — Week 2 · Arrays

Fill this in before you submit. It takes two minutes and trains you to review your own code critically. Be honest — this is for your own growth.

---

## Scoring guide

- **3** — Fully satisfied, no issues
- **2** — Mostly satisfied, minor issues
- **1** — Partially satisfied, clear improvements needed
- **0** — Not satisfied / not attempted

---

## Criteria

| # | Criterion | Score (0–3) | Notes |
|---|-----------|-------------|-------|
| 1 | **Guard clauses first** — every method checks null/empty/invalid arguments before doing any work | | |
| 2 | **Correct exception type** — `ArgumentNullException` for null, `ArgumentException` for semantic errors, `ArgumentOutOfRangeException` for out-of-range indices | | |
| 3 | **Right loop choice** — `for` when the index is needed; `foreach` when only the value is needed | | |
| 4 | **No mutation of inputs** — methods that say "returns a new array" do not modify the original | | |
| 5 | **Double division** — `Average` uses `(double)total / n`, not `total / n` | | |
| 6 | **Min/Max seeding** — seeded from `[0]`, not from `0` or `int.MaxValue` | | |
| 7 | **Library methods** — `Array.Sort`, `Array.IndexOf`, `Array.BinarySearch`, `Array.Find/FindAll/Exists` used where appropriate instead of reimplementing | | |
| 8 | **Readable names** — local variables named `min`, `max`, `total`, `count`, `rows`, `cols` (not `x`, `temp`, `val2`) | | |
| 9 | **Single responsibility** — each method does exactly one thing | | |
| 10 | **No magic numbers** — lengths come from `array.Length` or `GetLength(0/1)`, not hardcoded | | |

**Total: \_\_\_ / 30**

---

## Reflection (2–3 sentences)

What was the hardest concept this week?

___

What would you do differently if you wrote this lab again?

___

What question do you still have?

___
