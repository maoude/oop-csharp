/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W3.P2.Ex1 — BankAccount.
 *          Practise private backing fields, full properties with validation,
 *          a parameterised constructor, and instance methods that enforce
 *          business rules.
 */
namespace OopCsharp.Week3.Part2_PropertiesAndConstructors.Exercises;

/// <summary>
/// Exercise W3.P2.Ex1 — BankAccount.
///
/// Implement the BankAccount class.  Read every TODO carefully —
/// the order matters because later TODOs depend on earlier ones.
/// </summary>
public class BankAccount
{
    // ── TODO 1 — Private backing field ───────────────────────────────────────
    //
    // Replace the placeholder below with:
    //   private decimal _balance;
    //
    // 'decimal' is the correct type for money — it avoids the floating-point
    // rounding errors that 'double' has (0.1 + 0.2 is not exactly 0.3 in double,
    // but it is in decimal).
    //
    // This field is private — only code inside BankAccount reads or writes it.
    // External code uses the Balance property (TODO 4).
    private decimal _balance;   // ← keep this; it is already declared for you

    // ── TODO 2 — AccountNumber property (auto, init-only) ────────────────────
    //
    // Replace the placeholder with:
    //   public string AccountNumber { get; init; }
    //
    // 'init' means the setter only runs during object construction (in a
    // constructor or object initialiser { ... }).  After the constructor
    // finishes, AccountNumber becomes permanently read-only.
    public string AccountNumber { get; init; } = string.Empty;

    // ── TODO 3 — Owner property (auto, public get, private set) ──────────────
    //
    // Replace the placeholder with:
    //   public string Owner { get; private set; }
    //
    // Anyone can read Owner, but only BankAccount's own methods can change it.
    public string Owner { get; private set; } = string.Empty;

    // ── TODO 4 — Balance property (full property, read-only from outside) ─────
    //
    // Replace throw new NotImplementedException() in the getter with:
    //   return _balance;
    //
    // There is NO setter — balance changes only through Deposit/Withdraw.
    // This is ENCAPSULATION: the class controls how its data changes.
    public decimal Balance
    {
        get { throw new NotImplementedException(); }
    }

    // ── TODO 5 — Constructor ──────────────────────────────────────────────────
    //
    // Replace throw with:
    //   1. If initialBalance < 0, throw:
    //        throw new ArgumentException(
    //            "Initial balance cannot be negative.", nameof(initialBalance));
    //   2. AccountNumber = accountNumber;
    //   3. Owner = owner;
    //   4. _balance = initialBalance;
    //
    // WHY validate in the constructor? Because an object should NEVER exist
    // in an invalid state.  Catching bad data at construction time is cheaper
    // and safer than discovering it later during a transaction.
    public BankAccount(string accountNumber, string owner, decimal initialBalance)
    {
        throw new NotImplementedException();
    }

    // ── TODO 6 — Deposit(decimal amount) ─────────────────────────────────────
    //
    // Replace throw with:
    //   if (amount <= 0)
    //       throw new ArgumentException("Deposit amount must be positive.", nameof(amount));
    //   _balance += amount;
    public void Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    // ── TODO 7 — Withdraw(decimal amount) ────────────────────────────────────
    //
    // Replace throw with:
    //   if (amount <= 0)
    //       throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));
    //   if (amount > _balance) return false;
    //   _balance -= amount;
    //   return true;
    //
    // Returning bool instead of throwing on insufficient funds is a design
    // choice: insufficient funds is a normal business event, not an error.
    public bool Withdraw(decimal amount)
    {
        throw new NotImplementedException();
    }

    // ── TODO 8 — Summary() ───────────────────────────────────────────────────
    //
    // Replace throw with:
    //   return $"Account {AccountNumber} ({Owner}): ${Balance:F2}";
    //
    // ':F2' formats a decimal to exactly two decimal places.
    // Expected: "Account ACC001 (Alice): $1234.56"
    public string Summary()
    {
        throw new NotImplementedException();
    }
}
