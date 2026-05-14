/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise on Shape hierarchy with virtual Area/Perimeter and sealed Square implementation.
 */

namespace OopCsharp.Week5.Part2_VirtualAndOverride.Exercises;

// ============================================================
// Exercise 1 — Shape hierarchy with virtual / override
//
// Build:
//   Shape (base, virtual methods)
//     ├─ Circle    : Shape
//     └─ Rectangle : Shape
//         └─ Square : Rectangle  (sealed Area)
//
// Requirements are listed as TODO comments inside each class.
// ============================================================

public class Shape
{
    // TODO 1a: Add a public string property  Color  with a public setter.
    //          Default value: "Black"

    // TODO 1b: Implement  virtual double Area()
    //          Base returns 0.0

    // TODO 1c: Implement  virtual double Perimeter()
    //          Base returns 0.0

    // TODO 1d: Override ToString() to return
    //          "{ClassName}: color={Color}, area={Area():F2}, perimeter={Perimeter():F2}"
    //          Use GetType().Name for ClassName.
    //          Example: "Circle: color=Red, area=78.54, perimeter=31.42"
    public override string ToString() => throw new NotImplementedException();
}

public class Circle : Shape
{
    // TODO 2a: Add a public double property  Radius  (get-only, set in constructor)

    // TODO 2b: Implement the constructor Circle(double radius)
    //          Throw ArgumentOutOfRangeException if radius <= 0.

    // TODO 2c: Override Area()      → Math.PI * Radius * Radius
    // TODO 2d: Override Perimeter() → 2 * Math.PI * Radius
}

public class Rectangle : Shape
{
    // TODO 3a: Add public double properties  Width  and  Height  (get-only)

    // TODO 3b: Implement the constructor Rectangle(double width, double height)
    //          Throw ArgumentOutOfRangeException if width <= 0 or height <= 0.

    // TODO 3c: Override Area()      → Width * Height
    // TODO 3d: Override Perimeter() → 2 * (Width + Height)
}

public class Square : Rectangle
{
    // TODO 4a: Implement the constructor Square(double side)
    //          Call base(side, side).
    //          Hint: no new properties needed — Width == Height == side.

    // TODO 4b: sealed override Area() → side * side
    //          (use Width because Square stores the side as Width)
    //          Mark it sealed so no further subclass can change it.
}
