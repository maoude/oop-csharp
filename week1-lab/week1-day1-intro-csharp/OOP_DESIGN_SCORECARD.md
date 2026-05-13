# OOP Design Scorecard — Week 1

**Student:**  
**Exercise(s):**  
**Date:**  

---

For each item, mark ✅ (fully met), ⚠️ (partially met), or ❌ (not met).
Add a one-sentence justification for each mark.

| # | Criterion | Mark | Justification |
|---|-----------|------|---------------|
| 1 | **Encapsulated?** No implementation details leak through the public API. | | |
| 2 | **Single Responsibility?** Each method does exactly one thing. | | |
| 3 | **Named clearly?** Method names are verbs; parameter names describe their role. | | |
| 4 | **Testable?** The public API is exercisable without console interaction. | | |
| 5 | **Documented?** Public methods have a `///` XML summary comment. | | |
| 6 | **Immutable where possible?** No unnecessary mutation; `ref`/`out` used only when genuinely needed. | | |

---

## Week 1 focus: criteria 2, 3, 4

Week 1 code is mostly static helpers, so criteria 1 and 6 (encapsulation
and immutability) will matter more starting in Week 3 (classes). This week,
concentrate on:

- **2 — Single Responsibility:** Does each method do exactly one thing?
  `MathHelpers.Hypotenuse` should only compute the hypotenuse; it should not
  also print a result.
- **3 — Named clearly:** `ParseInt` tells you the input type and what it does.
  `DoThing` does not.
- **4 — Testable:** All Week 1 methods are pure functions (same input →
  same output, no side effects). This makes them trivially testable.

---

## Explanation Quality Rubric (use when writing your reflection)

- **Poor:** "I used TryParse."
- **Good:** "I used `int.TryParse` instead of `int.Parse` so the method
  returns a default value on bad input instead of crashing with an exception."
- **Excellent:** "`int.TryParse` returns `false` for non-numeric input and
  leaves the `out` variable at its default (0). My method then returns the
  caller-supplied `defaultValue` instead. This makes `ParseInt` total — it
  never throws — which is the correct design for a utility that processes
  untrusted string input."
