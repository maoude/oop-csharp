# Lab Instructions — Week 1: Introduction to C#

## Learning goals for today

By the end of this lab you will be able to:

1. Read and write simple C# programs with methods, parameters, and return values.
2. Distinguish between `void` and value-returning methods.
3. Use `ref` and `out` parameters correctly.
4. Call `Math` class methods and explain what each computes.
5. Write overloaded methods and explain how the compiler picks between them.
6. Parse string input safely using `TryParse` (not `Parse`).

---

## How the lab is structured

Work through the parts in order. Each part has:

- A **demo file** (`Demo0N_*.cs`) — read it before starting the exercises.
  It is already complete; your job is to understand it.
- **Exercise stubs** (`Exercises/Ex*.cs`) — files with `TODO` comments.
  Implement the method bodies so the grading tests go green.

---

## The workflow

```
1. Read the demo for the current part.
2. Read the exercise stub — understand what each method must do.
3. Implement the TODO body.
4. Run dotnet test --filter "FullyQualifiedName~StudentWeek1PartN_ExM".
5. Fix failures. Repeat until green.
6. Tick the box in CHECKLIST.md.
7. Move to the next exercise.
```

---

## Things to observe in the demos

### Demo 01 — Hello World
- What is the difference between `Console.Write` and `Console.WriteLine`?
- What does the `??` operator do in `Console.ReadLine() ?? "Student"`?
- What does `new string('-', 40)` produce?

### Demo 02 — Methods
- Where does the return value go when you call `Square(5)`?
- What happens to `x` after `Double(ref x)`? Why?
- Why does `TryDivide(10, 0, out double _)` use `_`?
- Three `Add` methods have the same name — how does the compiler know which to call?

### Demo 03 — Console I/O
- Why is `int.TryParse` safer than `int.Parse`?
- What does `(int)pi` do to the decimal part?
- Why is `double d = i;` safe but `int t = (int)pi;` "lossy"?

---

## Design principle introduced this week

> **Name methods as verbs that describe what they do, not how.**
>
> `CalculateHypotenuse` is better than `DoMath`.  
> `ParseInt` is better than `HandleInput`.  
> `Swap` is better than `Exchange2RefsInPlace`.

You will be asked about this in the oral quiz.
