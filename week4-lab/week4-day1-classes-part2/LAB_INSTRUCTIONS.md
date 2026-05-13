# Lab Instructions — Week 4 · Classes in C# (Part 2)

---

## Step 1 — Open the project

```powershell
cd path\to\week4-lab\week4-day1-classes-part2
code .
dotnet restore
dotnet build   # should succeed with zero errors
```

---

## Step 2 — Work through one exercise at a time

Recommended order: **Part1 Ex1 → Part2 Ex1 → Part3 Ex1**

For each exercise, read the demo file first, implement the TODOs in order, then run:

```powershell
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part1_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part2_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part3_Ex1"
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
| Part 1 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part1"` |
| Part 2 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part2"` |
| Part 3 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part3"` |
| Verbose | add `--logger "console;verbosity=detailed"` |
