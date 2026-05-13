# Oral Quiz Questions — Week 1

These questions are asked during or after the lab session. Students should
be able to answer without looking at their notes. Answers are in the
instructor key below (collapsed — expand only after the student answers).

---

## Q1 — Console output
What is the difference between `Console.Write("x")` and `Console.WriteLine("x")`?

<details><summary>Answer</summary>
`WriteLine` appends a newline character after the text so the cursor moves
to the next line. `Write` leaves the cursor on the same line.
</details>

---

## Q2 — Return types
A method declared as `void Greet(string name)` — what can you do with its
return value?

<details><summary>Answer</summary>
Nothing. `void` means the method produces no value. You cannot assign the
call to a variable or use it in an expression.
</details>

---

## Q3 — ref vs out
What is the key difference between a `ref` parameter and an `out` parameter?

<details><summary>Answer</summary>
`ref`: the variable must be initialised **before** the call; the method may
read and write it.
`out`: the variable does not need to be initialised before the call; the
method **must** assign it before returning.
</details>

---

## Q4 — TryParse
Why do we prefer `int.TryParse(s, out int n)` over `int.Parse(s)`?

<details><summary>Answer</summary>
`int.Parse` throws a `FormatException` when the string is not a valid
integer, which crashes the program unless caught. `int.TryParse` returns
`false` on bad input without throwing, letting the caller handle it safely.
</details>

---

## Q5 — Method overloading
We have `Max(int a, int b)` and `Max(double a, double b)`. A student calls
`Max(3, 4.0)`. Which overload is called and why?

<details><summary>Answer</summary>
The `Max(double, double)` overload is called. The compiler promotes `3`
(an `int`) to `double` (an implicit widening conversion) to match the
`double` overload. No explicit cast is needed.
</details>

---

## Q6 — Math class
Write one line of code that computes the distance between points (1, 2) and
(4, 6) using `Math` methods.

<details><summary>Answer</summary>

```csharp
double dist = Math.Sqrt(Math.Pow(4 - 1, 2) + Math.Pow(6 - 2, 2)); // 5.0
```
</details>

---

## Q7 — Optional parameters
Given `string Describe(string name, int age = 18)`, what does
`Describe("Alice")` return?

<details><summary>Answer</summary>
The `age` parameter takes its default value of 18, so the result is
whatever the method body computes with `name = "Alice"` and `age = 18`.
For the demo: `"Alice is 18 years old."`
</details>

---

## Q8 — Design question
A student writes a method called `DoStuff(int x)`. What naming guideline
does this violate, and what would a better name look like?

<details><summary>Answer</summary>
Method names should be **verbs** that clearly describe what the method does,
not vague placeholders. `DoStuff` gives the caller no information about
intent. Better names: `DoubleValue`, `ComputeSquare`, `PrintSeparator` —
each tells you exactly what happens.
</details>
