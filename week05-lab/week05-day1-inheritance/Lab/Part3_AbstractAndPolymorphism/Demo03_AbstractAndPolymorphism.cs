/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate abstract classes, abstract methods, and is/as/pattern matching for safe downcasting.
 */

namespace OopCsharp.Week5.Part3_AbstractAndPolymorphism;

// ============================================================
// DEMO 03 — abstract classes, is / as, upcasting / downcasting
// Topics: abstract class, abstract method, is / as / pattern matching,
//         safe downcasting, design rules
// ============================================================

// ----------------------------------------------------------
// Section 1: abstract class
// ----------------------------------------------------------
// An abstract class cannot be instantiated directly.
// It exists only to be inherited.
// It CAN contain fully implemented (concrete) members AND abstract members.

public abstract class Vehicle
{
    public string Make  { get; }
    public string Model { get; }
    public int    Year  { get; }

    protected Vehicle(string make, string model, int year)
    {
        Make  = make;
        Model = model;
        Year  = year;
    }

    // ----------------------------------------------------------
    // Section 2: abstract method
    // ----------------------------------------------------------
    // An abstract method has no body in the base class.
    // Every non-abstract derived class MUST override it.

    public abstract string FuelType();      // no body — must override
    public abstract double CostPerKm();     // no body — must override

    // Concrete method — inherited as-is (but can be overridden)
    public virtual string Summary()
        => $"{Year} {Make} {Model} | Fuel: {FuelType()} | Cost: {CostPerKm():F3} /km";
}

// ----------------------------------------------------------
// Section 3: concrete derived classes
// ----------------------------------------------------------

public class PetrolCar : Vehicle
{
    public double TankLitres      { get; }
    public double LitresPer100Km  { get; }

    public PetrolCar(string make, string model, int year,
                     double tankLitres, double litresPer100Km)
        : base(make, model, year)
    {
        TankLitres     = tankLitres;
        LitresPer100Km = litresPer100Km;
    }

    public override string FuelType()   => "Petrol";
    public override double CostPerKm()  => LitresPer100Km / 100 * 1.80; // 1.80/litre

    public double Range() => TankLitres / LitresPer100Km * 100;
}

public class ElectricCar : Vehicle
{
    public double BatteryKWh      { get; }
    public double KWhPer100Km     { get; }

    public ElectricCar(string make, string model, int year,
                       double batteryKWh, double kWhPer100Km)
        : base(make, model, year)
    {
        BatteryKWh    = batteryKWh;
        KWhPer100Km   = kWhPer100Km;
    }

    public override string FuelType()   => "Electric";
    public override double CostPerKm()  => KWhPer100Km / 100 * 0.25; // 0.25/kWh

    public double Range() => BatteryKWh / KWhPer100Km * 100;

    public override string Summary()
        => base.Summary() + $" | Range: {Range():F0} km";
}

// ----------------------------------------------------------
// Section 4: is / as / pattern matching
// ----------------------------------------------------------
// 'is' tests the runtime type.
// 'as' attempts a cast and returns null on failure (reference types only).
// Pattern matching ('is Type variable') tests AND declares in one step.

internal static class Demo03Runner
{
    internal static void Run()
    {
        // Upcast — always implicit and safe
        Vehicle v1 = new PetrolCar("Toyota", "Corolla", 2022, 50, 6.5);
        Vehicle v2 = new ElectricCar("Tesla",  "Model 3", 2023, 75, 15);

        var fleet = new List<Vehicle> { v1, v2 };

        foreach (var v in fleet)
            Console.WriteLine(v.Summary());   // polymorphism: correct override called

        Console.WriteLine();

        // ------ 'is' operator ------
        if (v1 is PetrolCar)
            Console.WriteLine("v1 is a PetrolCar");

        // ------ 'as' operator ------
        PetrolCar? pc = v1 as PetrolCar;   // null if not a PetrolCar
        if (pc != null)
            Console.WriteLine($"Tank: {pc.TankLitres} L, Range: {pc.Range():F0} km");

        // ------ pattern matching (preferred) ------
        foreach (var v in fleet)
        {
            if (v is ElectricCar ec)
                Console.WriteLine($"{ec.Model} battery: {ec.BatteryKWh} kWh");
            else if (v is PetrolCar petrol)
                Console.WriteLine($"{petrol.Model} tank: {petrol.TankLitres} L");
        }

        // ------ switch expression with type patterns ------
        foreach (var v in fleet)
        {
            string label = v switch
            {
                ElectricCar ec => $"EV — {ec.BatteryKWh} kWh",
                PetrolCar   p  => $"Petrol — {p.TankLitres} L",
                _              => "Unknown",
            };
            Console.WriteLine($"{v.Model}: {label}");
        }
    }
}
