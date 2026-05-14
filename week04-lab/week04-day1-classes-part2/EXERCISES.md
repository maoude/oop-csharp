# Exercises — Week 4 · Classes in C# (Part 2)

---

## Part 1 — ToString and Equality

### W4.P1.Ex1 — Money `[Lab/Part1_ToStringAndEquality/Exercises/Ex1_Money.cs]`

| # | Member | Signature |
|---|--------|-----------|
| 1 | ToString | `public override string ToString()` |
| 2 | Equals | `public override bool Equals(object? obj)` |
| 3 | GetHashCode | `public override int GetHashCode()` |
| 4 | operator == | `public static bool operator ==(Money a, Money b)` |
| 5 | operator != | `public static bool operator !=(Money a, Money b)` |
| 6 | Add | `public Money Add(Money other)` |

Test class: `StudentWeek4Part1_Ex1Tests`

---

## Part 2 — Operator Overloading

### W4.P2.Ex1 — Fraction `[Lab/Part2_OperatorOverloading/Exercises/Ex1_Fraction.cs]`

| # | Member | Signature |
|---|--------|-----------|
| 1 | ToString | `public override string ToString()` |
| 2 | operator + | `public static Fraction operator +(Fraction a, Fraction b)` |
| 3 | operator - (binary) | `public static Fraction operator -(Fraction a, Fraction b)` |
| 4 | operator * | `public static Fraction operator *(Fraction a, Fraction b)` |
| 5 | operator / | `public static Fraction operator /(Fraction a, Fraction b)` |
| 6 | operator - (unary) | `public static Fraction operator -(Fraction f)` |
| 7 | operator == | `public static bool operator ==(Fraction a, Fraction b)` |
| 8 | operator != | `public static bool operator !=(Fraction a, Fraction b)` |
| 9 | Equals | `public override bool Equals(object? obj)` |
| 10 | GetHashCode | `public override int GetHashCode()` |

Test class: `StudentWeek4Part2_Ex1Tests`

---

## Part 3 — Conversion and Comparison

### W4.P3.Ex1 — Weight `[Lab/Part3_ConversionAndComparison/Exercises/Ex1_Weight.cs]`

| # | Member | Signature |
|---|--------|-----------|
| 1 | implicit double→Weight | `public static implicit operator Weight(double kg)` |
| 2 | explicit Weight→double | `public static explicit operator double(Weight w)` |
| 3 | Pounds | `public double Pounds { get; }` |
| 4 | ToString | `public override string ToString()` |
| 5 | CompareTo | `public int CompareTo(Weight? other)` |
| 6 | operator < | `public static bool operator <(Weight a, Weight b)` |
| 7 | operator > | `public static bool operator >(Weight a, Weight b)` |

Test class: `StudentWeek4Part3_Ex1Tests`
