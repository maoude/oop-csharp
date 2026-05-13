/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Instructor demo — implicit and explicit conversion operators,
 *          IComparable<T> for natural ordering, and how Array.Sort /
 *          LINQ OrderBy use IComparable automatically.
 *          Read this file completely before starting Exercise 3.
 */

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 1 — Conversion operators: implicit vs explicit
// ══════════════════════════════════════════════════════════════════════════════
//
// Sometimes it makes sense to convert between two types.
// C# lets you define how that conversion works using 'implicit' or 'explicit'.
//
// IMPLICIT conversion: happens automatically, no cast needed.
//   Use only when the conversion is ALWAYS safe and loses NO information.
//   Example: int → double (never loses data)
//
// EXPLICIT conversion: requires a cast (double)x.
//   Use when the conversion might lose data or throw.
//   Example: double → int (truncates the decimal part)

namespace OopCsharp.Week4.Part3_ConversionAndComparison;

/// <summary>
/// Represents a temperature in Celsius with conversion to/from double.
/// </summary>
public class Celsius
{
    public double Value { get; }

    public Celsius(double value) { Value = value; }

    // IMPLICIT: double → Celsius (always safe — any double is a valid temperature)
    // With this, you can write:  Celsius t = 37.5;
    public static implicit operator Celsius(double value)
        => new Celsius(value);

    // EXPLICIT: Celsius → double (explicit cast required)
    // Forces the caller to acknowledge the conversion consciously.
    // With this, you can write:  double d = (double)t;
    public static explicit operator double(Celsius c)
        => c.Value;

    public override string ToString() => $"{Value:F1}°C";
}

/// <summary>
/// Represents a non-negative percentage (0–100).
/// Demonstrates an explicit conversion that validates input.
/// </summary>
public class Percentage
{
    public double Value { get; }

    private Percentage(double value) { Value = value; }

    // EXPLICIT double → Percentage: validates range
    public static explicit operator Percentage(double value)
    {
        if (value < 0 || value > 100)
            throw new InvalidCastException($"{value} is not a valid percentage (0–100).");
        return new Percentage(value);
    }

    // IMPLICIT Percentage → double: always safe
    public static implicit operator double(Percentage p) => p.Value;

    public override string ToString() => $"{Value:F1}%";
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 2 — IComparable<T>: natural ordering
// ══════════════════════════════════════════════════════════════════════════════
//
// IComparable<T> defines a natural (default) ordering for a type.
// Implementing it allows:
//   - Array.Sort(array)    — sorts your objects
//   - LINQ .OrderBy(x=>x) — orders a collection
//   - SortedSet<T>, SortedDictionary<K,V> — stores in sorted order
//
// CompareTo(other) returns:
//   < 0  →  this comes BEFORE other
//     0  →  this and other are EQUAL in ordering
//   > 0  →  this comes AFTER other

/// <summary>
/// A product with a natural ordering by price (cheapest first).
/// </summary>
public class Product : IComparable<Product>
{
    public string Name  { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        Name  = name;
        Price = price;
    }

    // The natural ordering: by Price ascending.
    // decimal.CompareTo handles the three-way comparison for us.
    public int CompareTo(Product? other)
    {
        if (other is null) return 1;   // by convention, null is less than everything
        return Price.CompareTo(other.Price);
    }

    // ── Comparison operators derived from CompareTo ────────────────────────
    //
    // Once CompareTo is implemented, you can define the six comparison
    // operators by delegating to it.  This is optional but makes the
    // type more convenient to use.
    public static bool operator < (Product a, Product b) => a.CompareTo(b) <  0;
    public static bool operator > (Product a, Product b) => a.CompareTo(b) >  0;
    public static bool operator <=(Product a, Product b) => a.CompareTo(b) <= 0;
    public static bool operator >=(Product a, Product b) => a.CompareTo(b) >= 0;

    public override string ToString() => $"{Name} (${Price:F2})";
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 3 — Demo runner
// ══════════════════════════════════════════════════════════════════════════════

public static class Demo03_ConversionAndComparison
{
    public static void Run()
    {
        // ── Implicit conversion ────────────────────────────────────────────
        Celsius bodyTemp = 37.5;          // implicit double → Celsius
        Console.WriteLine(bodyTemp);      // 37.5°C

        // ── Explicit conversion ────────────────────────────────────────────
        double raw = (double)bodyTemp;    // explicit Celsius → double
        Console.WriteLine(raw);           // 37.5

        // ── Percentage ────────────────────────────────────────────────────
        Percentage score = (Percentage)85.0;   // explicit — validates range
        double asDouble = score;               // implicit — always safe
        Console.WriteLine(score);             // 85.0%
        Console.WriteLine(asDouble);           // 85

        try { var bad = (Percentage)150.0; }   // throws — out of range
        catch (InvalidCastException ex) { Console.WriteLine(ex.Message); }

        // ── IComparable / Array.Sort ───────────────────────────────────────
        Product[] products =
        {
            new Product("Pen",    1.50m),
            new Product("Book",  12.00m),
            new Product("Ruler",  3.75m),
            new Product("Eraser", 0.80m),
        };

        Array.Sort(products);   // uses CompareTo — sorts by Price ascending
        foreach (var p in products)
            Console.WriteLine(p);
        // Eraser ($0.80)
        // Pen ($1.50)
        // Ruler ($3.75)
        // Book ($12.00)

        // ── Comparison operators ───────────────────────────────────────────
        Console.WriteLine(products[0] < products[1]);   // True — Eraser < Pen
        Console.WriteLine(products[3] > products[2]);   // True — Book > Ruler
    }
}
