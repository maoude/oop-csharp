/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for capability-based interface design.
 *           Students compare their product hierarchy against this model.
 */
namespace OopCsharp.Week6.Part2_InterfacesAndPolymorphism.Solutions;

public interface ITaxable
{
    double TaxRate     { get; }
    double TaxAmount()   => BasePrice * TaxRate;
    double PriceWithTax() => BasePrice + TaxAmount();

    // Helper for default methods — interface cannot access BasePrice directly
    // so we expose it via a property contract.
    double BasePrice   { get; }
}

public interface IDiscountable
{
    double DiscountPercent  { get; }
    double BasePrice        { get; }
    double DiscountedPrice() => BasePrice * (1 - DiscountPercent / 100);
}

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

    public string Summary()
        => $"{Category()}: {Name} — base ${BasePrice:F2}";
}

public class GroceryItem : ProductBase, ITaxable
{
    public double TaxRate { get; }

    public GroceryItem(string name, double basePrice, double taxRate)
        : base(name, basePrice)
    {
        TaxRate = taxRate;
    }

    public override string Category() => "Grocery";

    // ITaxable default methods use BasePrice from ProductBase through the interface
    public double TaxAmount()    => BasePrice * TaxRate;
    public double PriceWithTax() => BasePrice + TaxAmount();
}

public class ElectronicItem : ProductBase, ITaxable, IDiscountable
{
    public double TaxRate         { get; }
    public double DiscountPercent { get; }

    public ElectronicItem(string name, double basePrice,
                          double taxRate, double discountPercent)
        : base(name, basePrice)
    {
        TaxRate         = taxRate;
        DiscountPercent = discountPercent;
    }

    public override string Category() => "Electronic";

    public double TaxAmount()       => BasePrice * TaxRate;
    public double PriceWithTax()    => BasePrice + TaxAmount();
    public double DiscountedPrice() => BasePrice * (1 - DiscountPercent / 100);
}
