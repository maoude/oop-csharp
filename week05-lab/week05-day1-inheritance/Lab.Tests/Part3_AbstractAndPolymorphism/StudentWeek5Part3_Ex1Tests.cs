/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for Employee hierarchy exercises (14 tests covering abstract classes, polymorphism, pattern matching).
 */

using OopCsharp.Week5.Part3_AbstractAndPolymorphism.Exercises;
using Xunit;

namespace OopCsharp.Week5.Tests.Part3_AbstractAndPolymorphism;

// 14 tests
public class StudentWeek5Part3_Ex1Tests
{
    // ── FullTimeEmployee ─────────────────────────────────────────────────

    [Fact]
    public void FullTime_Properties_SetCorrectly()
    {
        var ft = new FullTimeEmployee("Alice", "FT001", "Engineering", 5000, 200);
        Assert.Equal("Alice",       ft.Name);
        Assert.Equal("FT001",       ft.Id);
        Assert.Equal("Engineering", ft.Department);
        Assert.Equal(5000,          ft.BaseSalary);
        Assert.Equal(200,           ft.Bonus);
    }

    [Fact]
    public void FullTime_MonthlySalary_IsBasePlusBonus()
    {
        var ft = new FullTimeEmployee("Alice", "FT001", "Engineering", 5000, 200);
        Assert.Equal(5200.0, ft.MonthlySalary());
    }

    [Fact]
    public void FullTime_NoBonusDefault()
    {
        var ft = new FullTimeEmployee("Bob", "FT002", "HR", 3000);
        Assert.Equal(0.0, ft.Bonus);
        Assert.Equal(3000.0, ft.MonthlySalary());
    }

    [Fact]
    public void FullTime_AnnualSalary_IsTwelveMonths()
    {
        var ft = new FullTimeEmployee("Alice", "FT001", "Engineering", 5000, 200);
        Assert.Equal(5200.0 * 12, ft.AnnualSalary());
    }

    [Fact]
    public void FullTime_EmployeeType_IsFullTime()
    {
        var ft = new FullTimeEmployee("Alice", "FT001", "Engineering", 5000);
        Assert.Equal("Full-Time", ft.EmployeeType());
    }

    [Fact]
    public void FullTime_Summary_ContainsKeyFields()
    {
        var ft = new FullTimeEmployee("Alice", "FT001", "Engineering", 5000, 200);
        string s = ft.Summary();
        Assert.Contains("Full-Time", s);
        Assert.Contains("Alice",     s);
        Assert.Contains("FT001",     s);
        Assert.Contains("5200.00",   s);
    }

    [Fact]
    public void FullTime_InvalidSalary_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new FullTimeEmployee("X", "X1", "Dept", 0));
    }

    // ── ContractEmployee ─────────────────────────────────────────────────

    [Fact]
    public void Contract_Properties_SetCorrectly()
    {
        var ce = new ContractEmployee("Bob", "C001", "IT", 50, 160);
        Assert.Equal("Bob",  ce.Name);
        Assert.Equal("C001", ce.Id);
        Assert.Equal(50.0,   ce.HourlyRate);
        Assert.Equal(160,    ce.HoursPerMonth);
    }

    [Fact]
    public void Contract_MonthlySalary_IsRateTimesHours()
    {
        var ce = new ContractEmployee("Bob", "C001", "IT", 50, 160);
        Assert.Equal(8000.0, ce.MonthlySalary());
    }

    [Fact]
    public void Contract_EmployeeType_IsContract()
    {
        var ce = new ContractEmployee("Bob", "C001", "IT", 50, 160);
        Assert.Equal("Contract", ce.EmployeeType());
    }

    [Theory]
    [InlineData(0,   160)]
    [InlineData(50,  0)]
    [InlineData(-10, 160)]
    public void Contract_InvalidArgs_Throw(double rate, int hours)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new ContractEmployee("X", "X1", "Dept", rate, hours));
    }

    [Fact]
    public void Contract_WithHours_ReturnsNewInstance()
    {
        var ce1 = new ContractEmployee("Bob", "C001", "IT", 50, 160);
        var ce2 = ce1.WithHours(80);
        Assert.NotSame(ce1, ce2);
        Assert.Equal(80, ce2.HoursPerMonth);
        Assert.Equal(ce1.HourlyRate, ce2.HourlyRate);
        Assert.Equal("Bob", ce2.Name);
    }

    // ── Polymorphism ─────────────────────────────────────────────────────

    [Fact]
    public void Polymorphism_TotalMonthlySalary_UsesCorrectOverrides()
    {
        var employees = new List<Employee>
        {
            new FullTimeEmployee("Alice", "FT001", "Eng",  5000, 200),
            new ContractEmployee("Bob",   "C001",  "IT",   50,   160),
        };
        double total = employees.Sum(e => e.MonthlySalary());
        Assert.Equal(5200 + 8000, total);
    }

    [Fact]
    public void Polymorphism_IsPattern_DowncastToContractEmployee()
    {
        Employee e = new ContractEmployee("Carol", "C002", "Ops", 60, 100);
        Assert.True(e is ContractEmployee);
        if (e is ContractEmployee ce)
        {
            var modified = ce.WithHours(120);
            Assert.Equal(60 * 120, modified.MonthlySalary());
        }
    }
}
