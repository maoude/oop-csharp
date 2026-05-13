/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Instructor demo — static members (fields, properties, methods,
 *          constructors), readonly fields, const vs readonly, and the
 *          common factory-method pattern using static.
 *          Read this file completely before starting Exercise 3.
 */

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 1 — static fields: shared state across all instances
// ══════════════════════════════════════════════════════════════════════════════
//
// A STATIC FIELD is declared with the 'static' keyword.
// There is exactly ONE copy, regardless of how many objects exist.
// Every instance of the class reads/writes the same storage location.
//
// Typical uses:
//   - Counting how many objects have been created (_count)
//   - Sharing configuration that is the same for all objects (DefaultTimeout)
//   - Caching an expensive computation that is class-wide

namespace OopCsharp.Week3.Part3_StaticAndReadonly;

/// <summary>
/// A counter that auto-assigns an ID to each new instance and tracks
/// the total number of counters ever created.
/// </summary>
public class Counter
{
    // ── Static field ─────────────────────────────────────────────────────────
    // Shared by ALL Counter objects.
    private static int _totalCreated = 0;

    // ── Instance fields ───────────────────────────────────────────────────────
    // Each Counter object has its OWN copy of these.
    private int _value;
    public readonly int Id;       // readonly — see Section 3

    // ── Static property (read-only from outside) ──────────────────────────────
    public static int TotalCreated => _totalCreated;

    // ── Constructor ───────────────────────────────────────────────────────────
    public Counter()
    {
        // ++ modifies the ONE shared _totalCreated.
        // Each new Counter gets a unique sequential ID.
        _totalCreated++;
        Id     = _totalCreated;
        _value = 0;
    }

    // ── Instance method — uses its own _value ──────────────────────────────
    public void Increment() => _value++;
    public int  Value      => _value;

    // ── Static method — can only access static members ────────────────────
    //
    // A static method has no 'this' — it is not called on any object.
    // It cannot access _value or Id (those are per-object).
    public static void ResetAll()
    {
        _totalCreated = 0;
        // _value = 0;  ← compile error — _value is an instance field
    }
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 2 — static constructor
// ══════════════════════════════════════════════════════════════════════════════
//
// A STATIC CONSTRUCTOR runs exactly ONCE, the first time the class is used.
// It has no parameters and no access modifier.
// Use it to initialise expensive shared resources (e.g. loading config files).

/// <summary>
/// Demonstrates a static constructor initialising a shared lookup table.
/// </summary>
public class PrimeCache
{
    private static readonly bool[] _isPrime;

    // Static constructor — runs once, the first time PrimeCache is used.
    static PrimeCache()
    {
        Console.WriteLine("[PrimeCache] Building sieve...");
        _isPrime = BuildSieve(1000);
    }

    private static bool[] BuildSieve(int limit)
    {
        bool[] sieve = new bool[limit + 1];
        Array.Fill(sieve, true);
        sieve[0] = sieve[1] = false;
        for (int i = 2; i * i <= limit; i++)
            if (sieve[i])
                for (int j = i * i; j <= limit; j += i)
                    sieve[j] = false;
        return sieve;
    }

    public static bool IsPrime(int n)
    {
        if (n < 0 || n >= _isPrime.Length) return false;
        return _isPrime[n];
    }
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 3 — readonly vs const
// ══════════════════════════════════════════════════════════════════════════════
//
// CONST:
//   - Value known at compile time
//   - Must be a primitive (int, double, string, bool, enum)
//   - Implicitly static — accessed via ClassName.ConstName
//   - Cannot depend on runtime state
//
// READONLY:
//   - Value set at runtime, either in the declaration or the constructor
//   - Can be any type (including objects)
//   - Can be instance OR static
//   - After the constructor finishes, it cannot be changed

/// <summary>Demonstrates both const and readonly.</summary>
public class PhysicsConstants
{
    // const: fixed at compile time, known to all users of this class
    public const double SpeedOfLight = 299_792_458.0;   // m/s
    public const double Planck       = 6.626e-34;       // J·s

    // readonly instance field: set in constructor, then immutable
    public readonly string Name;
    public readonly double Value;

    public PhysicsConstants(string name, double value)
    {
        Name  = name;
        Value = value;
        // After this constructor returns, Name and Value cannot be changed.
    }

    // readonly static field: computed once at class startup
    private static readonly double _goldenRatio = (1 + Math.Sqrt(5)) / 2;
    public static double GoldenRatio => _goldenRatio;
    // Cannot use 'const' here because Math.Sqrt is a runtime call.
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 4 — Factory method pattern (static method that creates objects)
// ══════════════════════════════════════════════════════════════════════════════
//
// A FACTORY METHOD is a static method that creates and returns an object.
// It is useful when:
//   - Object creation requires complex logic or validation
//   - You want a descriptive name for different creation modes
//   - You want to control which constructor variant is called

/// <summary>
/// A 2D point that can be created from Cartesian or polar coordinates.
/// The constructor is private — callers must use the factory methods.
/// </summary>
public class Point2D
{
    public double X { get; }
    public double Y { get; }

    // Private constructor — only the factory methods can call it.
    private Point2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Factory: create from Cartesian coordinates (x, y)
    public static Point2D FromCartesian(double x, double y)
        => new Point2D(x, y);

    // Factory: create from polar coordinates (r, θ in radians)
    public static Point2D FromPolar(double radius, double angleRadians)
        => new Point2D(
            radius * Math.Cos(angleRadians),
            radius * Math.Sin(angleRadians));

    public double DistanceTo(Point2D other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public override string ToString() => $"({X:F3}, {Y:F3})";
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 5 — Demo runner
// ══════════════════════════════════════════════════════════════════════════════

public static class Demo03_StaticAndReadonly
{
    public static void Run()
    {
        // ── Counter / static field ────────────────────────────────────────────
        Console.WriteLine($"Total before: {Counter.TotalCreated}");   // 0
        Counter a = new Counter();
        Counter b = new Counter();
        Counter c = new Counter();
        Console.WriteLine($"Total after:  {Counter.TotalCreated}");   // 3
        Console.WriteLine($"a.Id={a.Id}  b.Id={b.Id}  c.Id={c.Id}"); // 1 2 3

        a.Increment();
        a.Increment();
        b.Increment();
        Console.WriteLine($"a.Value={a.Value}  b.Value={b.Value}");   // 2  1

        // ── PrimeCache (static constructor) ────────────────────────────────
        Console.WriteLine(PrimeCache.IsPrime(7));    // True
        Console.WriteLine(PrimeCache.IsPrime(10));   // False

        // ── readonly vs const ─────────────────────────────────────────────
        Console.WriteLine($"c = {PhysicsConstants.SpeedOfLight}");
        Console.WriteLine($"φ = {PhysicsConstants.GoldenRatio:F6}");

        // ── Factory methods ───────────────────────────────────────────────
        Point2D p1 = Point2D.FromCartesian(3, 4);
        Point2D p2 = Point2D.FromPolar(1, Math.PI / 4);  // 45°
        Console.WriteLine($"p1 = {p1}");                         // (3.000, 4.000)
        Console.WriteLine($"p2 = {p2}");                         // (0.707, 0.707)
        Console.WriteLine($"Distance: {p1.DistanceTo(p2):F3}"); // ~4.627
    }
}
