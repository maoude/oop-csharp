/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W3.P2.Ex1 — BankAccount.
 *          Do NOT share with students before the submission deadline.
 */
namespace OopCsharp.Week3.Part2_PropertiesAndConstructors.Solutions;

/// <summary>Reference solution for BankAccount (W3.P2.Ex1).</summary>
public class Sol1_BankAccount
{
    private decimal _balance;

    public string  AccountNumber { get; init; }
    public string  Owner         { get; private set; }
    public decimal Balance       => _balance;

    public Sol1_BankAccount(string accountNumber, string owner, decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException(
                "Initial balance cannot be negative.", nameof(initialBalance));

        AccountNumber = accountNumber;
        Owner         = owner;
        _balance      = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.", nameof(amount));
        _balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));
        if (amount > _balance) return false;
        _balance -= amount;
        return true;
    }

    public string Summary()
        => $"Account {AccountNumber} ({Owner}): ${Balance:F2}";
}
