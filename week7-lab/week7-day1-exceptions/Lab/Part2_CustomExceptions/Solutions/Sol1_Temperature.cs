/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Custom Exceptions
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for domain exception design and thermometer implementation.
 *           Students compare their exception hierarchy against this model answer.
 */
namespace OopCsharp.Week7.Part2_CustomExceptions.Solutions;

public class TemperatureOutOfRangeException : Exception
{
    public double Temperature { get; }
    public double Min         { get; }
    public double Max         { get; }

    public TemperatureOutOfRangeException()
        : base("Temperature is outside the valid range.") { }

    public TemperatureOutOfRangeException(string message)
        : base(message) { }

    public TemperatureOutOfRangeException(string message, Exception innerException)
        : base(message, innerException) { }

    public TemperatureOutOfRangeException(double temperature, double min, double max)
        : base($"Temperature {temperature:F1}°C is outside the valid range [{min:F1}, {max:F1}].")
    {
        Temperature = temperature;
        Min         = min;
        Max         = max;
    }
}

public class Thermometer
{
    public const double MinTemp = -273.15;
    public const double MaxTemp = 1000.0;

    public double Temperature { get; private set; } = 20.0;

    public void SetTemperature(double value)
    {
        if (value < MinTemp || value > MaxTemp)
            throw new TemperatureOutOfRangeException(value, MinTemp, MaxTemp);
        Temperature = value;
    }

    public double ReadAverageOrDefault(double[] readings, double defaultValue)
    {
        double sum   = 0;
        int    count = 0;

        foreach (double r in readings)
        {
            try
            {
                SetTemperature(r);
                sum += r;
                count++;
            }
            catch (TemperatureOutOfRangeException)
            {
                // skip invalid reading
            }
        }

        Temperature = 20.0;
        return count == 0 ? defaultValue : sum / count;
    }
}
