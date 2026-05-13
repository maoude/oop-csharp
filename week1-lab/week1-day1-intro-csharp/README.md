# Lab 1 — Introduction to C# · Methods · Console I/O

**Course:** Introduction to Object-Oriented Programming with C#  
**Instructor:** Dr. Mohamad Aoude · Lebanese University, Faculty of Engineering  
**Week:** 1  
**Assessment weight:** Ungraded practice — Checkpoint 1 is in Week 5

---

## What you will learn in this lab

By the time you finish every exercise in this lab, you will be able to:

- Write and call static methods that return a value
- Distinguish between `void` methods (do something) and value-returning methods (compute something)
- Use string interpolation to build readable output strings
- Use `ref` parameters to modify a caller's variable in place
- Use `out` parameters to return multiple results from one method
- Call methods from the `Math` class (`Sqrt`, `Pow`, `Abs`, `Round`, `Max`)
- Write overloaded methods — same name, different parameter types or counts
- Parse user input safely with `TryParse` instead of crashing with `Parse`
- Split a line of text into tokens and process each one individually

These are not C# trivia. Every one of these skills appears again in every subsequent week of the course.

---

## Before you start — setup checklist

Open a terminal and verify these two things:

```powershell
dotnet --version
```

You must see a version number that starts with `8.` (e.g. `8.0.300`). If the command is not found, install the .NET 8 SDK from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

```powershell
code --version
```

You must have VS Code installed. Inside VS Code, confirm the **C# Dev Kit** extension is active (look for it in the Extensions panel).

---

## Lab structure — what each folder contains

```
week1-day1-intro-csharp/
│
├── README.md                  ← you are here
├── EXERCISES.md               ← numbered list of all exercises
├── CHECKLIST.md               ← tick each box as you pass a test class
├── QUIZ_QUESTIONS.md          ← 8 questions your instructor may ask orally
├── TROUBLESHOOTING.md         ← solutions to the most common errors
├── LAB_INSTRUCTIONS.md        ← step-by-step workflow
├── OOP_DESIGN_SCORECARD.md    ← rubric used to evaluate your code style
│
├── Lab/                       ← the C# library project (your code lives here)
│   ├── Part1_HelloWorld/
│   │   ├── Demo01_HelloWorld.cs       ← instructor demo, READ THIS FIRST
│   │   ├── Exercises/
│   │   │   └── Ex1_Greeting.cs        ← YOUR CODE GOES HERE
│   │   └── Solutions/                 ← locked until after submission
│   │
│   ├── Part2_Methods/
│   │   ├── Demo02_Methods.cs          ← instructor demo, READ THIS FIRST
│   │   ├── Exercises/
│   │   │   ├── Ex1_MathHelpers.cs     ← YOUR CODE GOES HERE
│   │   │   ├── Ex2_Parameters.cs      ← YOUR CODE GOES HERE
│   │   │   └── Ex3_Overloading.cs     ← YOUR CODE GOES HERE
│   │   └── Solutions/
│   │
│   └── Part3_ConsoleIO/
│       ├── Demo03_ConsoleIO.cs        ← instructor demo, READ THIS FIRST
│       ├── Exercises/
│       │   └── Ex1_InputParser.cs     ← YOUR CODE GOES HERE
│       └── Solutions/
│
└── Lab.Tests/                 ← xUnit test project — DO NOT EDIT
    ├── Part1_HelloWorld/Exercises/StudentWeek1Part1_Ex1Tests.cs
    ├── Part2_Methods/Exercises/StudentWeek1Part2_Ex1Tests.cs
    ├── Part2_Methods/Exercises/StudentWeek1Part2_Ex2Tests.cs
    ├── Part2_Methods/Exercises/StudentWeek1Part3_Ex3Tests.cs
    └── Part3_ConsoleIO/Exercises/StudentWeek1Part3_Ex1Tests.cs
```

**The only files you should ever edit are the ones inside `Lab/PartN_*/Exercises/`.**  
Do not modify demos, solutions, or test files.

---

## How to work through the lab

Follow this loop for every exercise:

```
1. Open the demo file for the current part and READ it completely.
   The comments explain every concept before you need to use it.

2. Open the exercise file (Ex*.cs).
   Read the header block — it tells you exactly what to implement.
   Read the TODO comments — they guide you step by step.

3. Replace  throw new NotImplementedException();  with your code.

4. Run the tests for that exercise (see commands below).

5. Read the failure message carefully — it tells you what was expected
   vs what you returned.

6. Fix the issue. Re-run. Repeat until all tests are green.

7. Tick the box in CHECKLIST.md and move to the next exercise.
```

> **Golden rule:** a method that is not yet implemented throws `NotImplementedException`.  
> That is intentional — it makes the file compile while signalling "not done yet."  
> Your job is to replace every `throw new NotImplementedException();` with real code.

---

## Running the tests

Open a terminal **inside the `week1-day1-intro-csharp/` folder** and use these commands:

```powershell
# Run ALL tests (all parts, all exercises):
dotnet test Lab.Tests/

# Run only tests for this week (same result here, useful in larger repos):
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1"

# Run only one part:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1Part1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1Part2"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1Part3"

# Run only one exercise:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1Part1_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1Part2_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1Part2_Ex2"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1Part2_Ex3"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek1Part3_Ex1"
```

### Reading a test failure

When a test fails, xUnit prints something like this:

```
Assert.Equal() Failure
Expected: Hello, Alice!
Actual:   Hello Alice!
           ^
```

The `^` points to the first character that differs. In this example, a comma is missing. Read the expected value carefully — punctuation, spaces, and capitalisation all matter.

---

## The exercises — what you need to implement

### Part 1 — Hello World

#### Exercise W1.P1.Ex1 — Greeting `[Ex1_Greeting.cs]`

Implement two methods that build and **return** greeting strings.

| Method | Input example | Expected return value |
|--------|---------------|-----------------------|
| `Greet(string name)` | `"Alice"` | `"Hello, Alice!"` |
| `GreetWithTitle(string title, string name)` | `"Dr."`, `"Aoude"` | `"Dr. Aoude, welcome!"` |

**Key concept:** The method must `return` the string — do not call `Console.WriteLine` inside it. The test checks the return value, not the console output.

```csharp
// What you will use:
return $"Hello, {name}!";
//      ↑ the $ prefix enables embedding expressions inside { }
```

Test class: `StudentWeek1Part1_Ex1Tests` (3 tests)

---

### Part 2 — Methods

#### Exercise W1.P2.Ex1 — MathHelpers `[Ex1_MathHelpers.cs]`

Implement four mathematical helpers using the `Math` class.

| Method | What it computes | Example |
|--------|------------------|---------|
| `Hypotenuse(double a, double b)` | √(a² + b²) | `Hypotenuse(3, 4)` → `5.0` |
| `CircleArea(double radius)` | π × radius² | `CircleArea(1)` → `3.14159…` |
| `Clamp(int value, int min, int max)` | keep value inside [min, max] | `Clamp(15, 1, 10)` → `10` |
| `AbsDiff(int a, int b)` | \|a − b\| | `AbsDiff(3, 10)` → `7` |

**Key concepts:**
- `Math.Sqrt(x)` — square root
- `Math.Pow(x, 2)` — raise to a power
- `Math.PI` — the constant 3.14159…
- `Math.Abs(x)` — remove the sign
- Write `Clamp` yourself using `if` — do not use `Math.Clamp`

Test class: `StudentWeek1Part2_Ex1Tests` (5 theory rows + 1 fact = 6 test cases)

---

#### Exercise W1.P2.Ex2 — Parameters `[Ex2_Parameters.cs]`

Implement four methods that demonstrate `ref` and `out` parameters.

| Method | What it does |
|--------|--------------|
| `Increment(ref int value)` | adds 1 to the caller's variable |
| `Swap(ref int a, ref int b)` | exchanges the two caller variables |
| `MinMax(int[] numbers, out int min, out int max)` | finds smallest and largest in one pass |
| `FormatTemperature(double celsius, out double fahrenheit)` | converts and returns `"22.0°C = 71.6°F"` |

**Key concepts:**

`ref` means the method shares the caller's storage — writing to the parameter changes the original variable.

```csharp
int x = 5;
Increment(ref x);   // x is now 6 — the method changed the caller's variable
```

`out` means the method *must* write the variable before returning. The caller does not need to initialise it first.

```csharp
MinMax(new[] { 3, 1, 9, 4 }, out int min, out int max);
// min = 1, max = 9 — both set by the method
```

`MinMax` must throw `ArgumentException` when the array is `null` or empty.

`FormatTemperature` formula: F = C × 9/5 + 32 — write `9.0 / 5.0`, not `9 / 5` (integer division gives 1, not 1.8).

Test class: `StudentWeek1Part2_Ex2Tests` (8 tests)

---

#### Exercise W1.P2.Ex3 — Overloading `[Ex3_Overloading.cs]`

Implement five overloaded methods — same name, different signatures.

| Method | Example | Result |
|--------|---------|--------|
| `Repeat(string text, int times)` | `Repeat("ab", 3)` | `"ababab"` |
| `Repeat(char ch, int times)` | `Repeat('*', 4)` | `"****"` |
| `Max(int a, int b)` | `Max(3, 7)` | `7` |
| `Max(double a, double b)` | `Max(2.5, 1.1)` | `2.5` |
| `Max(int a, int b, int c)` | `Max(1, 3, 2)` | `3` |

**Key concept:** The compiler selects the correct overload based on the *types and number* of the arguments — you never change the method name. Both `Repeat` methods coexist peacefully because their first parameter types differ (`string` vs `char`).

For `Repeat`, return an empty string when `times ≤ 0`.  
For `Max(int, int, int)`, call `Max(int, int)` inside — don't repeat the comparison logic.

Test class: `StudentWeek1Part2_Ex3Tests` (5 theory groups)

---

### Part 3 — Console I/O

#### Exercise W1.P3.Ex1 — InputParser `[Ex1_InputParser.cs]`

Implement four safe input-parsing methods. Every method must handle `null`, empty strings, and bad input **without throwing an exception**.

| Method | Input | Returns |
|--------|-------|---------|
| `ParseInt(string? input, int defaultValue)` | `"42"` | `42` |
| `ParseInt(string? input, int defaultValue)` | `"abc"` | `defaultValue` |
| `ParseDouble(string? input, double defaultValue)` | `"3.14"` | `3.14` |
| `ParseBool(string? input)` | `"YES"` | `true` |
| `ParseBool(string? input)` | `"maybe"` | `false` |
| `SplitAndSum(string? input)` | `"3 7 2"` | `12` |
| `SplitAndSum(string? input)` | `"1 abc 3"` | `4` (skips "abc") |

**Key concept — TryParse vs Parse:**

```csharp
// UNSAFE — throws FormatException on bad input:
int n = int.Parse("hello");    // crashes!

// SAFE — returns false on bad input, never throws:
if (int.TryParse("hello", out int n))
    // n is valid here
else
    // parsing failed, n is 0, no crash
```

**Accepted truthy values for `ParseBool`** (case-insensitive): `"true"`, `"yes"`, `"1"`, `"y"`. Everything else is `false`.

**`SplitAndSum` approach:** split on spaces with `RemoveEmptyEntries`, try to parse each token, skip bad tokens, sum the good ones.

Test class: `StudentWeek1Part3_Ex1Tests` (8 theory rows + 1 fact = 9 test cases)

---

## Progress summary

| Exercise | File | Test class | Tests |
|----------|------|------------|-------|
| W1.P1.Ex1 — Greeting | `Ex1_Greeting.cs` | `StudentWeek1Part1_Ex1Tests` | 3 |
| W1.P2.Ex1 — MathHelpers | `Ex1_MathHelpers.cs` | `StudentWeek1Part2_Ex1Tests` | 6 |
| W1.P2.Ex2 — Parameters | `Ex2_Parameters.cs` | `StudentWeek1Part2_Ex2Tests` | 8 |
| W1.P2.Ex3 — Overloading | `Ex3_Overloading.cs` | `StudentWeek1Part2_Ex3Tests` | 5 |
| W1.P3.Ex1 — InputParser | `Ex1_InputParser.cs` | `StudentWeek1Part3_Ex1Tests` | 9 |
| **Total** | | | **31 test cases** |

---

## Common mistakes and how to fix them

### "My method does not change anything — I used ref but nothing happened"

You must write `ref` **both** in the method declaration and at the call site:

```csharp
// Declaration:
public static void Increment(ref int value) { value++; }

// Call site — WRONG (compiles only without ref, but has no effect):
int x = 5;
Increment(x);      // ← compiler error: ref argument required

// Call site — CORRECT:
Increment(ref x);  // x is now 6
```

### "My temperature conversion gives the wrong answer"

The formula is `F = C × 9/5 + 32`. In C#, `9/5` is **integer division** and equals `1`, not `1.8`. Write `9.0 / 5.0`:

```csharp
// WRONG — integer division:
fahrenheit = celsius * 9 / 5 + 32;     // C=100 → 132, not 212

// CORRECT — floating-point division:
fahrenheit = celsius * 9.0 / 5.0 + 32; // C=100 → 212 ✓
```

### "My Clamp always returns the same value"

Check the order of your conditions. The logic must be:

```csharp
if (value < min) return min;   // below range
if (value > max) return max;   // above range
return value;                  // inside range
```

If you write `if (value > min)` instead of `<`, you have flipped the condition.

### "SplitAndSum crashes on null input"

Call `string.IsNullOrWhiteSpace(input)` first and return `0` immediately if it is true:

```csharp
if (string.IsNullOrWhiteSpace(input)) return 0;
```

This handles `null`, `""`, and `"   "` in one check.

### "The test says 'Hello Alice!' but expected 'Hello, Alice!'"

Punctuation inside the string literal matters. The comma and exclamation mark must be part of your interpolated string:

```csharp
return $"Hello, {name}!";   // ← comma is INSIDE the literal, not inside { }
```

---

## What makes good code this week

This week all your methods are **pure functions** — they take inputs, compute a result, and return it, with no side effects. That is the easiest code to test and reason about.

Before submitting, ask yourself about each method you wrote:

- Does it do **exactly one thing**? (A method called `ParseAndPrint` does two things — split it.)
- Is the name a **verb** that describes the action? (`Greet`, `Clamp`, `Swap` — good. `DoStuff` — bad.)
- Does it **return** the result instead of printing it directly? (The test cannot see what you printed.)
- Does it handle **edge cases** without crashing? (`null`, empty string, zero, negative numbers.)

Fill in `OOP_DESIGN_SCORECARD.md` before finishing — it only takes two minutes and it trains the habit of evaluating your own code.

---

## After the lab — oral quiz

Your instructor may ask you any of the questions in `QUIZ_QUESTIONS.md` at the start of the next session. There are 8 questions. Spend five minutes reading them before you leave — you already know the answers from doing the exercises.

---

## Need help?

1. Read `TROUBLESHOOTING.md` — it covers the most common errors with solutions.
2. Re-read the demo file for the part you are working on — the answer is almost always already there.
3. Read the test file for the exercise — it shows you the exact inputs and expected outputs.
4. Ask a classmate to look at your code (discussing is allowed; copying is not).
5. Bring the specific failing test name and your current code to the next session.
