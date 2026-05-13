/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Demonstrate interface fundamentals: contract declaration, implementation,
 *           multiple inheritance, polymorphism, and comparing interfaces with abstract classes.
 *           Run live during lecture — show how polymorphism enables loose coupling.
 */
namespace OopCsharp.Week6.Part1_InterfaceBasics;

// ============================================================
// DEMO 01 — Interface Basics
// Topics: interface declaration, implementing an interface,
//         interface vs abstract class, multiple interface
//         implementation, explicit interface implementation
// ============================================================

// ----------------------------------------------------------
// Section 1: Declaring an interface
// ----------------------------------------------------------
// An interface is a pure contract — it defines WHAT a type must do,
// not HOW it does it.
//
// Rules:
//  • All members are public by default (no access modifiers needed)
//  • No instance fields
//  • No constructors
//  • Members have no body (except default implementations in C# 8+)
//
// Naming convention: prefix with 'I'

public interface IDrawable
{
    void Draw();                        // must implement
    string Description { get; }        // read-only property contract
}

public interface IResizable
{
    void Resize(double factor);
}

// ----------------------------------------------------------
// Section 2: Implementing an interface
// ----------------------------------------------------------
// A class implements an interface by listing it after the colon.
// ALL interface members must be present or the class must be abstract.

public class Circle : IDrawable, IResizable
{
    public double Radius { get; private set; }

    public Circle(double radius) => Radius = radius;

    // Implements IDrawable
    public void Draw() => Console.WriteLine($"Drawing circle with radius {Radius:F1}");

    // Implements IDrawable
    public string Description => $"Circle(r={Radius:F1})";

    // Implements IResizable
    public void Resize(double factor)
    {
        if (factor <= 0) throw new ArgumentOutOfRangeException(nameof(factor));
        Radius *= factor;
    }
}

// ----------------------------------------------------------
// Section 3: Interface as a type
// ----------------------------------------------------------
// You can hold any implementing class in an interface-typed variable.
// This is the same polymorphism as with base classes — but without
// requiring a shared base class.

internal static class Demo01Runner
{
    internal static void Run()
    {
        // Interface-typed variable
        IDrawable shape = new Circle(5);
        shape.Draw();                         // dispatches to Circle.Draw()
        Console.WriteLine(shape.Description); // dispatches to Circle.Description

        // Collection of IDrawable — can mix any implementing types
        var drawables = new List<IDrawable>
        {
            new Circle(3),
            new Circle(7),
        };
        foreach (var d in drawables)
            d.Draw();

        // IResizable independently
        IResizable r = new Circle(4);
        r.Resize(2.0);
        Console.WriteLine(((Circle)r).Radius);  // 8.0

        // ----------------------------------------------------------
        // Section 4: interface vs abstract class comparison
        // ----------------------------------------------------------
        // Interface                      | Abstract class
        // -------------------------------|----------------------------
        // No instance fields             | Can have instance fields
        // No constructor                 | Can have constructor
        // Multiple implementations       | Single inheritance only
        // All members public by default  | Can have protected/private
        // Pure contract                  | Mix of contract + shared code
        //
        // Rule of thumb:
        //   • Shared STATE and LOGIC → abstract class
        //   • Pure capability contract → interface
        //   • Often you use BOTH together

        // ----------------------------------------------------------
        // Section 5: Explicit interface implementation
        // ----------------------------------------------------------
        // When two interfaces define a method with the same name,
        // you can implement them explicitly to distinguish:
    }
}

// Two interfaces, same method name
public interface IPrintable  { string Format(); }
public interface IExportable { string Format(); }

public class Report : IPrintable, IExportable
{
    // Explicit implementations — only accessible through the interface type
    string IPrintable.Format()  => "Print format";
    string IExportable.Format() => "Export format";
}

internal static class ExplicitDemo
{
    internal static void Run()
    {
        var report = new Report();
        // report.Format();                        // ambiguous — compile error
        IPrintable  p = report;
        IExportable e = report;
        Console.WriteLine(p.Format());  // "Print format"
        Console.WriteLine(e.Format());  // "Export format"
    }
}
