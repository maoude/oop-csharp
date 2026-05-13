# Troubleshooting — Week 6 · Interfaces & Abstract Classes

---

## Build errors

### "'Contact' does not implement interface member 'IPrintable.ToPrintString()'"

The method is missing, misspelled, or has the wrong signature. The signature must match exactly:

```csharp
public string ToPrintString() { ... }
```

### "'Contact' does not implement interface member 'IPersistable.Deserialize(string)'"

Even stub methods must be present. Add:

```csharp
public void Deserialize(string data) => throw new NotImplementedException();
```

### "Cannot create an instance of the abstract class 'ProductBase'"

`ProductBase` is abstract — instantiate a concrete subclass (`GroceryItem`, `ElectronicItem`).

### "CS0535: 'GroceryItem' does not implement interface member 'ITaxable.TaxRate'"

You declared `TaxRate` as a field instead of a property. Interfaces require properties:

```csharp
public double TaxRate { get; }
```

### "'LoggerBase.WriteEntry(string)' hides inherited abstract member"

You wrote `public new void WriteEntry(string message)` in a derived class. Use `override`:

```csharp
protected override void WriteEntry(string message) => Console.WriteLine(message);
```

---

## Test failures

### Contact — `ToPrintString()` test fails

Check the exact format: `"Contact: {FirstName} {LastName} <{Email}>"`. Angle brackets must surround the email; there is a space after the colon.

### Invoice — `ToPrintString()` format test fails

Verify: `$"Invoice #{InvoiceNumber} — {Client}: ${Amount:F2}"`. Note the em-dash (`—`) between client and amount, not a hyphen.

### GroceryItem — `TaxAmount` returns wrong value

`TaxAmount()` must be `BasePrice * TaxRate`, not `BasePrice * TaxRate / 100`. `TaxRate` is already a fraction (e.g. `0.10` for 10 %).

### ElectronicItem — `DiscountedPrice` test fails

The formula is `BasePrice * (1 - DiscountPercent / 100)`. If `DiscountPercent` is stored as `10` (not `0.10`), dividing by 100 is required.

### MemoryLogger — `GetLastEntry` returns wrong value

Use the index-from-end operator:

```csharp
public string GetLastEntry()
    => _entries.Count == 0 ? "" : _entries[^1];
```

### MemoryLogger — `LogError` test: message doesn't start with `[ERROR]`

Your `LogError` implementation does not call `Log("[ERROR] " + message)`. It must go through `Log()` so the entry is counted and stored:

```csharp
public void LogError(string message) => Log("[ERROR] " + message);
```

### `GetEntries()` test: `IsAssignableFrom<IReadOnlyList<string>>`

Return `_entries.AsReadOnly()`, not `_entries` directly:

```csharp
public IReadOnlyList<string> GetEntries() => _entries.AsReadOnly();
```

---

## Runtime errors

### `NullReferenceException` in `Log()`

`_entries` was not initialised. Either initialise in the field declaration or in the constructor:

```csharp
protected List<string> _entries = new();
```
