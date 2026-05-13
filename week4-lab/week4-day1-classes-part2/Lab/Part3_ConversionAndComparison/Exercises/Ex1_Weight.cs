/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W4.P3.Ex1 — Weight.
 *          Practise implicit and explicit conversion operators and
 *          IComparable<T> for natural ordering.
 */
namespace OopCsharp.Week4.Part3_ConversionAndComparison.Exercises;

/// <summary>
/// Exercise W4.P3.Ex1 — Weight.
///
/// A weight stored internally in kilograms.
/// Supports implicit conversion from double (kg) and explicit
/// conversion to double.  Implements IComparable&lt;Weight&gt; so
/// arrays of weights can be sorted with Array.Sort().
/// </summary>
public class Weight : IComparable<Weight>
{
    // ── Property (already declared) ────────────────────────────────────────────
    /// <summary>Weight in kilograms.</summary>
    public double Kilograms { get; }

    // ── Constructor (already implemented) ─────────────────────────────────────
    public Weight(double kilograms)
    {
        if (kilograms < 0)
            throw new ArgumentException("Weight cannot be negative.", nameof(kilograms));
        Kilograms = kilograms;
    }

    // ── TODO 1 — Implicit conversion: double → Weight ─────────────────────────
    //
    // Makes  Weight w = 70.5;  compile (no cast needed).
    //
    //   public static implicit operator Weight(double kg)
    //       => new Weight(kg);
    //
    // WHY implicit? Any non-negative double is a valid weight, so the
    // conversion is always safe and no information is lost.
    // (The constructor will still throw for negatives — that is acceptable.)
    public static implicit operator Weight(double kg)
    {
        throw new NotImplementedException();
    }

    // ── TODO 2 — Explicit conversion: Weight → double ─────────────────────────
    //
    // Makes  double kg = (double)w;  compile (cast required).
    //
    //   public static explicit operator double(Weight w)
    //       => w.Kilograms;
    //
    // WHY explicit? The caller should consciously decide to strip the
    // unit — making it implicit could lead to accidentally mixing up
    // a Weight object with a raw double in arithmetic.
    public static explicit operator double(Weight w)
    {
        throw new NotImplementedException();
    }

    // ── TODO 3 — Computed property: Pounds ────────────────────────────────────
    //
    // Returns the weight converted to pounds (1 kg = 2.20462 lb).
    //   public double Pounds => Kilograms * 2.20462;
    public double Pounds
    {
        get { throw new NotImplementedException(); }
    }

    // ── TODO 4 — ToString() ───────────────────────────────────────────────────
    //
    // Returns:  "70.50 kg"
    //   return $"{Kilograms:F2} kg";
    public override string ToString()
    {
        throw new NotImplementedException();
    }

    // ── TODO 5 — CompareTo(Weight? other) ────────────────────────────────────
    //
    // Implement IComparable<Weight> so Array.Sort works on Weight[].
    //
    // Natural ordering: lighter weights come first (ascending by Kilograms).
    //
    //   if (other is null) return 1;   // null is less than any Weight
    //   return Kilograms.CompareTo(other.Kilograms);
    //
    // CompareTo returns:
    //   < 0  →  this is lighter than other
    //     0  →  same weight
    //   > 0  →  this is heavier than other
    public int CompareTo(Weight? other)
    {
        throw new NotImplementedException();
    }

    // ── TODO 6 — Operator < and > ─────────────────────────────────────────────
    //
    // Derive from CompareTo (< and > must be defined together):
    //   operator <:  return a.CompareTo(b) < 0;
    //   operator >:  return a.CompareTo(b) > 0;
    public static bool operator <(Weight a, Weight b)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Weight a, Weight b)
    {
        throw new NotImplementedException();
    }
}
