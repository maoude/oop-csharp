/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Custom Exceptions
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: design a domain exception (TemperatureOutOfRangeException)
 *           and a class that throws it (Thermometer). Practice: exception hierarchies,
 *           property-carrying exceptions, and exception-driven validation.
 */
namespace OopCsharp.Week7.Part2_CustomExceptions.Exercises;

// ============================================================
// Exercise 1 — TemperatureOutOfRangeException + Thermometer
//
// Build a domain-specific exception and a class that uses it.
// ============================================================

// TODO 1: Implement TemperatureOutOfRangeException : Exception
//
//   Properties (get-only, set in the domain constructor):
//     double Temperature  — the value that was rejected
//     double Min          — the lower bound of the valid range
//     double Max          — the upper bound of the valid range
//
//   Standard three constructors (each calls the matching base):
//     TemperatureOutOfRangeException()
//     TemperatureOutOfRangeException(string message)
//     TemperatureOutOfRangeException(string message, Exception innerException)
//
//   Domain constructor:
//     TemperatureOutOfRangeException(double temperature, double min, double max)
//     Calls base with message:
//       $"Temperature {temperature:F1}°C is outside the valid range [{min:F1}, {max:F1}]."
//     Sets Temperature, Min, Max.

public class TemperatureOutOfRangeException : Exception
{
    // TODO 1a: Auto-properties (get-only) for Temperature, Min, Max
    public double Temperature { get; }
    public double Min         { get; }
    public double Max         { get; }

    // Standard constructors — call the matching base constructor.
    // TODO 1a: implement the three bodies (each is a single : base(...) call)
    public TemperatureOutOfRangeException()
        : base("Temperature is outside the valid range.") { }

    public TemperatureOutOfRangeException(string message)
        : base(message) { }

    public TemperatureOutOfRangeException(string message, Exception innerException)
        : base(message, innerException) { }

    // TODO 1b: Domain constructor
    //   Build the message: $"Temperature {temperature:F1}°C is outside the valid range [{min:F1}, {max:F1}]."
    //   Set Temperature, Min, Max.
    public TemperatureOutOfRangeException(double temperature, double min, double max)
        : base($"Temperature {temperature:F1}°C is outside the valid range [{min:F1}, {max:F1}].")
    {
        // TODO: assign Temperature, Min, Max
    }
}

// TODO 2: Implement class Thermometer
//
//   Constants:
//     public const double MinTemp = -273.15
//     public const double MaxTemp = 1000.0
//
//   Property:
//     public double Temperature { get; private set; }   — starts at 20.0
//
//   Method: void SetTemperature(double value)
//     Throws TemperatureOutOfRangeException(value, MinTemp, MaxTemp)
//     if value < MinTemp or value > MaxTemp.
//     Otherwise sets Temperature to value.
//
//   Method: double ReadAverageOrDefault(double[] readings, double defaultValue)
//     For each value in readings, call SetTemperature.
//     If it throws TemperatureOutOfRangeException, skip that reading (don't count it).
//     Compute and return the arithmetic mean of the accepted readings.
//     If no readings were accepted, return defaultValue.
//     Restore Temperature to 20.0 before returning.

public class Thermometer
{
    public const double MinTemp = -273.15;
    public const double MaxTemp = 1000.0;

    public double Temperature { get; private set; } = 20.0;

    public void SetTemperature(double value) => throw new NotImplementedException();

    public double ReadAverageOrDefault(double[] readings, double defaultValue)
        => throw new NotImplementedException();
}
