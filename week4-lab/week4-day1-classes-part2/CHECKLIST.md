# Checklist — Week 4 · Classes in C# (Part 2)

---

## Part 1 — ToString and Equality

- [ ] **W4.P1.Ex1 — Money** · `StudentWeek4Part1_Ex1Tests` · 14 tests
  - [ ] `ToString()` → `"9.99 USD"` (2 decimal places, uppercase currency)
  - [ ] `Equals` compares both Amount AND Currency
  - [ ] `Equals` returns false for null and wrong type
  - [ ] `GetHashCode` uses same fields as Equals
  - [ ] Equal Money objects work as Dictionary keys
  - [ ] `==` delegates to Equals; `!=` negates `==`
  - [ ] `Add` returns combined amount for same currency
  - [ ] `Add` throws `InvalidOperationException` for different currencies

---

## Part 2 — Operator Overloading

- [ ] **W4.P2.Ex1 — Fraction** · `StudentWeek4Part2_Ex1Tests` · 16 tests
  - [ ] `ToString()` → `"1/2"` or `"3"` (whole numbers drop slash)
  - [ ] `+` uses cross-multiplication formula, result is reduced
  - [ ] `-` (binary) subtracts correctly, result is reduced
  - [ ] `*` multiplies numerators and denominators, result is reduced
  - [ ] `/` divides (multiply by reciprocal), throws for zero divisor
  - [ ] `-` (unary) negates numerator only
  - [ ] `==` compares reduced Numerator and Denominator
  - [ ] `!=` is exactly `!(a == b)`
  - [ ] `Equals` and `GetHashCode` consistent with `==`

---

## Part 3 — Conversion and Comparison

- [ ] **W4.P3.Ex1 — Weight** · `StudentWeek4Part3_Ex1Tests` · 14 tests
  - [ ] `implicit` conversion: `Weight w = 70.5;` compiles without cast
  - [ ] `explicit` conversion: `double d = (double)w;` requires cast
  - [ ] `Pounds` returns `Kilograms * 2.20462`
  - [ ] `ToString()` → `"70.50 kg"`
  - [ ] `CompareTo` returns negative for lighter, 0 for equal, positive for heavier
  - [ ] `CompareTo(null)` returns positive (null < any weight)
  - [ ] `Array.Sort` on `Weight[]` sorts ascending by Kilograms
  - [ ] `<` and `>` operators derived correctly from `CompareTo`

---

## Final check

- [ ] All 44 tests pass: `dotnet test Lab.Tests/`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in
- [ ] `QUIZ_QUESTIONS.md` read at least once
