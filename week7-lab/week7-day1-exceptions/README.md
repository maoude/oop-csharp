# Week 7 — Exception Handling

**Course:** Introduction to OOP with C#  
**Lab:** week7-day1-exceptions

---

## Learning objectives

By the end of this lab you will be able to:

- Use `try` / `catch` / `finally` to handle and recover from runtime errors
- Catch multiple exception types and choose the most specific handler
- Use `when` clause filters and re-throw exceptions without losing the stack trace
- Create domain-specific exception classes with meaningful properties
- Follow exception best-practice guidelines (fail fast, TryXxx pattern, `using` statements)
- Distinguish between recoverable and unrecoverable errors

---

## Structure

```
week7-day1-exceptions/
├── Lab/
│   ├── Part1_TryCatchFinally/
│   │   ├── Demo01_TryCatchFinally.cs         ← Read first
│   │   └── Exercises/
│   │       └── Ex1_SafeCalculator.cs
│   ├── Part2_CustomExceptions/
│   │   ├── Demo02_CustomExceptions.cs
│   │   └── Exercises/
│   │       └── Ex1_Temperature.cs
│   └── Part3_BestPractices/
│       ├── Demo03_BestPractices.cs
│       └── Exercises/
│           └── Ex1_SafeQueue.cs
└── Lab.Tests/
    ├── Part1_TryCatchFinally/StudentWeek7Part1_Ex1Tests.cs   (12 tests)
    ├── Part2_CustomExceptions/StudentWeek7Part2_Ex1Tests.cs  (13 tests)
    └── Part3_BestPractices/StudentWeek7Part3_Ex1Tests.cs     (12 tests)
```

**Total: 37 tests**

---

## Quick start

```powershell
cd path\to\week7-lab\week7-day1-exceptions
dotnet restore
dotnet build
dotnet test Lab.Tests/
```
