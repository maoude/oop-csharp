/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W4.P2.Ex1 — Fraction.
 *          Do NOT share with students before the submission deadline.
 */
namespace OopCsharp.Week4.Part2_OperatorOverloading.Solutions;

public class Sol1_Fraction
{
    public int Numerator   { get; }
    public int Denominator { get; }

    public Sol1_Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
        int sign = denominator < 0 ? -1 : 1;
        int gcd  = Gcd(Math.Abs(numerator), Math.Abs(denominator));
        Numerator   = sign * numerator   / gcd;
        Denominator = sign * denominator / gcd;
    }

    private static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);

    public override string ToString()
        => Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";

    public static Sol1_Fraction operator +(Sol1_Fraction a, Sol1_Fraction b)
        => new(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
               a.Denominator * b.Denominator);

    public static Sol1_Fraction operator -(Sol1_Fraction a, Sol1_Fraction b)
        => new(a.Numerator * b.Denominator - b.Numerator * a.Denominator,
               a.Denominator * b.Denominator);

    public static Sol1_Fraction operator *(Sol1_Fraction a, Sol1_Fraction b)
        => new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

    public static Sol1_Fraction operator /(Sol1_Fraction a, Sol1_Fraction b)
    {
        if (b.Numerator == 0) throw new DivideByZeroException("Cannot divide by zero fraction.");
        return new(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    public static Sol1_Fraction operator -(Sol1_Fraction f)
        => new(-f.Numerator, f.Denominator);

    public static bool operator ==(Sol1_Fraction a, Sol1_Fraction b)
        => a.Numerator == b.Numerator && a.Denominator == b.Denominator;

    public static bool operator !=(Sol1_Fraction a, Sol1_Fraction b) => !(a == b);

    public override bool Equals(object? obj) => obj is Sol1_Fraction other && this == other;
    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);
}
