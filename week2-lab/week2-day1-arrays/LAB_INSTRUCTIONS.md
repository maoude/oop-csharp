# Lab Instructions — Week 2 · Arrays

Follow these steps in order the first time you open this lab. Once you have done the setup once, jump straight to step 4 on subsequent visits.

---

## Step 1 — Open the project in VS Code

```powershell
cd path\to\week2-lab\week2-day1-arrays
code .
```

VS Code will open the entire folder. The Solution Explorer panel (C# Dev Kit) will show `Lab` and `Lab.Tests` as separate projects.

---

## Step 2 — Restore dependencies

```powershell
dotnet restore
```

This downloads xUnit and any other NuGet packages listed in the `.csproj` files. You only need to do this once (or when packages change).

---

## Step 3 — Verify the project builds

```powershell
dotnet build
```

All exercise files ship with `throw new NotImplementedException();` stubs that compile but do nothing yet. The build should succeed with zero errors. If you see errors, check that you have not accidentally modified a demo or test file.

---

## Step 4 — Work through one exercise at a time

Recommended order:

```
Part1 → Ex1_ArrayBasics
Part2 → Ex1_ArrayOperations → Ex2_ForVsForeach
Part3 → Ex1_ArrayMethods   → Ex2_MultiDimArrays
```

For each exercise:

1. **Read the demo file** for the corresponding part first.
2. **Open the exercise file** (`Ex*.cs`). Read the class doc-comment and all TODO comments.
3. **Replace** `throw new NotImplementedException();` with your implementation.
4. **Run the tests** for just that exercise:

```powershell
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part1_Ex1"
```

5. **Read the failure message.** xUnit prints the expected value and the actual value. The `^` marker shows the first difference.
6. **Fix and re-run.** Repeat until all tests for that exercise are green.
7. **Tick the box** in `CHECKLIST.md`.

---

## Step 5 — Run the full suite before submission

```powershell
dotnet test Lab.Tests/
```

You should see all 68 tests pass. If any are red, revisit the failure message and TROUBLESHOOTING.md.

---

## Step 6 — Self-evaluate with OOP_DESIGN_SCORECARD.md

Fill in the scorecard. It takes two minutes and trains you to review your own code before submitting.

---

## Useful commands reference

| Goal | Command |
|------|---------|
| Build | `dotnet build` |
| All tests | `dotnet test Lab.Tests/` |
| All Week 2 | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2"` |
| Part 1 only | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part1"` |
| Part 2 only | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part2"` |
| Part 3 only | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part3"` |
| One exercise | `dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek2Part1_Ex1"` |
| Verbose output | add `--logger "console;verbosity=detailed"` |
