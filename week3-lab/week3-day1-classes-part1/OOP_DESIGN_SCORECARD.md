# OOP Design Scorecard — Week 3 · Classes in C# (Part 1)

Fill this in before you submit. Be honest — it is for your own growth.

---

## Scoring guide

- **3** — Fully satisfied
- **2** — Mostly satisfied, minor issues
- **1** — Partially satisfied
- **0** — Not satisfied / not attempted

---

## Criteria

| # | Criterion | Score (0–3) | Notes |
|---|-----------|-------------|-------|
| 1 | **Valid at construction** — constructors reject invalid arguments; no object exists in an invalid state | | |
| 2 | **Encapsulation** — private fields exposed only through properties; no public fields except where required (Ex1) | | |
| 3 | **Computed properties** — `FullName`, `IsAdult`, `Balance` derive from other members rather than storing redundant data | | |
| 4 | **Constructor chaining** — shared constructor logic is in one place; no copy-pasted validation | | |
| 5 | **Static vs instance** — static only for truly class-wide data (`_nextId`, `_enrolledCount`); instance for per-object data | | |
| 6 | **readonly correctly used** — `Id` is `readonly`, not just `private set` | | |
| 7 | **Idempotent operations** — `Unenroll()` is safe to call multiple times without double-decrementing | | |
| 8 | **Return vs throw** — `Withdraw` returns `false` for insufficient funds (business event); throws for invalid input (programming error) | | |
| 9 | **Naming** — classes are nouns, methods are verbs, properties are nouns or adjectives (`IsAdult`, not `CheckIfAdult`) | | |
| 10 | **Format strings** — `":F1"`, `":F2"` used correctly in `Describe()` and `Summary()` | | |

**Total: \_\_\_ / 30**

---

## Reflection

What was the hardest concept this week?

___

What is the clearest sign you understand the difference between a class and an object?

___

What question do you still have about classes?

___
