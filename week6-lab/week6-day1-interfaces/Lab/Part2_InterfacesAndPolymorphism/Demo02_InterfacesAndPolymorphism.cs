/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate interface-based polymorphism: holding objects via interface type,
 *           filtering with OfType<T>(), implementing the Strategy pattern, and practical
 *           use cases where interfaces enable extensibility without modifying existing code.
 *           Show real-world design patterns.
 */
namespace OopCsharp.Week6.Part2_InterfacesAndPolymorphism;

// ============================================================
// DEMO 02 — Interfaces and Polymorphism
// Topics: IComparable<T>, IEnumerable<T>, interface segregation,
//         combining interface + abstract class, LINQ with interfaces
// ============================================================

// ----------------------------------------------------------
// Section 1: Standard library interfaces — IComparable<T>
// ----------------------------------------------------------
// Implementing IComparable<T> plugs into Array.Sort, List.Sort,
// SortedSet, LINQ OrderBy, and more.

public class Product : IComparable<Product>
{
    public string Name  { get; }
    public double Price { get; }

    public Product(string name, double price)
    {
        Name  = name;
        Price = price;
    }

    // Sort ascending by Price
    public int CompareTo(Product? other)
    {
        if (other is null) return 1;   // null sorts before any real product
        return Price.CompareTo(other.Price);
    }

    public override string ToString() => $"{Name} (${Price:F2})";
}

// ----------------------------------------------------------
// Section 2: Combining interface + abstract class
// ----------------------------------------------------------
// A common pattern: abstract class implements the "housekeeping"
// while leaving the domain logic as abstract methods.
// Concrete classes implement BOTH the abstract method AND any
// additional interfaces they need.

public interface IShippable
{
    double WeightKg { get; }
    string ShippingLabel();
}

public abstract class OrderItem
{
    public string Sku      { get; }
    public int    Quantity { get; }

    protected OrderItem(string sku, int quantity)
    {
        Sku      = sku;
        Quantity = quantity;
    }

    public abstract double UnitPrice();
    public double LineTotal() => UnitPrice() * Quantity;
}

public class PhysicalBook : OrderItem, IShippable
{
    public string Title     { get; }
    public double _price;

    public PhysicalBook(string sku, string title, double price, int quantity)
        : base(sku, quantity)
    {
        Title  = title;
        _price = price;
    }

    public override double UnitPrice() => _price;

    // IShippable
    public double WeightKg     => 0.4 * Quantity;
    public string ShippingLabel() => $"SHIP: {Quantity}x \"{Title}\" — {WeightKg:F1} kg";
}

public class DigitalBook : OrderItem
{
    public string Title  { get; }
    public double _price;

    public DigitalBook(string sku, string title, double price, int quantity)
        : base(sku, quantity)
    {
        Title  = title;
        _price = price;
    }

    public override double UnitPrice() => _price;
    // No IShippable — digital goods don't ship
}

// ----------------------------------------------------------
// Section 3: Interface segregation principle (brief)
// ----------------------------------------------------------
// Prefer small, focused interfaces over one fat interface.
// Clients depend only on the members they actually use.

public interface IReadable  { string Read();  }
public interface IWritable  { void Write(string data); }
public interface ISeekable  { void Seek(long position); }

// A file stream implements all three.
// A network stream might only implement IReadable + IWritable.
// A read-only config file only needs IReadable.

// ----------------------------------------------------------
// Section 4: LINQ with interface types
// ----------------------------------------------------------
internal static class Demo02Runner
{
    internal static void Run()
    {
        // -- IComparable<T> + Array.Sort --
        var products = new[]
        {
            new Product("Widget", 9.99),
            new Product("Gadget", 4.50),
            new Product("Doohickey", 14.00),
        };
        Array.Sort(products);   // uses CompareTo
        foreach (var p in products)
            Console.WriteLine(p);

        Console.WriteLine();

        // -- Polymorphic order processing --
        var items = new List<OrderItem>
        {
            new PhysicalBook("B001", "Clean Code", 35.00, 2),
            new DigitalBook ("B002", "Refactoring",  25.00, 1),
            new PhysicalBook("B003", "SICP",         40.00, 1),
        };

        double orderTotal = items.Sum(i => i.LineTotal());
        Console.WriteLine($"Order total: ${orderTotal:F2}");

        // Only ship the IShippable items
        var toShip = items.OfType<IShippable>();
        foreach (var s in toShip)
            Console.WriteLine(s.ShippingLabel());

        // -- LINQ OrderBy uses IComparable<T> implicitly --
        var sorted = products.OrderBy(p => p).ToList();
        Console.WriteLine(string.Join(", ", sorted));
    }
}
