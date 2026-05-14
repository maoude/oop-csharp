/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Custom Exceptions
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate domain-specific exception classes: standard constructors,
 *           domain properties, InnerException chains, exception hierarchies, and
 *           how to throw and catch custom exceptions in realistic scenarios.
 *           Show how properties enhance diagnostics and logging.
 */
namespace OopCsharp.Week7.Part2_CustomExceptions;

// ============================================================
// DEMO 02 — Custom Exceptions
// Topics: creating custom exception classes, exception
//         properties, inner exceptions, best practices
// ============================================================

// ----------------------------------------------------------
// Section 1: Creating a custom exception
// ----------------------------------------------------------
// Inherit from Exception (or a more specific standard exception).
// Convention: name ends with "Exception".
// Provide at least three constructors (the "standard three"):
//   1. ()
//   2. (string message)
//   3. (string message, Exception innerException)

public class InsufficientFundsException : Exception
{
    // Custom properties carry domain-specific context
    public decimal Balance   { get; }
    public decimal Attempted { get; }

    public InsufficientFundsException()
        : base("Insufficient funds.") { }

    public InsufficientFundsException(string message)
        : base(message) { }

    public InsufficientFundsException(string message, Exception innerException)
        : base(message, innerException) { }

    // Domain-specific constructor for convenience
    public InsufficientFundsException(decimal balance, decimal attempted)
        : base($"Cannot withdraw {attempted:C}: balance is only {balance:C}.")
    {
        Balance   = balance;
        Attempted = attempted;
    }
}

// ----------------------------------------------------------
// Section 2: A class that throws the custom exception
// ----------------------------------------------------------

public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(initialBalance),
                "Initial balance cannot be negative.");
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Deposit amount must be positive.");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Withdrawal amount must be positive.");

        if (amount > Balance)
            throw new InsufficientFundsException(Balance, amount);

        Balance -= amount;
    }
}

// ----------------------------------------------------------
// Section 3: Inner exceptions — wrapping one exception in another
// ----------------------------------------------------------
// When you catch a low-level exception and throw a higher-level one,
// pass the original as the innerException so callers can inspect
// the full cause chain via ex.InnerException.

public class DataProcessingException : Exception
{
    public string FileName { get; }

    public DataProcessingException(string fileName, Exception inner)
        : base($"Failed to process file '{fileName}'.", inner)
    {
        FileName = fileName;
    }
}

internal static class FileProcessor
{
    internal static void Process(string fileName, string content)
    {
        try
        {
            int value = int.Parse(content);   // might throw FormatException
            Console.WriteLine($"Processed value: {value}");
        }
        catch (FormatException ex)
        {
            // Wrap low-level FormatException in a domain-specific exception.
            // The original FormatException is still accessible via InnerException.
            throw new DataProcessingException(fileName, ex);
        }
    }
}

// ----------------------------------------------------------
// Section 4: Exception hierarchy for a domain
// ----------------------------------------------------------
// Build a small hierarchy so callers can catch at the right level.

public class AppException : Exception
{
    public AppException(string message) : base(message) { }
    public AppException(string message, Exception inner) : base(message, inner) { }
}

public class ValidationException : AppException
{
    public string FieldName { get; }
    public ValidationException(string fieldName, string message)
        : base(message)
    {
        FieldName = fieldName;
    }
}

public class NotFoundException : AppException
{
    public NotFoundException(string entityType, object id)
        : base($"{entityType} with id '{id}' was not found.") { }
}

// Callers can catch:
//   catch (ValidationException)  — only validation errors
//   catch (AppException)         — any app-level error
//   catch (Exception)            — everything

// ----------------------------------------------------------
// Section 5: Runner
// ----------------------------------------------------------
internal static class Demo02Runner
{
    internal static void Run()
    {
        // Custom exception with domain data
        var account = new BankAccount(100m);
        try
        {
            account.Withdraw(200m);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"  Balance: {ex.Balance:C}  Attempted: {ex.Attempted:C}");
        }

        // Inner exception chain
        try
        {
            FileProcessor.Process("data.txt", "not-a-number");
        }
        catch (DataProcessingException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"  Caused by: {ex.InnerException?.GetType().Name}");
            Console.WriteLine($"  Inner message: {ex.InnerException?.Message}");
        }

        // Exception hierarchy
        try
        {
            throw new ValidationException("Email", "Email format is invalid.");
        }
        catch (AppException ex)   // catches both ValidationException and NotFoundException
        {
            Console.WriteLine($"AppException caught: {ex.Message}");
            if (ex is ValidationException ve)
                Console.WriteLine($"  Field: {ve.FieldName}");
        }
    }
}
