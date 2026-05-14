# Lab Instructions — Week 3 · Classes in C# (Part 1)

---

## Step 1 — Open the project

```powershell
cd path\to\week3-lab\week3-day1-classes-part1
code .
```

---

## Step 2 — Restore and build

```powershell
dotnet restore
dotnet build
```

All exercise files compile with `throw new NotImplementedException()` stubs — expect zero build errors. If you see errors, you have accidentally edited a demo or test file.

---

## Step 3 — Work through one exercise at a time

Recommended order: **Part1 Ex1 → Part2 Ex1 → Part2 Ex2 → Part3 Ex1**

For each exercise:

1. **Read the demo** for that part in full (5–10 minutes).
2. **Open the exercise file.** Read the class doc-comment, then each TODO in order.
3. **Implement each TODO.** Do not skip ahead — later TODOs assume earlier ones are done.
4. **Run only that exercise's tests:**

```powershell
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part1_Ex1"
```

5. **Read the failure.** xUnit shows `Expected:` and `Actual:` — the difference tells you what to fix.
6. **Fix and re-run.** Keep going until all tests for that exercise are green.
7. **Tick the box** in `CHECKLIST.md`.

---

## Step 4 — Run the full suite before submitting

```powershell
dotnet test Lab.Tests/
```

All 46 tests should pass.

---

## Step 5 — Self-evaluate

Fill in `OOP_DESIGN_SCORECARD.md`. Read `QUIZ_QUESTIONS.md`.

---

## Command reference

| Goal | Command |
|------|---------|
| Build | `dotnet build` |
| All tests | `dotnet test Lab.Tests/` |
| Part 1 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part1"` |
| Part 2 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part2"` |
| Part 3 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part3"` |
| W3.P1.Ex1 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part1_Ex1"` |
| W3.P2.Ex1 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part2_Ex1"` |
| W3.P2.Ex2 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part2_Ex2"` |
| W3.P3.Ex1 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part3_Ex1"` |
| Verbose | add `--logger "console;verbosity=detailed"` |
