/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise on Employee abstract hierarchy with FullTime/Contract polymorphic implementations.
 */

namespace OopCsharp.Week5.Part3_AbstractAndPolymorphism.Exercises;

// ============================================================
// Exercise 1 — Employee hierarchy with abstract class
//
// Build:
//   Employee (abstract base)
//     ├─ FullTimeEmployee : Employee
//     └─ ContractEmployee : Employee
//
// Requirements are listed as TODO comments inside each class.
// ============================================================

public abstract class Employee
{
    // TODO 1a: Add a public string property  Name      (get-only)
    // TODO 1b: Add a public string property  Id        (get-only)
    // TODO 1c: Add a public string property  Department (get-only)

    // TODO 1d: Implement the protected constructor Employee(string name, string id, string department)

    // TODO 1e: Declare abstract method  double MonthlySalary()
    //          (no body — derived classes must implement)

    // TODO 1f: Declare abstract method  string EmployeeType()
    //          (no body — derived classes must implement)

    // TODO 1g: Implement  virtual string Summary()
    //          Returns:
    //          "[{EmployeeType()}] {Name} (ID: {Id}) — Dept: {Department} — Monthly: {MonthlySalary():F2}"
    //          Example: "[Full-Time] Alice (ID: FT001) — Dept: Engineering — Monthly: 5000.00"
    public virtual string Summary() => throw new NotImplementedException();

    // TODO 1h: Implement  double AnnualSalary()
    //          Returns MonthlySalary() * 12
    public double AnnualSalary() => throw new NotImplementedException();
}

public class FullTimeEmployee : Employee
{
    // TODO 2a: Add a public double property  BaseSalary  (get-only)
    // TODO 2b: Add a public double property  Bonus       (get-only, default 0.0)

    // TODO 2c: Implement the constructor
    //          FullTimeEmployee(string name, string id, string department,
    //                           double baseSalary, double bonus = 0.0)
    //          Call base(name, id, department).
    //          Throw ArgumentOutOfRangeException if baseSalary <= 0.

    // TODO 2d: Override MonthlySalary() → BaseSalary + Bonus
    // TODO 2e: Override EmployeeType()  → "Full-Time"
}

public class ContractEmployee : Employee
{
    // TODO 3a: Add a public double property  HourlyRate    (get-only)
    // TODO 3b: Add a public int    property  HoursPerMonth (get-only)

    // TODO 3c: Implement the constructor
    //          ContractEmployee(string name, string id, string department,
    //                           double hourlyRate, int hoursPerMonth)
    //          Call base(name, id, department).
    //          Throw ArgumentOutOfRangeException if hourlyRate <= 0 or hoursPerMonth <= 0.

    // TODO 3d: Override MonthlySalary() → HourlyRate * HoursPerMonth
    // TODO 3e: Override EmployeeType()  → "Contract"

    // TODO 3f: Implement  ContractEmployee WithHours(int hours)
    //          Returns a NEW ContractEmployee with the same name/id/dept/hourlyRate
    //          but the given hours.  (Useful for adjusting a contract.)
    public ContractEmployee WithHours(int hours) => throw new NotImplementedException();
}
