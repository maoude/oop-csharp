# Exercises — Week 1

All exercises are **ungraded practice**. Checkpoint 1 is in Week 5.
Pass every test class below before moving to Week 2.

---

## Part 1 — Hello World

### W1.P1.Ex1 — Greeting `[StudentWeek1Part1_Ex1Tests]`

File: `Lab/Part1_HelloWorld/Exercises/Ex1_Greeting.cs`

Implement two static methods that build greeting strings using string interpolation:

- `Greet(string name)` → `"Hello, <name>!"`
- `GreetWithTitle(string title, string name)` → `"<title> <name>, welcome!"`

**Concepts:** string interpolation, static methods, return values.

---

## Part 2 — Methods

### W1.P2.Ex1 — MathHelpers `[StudentWeek1Part2_Ex1Tests]`

File: `Lab/Part2_Methods/Exercises/Ex1_MathHelpers.cs`

Implement four mathematical helper methods:

- `Hypotenuse(double a, double b)` — Pythagoras theorem
- `CircleArea(double radius)` — π × r²
- `Clamp(int value, int min, int max)` — bound value to a range (write the logic yourself, no `Math.Clamp`)
- `AbsDiff(int a, int b)` — absolute difference

**Concepts:** `Math.Sqrt`, `Math.Pow`, `Math.PI`, `Math.Abs`, conditional logic.

---

### W1.P2.Ex2 — Parameters `[StudentWeek1Part2_Ex2Tests]`

File: `Lab/Part2_Methods/Exercises/Ex2_Parameters.cs`

Implement four methods that demonstrate parameter passing modes:

- `Increment(ref int value)` — adds 1 in place
- `Swap(ref int a, ref int b)` — exchanges two variables
- `MinMax(int[] numbers, out int min, out int max)` — finds both extremes in one pass; throws `ArgumentException` on empty/null input
- `FormatTemperature(double celsius, out double fahrenheit)` — converts and formats

**Concepts:** `ref`, `out`, `ArgumentException`, single-pass algorithms.

---

### W1.P2.Ex3 — Overloading `[StudentWeek1Part2_Ex3Tests]`

File: `Lab/Part2_Methods/Exercises/Ex3_Overloading.cs`

Implement five overloaded methods:

- `Repeat(string text, int times)` — string repetition
- `Repeat(char ch, int times)` — character repetition
- `Max(int a, int b)` — larger of two ints
- `Max(double a, double b)` — larger of two doubles
- `Max(int a, int b, int c)` — largest of three ints (call `Max(int, int)` inside)

**Concepts:** method overloading, compiler disambiguation, code reuse between overloads.

---

## Part 3 — Console I/O

### W1.P3.Ex1 — InputParser `[StudentWeek1Part3_Ex1Tests]`

File: `Lab/Part3_ConsoleIO/Exercises/Ex1_InputParser.cs`

Implement four safe input-parsing methods:

- `ParseInt(string? input, int defaultValue)` — safe int parse
- `ParseDouble(string? input, double defaultValue)` — safe double parse
- `ParseBool(string? input)` — accepts "true", "yes", "1", "y" (case-insensitive)
- `SplitAndSum(string? input)` — tokenise whitespace-separated ints, skip bad tokens, sum

**Concepts:** `TryParse`, null-safety (`string?`), `Split`, defensive programming.

---

## Summary table

| Exercise | Test class | Concepts |
|---|---|---|
| W1.P1.Ex1 | `StudentWeek1Part1_Ex1Tests` | interpolation, static, return |
| W1.P2.Ex1 | `StudentWeek1Part2_Ex1Tests` | Math class, conditionals |
| W1.P2.Ex2 | `StudentWeek1Part2_Ex2Tests` | ref, out, ArgumentException |
| W1.P2.Ex3 | `StudentWeek1Part3_Ex3Tests` | overloading |
| W1.P3.Ex1 | `StudentWeek1Part3_Ex1Tests` | TryParse, null-safety, Split |
