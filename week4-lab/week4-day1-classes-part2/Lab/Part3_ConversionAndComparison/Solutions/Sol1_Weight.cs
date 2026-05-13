/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W4.P3.Ex1 — Weight.
 *          Do NOT share with students before the submission deadline.
 */
namespace OopCsharp.Week4.Part3_ConversionAndComparison.Solutions;

public class Sol1_Weight : IComparable<Sol1_Weight>
{
    public double Kilograms { get; }

    public Sol1_Weight(double kilograms)
    {
        if (kilograms < 0)
            throw new ArgumentException("Weight cannot be negative.", nameof(kilograms));
        Kilograms = kilograms;
    }

    public static implicit operator Sol1_Weight(double kg) => new(kg);
    public static explicit operator double(Sol1_Weight w)  => w.Kilograms;

    public double Pounds => Kilograms * 2.20462;

    public override string ToString() => $"{Kilograms:F2} kg";

    public int CompareTo(Sol1_Weight? other)
    {
        if (other is null) return 1;
        return Kilograms.CompareTo(other.Kilograms);
    }

    public static bool operator <(Sol1_Weight a, Sol1_Weight b) => a.CompareTo(b) < 0;
    public static bool operator >(Sol1_Weight a, Sol1_Weight b) => a.CompareTo(b) > 0;
}
