/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Instructor demo — properties (full and auto), constructors,
 *          constructor overloading, constructor chaining, and object
 *          initialiser syntax.
 *          Read this file completely before starting Exercises 1 and 2.
 */

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 1 — Why not public fields?
// ══════════════════════════════════════════════════════════════════════════════
//
// In Demo01 Circle.Radius was a public field.  That works but has a problem:
//
//   Circle c = new Circle();
//   c.Radius = -5;   // ← Radius cannot be negative, but nothing stops this!
//
// A PROPERTY solves this: it looks like a field from the outside but runs
// code (a getter/setter) so you can validate the value.

namespace OopCsharp.Week3.Part2_PropertiesAndConstructors;

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 2 — Full property pattern (backing field + get/set)
// ══════════════════════════════════════════════════════════════════════════════

/// <summary>
/// A temperature value that enforces it is never below absolute zero (-273.15 °C).
/// Demonstrates the full property pattern with a private backing field.
/// </summary>
public class Temperature
{
    // Private backing field — stores the actual value.
    // Naming convention: _camelCase with underscore prefix.
    private double _celsius;

    // Full property: a getter and a setter with validation.
    //
    // From outside this class, it looks like a field:
    //   Temperature t = new Temperature();
    //   t.Celsius = 100;     ← calls the setter
    //   double d = t.Celsius; ← calls the getter
    //
    // But the setter enforces the physics law.
    public double Celsius
    {
        get { return _celsius; }
        set
        {
            if (value < -273.15)
                throw new ArgumentOutOfRangeException(
                    nameof(value), "Temperature cannot be below absolute zero.");
            _celsius = value;
        }
    }

    // Computed (read-only) property — no backing field needed.
    // The getter derives its value from another property.
    public double Fahrenheit => _celsius * 9.0 / 5.0 + 32;
    //                        ↑ expression-body property — equivalent to
    //                          get { return _celsius * 9.0 / 5.0 + 32; }
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 3 — Auto-implemented properties
// ══════════════════════════════════════════════════════════════════════════════
//
// When you do NOT need validation, the compiler can generate the backing field:
//
//   public string Name { get; set; }
//     ↑ Compiler generates a hidden private field and trivial get/set.
//
//   public int Age { get; private set; }
//     ↑ Anyone can read Age, but only code in this class can set it.
//
//   public string Id { get; init; }
//     ↑ 'init' setter: can be set during object initialisation, then
//       becomes read-only — perfect for IDs that should not change.

/// <summary>
/// A student record using auto-implemented properties.
/// </summary>
public class Student
{
    public string Name { get; set; }           // read/write by anyone
    public int    Age  { get; private set; }   // anyone reads, only Student sets
    public string Id   { get; init; }          // set at construction, then immutable

    // ── Constructors ─────────────────────────────────────────────────────────
    //
    // A CONSTRUCTOR is a special method that runs when 'new' is called.
    // Its name must match the class name; it has no return type.
    //
    // If you write NO constructor, C# provides a parameterless default
    // that zero-initialises all fields and properties.
    // The moment you write ONE constructor, the default disappears.

    // Parameterised constructor — sets all three properties at once.
    public Student(string name, int age, string id)
    {
        // 'this.' is required here because the parameter names match
        // the property names (case-insensitive in the context of the
        // property, but it is clearer to be explicit).
        Name = name;
        Age  = age;
        Id   = id;
    }

    // ── Constructor overloading ───────────────────────────────────────────────
    //
    // Two constructors can coexist as long as their parameter lists differ.
    // This one assigns a default ID when none is provided.
    public Student(string name, int age)
        : this(name, age, Guid.NewGuid().ToString("N")[..8])
        // ↑ Constructor chaining — calls the three-parameter constructor.
        //   'this(...)' must be the first thing (before the body {}).
        //   This avoids duplicating the assignment logic.
    {
        // Body can be empty if the chained constructor did everything.
    }

    /// <summary>Returns a human-readable summary of this student.</summary>
    public string Describe() => $"[{Id}] {Name}, age {Age}";
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 4 — Object initialiser syntax
// ══════════════════════════════════════════════════════════════════════════════

public static class Demo02_PropertiesAndConstructors
{
    public static void Run()
    {
        // ── Standard constructor ──────────────────────────────────────────────
        Student s1 = new Student("Alice", 20, "S001");
        Console.WriteLine(s1.Describe());   // [S001] Alice, age 20

        // ── Chained constructor (auto-generates ID) ───────────────────────────
        Student s2 = new Student("Bob", 22);
        Console.WriteLine(s2.Describe());   // [xxxxxxxx] Bob, age 22

        // ── Object initialiser syntax ─────────────────────────────────────────
        //
        // After the constructor runs, C# lets you set additional public
        // properties using { Property = value, ... } syntax.
        // This is purely syntactic sugar — it is equivalent to calling
        // the constructor and then doing separate assignments.
        //
        // Useful for: setting optional properties without 10 constructor overloads.
        // Requires: the property has a public setter (or 'init').
        Student s3 = new Student("Carol", 19) { Name = "Caroline" };
        // ↑ Calls Student("Carol", 19), then sets Name to "Caroline".
        Console.WriteLine(s3.Describe());

        // ── Temperatures ─────────────────────────────────────────────────────
        Temperature t = new Temperature { Celsius = 100 };
        Console.WriteLine($"{t.Celsius} °C = {t.Fahrenheit} °F");   // 100 °C = 212 °F

        try
        {
            t.Celsius = -300;   // below absolute zero
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Caught: {ex.ParamName}");   // value
        }

        // ── init-only enforcement ─────────────────────────────────────────────
        // s1.Id = "S002";  ← compile error — 'Id' has an init setter,
        //                    so it can only be set in { ... } or a constructor.
        // This is how we guarantee IDs never change after creation.
    }
}
