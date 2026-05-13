# Exercises — Week 5 · Inheritance

---

## Part 1 · Inheritance Basics — `Ex1_Animal.cs`

Build a three-class hierarchy: `Animal` (base), `Dog`, and `Cat`.

**Animal**
- Properties: `Name` (string), `Age` (int) — get-only, set by constructor
- `ToString()` → `"Animal: {Name}, age {Age}"`
- `virtual string Speak()` → `"..."`
- `bool IsAdult()` → true when `Age >= 3`

**Dog : Animal**
- Additional property: `Breed` (string)
- Constructor calls `base(name, age)`
- `Speak()` → `"Woof!"`
- `ToString()` → `"Dog: {Name} ({Breed}), age {Age}"`

**Cat : Animal**
- Additional property: `IsIndoor` (bool)
- Constructor calls `base(name, age)`
- `Speak()` → `"Meow!"`
- `Lifestyle()` → `"Indoor cat"` or `"Outdoor cat"`

---

## Part 2 · virtual / override — `Ex1_Shape.cs`

Build a four-class hierarchy: `Shape` → `Circle`, `Rectangle` → `Square`.

**Shape**
- Property: `Color` (string, default `"Black"`, public setter)
- `virtual double Area()` → 0.0
- `virtual double Perimeter()` → 0.0
- `ToString()` → `"{ClassName}: color={Color}, area={Area():F2}, perimeter={Perimeter():F2}"`

**Circle : Shape**
- Property: `Radius` (double, get-only)
- Constructor throws `ArgumentOutOfRangeException` when `radius <= 0`
- `Area()` → π r²
- `Perimeter()` → 2 π r

**Rectangle : Shape**
- Properties: `Width`, `Height` (double, get-only)
- Constructor throws when either dimension ≤ 0
- `Area()` → Width × Height
- `Perimeter()` → 2 × (Width + Height)

**Square : Rectangle**
- Constructor `Square(double side)` calls `base(side, side)`
- `sealed override Area()` → Width × Width

---

## Part 3 · Abstract class — `Ex1_Employee.cs`

Build a three-class hierarchy: abstract `Employee` → `FullTimeEmployee`, `ContractEmployee`.

**Employee (abstract)**
- Properties: `Name`, `Id`, `Department` (string, get-only)
- `abstract double MonthlySalary()`
- `abstract string EmployeeType()`
- `virtual string Summary()` — formatted summary (see stub comment)
- `double AnnualSalary()` → `MonthlySalary() * 12`

**FullTimeEmployee : Employee**
- Additional: `BaseSalary` (double), `Bonus` (double, default 0)
- `MonthlySalary()` → `BaseSalary + Bonus`
- `EmployeeType()` → `"Full-Time"`
- Throws when `BaseSalary <= 0`

**ContractEmployee : Employee**
- Additional: `HourlyRate` (double), `HoursPerMonth` (int)
- `MonthlySalary()` → `HourlyRate * HoursPerMonth`
- `EmployeeType()` → `"Contract"`
- Throws when either argument ≤ 0
- `ContractEmployee WithHours(int hours)` — returns a new instance with updated hours
