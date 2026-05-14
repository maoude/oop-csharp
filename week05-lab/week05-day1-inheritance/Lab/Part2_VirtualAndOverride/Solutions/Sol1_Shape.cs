/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     5 — Inheritance
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for Shape hierarchy with Circle, Rectangle, and sealed Square implementations.
 */

namespace OopCsharp.Week5.Part2_VirtualAndOverride.Solutions;

public class Shape
{
    public string Color { get; set; } = "Black";

    public virtual double Area()      => 0.0;
    public virtual double Perimeter() => 0.0;

    public override string ToString()
        => $"{GetType().Name}: color={Color}, area={Area():F2}, perimeter={Perimeter():F2}";
}

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be positive.");
        Radius = radius;
    }

    public override double Area()      => Math.PI * Radius * Radius;
    public override double Perimeter() => 2 * Math.PI * Radius;
}

public class Rectangle : Shape
{
    public double Width  { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        if (width  <= 0) throw new ArgumentOutOfRangeException(nameof(width),  "Width must be positive.");
        if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "Height must be positive.");
        Width  = width;
        Height = height;
    }

    public override double Area()      => Width * Height;
    public override double Perimeter() => 2 * (Width + Height);
}

public class Square : Rectangle
{
    public Square(double side) : base(side, side) { }

    public sealed override double Area() => Width * Width;
}
