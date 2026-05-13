# Lab Instructions — Week 5 · Inheritance

---

## Step 1 — Open the project

```powershell
cd path\to\week5-lab\week5-day1-inheritance
code .
dotnet restore
dotnet build   # should succeed with zero errors
```

---

## Step 2 — Work through one exercise at a time

Recommended order: **Part1 Ex1 → Part2 Ex1 → Part3 Ex1**

For each exercise, read the demo file first, implement the TODOs in order, then run:

```powershell
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek5Part1_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek5Part2_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek5Part3_Ex1"
```

---

## Step 3 — Run the full suite

```powershell
dotnet test Lab.Tests/
```

All 44 tests should pass.

---

## Command reference

| Goal | Command |
|------|---------|
| All tests | `dotnet test Lab.Tests/` |
| Part 1 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek5Part1"` |
| Part 2 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek5Part2"` |
| Part 3 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek5Part3"` |
| Verbose | add `--logger "console;verbosity=detailed"` |
