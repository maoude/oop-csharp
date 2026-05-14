# Troubleshooting — Week 1

---

## "CS0161: not all code paths return a value"

**Cause:** Your method has a return type but some branch reaches the end
without a `return` statement.

```csharp
// Broken
public static int Clamp(int value, int min, int max)
{
    if (value < min) return min;
    if (value > max) return max;
    // MISSING: what if value is between min and max?
}
```

**Fix:** Add the missing `return value;` at the end.

---

## "System.NotImplementedException" at runtime / test fails with NotImplementedException

**Cause:** You ran the tests before implementing the method. The stub
intentionally throws `NotImplementedException`.

**Fix:** Replace `throw new NotImplementedException();` with your implementation.

---

## `int.Parse` throws `FormatException` during tests

**Cause:** A test is passing a non-numeric string such as `"abc"` or `null`
and you used `int.Parse` instead of `int.TryParse`.

**Fix:** Switch to `int.TryParse(input, out int value)` and return the
default when it returns `false`.

---

## Test passes locally but fails on a different machine

**Cause:** Usually a culture issue with `double.TryParse`. On some systems
the decimal separator is `,` not `.`.

**Fix:** Pass `CultureInfo.InvariantCulture` as the third argument:

```csharp
double.TryParse(input,
    NumberStyles.Float,
    CultureInfo.InvariantCulture,
    out double value)
```

---

## "CS0019: Operator '+' cannot be applied to operands of type 'string' and 'int'"

**Cause:** Trying to concatenate a string and an int with `+` without
converting the int first.

```csharp
string s = "Age: " + age;        // OK — int is auto-converted via ToString()
string s2 = age + " years old";  // Also OK
string s3 = "x=" + x + y;        // TRAP: if x and y are ints, this is fine;
                                  // but order of evaluation matters
```

**Fix:** Prefer string interpolation: `$"Age: {age}"` — clearer and safer.

---

## `Swap` does not actually swap the values

**Cause:** Missing `ref` keyword on the parameter or in the call.

```csharp
// Wrong — value copy, caller unchanged
public static void Swap(int a, int b) { ... }

// Right
public static void Swap(ref int a, ref int b) { ... }
// Call site must also use ref:
Swap(ref x, ref y);
```

---

## `MinMax` — out variables are unassigned after the call

**Cause:** Your method throws an exception before assigning `min` and `max`,
or has a branch that returns without assigning them.

**Rule:** Every `out` parameter **must** be assigned on **every** path that
reaches a `return` statement (including implicit returns at end of method).
The compiler will tell you if you miss one.

---

## `dotnet test` reports "No test assemblies were found"

**Cause:** You are running from the wrong directory, or the project has not
been built yet.

**Fix:**

```powershell
cd week1-lab/week1-day1-intro-csharp
dotnet build
dotnet test Lab.Tests/
```
