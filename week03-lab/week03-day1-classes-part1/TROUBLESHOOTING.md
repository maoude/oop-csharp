# Troubleshooting — Week 3 · Classes in C# (Part 1)

---

## Build errors

### "Cannot use object initializer with fields"

Object initialiser syntax `new Rectangle { Width = 4 }` works with public *properties* AND public *fields*. Both are valid. If you see this error, check that `Width` is spelled correctly and is actually public.

### "Property or indexer cannot be assigned — it is read only"

You tried to assign to a property that has no setter or only an `init` setter after construction.

- `AccountNumber { get; init; }` → can only be set during construction
- `Balance => _balance` → no setter at all; use `Deposit`/`Withdraw`

### "A readonly field cannot be assigned to (except in a constructor)"

`readonly` fields must be set in the constructor. You cannot write `Id = 5;` inside a regular method. Move the assignment into the constructor body.

### "Static member cannot be accessed with an instance reference"

`EnrolledCount` is a static property — access it via the class name:

```csharp
// WRONG:
var s = new StudentRegistry("Alice");
int n = s.EnrolledCount;   // compiler error

// CORRECT:
int n = StudentRegistry.EnrolledCount;
```

---

## Test failures

### Rectangle — "Two rectangles have independent fields" fails

You declared `Width` or `Height` as `static`. Remove `static` — every Rectangle must own its own width and height.

### BankAccount — Balance is wrong after Withdraw returns false

Your `Withdraw` is subtracting from `_balance` before checking whether there is enough. Check the balance FIRST, then subtract:

```csharp
if (amount > _balance) return false;   // check first
_balance -= amount;                    // only subtract if we passed the check
return true;
```

### BankAccount — Summary format test fails

Check for spaces, parentheses, dollar sign, and the `:F2` format specifier. The expected string is `"Account ACC001 (Alice): $1234.56"` — note the space before `(` and the colon after `)`.

### Person — FullName does not update after FirstName changes

Change `FullName` from a field to an expression-body property:

```csharp
public string FullName => $"{FirstName} {LastName}";
```

### Person — "Constructor two args sets age to zero" fails

Your two-argument constructor does not chain to the three-argument one. Add `: this(firstName, lastName, 0)`:

```csharp
public Person(string firstName, string lastName)
    : this(firstName, lastName, 0)
{ }
```

### StudentRegistry — "Second student gets Id 1 too"

You assigned `Id = 1` literally, or you forgot to increment `_nextId`. Use the post-increment operator:

```csharp
Id = _nextId++;   // assigns current value of _nextId to Id, THEN increments
```

### StudentRegistry — "Unenroll is idempotent" fails

Your `Unenroll` decrements `_enrolledCount` even when already unenrolled. Guard with `if (!Enrolled) return;` at the top.

### StudentRegistry — All tests get wrong IDs even after reset

Ensure `ResetRegistry()` really sets `_nextId = 1` (not 0). The first student should get Id 1.

---

## dotnet test issues

### "No test matches the filter"

Filter strings are case-sensitive. Use `StudentWeek3Part1_Ex1` exactly (capital S, W, P, E).

### Build succeeds but tests show "Error"

A `NotImplementedException` is still being thrown. Find which TODO you have not completed yet — the xUnit error message will name the method.

### "The type or namespace 'BankAccount' could not be found"

Check that your exercise file's namespace exactly matches what the test expects: `OopCsharp.Week3.Part2_PropertiesAndConstructors.Exercises`. Do not rename it.
