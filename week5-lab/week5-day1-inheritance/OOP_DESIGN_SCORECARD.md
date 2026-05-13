# OOP Design Scorecard — Week 5 · Inheritance

## Scoring: 3 = fully satisfied · 2 = minor issues · 1 = partial · 0 = missing

| # | Criterion | Score (0–3) | Notes |
|---|-----------|-------------|-------|
| 1 | **base() called correctly** — derived constructors chain to the right base constructor | | |
| 2 | **override used (not new)** — derived methods participate in polymorphism | | |
| 3 | **virtual declared in base** — every overridable method is marked virtual or abstract | | |
| 4 | **sealed where intended** — `Square.Area()` is sealed so no further override is possible | | |
| 5 | **abstract class cannot be instantiated** — `Employee` is declared abstract | | |
| 6 | **abstract methods have no body** — no `{ }` on `MonthlySalary()` / `EmployeeType()` | | |
| 7 | **Guard clauses present** — constructors throw for invalid arguments | | |
| 8 | **Polymorphism demonstrated** — base-type collections dispatch to correct override | | |
| 9 | **is/as used safely** — no bare `(Cast)` without a prior type-check | | |
| 10 | **WithHours returns new instance** — original object is not mutated | | |

**Total: \_\_\_ / 30**

## Reflection

What surprised you most about how `override` and `new` differ at runtime?

___

In your own words, when would you choose an abstract class over a plain virtual method?

___
