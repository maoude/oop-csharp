/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W4.P2.Ex1 — Fraction.
 *          Practise operator overloading: arithmetic (+, -, *, /),
 *          equality (==, !=), unary (-), and ToString() for display.
 *          Fractions are always stored in reduced form.
 */
namespace OopCsharp.Week4.Part2_OperatorOverloading.Exercises;

/// <summary>
/// Exercise W4.P2.Ex1 — Fraction.
///
/// An exact rational number (numerator / denominator).
/// Always stored in lowest terms with a positive denominator.
/// Implement the members marked with TODO below.
/// </summary>
public class Fraction
{
    public int Numerator   { get; }
    public int Denominator { get; }

    // ── Constructor (already implemented) ─────────────────────────────────────
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));

        // Normalise: keep denominator positive; move sign to numerator
        int sign = denominator < 0 ? -1 : 1;
        int gcd  = Gcd(Math.Abs(numerator), Math.Abs(denominator));

        Numerator   = sign * numerator   / gcd;
        Denominator = sign * denominator / gcd;
    }

    // ── GCD helper (already implemented) ──────────────────────────────────────
    private static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);

    // ── TODO 1 — ToString() ───────────────────────────────────────────────────
    //
    // Return the fraction as a string:
    //   1/2  →  "1/2"
    //   3/1  →  "3"   (whole numbers drop the denominator)
    //
    // Use:
    //   if (Denominator == 1) return Numerator.ToString();
    //   return $"{Numerator}/{Denominator}";
    public override string ToString()
    {
        throw new NotImplementedException();
    }

    // ── TODO 2 — operator + ───────────────────────────────────────────────────
    //
    // Fraction addition:  a/b + c/d = (a*d + c*b) / (b*d)
    //
    // The Fraction constructor will automatically reduce the result.
    //
    //   return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
    //                       a.Denominator * b.Denominator);
    public static Fraction operator +(Fraction a, Fraction b)
    {
        throw new NotImplementedException();
    }

    // ── TODO 3 — operator - (binary) ─────────────────────────────────────────
    //
    // Fraction subtraction: a/b - c/d = (a*d - c*b) / (b*d)
    public static Fraction operator -(Fraction a, Fraction b)
    {
        throw new NotImplementedException();
    }

    // ── TODO 4 — operator * ───────────────────────────────────────────────────
    //
    // Fraction multiplication: a/b * c/d = (a*c) / (b*d)
    public static Fraction operator *(Fraction a, Fraction b)
    {
        throw new NotImplementedException();
    }

    // ── TODO 5 — operator / ───────────────────────────────────────────────────
    //
    // Fraction division: a/b / c/d = (a*d) / (b*c)
    // Tip: dividing by c/d is the same as multiplying by d/c.
    //
    // If b is zero (i.e. b.Numerator == 0), throw:
    //   throw new DivideByZeroException("Cannot divide by zero fraction.");
    public static Fraction operator /(Fraction a, Fraction b)
    {
        throw new NotImplementedException();
    }

    // ── TODO 6 — operator - (unary) ───────────────────────────────────────────
    //
    // Negation: -a/b = (-a)/b
    //   return new Fraction(-f.Numerator, f.Denominator);
    public static Fraction operator -(Fraction f)
    {
        throw new NotImplementedException();
    }

    // ── TODO 7 — operator == and != ───────────────────────────────────────────
    //
    // Two fractions are equal when their numerators AND denominators match
    // (they are already reduced, so 1/2 and 2/4 both become 1/2).
    //
    //   operator==:  return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
    //   operator!=:  return !(a == b);
    public static bool operator ==(Fraction a, Fraction b)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        throw new NotImplementedException();
    }

    // ── TODO 8 — Equals and GetHashCode (required by compiler warning) ─────────
    //
    // Equals:      return obj is Fraction other && this == other;
    // GetHashCode: return HashCode.Combine(Numerator, Denominator);
    public override bool Equals(object? obj)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
