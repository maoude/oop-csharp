using OopCsharp.Week6.Part1_InterfaceBasics.Exercises;
using Xunit;

namespace OopCsharp.Week6.Tests.Part1_InterfaceBasics;

// 16 tests
public class StudentWeek6Part1_Ex1Tests
{
    // ── Contact ──────────────────────────────────────────────────────────

    [Fact]
    public void Contact_Properties_SetByConstructor()
    {
        var c = new Contact("Ada", "Lovelace", "ada@example.com");
        Assert.Equal("Ada",            c.FirstName);
        Assert.Equal("Lovelace",       c.LastName);
        Assert.Equal("ada@example.com",c.Email);
    }

    [Fact]
    public void Contact_ToPrintString_ReturnsExpectedFormat()
    {
        var c = new Contact("Ada", "Lovelace", "ada@example.com");
        Assert.Equal("Contact: Ada Lovelace <ada@example.com>", c.ToPrintString());
    }

    [Fact]
    public void Contact_Serialize_ReturnsPipeSeparated()
    {
        var c = new Contact("Ada", "Lovelace", "ada@example.com");
        Assert.Equal("Ada|Lovelace|ada@example.com", c.Serialize());
    }

    [Fact]
    public void Contact_ImplementsIPrintable()
    {
        // IPrintable i = new Contact(...) must compile
        var c = new Contact("Bob", "Smith", "bob@test.com");
        Assert.IsAssignableFrom<IPrintable>(c);
    }

    [Fact]
    public void Contact_ImplementsIPersistable()
    {
        var c = new Contact("Bob", "Smith", "bob@test.com");
        Assert.IsAssignableFrom<IPersistable>(c);
    }

    [Fact]
    public void Contact_ToPrintString_ThroughInterface()
    {
        IPrintable p = new Contact("Turing", "Alan", "alan@bletchley.uk");
        Assert.Equal("Contact: Turing Alan <alan@bletchley.uk>", p.ToPrintString());
    }

    [Fact]
    public void Contact_Serialize_ThroughInterface()
    {
        IPersistable p = new Contact("Grace", "Hopper", "grace@navy.mil");
        Assert.Equal("Grace|Hopper|grace@navy.mil", p.Serialize());
    }

    // ── Invoice ───────────────────────────────────────────────────────────

    [Fact]
    public void Invoice_Properties_SetByConstructor()
    {
        var inv = new Invoice("INV-001", "Acme Corp", 1500.0);
        Assert.Equal("INV-001",   inv.InvoiceNumber);
        Assert.Equal("Acme Corp", inv.Client);
        Assert.Equal(1500.0,      inv.Amount);
    }

    [Fact]
    public void Invoice_ToPrintString_ReturnsExpectedFormat()
    {
        var inv = new Invoice("INV-001", "Acme Corp", 1500.0);
        Assert.Equal("Invoice #INV-001 — Acme Corp: $1500.00", inv.ToPrintString());
    }

    [Fact]
    public void Invoice_Serialize_ReturnsPipeSeparated()
    {
        var inv = new Invoice("INV-001", "Acme Corp", 1500);
        string s = inv.Serialize();
        Assert.StartsWith("INV-001|Acme Corp|", s);
    }

    [Fact]
    public void Invoice_ImplementsIPrintable()
    {
        var inv = new Invoice("X", "Y", 1);
        Assert.IsAssignableFrom<IPrintable>(inv);
    }

    [Fact]
    public void Invoice_ImplementsIPersistable()
    {
        var inv = new Invoice("X", "Y", 1);
        Assert.IsAssignableFrom<IPersistable>(inv);
    }

    [Fact]
    public void Invoice_ToPrintString_ThroughInterface()
    {
        IPrintable p = new Invoice("INV-007", "ACME", 999.99);
        Assert.Contains("INV-007", p.ToPrintString());
        Assert.Contains("ACME",    p.ToPrintString());
        Assert.Contains("999.99",  p.ToPrintString());
    }

    // ── Polymorphism ─────────────────────────────────────────────────────

    [Fact]
    public void MixedList_ToPrintString_DispatchesCorrectly()
    {
        var items = new List<IPrintable>
        {
            new Contact("Ada", "Lovelace", "ada@example.com"),
            new Invoice("INV-002", "Beta Co", 250.00),
        };
        var results = items.Select(i => i.ToPrintString()).ToList();
        Assert.Contains("Contact:", results[0]);
        Assert.Contains("Invoice #", results[1]);
    }

    [Fact]
    public void MixedList_Serialize_DispatchesCorrectly()
    {
        var items = new List<IPersistable>
        {
            new Contact("Ada", "Lovelace", "ada@example.com"),
            new Invoice("INV-003", "Gamma Ltd", 750.00),
        };
        Assert.All(items, i => Assert.Contains("|", i.Serialize()));
    }

    [Fact]
    public void BothInterfaces_SameObject()
    {
        // A Contact is both IPrintable and IPersistable
        object c = new Contact("X", "Y", "xy@z.com");
        Assert.IsAssignableFrom<IPrintable>(c);
        Assert.IsAssignableFrom<IPersistable>(c);
    }
}
