/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: build a product hierarchy using abstract base class
 *           and multiple interfaces for capabilities. Practice polymorphism,
 *           capability interfaces, and filtering collections by type.
 */
namespace OopCsharp.Week6.Part2_InterfacesAndPolymorphism.Exercises;

// ============================================================
// Exercise 1 — ITaxable and product hierarchy
//
// Build:
//   ITaxable   (interface)
//   IDiscountable (interface)
//   abstract ProductBase
//     ├─ GroceryItem   : ProductBase, ITaxable   (not discountable)
//     └─ ElectronicItem: ProductBase, ITaxable, IDiscountable
//
// Requirements are listed as TODO comments.
// ============================================================

// TODO 1: Declare interface ITaxable
//   Member: double TaxRate { get; }   — e.g. 0.10 for 10 %
//           double TaxAmount()        — returns BasePrice * TaxRate
//           double PriceWithTax()     — returns BasePrice + TaxAmount()
//   Note: TaxAmount() and PriceWithTax() may be default interface methods
//         or left for each class to implement — your choice.

// TODO 2: Declare interface IDiscountable
//   Member: double DiscountPercent { get; }
//           double DiscountedPrice()    — BasePrice * (1 - DiscountPercent/100)

// TODO 3: Declare abstract class ProductBase
//   Properties (get-only):
//     string Name
//     double BasePrice
//   Protected constructor: ProductBase(string name, double basePrice)
//     Throw ArgumentOutOfRangeException if basePrice <= 0.
//   Abstract method: string Category()
//   Concrete method: string Summary()
//     → "{Category()}: {Name} — base ${BasePrice:F2}"
//     Example: "Grocery: Milk — base $2.50"

// TODO 4: Implement GroceryItem : ProductBase, ITaxable
//   Constructor: GroceryItem(string name, double basePrice, double taxRate)
//   Category()  → "Grocery"
//   TaxRate     → as passed to constructor
//   TaxAmount() → BasePrice * TaxRate
//   PriceWithTax() → BasePrice + TaxAmount()

// TODO 5: Implement ElectronicItem : ProductBase, ITaxable, IDiscountable
//   Constructor: ElectronicItem(string name, double basePrice,
//                               double taxRate, double discountPercent)
//   Category()        → "Electronic"
//   TaxRate           → as passed
//   DiscountPercent   → as passed
//   TaxAmount()       → BasePrice * TaxRate
//   PriceWithTax()    → BasePrice + TaxAmount()
//   DiscountedPrice() → BasePrice * (1 - DiscountPercent / 100)

// Stubs so the project compiles while you implement the TODOs above:

public abstract class ProductBase
{
    public string Name      { get; }
    public double BasePrice { get; }

    protected ProductBase(string name, double basePrice)
    {
        if (basePrice <= 0)
            throw new ArgumentOutOfRangeException(nameof(basePrice), "BasePrice must be positive.");
        Name      = name;
        BasePrice = basePrice;
    }

    public abstract string Category();
    public string Summary() => throw new NotImplementedException();
}

public class GroceryItem : ProductBase
{
    public GroceryItem(string name, double basePrice, double taxRate)
        : base(name, basePrice)
    {
    }

    public override string Category() => throw new NotImplementedException();
    public double TaxRate      => throw new NotImplementedException();
    public double TaxAmount()  => throw new NotImplementedException();
    public double PriceWithTax() => throw new NotImplementedException();
}

public class ElectronicItem : ProductBase
{
    public ElectronicItem(string name, double basePrice,
                          double taxRate, double discountPercent)
        : base(name, basePrice)
    {
    }

    public override string Category() => throw new NotImplementedException();
    public double TaxRate           => throw new NotImplementedException();
    public double DiscountPercent   => throw new NotImplementedException();
    public double TaxAmount()       => throw new NotImplementedException();
    public double PriceWithTax()    => throw new NotImplementedException();
    public double DiscountedPrice() => throw new NotImplementedException();
}
