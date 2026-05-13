/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W3.P1.Ex1 — Rectangle.
 *          Do NOT share with students before the submission deadline.
 */
namespace OopCsharp.Week3.Part1_ClassesAndObjects.Solutions;

/// <summary>Reference solution for Rectangle (W3.P1.Ex1).</summary>
public class Sol1_Rectangle
{
    public double Width;
    public double Height;

    public double Area()      => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
    public bool   IsSquare()  => Width == Height;

    public void Scale(double factor)
    {
        Width  *= factor;
        Height *= factor;
    }

    public string Describe()
        => $"Rectangle {Width:F1} x {Height:F1}, area={Area():F1}";
}
