# Checklist — Week 5 · Inheritance

---

## Part 1 — Inheritance Basics

- [ ] **W5.P1.Ex1 — Animal** · `StudentWeek5Part1_Ex1Tests` · 14 tests
  - [ ] `Animal` properties (`Name`, `Age`) set by constructor
  - [ ] `Animal.ToString()` → `"Animal: {Name}, age {Age}"`
  - [ ] `Animal.Speak()` → `"..."` (virtual base)
  - [ ] `Animal.IsAdult()` → true when `Age >= 3`
  - [ ] `Dog` inherits from `Animal`, adds `Breed`
  - [ ] `Dog.Speak()` → `"Woof!"`
  - [ ] `Dog.ToString()` → `"Dog: {Name} ({Breed}), age {Age}"`
  - [ ] `Cat` inherits from `Animal`, adds `IsIndoor`
  - [ ] `Cat.Speak()` → `"Meow!"`
  - [ ] `Cat.Lifestyle()` returns correct string
  - [ ] Upcasting to `Animal` uses polymorphic `Speak()`
  - [ ] Pattern matching downcast `a is Dog d` works

---

## Part 2 — virtual / override

- [ ] **W5.P2.Ex1 — Shape** · `StudentWeek5Part2_Ex1Tests` · 16 tests
  - [ ] `Shape.Color` defaults to `"Black"`, settable
  - [ ] `Shape.Area()` and `Perimeter()` default to 0
  - [ ] `Circle` overrides both, validates `radius > 0`
  - [ ] `Rectangle` overrides both, validates both dimensions
  - [ ] `Square` calls `base(side, side)`, `sealed override Area()`
  - [ ] `ToString()` uses `GetType().Name`, formatted values
  - [ ] Polymorphic `Sum(s => s.Area())` dispatches correctly

---

## Part 3 — Abstract class

- [ ] **W5.P3.Ex1 — Employee** · `StudentWeek5Part3_Ex1Tests` · 14 tests
  - [ ] `Employee` is abstract — cannot be instantiated directly
  - [ ] `FullTimeEmployee.MonthlySalary()` = `BaseSalary + Bonus`
  - [ ] Default bonus is 0
  - [ ] Throws when `BaseSalary <= 0`
  - [ ] `ContractEmployee.MonthlySalary()` = `HourlyRate * HoursPerMonth`
  - [ ] Throws when rate or hours ≤ 0
  - [ ] `WithHours(n)` returns a new instance — not the same object
  - [ ] `AnnualSalary()` = `MonthlySalary() * 12`
  - [ ] Polymorphic `Sum(e => e.MonthlySalary())` dispatches correctly
  - [ ] Pattern matching downcast to `ContractEmployee` works

---

## Final check

- [ ] All 44 tests pass: `dotnet test Lab.Tests/`
- [ ] `OOP_DESIGN_SCORECARD.md` filled in
- [ ] `QUIZ_QUESTIONS.md` read at least once
