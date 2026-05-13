# Week 5 — Inheritance

**Course:** Introduction to OOP with C#  
**Lab:** week5-day1-inheritance

---

## Learning objectives

By the end of this lab you will be able to:

- Model "is-a" relationships using `class Child : Parent`
- Call the parent constructor with `base(...)` and the parent method with `base.Method()`
- Declare `virtual` methods and override them correctly
- Understand why `new` (hiding) is not the same as `override`
- Seal an override with `sealed` to prevent further sub-classing
- Declare and implement `abstract` classes and abstract methods
- Use `is`, `as`, and pattern matching to safely downcast
- Apply polymorphism: write code against a base type and let the runtime dispatch to the right override

---

## Structure

```
week5-day1-inheritance/
├── Lab/
│   ├── Part1_InheritanceBasics/
│   │   ├── Demo01_InheritanceBasics.cs   ← Read first
│   │   └── Exercises/
│   │       └── Ex1_Animal.cs
│   ├── Part2_VirtualAndOverride/
│   │   ├── Demo02_VirtualAndOverride.cs  ← Read first
│   │   └── Exercises/
│   │       └── Ex1_Shape.cs
│   └── Part3_AbstractAndPolymorphism/
│       ├── Demo03_AbstractAndPolymorphism.cs  ← Read first
│       └── Exercises/
│           └── Ex1_Employee.cs
└── Lab.Tests/
    ├── Part1_InheritanceBasics/StudentWeek5Part1_Ex1Tests.cs   (14 tests)
    ├── Part2_VirtualAndOverride/StudentWeek5Part2_Ex1Tests.cs  (16 tests)
    └── Part3_AbstractAndPolymorphism/StudentWeek5Part3_Ex1Tests.cs (14 tests)
```

**Total: 44 tests**

---

## Quick start

```powershell
cd path\to\week5-lab\week5-day1-inheritance
dotnet restore
dotnet build
dotnet test Lab.Tests/
```
