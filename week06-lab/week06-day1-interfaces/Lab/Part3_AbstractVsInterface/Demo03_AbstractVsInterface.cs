/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate the trade-offs between abstract classes and interfaces:
 *           when to use each, inheritance hierarchies, default interface methods (C# 8+),
 *           and mixed hierarchies combining both. Show real-world decision criteria.
 *           Emphasize design patterns and architecture principles.
 */
namespace OopCsharp.Week6.Part3_AbstractVsInterface;

// ============================================================
// DEMO 03 — Abstract class vs Interface: design trade-offs
// Topics: when to use each, default interface methods (C# 8+),
//         interface inheritance, the "diamond problem" and how
//         C# avoids it, practical design patterns
// ============================================================

// ----------------------------------------------------------
// Section 1: When to choose abstract class
// ----------------------------------------------------------
// Use abstract class when derived types share:
//  • State (instance fields)
//  • Constructor logic
//  • Concrete helper methods

public abstract class Logger
{
    private readonly string _prefix;

    protected Logger(string prefix) => _prefix = prefix;

    // Concrete — shared by all loggers
    public void Log(string message)
    {
        string formatted = $"[{_prefix}] {DateTime.Now:HH:mm:ss} {message}";
        Write(formatted);   // calls the abstract method
    }

    // Abstract — each logger decides where to write
    protected abstract void Write(string line);
}

public class ConsoleLogger : Logger
{
    public ConsoleLogger() : base("CONSOLE") { }
    protected override void Write(string line) => Console.WriteLine(line);
}

public class ListLogger : Logger
{
    private readonly List<string> _lines = new();
    public IReadOnlyList<string> Lines => _lines;

    public ListLogger() : base("LIST") { }
    protected override void Write(string line) => _lines.Add(line);
}

// ----------------------------------------------------------
// Section 2: When to choose interface
// ----------------------------------------------------------
// Use interface when you need:
//  • Multiple unrelated types to share a capability
//  • The "can-do" relationship (not "is-a")
//  • To avoid tying consumers to a specific base class

public interface ILogger
{
    void Log(string message);
}

// Any class — regardless of its base — can implement ILogger.
// This lets you swap implementations in tests without changing the base class.

// ----------------------------------------------------------
// Section 3: Default interface methods (C# 8+)
// ----------------------------------------------------------
// You can now provide a default body in an interface.
// This is useful for adding new members to an existing interface
// without breaking all existing implementations.

public interface INotifier
{
    void Notify(string message);

    // Default implementation — implementors may override
    void NotifyAll(IEnumerable<string> messages)
    {
        foreach (var m in messages)
            Notify(m);
    }
}

public class EmailNotifier : INotifier
{
    public void Notify(string message)
        => Console.WriteLine($"EMAIL: {message}");
    // NotifyAll is inherited from the interface default
}

// ----------------------------------------------------------
// Section 4: Interface inheritance
// ----------------------------------------------------------
// Interfaces can extend other interfaces.

public interface IShape
{
    double Area();
}

public interface IColoredShape : IShape
{
    string Color { get; }
    string ColoredDescription() => $"{Color} shape, area={Area():F2}";
}

public class RedCircle : IColoredShape
{
    private readonly double _r;
    public RedCircle(double r) => _r = r;

    public double Area()  => Math.PI * _r * _r;
    public string Color   => "Red";
    // ColoredDescription() is provided by the default implementation
}

// ----------------------------------------------------------
// Section 5: Practical pattern — Strategy via interface
// ----------------------------------------------------------
// Replace a conditional with a polymorphic call through an interface.

public interface IDiscountStrategy
{
    double Apply(double price);
}

public class NoDiscount : IDiscountStrategy
{
    public double Apply(double price) => price;
}

public class PercentDiscount : IDiscountStrategy
{
    private readonly double _pct;
    public PercentDiscount(double pct) => _pct = pct;
    public double Apply(double price) => price * (1 - _pct / 100);
}

public class FlatDiscount : IDiscountStrategy
{
    private readonly double _amount;
    public FlatDiscount(double amount) => _amount = amount;
    public double Apply(double price) => Math.Max(0, price - _amount);
}

public class Checkout
{
    private readonly IDiscountStrategy _discount;
    public Checkout(IDiscountStrategy discount) => _discount = discount;

    public double FinalPrice(double price) => _discount.Apply(price);
}

// ----------------------------------------------------------
// Section 6: Runner
// ----------------------------------------------------------
internal static class Demo03Runner
{
    internal static void Run()
    {
        // Abstract class — Logger
        var console = new ConsoleLogger();
        var list    = new ListLogger();
        console.Log("Hello from ConsoleLogger");
        list.Log("Hello from ListLogger");
        Console.WriteLine($"Captured: {list.Lines[0]}");

        // Default interface methods
        // Note: default interface methods are only accessible via the interface type,
        // not via the concrete class. Cast to INotifier to reach NotifyAll.
        INotifier notifier = new EmailNotifier();
        notifier.NotifyAll(new[] { "First", "Second", "Third" });

        // Colored shape
        // Same rule: ColoredDescription() is a default interface method on IColoredShape.
        IColoredShape rc = new RedCircle(4);
        Console.WriteLine(rc.ColoredDescription());

        // Strategy pattern
        var scenarios = new (string, IDiscountStrategy)[]
        {
            ("Full price",    new NoDiscount()),
            ("10% off",       new PercentDiscount(10)),
            ("$5 flat",       new FlatDiscount(5)),
        };

        foreach (var (label, strategy) in scenarios)
        {
            var checkout = new Checkout(strategy);
            Console.WriteLine($"{label}: ${checkout.FinalPrice(49.99):F2}");
        }
    }
}
