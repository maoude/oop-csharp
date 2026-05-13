# Introduction to Object-Oriented Programming with C#

**Course:** Introduction to OOP with C#
**Subtitle:** Building Reliable Object Models - Foundations, Relationships, and Practical Patterns
**Language:** C# 12 / .NET 8
**Test framework:** xUnit
**Level:** Undergraduate (typically 2nd year)
**Instructor:** Dr. Mohamad Aoude
**Institution:** Lebanese University, Faculty of Engineering

This repository follows the same conventions as the sibling Concurrency &
Distributed Systems course (`D:\courses\concerent`). Every week looks the
same: docs, demos, student exercises, tests, scorecard, optional
instructor solutions.

---

## Quick start

```powershell
# .NET 8 SDK required
dotnet --version          # must be >= 8.0
```

To run the grading tests for a given week:

```powershell
cd week5-lab\week5-day1-encapsulation
dotnet test --filter "FullyQualifiedName~StudentWeek"
```

To run only your exercise:

```powershell
dotnet test --filter "FullyQualifiedName~StudentWeek5Part2_Ex1"
```

To run all tests for one week:

```powershell
dotnet test --filter "FullyQualifiedName~StudentWeek5"
```

---

## Repository layout

```
oop-csharp/
├── README.md                       (this file)
├── SYLLABUS.md                     14-week plan, learning outcomes, weights
├── CONVENTIONS.md                  folder/naming/test conventions
├── COURSE_TODO.md                  master TODO list (durable copy)
├── OOP_DESIGN_SCORECARD.md         6-item rubric used weekly
├── PITFALLS.md                     cheat sheet, 4 progressive releases
├── EXERCISES_TEMPLATE.md           per-week exercise list template
├── .gitignore                      .NET-standard ignore rules
├── Lectures/                       syllabus, lecture plans, lab manuals
│   └── syllabus.md
├── case-studies/                   discussion handouts
│   └── README.md
├── _template-week/                 copy this for new weeks
│   ├── README.md, EXERCISES.md, CHECKLIST.md, ...
│   ├── Lab/                        the .NET library project
│   └── Lab.Tests/                  the xUnit test project
└── weekN-lab/weekN-dayD-topic/     actual weekly labs (scaffolded later)
```

---

## What students must read before Week 1

1. `SYLLABUS.md` - the 14-week plan and what each checkpoint is graded on
2. `CONVENTIONS.md` - especially the section on `StudentWeek*Tests` naming
3. `OOP_DESIGN_SCORECARD.md` - the rubric every lab is graded against

---

## Rule of the course

> *Code reads more than it is written. Design for the reader, not the writer.*
