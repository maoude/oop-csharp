/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W4.P1.Ex1 — Money.
 *          Do NOT share with students before the submission deadline.
 */
namespace OopCsharp.Week4.Part1_ToStringAndEquality.Solutions;

public class Sol1_Money
{
    public decimal Amount   { get; }
    public string  Currency { get; }

    public Sol1_Money(decimal amount, string currency)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));
        Amount   = amount;
        Currency = currency.ToUpperInvariant();
    }

    public override string ToString() => $"{Amount:F2} {Currency}";

    public override bool Equals(object? obj)
    {
        if (obj is not Sol1_Money other) return false;
        return Amount == other.Amount && Currency == other.Currency;
    }

    public override int GetHashCode() => HashCode.Combine(Amount, Currency);

    public static bool operator ==(Sol1_Money a, Sol1_Money b) => a.Equals(b);
    public static bool operator !=(Sol1_Money a, Sol1_Money b) => !(a == b);

    public Sol1_Money Add(Sol1_Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException(
                $"Cannot add {Currency} and {other.Currency}.");
        return new Sol1_Money(Amount + other.Amount, Currency);
    }
}
