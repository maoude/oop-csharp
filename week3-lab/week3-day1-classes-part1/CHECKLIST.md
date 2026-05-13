# Checklist — Week 3 · Classes in C# (Part 1)

Tick each box only after ALL tests in that class are green.

---

## Part 1 — Classes and Objects

- [ ] **W3.P1.Ex1 — Rectangle** · `StudentWeek3Part1_Ex1Tests` · 10 tests
  - [ ] `Width` and `Height` are public fields (not properties)
  - [ ] `Area()` returns `Width * Height`
  - [ ] `Perimeter()` returns `2 * (Width + Height)`
  - [ ] `IsSquare()` returns `Width == Height`
  - [ ] `Scale(factor)` multiplies both dimensions in place
  - [ ] `Describe()` returns `"Rectangle 4.0 x 5.0, area=20.0"` format
  - [ ] Two rectangles have completely independent field values

---

## Part 2 — Properties and Constructors

- [ ] **W3.P2.Ex1 — BankAccount** · `StudentWeek3Part2_Ex1Tests` · 12 tests
  - [ ] `_balance` is private; `Balance` is a read-only property
  - [ ] `AccountNumber` has `init` setter — immutable after construction
  - [ ] `Owner` has `private set` — no external mutation
  - [ ] Constructor throws `ArgumentException` for negative initial balance
  - [ ] `Deposit` throws for ≤ 0; adds to balance for valid amounts
  - [ ] `Withdraw` returns `false` (not throws) for insufficient funds
  - [ ] `Withdraw` throws `ArgumentException` for ≤ 0 amount
  - [ ] `Summary()` format exactly: `"Account ACC001 (Alice): $1234.56"`

- [ ] **W3.P2.Ex2 — Person** · `StudentWeek3Part2_Ex2Tests` · 11 tests
  - [ ] `FullName` is a computed property (re-evaluated on every read)
  - [ ] `Age` has `private set` — only `HaveBirthday()` increments it
  - [ ] Two-arg constructor chains to three-arg constructor
  - [ ] `Person(..., -1)` throws `ArgumentOutOfRangeException`
  - [ ] `IsAdult` returns `true` exactly at age 18
  - [ ] `Greet` format: `"Hi Bob Smith, I'm Alice Jones!"`

---

## Part 3 — Static Members and Readonly

- [ ] **W3.P3.Ex1 — StudentRegistry** · `StudentWeek3Part3_Ex1Tests` · 13 tests
  - [ ] First student after reset gets `Id = 1`
  - [ ] Subsequent students get sequential IDs (1, 2, 3, …)
  - [ ] `Id` is `readonly` — cannot be changed after construction
  - [ ] `EnrolledCount` starts at 0 after `ResetRegistry()`
  - [ ] `EnrolledCount` increments per new student
  - [ ] `Unenroll()` decrements `EnrolledCount` and sets `Enrolled = false`
  - [ ] `Unenroll()` is idempotent (calling twice = calling once)
  - [ ] `ResetRegistry()` resets both `_nextId` and `_enrolledCount`
  - [ ] `Describe()` format: `"Student #3 Alice [enrolled]"` / `[unenrolled]`

---

## Final check

- [ ] All 46 tests pass: `dotnet test Lab.Tests/`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in
- [ ] `QUIZ_QUESTIONS.md` read at least once
