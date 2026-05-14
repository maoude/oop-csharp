# Lab 3 — Classes in C# (Part 1)

**Course:** Introduction to Object-Oriented Programming with C#  
**Instructor:** Dr. Mohamad Aoude · Lebanese University, Faculty of Engineering  
**Week:** 3  
**Assessment weight:** Ungraded practice — Checkpoint 1 is in Week 5

---

## What you will learn in this lab

By the time you finish every exercise in this lab, you will be able to:

- Explain the difference between a *class* (blueprint) and an *object* (instance)
- Declare public fields and instance methods with no `static` keyword
- Explain why two objects of the same class do not share field values
- Use private backing fields and full properties with `get`/`set` for validation
- Use auto-implemented properties (`{ get; set; }`, `{ get; private set; }`, `{ get; init; }`)
- Write computed (expression-body) properties that derive their value from other properties
- Write a parameterised constructor and validate its arguments
- Use constructor overloading and constructor chaining with `this(...)`
- Distinguish instance members from static members
- Use static fields to track shared state across all instances
- Use `readonly` fields that are set once in the constructor and never again
- Explain the difference between `const` (compile-time) and `readonly` (runtime)
- Design a class so objects are never created in an invalid state

These concepts underpin every class you will write for the rest of the course.

---

## Before you start — setup checklist

```powershell
dotnet --version   # must start with 8.
code --version     # VS Code must be installed
```

Confirm the **C# Dev Kit** extension is active in VS Code.

---

## Lab structure — what each folder contains

```
week3-day1-classes-part1/
│
├── README.md
├── EXERCISES.md
├── CHECKLIST.md
├── QUIZ_QUESTIONS.md
├── TROUBLESHOOTING.md
├── LAB_INSTRUCTIONS.md
├── OOP_DESIGN_SCORECARD.md
│
├── Lab/
│   ├── Part1_ClassesAndObjects/
│   │   ├── Demo01_ClassesAndObjects.cs     ← READ THIS FIRST
│   │   ├── Exercises/
│   │   │   └── Ex1_Rectangle.cs            ← YOUR CODE GOES HERE
│   │   └── Solutions/
│   │
│   ├── Part2_PropertiesAndConstructors/
│   │   ├── Demo02_PropertiesAndConstructors.cs  ← READ THIS FIRST
│   │   ├── Exercises/
│   │   │   ├── Ex1_BankAccount.cs               ← YOUR CODE GOES HERE
│   │   │   └── Ex2_Person.cs                    ← YOUR CODE GOES HERE
│   │   └── Solutions/
│   │
│   └── Part3_StaticAndReadonly/
│       ├── Demo03_StaticAndReadonly.cs      ← READ THIS FIRST
│       ├── Exercises/
│       │   └── Ex1_StudentRegistry.cs       ← YOUR CODE GOES HERE
│       └── Solutions/
│
└── Lab.Tests/
    ├── Part1_ClassesAndObjects/Exercises/StudentWeek3Part1_Ex1Tests.cs
    ├── Part2_PropertiesAndConstructors/Exercises/StudentWeek3Part2_Ex1Tests.cs
    ├── Part2_PropertiesAndConstructors/Exercises/StudentWeek3Part2_Ex2Tests.cs
    └── Part3_StaticAndReadonly/Exercises/StudentWeek3Part3_Ex1Tests.cs
```

**Edit only the files inside `Lab/PartN_*/Exercises/`.** Never touch demos, solutions, or tests.

---

## How to work through the lab

```
1. Open the demo file for the part and READ it completely.
   Every concept you need is explained there with examples.

2. Open the exercise file. Read the class-level doc comment and every TODO.

3. Implement each TODO in order — later TODOs often use earlier ones.

4. Run the tests for that exercise.

5. Read the failure message. Fix. Re-run. Repeat until green.

6. Tick the box in CHECKLIST.md and move on.
```

> **Important:** This week's exercises ask you to write entire *classes*, not just methods. Start by writing the fields/properties, then the constructor, then the methods — in the order the TODOs tell you.

---

## Running the tests

Open a terminal **inside `week3-day1-classes-part1/`**:

```powershell
# All tests:
dotnet test Lab.Tests/

# By part:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part2"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part3"

# By exercise:
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part1_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part2_Ex1"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part2_Ex2"
dotnet test Lab.Tests/ --filter "FullyQualifiedName~StudentWeek3Part3_Ex1"
```

---

## The exercises — what you need to implement

### Part 1 — Classes and Objects

#### Exercise W3.P1.Ex1 — Rectangle `[Ex1_Rectangle.cs]`

Your first class from scratch. Implement public fields and instance methods.

| Member | Kind | Description |
|--------|------|-------------|
| `Width` | field | The width of the rectangle |
| `Height` | field | The height of the rectangle |
| `Area()` | method | Returns `Width * Height` |
| `Perimeter()` | method | Returns `2 * (Width + Height)` |
| `IsSquare()` | method | Returns `true` when `Width == Height` |
| `Scale(double factor)` | method | Multiplies both dimensions by `factor` |
| `Describe()` | method | `"Rectangle 4.0 x 5.0, area=20.0"` |

**Key concepts:** instance vs static, object independence (two `Rectangle` objects cannot affect each other's fields), `{:F1}` number formatting.

Test class: `StudentWeek3Part1_Ex1Tests` (10 tests)

---

### Part 2 — Properties and Constructors

#### Exercise W3.P2.Ex1 — BankAccount `[Ex1_BankAccount.cs]`

A class that enforces business rules through encapsulation.

| Member | Kind | Description |
|--------|------|-------------|
| `_balance` | private field | Stores the balance; only changed by Deposit/Withdraw |
| `AccountNumber` | `init` property | Set at construction, immutable thereafter |
| `Owner` | `private set` property | Read by anyone, changed only internally |
| `Balance` | read-only property | Exposes `_balance`; no external setter |
| `BankAccount(string, string, decimal)` | constructor | Validates `initialBalance ≥ 0` |
| `Deposit(decimal)` | method | Adds to balance; throws if ≤ 0 |
| `Withdraw(decimal)` | method | Returns `bool`; returns `false` if insufficient funds |
| `Summary()` | method | `"Account ACC001 (Alice): $1234.56"` |

**Key concept — encapsulation:** `Balance` has no setter. The only way to change it is through `Deposit` and `Withdraw`, which enforce the rules. External code cannot bypass the rules.

Test class: `StudentWeek3Part2_Ex1Tests` (12 tests)

---

#### Exercise W3.P2.Ex2 — Person `[Ex2_Person.cs]`

Auto-properties, constructor chaining, and computed properties.

| Member | Kind | Description |
|--------|------|-------------|
| `FirstName` | `{ get; set; }` | Read/write by anyone |
| `LastName` | `{ get; set; }` | Read/write by anyone |
| `Age` | `{ get; private set; }` | Anyone reads; only `Person` writes |
| `FullName` | computed property | `$"{FirstName} {LastName}"` |
| `Person(string, string, int)` | constructor | Validates `age ≥ 0` |
| `Person(string, string)` | constructor | Chains to above with `age = 0` |
| `HaveBirthday()` | method | Increments `Age` by 1 |
| `IsAdult` | computed property | `Age >= 18` |
| `Greet(Person other)` | method | `"Hi Bob Smith, I'm Alice Jones!"` |

**Key concept — constructor chaining:** `this(firstName, lastName, 0)` calls the three-argument constructor so validation always runs. Never duplicate constructor logic.

Test class: `StudentWeek3Part2_Ex2Tests` (11 tests)

---

### Part 3 — Static Members and Readonly

#### Exercise W3.P3.Ex1 — StudentRegistry `[Ex1_StudentRegistry.cs]`

Static fields that track global state alongside per-object instance data.

| Member | Kind | Description |
|--------|------|-------------|
| `_nextId` | static field | Shared counter; gives each student a unique ID |
| `_enrolledCount` | static field | Total students currently enrolled |
| `Id` | `readonly` field | Set in constructor; immutable forever |
| `Name` | `private set` property | |
| `Enrolled` | `private set` property | True until `Unenroll()` is called |
| `EnrolledCount` | static property | Exposes `_enrolledCount` read-only |
| `StudentRegistry(string)` | constructor | Assigns ID, increments counters |
| `Unenroll()` | method | Idempotent — safe to call twice |
| `ResetRegistry()` | static method | Resets both static fields to initial values |
| `Describe()` | method | `"Student #3 Alice [enrolled]"` |

**Key concepts:** a static field has ONE value shared by ALL objects. `Id` is `readonly` — like a database primary key, it is set once and never changes. `ResetRegistry()` is called by tests to clean up shared state between test runs.

Test class: `StudentWeek3Part3_Ex1Tests` (13 tests)

---

## Progress summary

| Exercise | File | Test class | Tests |
|----------|------|------------|-------|
| W3.P1.Ex1 — Rectangle | `Ex1_Rectangle.cs` | `StudentWeek3Part1_Ex1Tests` | 10 |
| W3.P2.Ex1 — BankAccount | `Ex1_BankAccount.cs` | `StudentWeek3Part2_Ex1Tests` | 12 |
| W3.P2.Ex2 — Person | `Ex2_Person.cs` | `StudentWeek3Part2_Ex2Tests` | 11 |
| W3.P3.Ex1 — StudentRegistry | `Ex1_StudentRegistry.cs` | `StudentWeek3Part3_Ex1Tests` | 13 |
| **Total** | | | **46 test cases** |

---

## Common mistakes and how to fix them

### "My method returns the right value for the first object but wrong for the second"

You probably used a `static` field when you should have used an instance field. Static fields are shared — both objects read and write the same variable.

```csharp
// WRONG — static field is shared by all rectangles:
static double Width;   // r1.Width == r2.Width always!

// CORRECT — instance field, each object has its own:
public double Width;
```

### "Balance changed even though I didn't call Deposit or Withdraw"

You gave `Balance` a public setter. Remove the setter — the only way to change the balance should be through the methods that enforce business rules.

```csharp
// WRONG:
public decimal Balance { get; set; }

// CORRECT — getter only, backed by the private field:
public decimal Balance => _balance;
```

### "The second student got Id 1 too"

You forgot to increment `_nextId` after using it in the constructor.

```csharp
// WRONG — every student gets Id 1:
Id = _nextId;

// CORRECT — assign then increment:
Id = _nextId++;   // post-increment: assigns current value, THEN increments
```

### "Unenroll crashes the second time I call it"

You decremented `_enrolledCount` without checking whether the student was already unenrolled.

```csharp
public void Unenroll()
{
    if (!Enrolled) return;   // idempotent guard
    Enrolled = false;
    _enrolledCount--;
}
```

### "FullName does not update when I change FirstName"

This is correct behaviour if you computed `FullName` in the constructor and stored it in a field. Use an expression-body property instead — it re-computes every time it is read.

```csharp
// WRONG — computed once at construction:
public string FullName;
public Person(...) { FullName = $"{FirstName} {LastName}"; }

// CORRECT — recomputed on every read:
public string FullName => $"{FirstName} {LastName}";
```

### "My constructor chaining does not validate age"

Chain to the constructor that HAS the validation, not around it.

```csharp
// CORRECT — the two-arg constructor delegates to the three-arg constructor
// which has the age < 0 check:
public Person(string firstName, string lastName)
    : this(firstName, lastName, 0)   // ← calls the validating constructor
{ }
```

---

## What makes good code this week

- **Every object starts valid.** Validate all arguments in the constructor. An object with a negative balance or a null name should never exist.
- **Private fields, public properties.** External code reads through a property; internal code writes through a private field. Never expose a backing field directly.
- **One setter path.** If a value can only change through a specific method (`Deposit`, `Withdraw`), the property should have no external setter.
- **Static for shared, instance for per-object.** If the data is the same for all objects → static. If each object has its own copy → instance field.
- **readonly for immutable identity.** Fields like `Id` or `AccountNumber` that must never change after construction should be `readonly`.

---

## After the lab — oral quiz

Your instructor may ask any of the 8 questions in `QUIZ_QUESTIONS.md`. Read them before you leave.

---

## Need help?

1. Re-read the demo file for the part — the answer is almost always there.
2. Read `TROUBLESHOOTING.md`.
3. Read the test file — it shows exact inputs and expected outputs.
4. Ask a classmate (discussing is fine; copying is not).
5. Bring the failing test name and your current code to the next session.
