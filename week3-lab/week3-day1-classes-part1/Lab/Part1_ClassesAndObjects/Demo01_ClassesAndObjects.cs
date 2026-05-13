/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Instructor demo — what a class is, how objects are created,
 *          the difference between a class (blueprint) and an object
 *          (instance), and the fundamental members: fields and methods.
 *          Read this file completely before starting Exercise 1.
 */

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 1 — What is a class?
// ══════════════════════════════════════════════════════════════════════════════
//
// So far every method you wrote was static and lived inside a static class.
// That means there was only ONE copy of the code, and it held no state between
// calls.
//
// A CLASS is a blueprint that describes:
//   - DATA the object holds (fields / properties)
//   - BEHAVIOUR the object can perform (instance methods)
//
// An OBJECT is a specific thing built from that blueprint.
// You can create as many objects as you need — each has its OWN copy of the data.
//
//   Blueprint (class):  Dog
//   Objects (instances): myDog, yourDog, theirDog
//   Each dog has its OWN name, breed, and age.
//
// Analogy: a class is an architect's floor plan; objects are actual houses.
// The plan is one document. The houses are physical buildings — each can be
// painted a different colour, have different furniture, etc.

namespace OopCsharp.Week3.Part1_ClassesAndObjects;

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 2 — A minimal class: fields and a method
// ══════════════════════════════════════════════════════════════════════════════

/// <summary>
/// A simple model of a circle. It has one field (Radius) and two methods
/// (Area, Perimeter). This is the smallest meaningful class you can write.
/// </summary>
public class Circle
{
    // ── Fields ───────────────────────────────────────────────────────────────
    //
    // A FIELD is a variable that belongs to an OBJECT (not to a method).
    // Each Circle object gets its own private copy of _radius.
    //
    // Convention:
    //   - Private fields start with an underscore: _radius
    //   - Public fields are rare in well-designed classes (use properties instead)
    //
    // 'public' means code outside this class can read/write it.
    // We will make this private and expose it through a property in Part 2.
    public double Radius;

    // ── Instance Methods ─────────────────────────────────────────────────────
    //
    // An INSTANCE METHOD is called on a specific object:
    //   Circle c = new Circle();
    //   double a = c.Area();      ← 'c' is the receiver
    //
    // Notice: NO 'static' keyword. Static methods belong to the class;
    // instance methods belong to an object.

    /// <summary>Returns π × r².</summary>
    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    /// <summary>Returns 2 × π × r.</summary>
    public double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 3 — Creating objects (instantiation)
// ══════════════════════════════════════════════════════════════════════════════

/// <summary>
/// Demo runner — shows how to create objects and call instance methods.
/// In production code this would be Main() or a test; here it is a method
/// so we can call it from other demo code without a full program entry point.
/// </summary>
public static class Demo01_ClassesAndObjects
{
    public static void Run()
    {
        // ── Instantiation ────────────────────────────────────────────────────
        //
        // 'new' does three things:
        //   1. Allocates memory on the heap for ONE Circle object
        //   2. Runs the constructor (Circle() — default, does nothing here)
        //   3. Returns a REFERENCE to the object
        //
        // c1 and c2 are REFERENCES — they point to different objects.
        Circle c1 = new Circle();
        c1.Radius = 3.0;

        Circle c2 = new Circle();
        c2.Radius = 5.0;

        Console.WriteLine($"Circle 1 area:      {c1.Area():F4}");    // 28.2743
        Console.WriteLine($"Circle 2 area:      {c2.Area():F4}");    // 78.5398
        Console.WriteLine($"Circle 1 perimeter: {c1.Perimeter():F4}"); // 18.8496

        // ── Reference semantics ──────────────────────────────────────────────
        //
        // c3 is NOT a new circle — it is a second name for the SAME object.
        // Changing c3.Radius also changes c1.Radius.
        Circle c3 = c1;
        c3.Radius = 10.0;
        Console.WriteLine($"c1.Radius after c3 change: {c1.Radius}"); // 10 — same object!

        // Compare with value types (e.g. int):
        int x = 5;
        int y = x;   // y is a COPY — changing y does not change x
        y = 99;
        Console.WriteLine($"x after y change: {x}"); // still 5

        // ── Null references ──────────────────────────────────────────────────
        //
        // A reference variable can point to "nothing" — the null reference.
        // Calling a method on null causes NullReferenceException.
        Circle? maybeCircle = null;
        // maybeCircle.Area();   ← would crash here!
        if (maybeCircle != null)
            Console.WriteLine(maybeCircle.Area());

        // Null-conditional operator — safe shorthand:
        double? area = maybeCircle?.Area();   // area is null if maybeCircle is null
        Console.WriteLine($"Safe area: {area}"); // prints ""
    }

    // ══════════════════════════════════════════════════════════════════════════
    // SECTION 4 — The 'this' reference
    // ══════════════════════════════════════════════════════════════════════════
    //
    // Inside an instance method, 'this' refers to the object the method was
    // called on.  It is used in two situations:
    //
    // 1. Disambiguate when a parameter has the same name as a field:
    //
    //    public void SetRadius(double Radius)
    //    {
    //        this.Radius = Radius;   // this.Radius = field, Radius = parameter
    //    }
    //
    // 2. Pass the current object to another method:
    //
    //    public void Print()
    //    {
    //        Printer.Print(this);   // send ourselves as an argument
    //    }
    //
    // You do NOT need 'this' when there is no ambiguity — it is optional.
    // Good style: only write 'this.' when it clarifies something.
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 5 — Instance vs Static: the full picture
// ══════════════════════════════════════════════════════════════════════════════
//
// STATIC members:
//   - Belong to the CLASS, not any object
//   - There is exactly ONE copy, shared by everyone
//   - Accessed via the class name: Math.Sqrt(x)
//   - Use case: utility methods that need no state (Math, Convert, Console)
//
// INSTANCE members:
//   - Belong to an OBJECT
//   - Each object has its own copy of the data
//   - Accessed via a reference: c1.Area()
//   - Use case: anything that depends on the object's own data
//
// Rule of thumb: if the method uses any field of the object → instance method.
//               if it only takes inputs and produces outputs → consider static.
//
// Example:
//   static double ScaleRadius(double r, double factor) { return r * factor; }
//     ↑ No object state needed → static makes sense
//
//   public double Area() { return Math.PI * Radius * Radius; }
//     ↑ Uses 'Radius' field → must be instance method (or take Radius as param)
