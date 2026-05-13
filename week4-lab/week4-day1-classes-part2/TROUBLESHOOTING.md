# Troubleshooting — Week 4 · Classes in C# (Part 2)

---

## Build errors

### "Operator '==' requires a matching operator '!=' to also be defined"

`==` and `!=` must always be defined as a pair. Add the `!=` overload:

```csharp
public static bool operator !=(MyType a, MyType b) => !(a == b);
```

### "'override' required — member hides inherited member"

You wrote `public new string ToString()` instead of `public override string ToString()`. Change `new` to `override`.

### "Cannot implicitly convert type 'double' to 'Weight'"

Your implicit operator is missing or has the wrong signature. It must be exactly:

```csharp
public static implicit operator Weight(double kg) => new Weight(kg);
```

### "CS0535: 'Weight' does not implement interface member 'IComparable<Weight>.CompareTo'"

Your `CompareTo` method has a wrong signature. It must be:

```csharp
public int CompareTo(Weight? other)
```

Not `CompareTo(object? other)` — that is the non-generic `IComparable` interface.

---

## Test failures

### Money — Dictionary lookup test fails

You overrode `Equals` but not `GetHashCode`. Add:

```csharp
public override int GetHashCode() => HashCode.Combine(Amount, Currency);
```

### Money — "Add different currencies" test does not throw

You are not comparing the currencies before adding. Check:

```csharp
if (Currency != other.Currency)
    throw new InvalidOperationException($"Cannot add {Currency} and {other.Currency}.");
```

### Fraction — "1/2 + 1/3 equals 5/6" fails

Your result is not being reduced. Make sure you return `new Fraction(numerator, denominator)` (not a raw struct) — the `Fraction` constructor handles GCD reduction automatically.

### Fraction — Division throws for valid fractions

You may be checking `if (b == 0)` which compares a `Fraction` to an `int` and always fails. Check the numerator:

```csharp
if (b.Numerator == 0) throw new DivideByZeroException("Cannot divide by zero fraction.");
```

### Fraction — Unary minus test fails

Your unary `-` operator negated the denominator instead of the numerator. The denominator must stay positive:

```csharp
return new Fraction(-f.Numerator, f.Denominator);
```

### Weight — `Array.Sort` does not sort correctly

`CompareTo` is returning the wrong sign. Verify:

```csharp
return Kilograms.CompareTo(other.Kilograms);
// NOT: return other.Kilograms.CompareTo(Kilograms);  ← that would sort descending
```

### Weight — `<` operator always returns false

You may have written `a.CompareTo(b) > 0` instead of `< 0` for the `<` operator:

```csharp
public static bool operator <(Weight a, Weight b) => a.CompareTo(b) < 0;
public static bool operator >(Weight a, Weight b) => a.CompareTo(b) > 0;
```

---

## Runtime errors

### NullReferenceException in Equals

You did not guard against `null`. Use the `is not` pattern:

```csharp
if (obj is not Money other) return false;
```

This handles both `null` and wrong-type in one check.

### InvalidCastException from explicit conversion

If a test calls `(double)weight` and you have not implemented the `explicit` operator, the runtime throws. Make sure the operator exists:

```csharp
public static explicit operator double(Weight w) => w.Kilograms;
```
