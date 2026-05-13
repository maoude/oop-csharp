/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     4 — Classes in C# (Part 2)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W4.P1.Ex1 — Money.
 *           Tests verify ToString format, value equality (Amount + Currency),
 *           hash-code contract, == / != operators, and Add business rule.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week4.Part1_ToStringAndEquality.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="Money"/> (W4.P1.Ex1).</summary>
public class StudentWeek4Part1_Ex1Tests
{
    // ── ToString ──────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(9.99,    "USD", "9.99 USD")]
    [InlineData(0.00,    "EUR", "0.00 EUR")]
    [InlineData(1234.50, "gbp", "1234.50 GBP")]  // currency normalised to upper
    public void ToString_returns_correct_format(decimal amount, string cur, string expected)
    {
        Assert.Equal(expected, new Money(amount, cur).ToString());
    }

    // ── Equals ────────────────────────────────────────────────────────────────

    [Fact]
    public void Equals_same_amount_and_currency_returns_true()
    {
        Assert.True(new Money(5.00m, "USD").Equals(new Money(5.00m, "USD")));
    }

    [Fact]
    public void Equals_different_currency_returns_false()
    {
        Assert.False(new Money(5.00m, "USD").Equals(new Money(5.00m, "EUR")));
    }

    [Fact]
    public void Equals_different_amount_returns_false()
    {
        Assert.False(new Money(5.00m, "USD").Equals(new Money(6.00m, "USD")));
    }

    [Fact]
    public void Equals_null_returns_false()
    {
        Assert.False(new Money(1m, "USD").Equals(null));
    }

    [Fact]
    public void Equals_wrong_type_returns_false()
    {
        Assert.False(new Money(1m, "USD").Equals("1 USD"));
    }

    // ── GetHashCode contract ──────────────────────────────────────────────────

    [Fact]
    public void Equal_objects_have_same_hash_code()
    {
        var a = new Money(9.99m, "USD");
        var b = new Money(9.99m, "USD");
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    [Fact]
    public void Equal_objects_work_as_dictionary_keys()
    {
        var dict = new Dictionary<Money, string>();
        var key  = new Money(10m, "USD");
        dict[key] = "ten dollars";
        var lookup = new Money(10m, "USD");
        Assert.Equal("ten dollars", dict[lookup]);
    }

    // ── == and != operators ───────────────────────────────────────────────────

    [Fact]
    public void Equality_operator_returns_true_for_same_value()
    {
        Assert.True(new Money(5m, "USD") == new Money(5m, "USD"));
    }

    [Fact]
    public void Inequality_operator_returns_true_for_different_currency()
    {
        Assert.True(new Money(5m, "USD") != new Money(5m, "EUR"));
    }

    // ── Add ───────────────────────────────────────────────────────────────────

    [Fact]
    public void Add_same_currency_returns_sum()
    {
        var result = new Money(3.00m, "USD").Add(new Money(4.50m, "USD"));
        Assert.Equal(new Money(7.50m, "USD"), result);
    }

    [Fact]
    public void Add_different_currencies_throws_InvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new Money(5m, "USD").Add(new Money(5m, "EUR")));
    }

    // ── Constructor validation ────────────────────────────────────────────────

    [Fact]
    public void Constructor_negative_amount_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Money(-1m, "USD"));
    }

    [Fact]
    public void Constructor_normalises_currency_to_uppercase()
    {
        var m = new Money(1m, "eur");
        Assert.Equal("EUR", m.Currency);
    }
}
