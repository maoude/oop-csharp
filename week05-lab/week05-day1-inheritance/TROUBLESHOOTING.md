# Troubleshooting — Week 5 · Inheritance

---

## Build errors

### "There is no argument given that corresponds to the required parameter…"

You forgot to call `base(...)` in a derived constructor, or called it with the wrong arguments.  Every derived constructor must chain to a base constructor. Check:

```csharp
public Dog(string name, int age, string breed)
    : base(name, age)   // ← required
{
    Breed = breed;
}
```

### "Cannot create an instance of the abstract class or interface 'Employee'"

You tried `new Employee(...)`. Abstract classes cannot be instantiated directly — create a `FullTimeEmployee` or `ContractEmployee` instead.

### "'Square.Area()': cannot override inherited member 'Rectangle.Area()' because it is not marked virtual, abstract, or override"

Your `Rectangle.Area()` is not marked `override` (it should override `Shape.Area()` which is `virtual`). Fix `Rectangle`:

```csharp
public override double Area() => Width * Height;
```

### "CS0533: 'Square.Area()' hides inherited abstract member"

Same root cause — use `override` (and `sealed` if intended):

```csharp
public sealed override double Area() => Width * Width;
```

---

## Test failures

### Animal — `Speak()` test fails for Dog/Cat through `Animal` reference

You used `new` instead of `override`. Change:

```csharp
// wrong
public new string Speak() => "Woof!";

// correct
public override string Speak() => "Woof!";
```

### Shape — `ToString()` shows wrong class name

You hard-coded the class name as a string literal. Use `GetType().Name` so each subclass reports its own name:

```csharp
public override string ToString()
    => $"{GetType().Name}: color={Color}, area={Area():F2}, perimeter={Perimeter():F2}";
```

### Shape — Circle negative radius test does not throw

Your constructor accepts any value. Add a guard:

```csharp
if (radius <= 0)
    throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be positive.");
```

### Employee — `WithHours` test asserts `NotSame`

You returned `this` instead of a new object. `WithHours` must return a brand-new instance:

```csharp
public ContractEmployee WithHours(int hours)
    => new ContractEmployee(Name, Id, Department, HourlyRate, hours);
```

### Employee — `AnnualSalary` returns wrong value

You hard-coded `12` in a multiplication with the wrong property. Make sure you call `MonthlySalary()` (the virtual method), not `BaseSalary` directly:

```csharp
public double AnnualSalary() => MonthlySalary() * 12;
```

---

## Runtime errors

### `NullReferenceException` inside `ToString()`

A property used in `ToString()` is null. Check that the constructor assigns every property before the body completes.

### `InvalidCastException` on downcast

You wrote `(Dog)animal` but the actual runtime type is not `Dog`. Use a pattern match:

```csharp
if (animal is Dog dog)
    Console.WriteLine(dog.Breed);
```
