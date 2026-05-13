# OOP Design Scorecard — Week 4 · Classes in C# (Part 2)

## Scoring: 3 = fully satisfied · 2 = minor issues · 1 = partial · 0 = missing

| # | Criterion | Score (0–3) | Notes |
|---|-----------|-------------|-------|
| 1 | **ToString is overridden** with `override` (not `new`); appears in string interpolation correctly | | |
| 2 | **Equals/GetHashCode contract** — equal objects always have the same hash code | | |
| 3 | **== and != defined as a pair** — neither is missing | | |
| 4 | **== consistent with Equals** — they agree on every pair of inputs | | |
| 5 | **Operators return new objects** — no mutation of operands | | |
| 6 | **Commutativity** — both `T * scalar` and `scalar * T` defined where needed | | |
| 7 | **implicit only for safe conversions** — explicit used where information could be lost | | |
| 8 | **IComparable returns correct sign** — negative for less-than, zero for equal | | |
| 9 | **Comparison operators derived from CompareTo** — no duplicated comparison logic | | |
| 10 | **Guard clauses present** — null handled in Equals and CompareTo | | |

**Total: \_\_\_ / 30**

## Reflection

What was the hardest operator to implement this week?

___

In your own words, why does violating the Equals/GetHashCode contract break Dictionary?

___
