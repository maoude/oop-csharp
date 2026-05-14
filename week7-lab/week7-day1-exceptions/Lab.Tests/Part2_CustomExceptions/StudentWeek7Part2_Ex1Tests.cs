/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Unit tests for custom exception exercises (13 tests covering TemperatureOutOfRangeException and Thermometer).
 */

using OopCsharp.Week7.Part2_CustomExceptions.Exercises;
using Xunit;

namespace OopCsharp.Week7.Tests.Part2_CustomExceptions;

// 13 tests
public class StudentWeek7Part2_Ex1Tests
{
    private const double Tol = 1e-9;

    // ── TemperatureOutOfRangeException ───────────────────────────────────

    [Fact]
    public void Exception_InheritsFromException()
    {
        var ex = new TemperatureOutOfRangeException();
        Assert.IsAssignableFrom<Exception>(ex);
    }

    [Fact]
    public void Exception_DomainCtor_SetsProperties()
    {
        var ex = new TemperatureOutOfRangeException(1200.0, -273.15, 1000.0);
        Assert.Equal(1200.0,   ex.Temperature, Tol);
        Assert.Equal(-273.15,  ex.Min,         Tol);
        Assert.Equal(1000.0,   ex.Max,         Tol);
    }

    [Fact]
    public void Exception_DomainCtor_MessageContainsTemperature()
    {
        var ex = new TemperatureOutOfRangeException(1200.0, -273.15, 1000.0);
        Assert.Contains("1200", ex.Message);
    }

    [Fact]
    public void Exception_MessageCtor_SetsMessage()
    {
        var ex = new TemperatureOutOfRangeException("custom message");
        Assert.Equal("custom message", ex.Message);
    }

    // ── Thermometer.SetTemperature ───────────────────────────────────────

    [Fact]
    public void Thermometer_DefaultTemperature_Is20()
    {
        var t = new Thermometer();
        Assert.Equal(20.0, t.Temperature, Tol);
    }

    [Fact]
    public void Thermometer_SetTemperature_ValidValue_Updates()
    {
        var t = new Thermometer();
        t.SetTemperature(100.0);
        Assert.Equal(100.0, t.Temperature, Tol);
    }

    [Fact]
    public void Thermometer_SetTemperature_BelowMin_Throws()
    {
        var t = new Thermometer();
        Assert.Throws<TemperatureOutOfRangeException>(() => t.SetTemperature(-300.0));
    }

    [Fact]
    public void Thermometer_SetTemperature_AboveMax_Throws()
    {
        var t = new Thermometer();
        Assert.Throws<TemperatureOutOfRangeException>(() => t.SetTemperature(1001.0));
    }

    [Fact]
    public void Thermometer_SetTemperature_ExceptionCarriesTemperature()
    {
        var t  = new Thermometer();
        var ex = Assert.Throws<TemperatureOutOfRangeException>(() => t.SetTemperature(-300.0));
        Assert.Equal(-300.0, ex.Temperature, Tol);
    }

    // ── Thermometer.ReadAverageOrDefault ─────────────────────────────────

    [Fact]
    public void ReadAverage_AllValid_ReturnsCorrectMean()
    {
        var t = new Thermometer();
        double avg = t.ReadAverageOrDefault(new[] { 10.0, 20.0, 30.0 }, -999.0);
        Assert.Equal(20.0, avg, Tol);
    }

    [Fact]
    public void ReadAverage_SomeInvalid_SkipsInvalidValues()
    {
        var t = new Thermometer();
        // 100 is valid, -500 is invalid, 200 is valid → average = 150
        double avg = t.ReadAverageOrDefault(new[] { 100.0, -500.0, 200.0 }, -999.0);
        Assert.Equal(150.0, avg, Tol);
    }

    [Fact]
    public void ReadAverage_AllInvalid_ReturnsDefaultValue()
    {
        var t = new Thermometer();
        double avg = t.ReadAverageOrDefault(new[] { -500.0, 2000.0 }, -1.0);
        Assert.Equal(-1.0, avg, Tol);
    }

    [Fact]
    public void ReadAverage_RestoresTemperatureAfter()
    {
        var t = new Thermometer();
        t.ReadAverageOrDefault(new[] { 100.0, 200.0 }, 0.0);
        Assert.Equal(20.0, t.Temperature, Tol);
    }
}
