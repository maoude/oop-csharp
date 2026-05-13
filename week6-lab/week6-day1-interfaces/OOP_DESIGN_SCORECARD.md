# OOP Design Scorecard — Week 6 · Interfaces & Abstract Classes

## Scoring: 3 = fully satisfied · 2 = minor issues · 1 = partial · 0 = missing

| # | Criterion | Score (0–3) | Notes |
|---|-----------|-------------|-------|
| 1 | **Interface declared correctly** — no instance fields, no constructors, all members public | | |
| 2 | **Multiple interface implementation** — `Contact` and `Invoice` implement both interfaces | | |
| 3 | **Interface-typed variables used** — code references `IPrintable` / `IPersistable`, not the concrete class | | |
| 4 | **Abstract class has no public constructor** — constructor is `protected` | | |
| 5 | **Abstract method has no body** — `Category()` declared without `{ }` | | |
| 6 | **Guard clause present** — `ProductBase` throws for non-positive base price | | |
| 7 | **`ILogger` implemented through abstract class** — `LoggerBase` satisfies the contract | | |
| 8 | **`Log()` calls `WriteEntry()`** — entries are stored AND dispatched | | |
| 9 | **`GetEntries()` returns read-only** — `IReadOnlyList<string>`, not `List<string>` | | |
| 10 | **Polymorphism demonstrated** — collections of interface/base type dispatch correctly | | |

**Total: \_\_\_ / 30**

## Reflection

In your own words: when would you choose an interface over an abstract class?

___

Why does making `_entries` protected (rather than private) make sense in `LoggerBase`?

___
