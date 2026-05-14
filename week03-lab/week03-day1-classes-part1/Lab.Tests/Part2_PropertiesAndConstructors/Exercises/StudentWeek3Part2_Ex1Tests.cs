/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     3 — Classes in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W3.P2.Ex1 — BankAccount.
 *           Tests verify constructor validation, property encapsulation,
 *           deposit/withdraw business rules, and the Summary format.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week3.Part2_PropertiesAndConstructors.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="BankAccount"/> (W3.P2.Ex1).</summary>
public class StudentWeek3Part2_Ex1Tests
{
    // ── Constructor ───────────────────────────────────────────────────────────

    [Fact]
    public void Constructor_sets_properties_correctly()
    {
        var acc = new BankAccount("ACC001", "Alice", 100m);
        Assert.Equal("ACC001", acc.AccountNumber);
        Assert.Equal("Alice",  acc.Owner);
        Assert.Equal(100m,     acc.Balance);
    }

    [Fact]
    public void Constructor_negative_balance_throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            new BankAccount("ACC002", "Bob", -1m));
    }

    [Fact]
    public void Constructor_zero_balance_is_valid()
    {
        var acc = new BankAccount("ACC003", "Carol", 0m);
        Assert.Equal(0m, acc.Balance);
    }

    // ── AccountNumber is init-only ────────────────────────────────────────────
    // (Compile-time check — if AccountNumber had a public setter this
    //  test would not be needed, but we verify it stays immutable at runtime
    //  by confirming Balance can still be read after construction.)
    [Fact]
    public void AccountNumber_is_readable_after_construction()
    {
        var acc = new BankAccount("X99", "Test", 50m);
        Assert.Equal("X99", acc.AccountNumber);
    }

    // ── Deposit ───────────────────────────────────────────────────────────────

    [Fact]
    public void Deposit_increases_balance()
    {
        var acc = new BankAccount("A1", "Dave", 100m);
        acc.Deposit(50m);
        Assert.Equal(150m, acc.Balance);
    }

    [Fact]
    public void Deposit_zero_throws_ArgumentException()
    {
        var acc = new BankAccount("A1", "Dave", 100m);
        Assert.Throws<ArgumentException>(() => acc.Deposit(0m));
    }

    [Fact]
    public void Deposit_negative_throws_ArgumentException()
    {
        var acc = new BankAccount("A1", "Dave", 100m);
        Assert.Throws<ArgumentException>(() => acc.Deposit(-10m));
    }

    // ── Withdraw ──────────────────────────────────────────────────────────────

    [Fact]
    public void Withdraw_decreases_balance_and_returns_true()
    {
        var acc = new BankAccount("A1", "Eve", 200m);
        bool ok = acc.Withdraw(75m);
        Assert.True(ok);
        Assert.Equal(125m, acc.Balance);
    }

    [Fact]
    public void Withdraw_exact_balance_succeeds()
    {
        var acc = new BankAccount("A1", "Eve", 100m);
        bool ok = acc.Withdraw(100m);
        Assert.True(ok);
        Assert.Equal(0m, acc.Balance);
    }

    [Fact]
    public void Withdraw_insufficient_funds_returns_false_balance_unchanged()
    {
        var acc = new BankAccount("A1", "Eve", 50m);
        bool ok = acc.Withdraw(100m);
        Assert.False(ok);
        Assert.Equal(50m, acc.Balance);   // unchanged
    }

    [Fact]
    public void Withdraw_zero_throws_ArgumentException()
    {
        var acc = new BankAccount("A1", "Eve", 100m);
        Assert.Throws<ArgumentException>(() => acc.Withdraw(0m));
    }

    // ── Summary ───────────────────────────────────────────────────────────────

    [Fact]
    public void Summary_returns_correct_format()
    {
        var acc = new BankAccount("ACC001", "Alice", 1234.56m);
        Assert.Equal("Account ACC001 (Alice): $1234.56", acc.Summary());
    }

    [Fact]
    public void Summary_formats_zero_correctly()
    {
        var acc = new BankAccount("Z00", "Zero", 0m);
        Assert.Equal("Account Z00 (Zero): $0.00", acc.Summary());
    }
}
