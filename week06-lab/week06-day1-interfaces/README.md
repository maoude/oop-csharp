# Week 6 — Interfaces & Abstract Classes

**Course:** Introduction to OOP with C#  
**Lab:** week6-day1-interfaces

---

## Learning objectives

By the end of this lab you will be able to:

- Declare interfaces with method and property contracts
- Implement multiple interfaces on a single class
- Hold any implementing type in an interface-typed variable (polymorphism)
- Understand when to prefer an interface over an abstract class (and vice versa)
- Use `is` / `as` / `OfType<T>()` to filter by interface type
- Apply the Strategy pattern using an interface
- Write default interface method implementations (C# 8+)

---

## Structure

```
week6-day1-interfaces/
├── Lab/
│   ├── Part1_InterfaceBasics/
│   │   ├── Demo01_InterfaceBasics.cs         ← Read first
│   │   └── Exercises/
│   │       └── Ex1_Printable.cs
│   ├── Part2_InterfacesAndPolymorphism/
│   │   ├── Demo02_InterfacesAndPolymorphism.cs
│   │   └── Exercises/
│   │       └── Ex1_Taxable.cs
│   └── Part3_AbstractVsInterface/
│       ├── Demo03_AbstractVsInterface.cs
│       └── Exercises/
│           └── Ex1_Logger.cs
└── Lab.Tests/
    ├── Part1_InterfaceBasics/StudentWeek6Part1_Ex1Tests.cs   (16 tests)
    ├── Part2_InterfacesAndPolymorphism/StudentWeek6Part2_Ex1Tests.cs (18 tests)
    └── Part3_AbstractVsInterface/StudentWeek6Part3_Ex1Tests.cs (14 tests)
```

**Total: 48 tests**

---

## Quick start

```powershell
cd path\to\week6-lab\week6-day1-interfaces
dotnet restore
dotnet build
dotnet test Lab.Tests/
```
