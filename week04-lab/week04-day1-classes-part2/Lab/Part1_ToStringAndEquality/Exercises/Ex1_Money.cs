/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W4.P1.Ex1 — Money.
 *          Practise overriding ToString(), Equals(), and GetHashCode().
 *          Understand the contract: if two objects are equal, they must
 *          have the same hash code.
 */
namespace OopCsharp.Week4.Part1_ToStringAndEquality.Exercises;

/// <summary>
/// Exercise W4.P1.Ex1 — Money.
///
/// A monetary amount with a currency code (e.g. 9.99, "USD").
/// Two Money values are equal when BOTH amount AND currency match.
/// Implement the six members marked with TODO below.
/// </summary>
public class Money
{
    // ── Properties (already declared — do not change) ─────────────────────────
    public decimal Amount   { get; }
    public string  Currency { get; }

    // ── Constructor (already implemented — do not change) ─────────────────────
    public Money(decimal amount, string currency)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));
        Amount   = amount;
        Currency = currency.ToUpperInvariant();
    }

    // ── TODO 1 — ToString() ───────────────────────────────────────────────────
    //
    // Override ToString() to return:
    //   "9.99 USD"
    //
    // Use:
    //   return $"{Amount:F2} {Currency}";
    //
    // ':F2' formats the decimal to exactly two decimal places.
    // This string will appear automatically in Console.WriteLine and
    // in string interpolation: $"Price: {money}"
    public override string ToString()
    {
        throw new NotImplementedException();
    }

    // ── TODO 2 — Equals(object? obj) ──────────────────────────────────────────
    //
    // Override Equals() to return true when BOTH Amount AND Currency match.
    //
    // Pattern:
    //   if (obj is not Money other) return false;
    //   return Amount == other.Amount && Currency == other.Currency;
    //
    // KEY: two Money objects with different currencies (USD vs EUR)
    // must NOT be equal even if they have the same numeric amount.
    public override bool Equals(object? obj)
    {
        throw new NotImplementedException();
    }

    // ── TODO 3 — GetHashCode() ────────────────────────────────────────────────
    //
    // Override GetHashCode() using the same fields as Equals():
    //   return HashCode.Combine(Amount, Currency);
    //
    // CONTRACT: if a.Equals(b) is true, then a.GetHashCode() == b.GetHashCode().
    // Violating this contract breaks Dictionary<Money,T> lookups.
    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    // ── TODO 4 — operator == ─────────────────────────────────────────────────
    //
    // Overload == to use value equality (delegate to Equals):
    //   return a.Equals(b);
    //
    // == and != must ALWAYS be defined in pairs.
    public static bool operator ==(Money a, Money b)
    {
        throw new NotImplementedException();
    }

    // ── TODO 5 — operator != ─────────────────────────────────────────────────
    //
    // Overload != by negating ==:
    //   return !(a == b);
    public static bool operator !=(Money a, Money b)
    {
        throw new NotImplementedException();
    }

    // ── TODO 6 — Add(Money other) ────────────────────────────────────────────
    //
    // Returns a NEW Money with the combined amounts.
    // If the currencies differ, throw:
    //   throw new InvalidOperationException(
    //       $"Cannot add {Currency} and {other.Currency}.");
    //
    // Example:
    //   new Money(5.00m, "USD").Add(new Money(3.00m, "USD"))
    //   → new Money(8.00m, "USD")
    public Money Add(Money other)
    {
        throw new NotImplementedException();
    }
}
