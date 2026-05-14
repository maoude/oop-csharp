/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for ITaxable / ProductBase polymorphism exercises (18 tests covering GroceryItem and ElectronicItem).
 */

using OopCsharp.Week6.Part2_InterfacesAndPolymorphism.Exercises;
using Xunit;

namespace OopCsharp.Week6.Tests.Part2_InterfacesAndPolymorphism;

// 18 tests
public class StudentWeek6Part2_Ex1Tests
{
    private const double Tol = 1e-9;

    // ── ProductBase guard ────────────────────────────────────────────────

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void ProductBase_InvalidPrice_Throws(double price)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new GroceryItem("X", price, 0.05));
    }

    // ── GroceryItem ──────────────────────────────────────────────────────

    [Fact]
    public void Grocery_Properties_SetCorrectly()
    {
        var g = new GroceryItem("Milk", 2.50, 0.10);
        Assert.Equal("Milk", g.Name);
        Assert.Equal(2.50,   g.BasePrice, Tol);
        Assert.Equal(0.10,   g.TaxRate,   Tol);
    }

    [Fact]
    public void Grocery_Category_IsGrocery()
    {
        var g = new GroceryItem("Bread", 3.00, 0.05);
        Assert.Equal("Grocery", g.Category());
    }

    [Fact]
    public void Grocery_TaxAmount_IsCorrect()
    {
        var g = new GroceryItem("Milk", 2.50, 0.10);
        Assert.Equal(0.25, g.TaxAmount(), Tol);
    }

    [Fact]
    public void Grocery_PriceWithTax_IsCorrect()
    {
        var g = new GroceryItem("Milk", 2.50, 0.10);
        Assert.Equal(2.75, g.PriceWithTax(), Tol);
    }

    [Fact]
    public void Grocery_Summary_ContainsNameAndPrice()
    {
        var g = new GroceryItem("Milk", 2.50, 0.10);
        string s = g.Summary();
        Assert.Contains("Grocery", s);
        Assert.Contains("Milk",    s);
        Assert.Contains("2.50",    s);
    }

    [Fact]
    public void Grocery_IsProductBase()
    {
        var g = new GroceryItem("Eggs", 1.00, 0.05);
        Assert.IsAssignableFrom<ProductBase>(g);
    }

    // ── ElectronicItem ───────────────────────────────────────────────────

    [Fact]
    public void Electronic_Properties_SetCorrectly()
    {
        var e = new ElectronicItem("Laptop", 1000, 0.15, 10);
        Assert.Equal("Laptop", e.Name);
        Assert.Equal(1000,     e.BasePrice, Tol);
        Assert.Equal(0.15,     e.TaxRate,   Tol);
        Assert.Equal(10,       e.DiscountPercent, Tol);
    }

    [Fact]
    public void Electronic_Category_IsElectronic()
    {
        var e = new ElectronicItem("Phone", 500, 0.20, 5);
        Assert.Equal("Electronic", e.Category());
    }

    [Fact]
    public void Electronic_TaxAmount_IsCorrect()
    {
        var e = new ElectronicItem("Laptop", 1000, 0.15, 10);
        Assert.Equal(150.0, e.TaxAmount(), Tol);
    }

    [Fact]
    public void Electronic_PriceWithTax_IsCorrect()
    {
        var e = new ElectronicItem("Laptop", 1000, 0.15, 10);
        Assert.Equal(1150.0, e.PriceWithTax(), Tol);
    }

    [Fact]
    public void Electronic_DiscountedPrice_IsCorrect()
    {
        var e = new ElectronicItem("Laptop", 1000, 0.15, 10);
        Assert.Equal(900.0, e.DiscountedPrice(), Tol);
    }

    [Fact]
    public void Electronic_IsProductBase()
    {
        var e = new ElectronicItem("TV", 800, 0.20, 5);
        Assert.IsAssignableFrom<ProductBase>(e);
    }

    // ── Polymorphism ─────────────────────────────────────────────────────

    [Fact]
    public void Polymorphism_MixedList_SumBasePrices()
    {
        var products = new List<ProductBase>
        {
            new GroceryItem("Milk",   2.50, 0.10),
            new GroceryItem("Bread",  3.00, 0.05),
            new ElectronicItem("USB", 20.0, 0.15, 0),
        };
        double total = products.Sum(p => p.BasePrice);
        Assert.Equal(25.5, total, Tol);
    }

    [Fact]
    public void Polymorphism_OfType_FiltersElectronics()
    {
        var products = new List<ProductBase>
        {
            new GroceryItem("Milk",    2.50, 0.10),
            new ElectronicItem("TV",   800,  0.20, 5),
            new ElectronicItem("Phone",500,  0.20, 10),
        };
        // Only ElectronicItems have DiscountedPrice()
        var electronics = products.OfType<ElectronicItem>().ToList();
        Assert.Equal(2, electronics.Count);
        Assert.All(electronics, e => Assert.True(e.DiscountedPrice() < e.BasePrice));
    }

    [Fact]
    public void Polymorphism_Summary_AllProducts()
    {
        var products = new List<ProductBase>
        {
            new GroceryItem("Milk",    2.50, 0.10),
            new ElectronicItem("TV",   800,  0.20, 5),
        };
        Assert.All(products, p =>
        {
            string s = p.Summary();
            Assert.Contains(p.Name, s);
            Assert.Contains(p.Category(), s);
        });
    }
}
