# Exercises — Week 6 · Interfaces & Abstract Classes

---

## Part 1 · Interface Basics — `Ex1_Printable.cs`

Declare two interfaces and implement them on two classes.

**IPrintable**
- `string ToPrintString()` — returns a human-readable single-line summary

**IPersistable**
- `string Serialize()` — returns a pipe-separated data string
- `void Deserialize(string data)` — stub only (`throw new NotImplementedException()`)

**Contact : IPrintable, IPersistable**
- Properties: `FirstName`, `LastName`, `Email` (string, get-only)
- `ToPrintString()` → `"Contact: {FirstName} {LastName} <{Email}>"`
- `Serialize()` → `"{FirstName}|{LastName}|{Email}"`

**Invoice : IPrintable, IPersistable**
- Properties: `InvoiceNumber`, `Client` (string), `Amount` (double)
- `ToPrintString()` → `"Invoice #{InvoiceNumber} — {Client}: ${Amount:F2}"`
- `Serialize()` → `"{InvoiceNumber}|{Client}|{Amount}"`

---

## Part 2 · Interfaces and Polymorphism — `Ex1_Taxable.cs`

Build a product hierarchy with two capability interfaces.

**ITaxable**
- `double TaxRate { get; }`
- `double TaxAmount()` → `BasePrice * TaxRate`
- `double PriceWithTax()` → `BasePrice + TaxAmount()`

**IDiscountable**
- `double DiscountPercent { get; }`
- `double DiscountedPrice()` → `BasePrice * (1 - DiscountPercent / 100)`

**abstract ProductBase**
- Properties: `Name` (string), `BasePrice` (double)
- Throws `ArgumentOutOfRangeException` when `basePrice <= 0`
- `abstract string Category()`
- `string Summary()` → `"{Category()}: {Name} — base ${BasePrice:F2}"`

**GroceryItem : ProductBase, ITaxable**
- Constructor: `GroceryItem(string name, double basePrice, double taxRate)`
- `Category()` → `"Grocery"`

**ElectronicItem : ProductBase, ITaxable, IDiscountable**
- Constructor: `ElectronicItem(string name, double basePrice, double taxRate, double discountPercent)`
- `Category()` → `"Electronic"`

---

## Part 3 · Abstract vs Interface — `Ex1_Logger.cs`

Build a logger hierarchy combining an interface with an abstract class.

**ILogger (interface)**
- `void Log(string message)`
- `void LogError(string message)` — default: `Log("[ERROR] " + message)`
- `int EntryCount { get; }`

**abstract LoggerBase : ILogger**
- Stores all logged messages in `_entries` (List<string>)
- `EntryCount` → `_entries.Count`
- `Log(message)` appends to `_entries`, then calls `WriteEntry(message)`
- `LogError(message)` → `Log("[ERROR] " + message)`
- `abstract void WriteEntry(string message)`
- `IReadOnlyList<string> GetEntries()`

**ConsoleLogger : LoggerBase**
- `WriteEntry(message)` → `Console.WriteLine(message)`

**MemoryLogger : LoggerBase**
- `WriteEntry(message)` → does nothing extra (entries stored by base)
- `string GetLastEntry()` → last entry, or `""` if empty
