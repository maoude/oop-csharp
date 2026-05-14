# Lab 4 — Classes in C# (Part 2)

**Course:** Introduction to Object-Oriented Programming with C#  
**Instructor:** Dr. Mohamad Aoude · Lebanese University, Faculty of Engineering  
**Week:** 4  
**Assessment weight:** Ungraded practice — Checkpoint 1 is in Week 5

---

## What you will learn in this lab

By the time you finish every exercise in this lab, you will be able to:

- Override `ToString()` to give any class a meaningful string representation
- Override `Equals(object?)` to define value equality (same data = same object)
- Override `GetHashCode()` and explain why it must be consistent with `Equals()`
- Overload `==` and `!=` operators (and why they come in pairs)
- Overload binary arithmetic operators (`+`, `-`, `*`, `/`)
- Overload the unary negation operator (`-`)
- Explain why commutative operators like `*` need two overloads (`T * scalar` and `scalar * T`)
- Define `implicit` conversion operators (safe, automatic) and `explicit` ones (require a cast)
- Implement `IComparable<T>` to define a natural ordering for a type
- Use `Array.Sort()` on your own types once `IComparable<T>` is implemented
- Derive comparison operators (`<`, `>`) from `CompareTo`

These skills complete your ability to make user-defined types behave like built-in types.

---

## Lab structure

```
week4-day1-classes-part2/
│
├── README.md
├── EXERCISES.md
├── CHECKLIST.md
├── QUIZ_QUESTIONS.md
├── TROUBLESHOOTING.md
├── LAB_INSTRUCTIONS.md
├── OOP_DESIGN_SCORECARD.md
│
├── Lab/
│   ├── Part1_ToStringAndEquality/
│   │   ├── Demo01_ToStringAndEquality.cs    ← READ THIS FIRST
│   │   ├── Exercises/
│   │   │   └── Ex1_Money.cs                 ← YOUR CODE
│   │   └── Solutions/
│   │
│   ├── Part2_OperatorOverloading/
│   │   ├── Demo02_OperatorOverloading.cs    ← READ THIS FIRST
│   │   ├── Exercises/
│   │   │   └── Ex1_Fraction.cs              ← YOUR CODE
│   │   └── Solutions/
│   │
│   └── Part3_ConversionAndComparison/
│       ├── Demo03_ConversionAndComparison.cs ← READ THIS FIRST
│       ├── Exercises/
│       │   └── Ex1_Weight.cs                 ← YOUR CODE
│       └── Solutions/
│
└── Lab.Tests/
    ├── Part1_ToStringAndEquality/Exercises/StudentWeek4Part1_Ex1Tests.cs
    ├── Part2_OperatorOverloading/Exercises/StudentWeek4Part2_Ex1Tests.cs
    └── Part3_ConversionAndComparison/Exercises/StudentWeek4Part3_Ex1Tests.cs
```

---

## Running the tests

```powershell
# All tests:
dotnet test Lab.Tests/

# By part:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part2"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part3"

# By exercise:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part1_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part2_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek4Part3_Ex1"
```

---

## The exercises — what you need to implement

### Part 1 — ToString and Equality

#### Exercise W4.P1.Ex1 — Money `[Ex1_Money.cs]`

A monetary amount (`9.99 USD`) that uses value equality: two `Money` objects are equal when both `Amount` and `Currency` match.

| Member | Description |
|--------|-------------|
| `ToString()` | `"9.99 USD"` — amount to 2 d.p., space, uppercase currency |
| `Equals(object?)` | True when Amount AND Currency both match |
| `GetHashCode()` | `HashCode.Combine(Amount, Currency)` |
| `operator ==` | Delegates to `Equals` |
| `operator !=` | Negates `==` |
| `Add(Money other)` | Returns a new Money with combined amount; throws for different currencies |

**Key concept:** The `Equals`/`GetHashCode` **contract** — if `a.Equals(b)` is true, then `a.GetHashCode() == b.GetHashCode()` must also be true. Violating this breaks `Dictionary<Money, V>` lookups.

Test class: `StudentWeek4Part1_Ex1Tests` (14 tests)

---

### Part 2 — Operator Overloading

#### Exercise W4.P2.Ex1 — Fraction `[Ex1_Fraction.cs]`

An exact rational number (`1/2`, `3/4`) always stored in lowest terms. The constructor already handles reduction and sign normalisation — your operators just need to apply the correct formula and return a new `Fraction`.

| Operator | Formula |
|----------|---------|
| `+` | `(a.N * b.D + b.N * a.D) / (a.D * b.D)` |
| `-` (binary) | `(a.N * b.D - b.N * a.D) / (a.D * b.D)` |
| `*` | `(a.N * b.N) / (a.D * b.D)` |
| `/` | `(a.N * b.D) / (a.D * b.N)` — throws `DivideByZeroException` if `b.N == 0` |
| `-` (unary) | `(-f.N) / f.D` |
| `==` / `!=` | Compare Numerator AND Denominator (already reduced, so `2/4` and `1/2` are equal) |

**Key concept:** `==` and `!=` must be defined as a pair. Overloading `==` requires overriding `Equals()` and `GetHashCode()` for consistency.

Test class: `StudentWeek4Part2_Ex1Tests` (16 tests)

---

### Part 3 — Conversion and Comparison

#### Exercise W4.P3.Ex1 — Weight `[Ex1_Weight.cs]`

A weight in kilograms that supports unit-safe conversions and natural ordering.

| Member | Kind | Description |
|--------|------|-------------|
| `implicit operator Weight(double kg)` | implicit | `Weight w = 70.5;` — no cast needed |
| `explicit operator double(Weight w)` | explicit | `double d = (double)w;` — cast required |
| `Pounds` | computed property | `Kilograms * 2.20462` |
| `ToString()` | override | `"70.50 kg"` |
| `CompareTo(Weight?)` | `IComparable<Weight>` | Ascending by Kilograms; null → return 1 |
| `operator <` | derived from `CompareTo` | `a.CompareTo(b) < 0` |
| `operator >` | derived from `CompareTo` | `a.CompareTo(b) > 0` |

**Key concept:** `implicit` conversion means no cast required — use it only when the conversion is always safe. `explicit` forces the caller to write a cast, signalling that they are consciously extracting a raw value.

Test class: `StudentWeek4Part3_Ex1Tests` (14 tests)

---

## Progress summary

| Exercise | File | Test class | Tests |
|----------|------|------------|-------|
| W4.P1.Ex1 — Money | `Ex1_Money.cs` | `StudentWeek4Part1_Ex1Tests` | 14 |
| W4.P2.Ex1 — Fraction | `Ex1_Fraction.cs` | `StudentWeek4Part2_Ex1Tests` | 16 |
| W4.P3.Ex1 — Weight | `Ex1_Weight.cs` | `StudentWeek4Part3_Ex1Tests` | 14 |
| **Total** | | | **44 test cases** |

---

## Common mistakes and how to fix them

### "My Dictionary lookup fails even though the keys look equal"

You overrode `Equals` but not `GetHashCode`. A `Dictionary` uses the hash code to find the bucket, then uses `Equals` to confirm the match. If two equal objects have different hash codes, the lookup fails silently.

```csharp
// ALWAYS override both together:
public override bool Equals(object? obj) { ... }
public override int GetHashCode() => HashCode.Combine(Amount, Currency);
```

### "3.0 * fraction gives a compile error"

You only defined `operator *(Fraction, double)` but not `operator *(double, Fraction)`. C# does NOT automatically flip the operands — you need both overloads.

### "1/2 + 1/3 gives 5/6 but the test expects Fraction(5,6) — they look the same but fail"

Check that your `Equals` compares `Numerator` and `Denominator` after reduction. If your operator returns an unreduced fraction (`10/12` instead of `5/6`), the `Equals` check fails.

### "Fraction division throws even for valid fractions"

You checked `b == 0` (the int literal) instead of `b.Numerator == 0`. The divisor Fraction is zero only when its numerator is zero.

```csharp
if (b.Numerator == 0) throw new DivideByZeroException(...);
```

### "Weight w = 70.5 gives a compile error"

Your implicit operator signature is wrong. It must match exactly:

```csharp
public static implicit operator Weight(double kg) => new Weight(kg);
```

### "Array.Sort doesn't sort my Weights"

`CompareTo` must return a negative number when `this < other`. Check you are calling `Kilograms.CompareTo(other.Kilograms)`, not the reverse.

---

## After the lab — oral quiz

Read `QUIZ_QUESTIONS.md` before the next session — 8 questions, five minutes.

---

## Need help?

1. Re-read the demo file for the part.
2. Read `TROUBLESHOOTING.md`.
3. Read the test file — exact inputs and expected outputs are there.
4. Ask a classmate (discuss, don't copy).
5. Bring the failing test name and your code to the next session.
