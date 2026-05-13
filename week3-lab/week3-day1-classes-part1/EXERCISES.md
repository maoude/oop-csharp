# Exercises — Week 3 · Classes in C# (Part 1)

Complete these exercises in order. Each builds on the demo file of the same part.

---

## Part 1 — Classes and Objects

### W3.P1.Ex1 — Rectangle `[Lab/Part1_ClassesAndObjects/Exercises/Ex1_Rectangle.cs]`

Implement a `Rectangle` class with public fields and six instance methods.

| # | Member | Signature |
|---|--------|-----------|
| 1 | Width field | `public double Width;` |
| 2 | Height field | `public double Height;` |
| 3 | Area | `public double Area()` |
| 4 | Perimeter | `public double Perimeter()` |
| 5 | IsSquare | `public bool IsSquare()` |
| 6 | Scale | `public void Scale(double factor)` |
| 7 | Describe | `public string Describe()` |

Test class: `StudentWeek3Part1_Ex1Tests`

---

## Part 2 — Properties and Constructors

### W3.P2.Ex1 — BankAccount `[Lab/Part2_PropertiesAndConstructors/Exercises/Ex1_BankAccount.cs]`

Implement a `BankAccount` class with encapsulation, validation, and business rules.

| # | Member | Signature |
|---|--------|-----------|
| 1 | Backing field | `private decimal _balance;` |
| 2 | AccountNumber | `public string AccountNumber { get; init; }` |
| 3 | Owner | `public string Owner { get; private set; }` |
| 4 | Balance | `public decimal Balance { get { ... } }` |
| 5 | Constructor | `public BankAccount(string, string, decimal)` |
| 6 | Deposit | `public void Deposit(decimal amount)` |
| 7 | Withdraw | `public bool Withdraw(decimal amount)` |
| 8 | Summary | `public string Summary()` |

Test class: `StudentWeek3Part2_Ex1Tests`

---

### W3.P2.Ex2 — Person `[Lab/Part2_PropertiesAndConstructors/Exercises/Ex2_Person.cs]`

Implement a `Person` class with auto-properties, constructor chaining, and computed properties.

| # | Member | Signature |
|---|--------|-----------|
| 1 | FirstName | `public string FirstName { get; set; }` |
| 2 | LastName | `public string LastName { get; set; }` |
| 3 | Age | `public int Age { get; private set; }` |
| 4 | FullName | `public string FullName => ...` |
| 5 | Constructor (3 args) | `public Person(string, string, int)` |
| 6 | Constructor (2 args) | `public Person(string, string) : this(...)` |
| 7 | HaveBirthday | `public void HaveBirthday()` |
| 8 | IsAdult | `public bool IsAdult => ...` |
| 9 | Greet | `public string Greet(Person other)` |

Test class: `StudentWeek3Part2_Ex2Tests`

---

## Part 3 — Static Members and Readonly

### W3.P3.Ex1 — StudentRegistry `[Lab/Part3_StaticAndReadonly/Exercises/Ex1_StudentRegistry.cs]`

Implement a `StudentRegistry` class with static shared state and readonly instance identity.

| # | Member | Signature |
|---|--------|-----------|
| 1 | Shared ID counter | `private static int _nextId = 1;` |
| 2 | Shared enrolment count | `private static int _enrolledCount = 0;` |
| 3 | Readonly Id | `public readonly int Id;` |
| 4 | Name | `public string Name { get; private set; }` |
| 5 | Enrolled | `public bool Enrolled { get; private set; }` |
| 6 | EnrolledCount | `public static int EnrolledCount => ...` |
| 7 | Constructor | `public StudentRegistry(string name)` |
| 8 | Unenroll | `public void Unenroll()` |
| 9 | ResetRegistry | `public static void ResetRegistry()` |
| 10 | Describe | `public string Describe()` |

Test class: `StudentWeek3Part3_Ex1Tests`
