/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Employee abstract hierarchy with FullTime and Contract implementations.
 */

namespace OopCsharp.Week5.Part3_AbstractAndPolymorphism.Solutions;

public abstract class Employee
{
    public string Name       { get; }
    public string Id         { get; }
    public string Department { get; }

    protected Employee(string name, string id, string department)
    {
        Name       = name;
        Id         = id;
        Department = department;
    }

    public abstract double MonthlySalary();
    public abstract string EmployeeType();

    public virtual string Summary()
        => $"[{EmployeeType()}] {Name} (ID: {Id}) — Dept: {Department} — Monthly: {MonthlySalary():F2}";

    public double AnnualSalary() => MonthlySalary() * 12;
}

public class FullTimeEmployee : Employee
{
    public double BaseSalary { get; }
    public double Bonus      { get; }

    public FullTimeEmployee(string name, string id, string department,
                            double baseSalary, double bonus = 0.0)
        : base(name, id, department)
    {
        if (baseSalary <= 0)
            throw new ArgumentOutOfRangeException(nameof(baseSalary), "Base salary must be positive.");
        BaseSalary = baseSalary;
        Bonus      = bonus;
    }

    public override double MonthlySalary() => BaseSalary + Bonus;
    public override string EmployeeType()  => "Full-Time";
}

public class ContractEmployee : Employee
{
    public double HourlyRate    { get; }
    public int    HoursPerMonth { get; }

    public ContractEmployee(string name, string id, string department,
                            double hourlyRate, int hoursPerMonth)
        : base(name, id, department)
    {
        if (hourlyRate    <= 0) throw new ArgumentOutOfRangeException(nameof(hourlyRate),    "Hourly rate must be positive.");
        if (hoursPerMonth <= 0) throw new ArgumentOutOfRangeException(nameof(hoursPerMonth), "Hours per month must be positive.");
        HourlyRate    = hourlyRate;
        HoursPerMonth = hoursPerMonth;
    }

    public override double MonthlySalary() => HourlyRate * HoursPerMonth;
    public override string EmployeeType()  => "Contract";

    public ContractEmployee WithHours(int hours)
        => new ContractEmployee(Name, Id, Department, HourlyRate, hours);
}
