/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate virtual/override polymorphism, sealed methods, and runtime dispatch patterns.
 */

namespace OopCsharp.Week5.Part2_VirtualAndOverride;

// ============================================================
// DEMO 02 — virtual / override / sealed
// Topics: virtual methods, override, sealed, polymorphism,
//         calling base.Method() from an override
// ============================================================

// ----------------------------------------------------------
// Section 1: virtual + override — true polymorphism
// ----------------------------------------------------------
// Mark a base method 'virtual' to allow derived classes to replace it.
// The derived class uses 'override' to replace the implementation.
// Callers holding a base-class reference always get the most-derived version.

public class Shape
{
    public string Color { get; set; } = "Black";

    // virtual: derived classes MAY override this
    public virtual double Area() => 0.0;

    public virtual string Describe()
        => $"{GetType().Name} (color: {Color}, area: {Area():F2})";
}

public class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius) => Radius = radius;

    // override: replaces Shape.Area() for all Circle references
    public override double Area() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double Width  { get; }
    public double Height { get; }
    public Rectangle(double width, double height)
    {
        Width  = width;
        Height = height;
    }

    public override double Area() => Width * Height;
}

// ----------------------------------------------------------
// Section 2: calling base.Method() from an override
// ----------------------------------------------------------
// Sometimes you want to extend rather than replace the base behaviour.
// Call base.Method() to include the parent's output, then add to it.

public class Triangle : Shape
{
    public double Base   { get; }
    public double Height { get; }
    public Triangle(double b, double h) { Base = b; Height = h; }

    public override double Area() => 0.5 * Base * Height;

    public override string Describe()
        => base.Describe() + $", sides: {Base} × {Height}";
    //   ^^^^^^^^^^^^^^^^^^^^
    //   calls Shape.Describe() first, then appends triangle-specific info
}

// ----------------------------------------------------------
// Section 3: sealed — prevent further overriding
// ----------------------------------------------------------
// 'sealed' on an override stops the chain: no further subclass
// can override that method.  Use it to lock a critical implementation.

public class EquilateralTriangle : Triangle
{
    public double Side { get; }
    public EquilateralTriangle(double side)
        : base(side, side * Math.Sqrt(3) / 2)
    {
        Side = side;
    }

    // 'sealed override' — nothing can override Area() further
    public sealed override double Area()
        => Math.Sqrt(3) / 4 * Side * Side;
}

// If someone tries:
//   class MyTriangle : EquilateralTriangle { public override double Area() => 0; }
// → compile error: cannot override sealed member.

// ----------------------------------------------------------
// Section 4: Polymorphism in action
// ----------------------------------------------------------
// A list of Shape references can hold Circles, Rectangles, etc.
// Calling .Area() dispatches to the correct override at runtime.

internal static class Demo02Runner
{
    internal static void Run()
    {
        var shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 8),
            new EquilateralTriangle(10),
        };

        // Each call dispatches to the correct override — polymorphism.
        foreach (var shape in shapes)
            Console.WriteLine(shape.Describe());

        Console.WriteLine();

        // Total area — works regardless of shape type
        double total = shapes.Sum(s => s.Area());
        Console.WriteLine($"Total area: {total:F2}");

        // ------ virtual vs non-virtual timing ------
        // With a base-class reference:
        Shape s1 = new Circle(3);
        Console.WriteLine(s1.Area());   // Circle.Area() — virtual dispatch
    }
}
