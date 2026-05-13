# Checklist — Week 6 · Interfaces & Abstract Classes

---

## Part 1 — Interface Basics

- [ ] **W6.P1.Ex1 — Printable** · `StudentWeek6Part1_Ex1Tests` · 16 tests
  - [ ] `IPrintable` declared with `ToPrintString()`
  - [ ] `IPersistable` declared with `Serialize()` and `Deserialize()`
  - [ ] `Contact` implements both interfaces
  - [ ] `Contact.ToPrintString()` → `"Contact: {FirstName} {LastName} <{Email}>"`
  - [ ] `Contact.Serialize()` → `"{FirstName}|{LastName}|{Email}"`
  - [ ] `Invoice` implements both interfaces
  - [ ] `Invoice.ToPrintString()` contains invoice number, client, and formatted amount
  - [ ] Mixed `List<IPrintable>` dispatches to correct class

---

## Part 2 — Interfaces and Polymorphism

- [ ] **W6.P2.Ex1 — Taxable** · `StudentWeek6Part2_Ex1Tests` · 18 tests
  - [ ] `ProductBase` is abstract with `Category()` abstract
  - [ ] `ProductBase` constructor throws for non-positive `basePrice`
  - [ ] `GroceryItem.TaxAmount()` → `BasePrice * TaxRate`
  - [ ] `GroceryItem.PriceWithTax()` → `BasePrice + TaxAmount()`
  - [ ] `ElectronicItem.DiscountedPrice()` → `BasePrice * (1 - pct/100)`
  - [ ] `OfType<ElectronicItem>()` correctly filters a mixed list
  - [ ] `Summary()` contains name, category, and price

---

## Part 3 — Abstract vs Interface

- [ ] **W6.P3.Ex1 — Logger** · `StudentWeek6Part3_Ex1Tests` · 14 tests
  - [ ] `ILogger` interface declared with `Log`, `LogError`, `EntryCount`
  - [ ] `LoggerBase` is abstract and implements `ILogger`
  - [ ] `Log()` appends to `_entries` AND calls `WriteEntry()`
  - [ ] `LogError()` prepends `"[ERROR] "` to the message
  - [ ] `EntryCount` reflects the number of calls to `Log()`
  - [ ] `GetEntries()` returns `IReadOnlyList<string>`
  - [ ] `MemoryLogger.GetLastEntry()` returns last message or `""`
  - [ ] Both loggers implement `ILogger` — polymorphic through interface

---

## Final check

- [ ] All 48 tests pass: `dotnet test Lab.Tests/`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in
- [ ] `QUIZ_QUESTIONS.md` read at least once
