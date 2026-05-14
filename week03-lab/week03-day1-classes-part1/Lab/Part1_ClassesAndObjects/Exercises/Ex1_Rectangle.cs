/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W3.P1.Ex1 — Rectangle.
 *          Design and implement a class from scratch.  You will add public
 *          fields, instance methods, and learn the difference between a class
 *          (blueprint) and an object (instance).
 */
namespace OopCsharp.Week3.Part1_ClassesAndObjects.Exercises;

/// <summary>
/// Exercise W3.P1.Ex1 — Rectangle.
///
/// This file already compiles — each method throws NotImplementedException
/// until you replace it with real code.
/// Work through the TODOs in order: fields first, then methods.
/// Do NOT change the class name, field names, or method signatures.
/// </summary>
public class Rectangle
{
    // ── TODO 1 — Public fields ───────────────────────────────────────────────
    //
    // Replace the two lines below with proper public field declarations:
    //
    //   public double Width;
    //   public double Height;
    //
    // A FIELD is a variable that belongs to each object (instance).
    // Every Rectangle you create will have its OWN Width and Height.
    // Public means code outside this class can read and write them directly.
    //
    // In Part 2 you will learn to replace public fields with properties.
    // For now, public fields keep the focus on the class/object concept.
    public double Width;    // ← already declared for you; delete this comment when done
    public double Height;   // ← already declared for you; delete this comment when done

    // ── TODO 2 — Area() ──────────────────────────────────────────────────────
    //
    // Replace throw new NotImplementedException() with:
    //   return Width * Height;
    //
    // This is an INSTANCE method — it reads the object's own Width and Height.
    // It has NO 'static' keyword.
    //
    // Example:
    //   Rectangle r = new Rectangle();
    //   r.Width  = 4;
    //   r.Height = 5;
    //   r.Area() → 20.0
    public double Area()
    {
        throw new NotImplementedException();
    }

    // ── TODO 3 — Perimeter() ─────────────────────────────────────────────────
    //
    // Replace throw with:
    //   return 2 * (Width + Height);
    public double Perimeter()
    {
        throw new NotImplementedException();
    }

    // ── TODO 4 — IsSquare() ──────────────────────────────────────────────────
    //
    // Replace throw with:
    //   return Width == Height;
    //
    // Returns true if Width == Height (floating-point comparison is exact here
    // because the tests set values directly — no rounding occurs).
    public bool IsSquare()
    {
        throw new NotImplementedException();
    }

    // ── TODO 5 — Scale(double factor) ────────────────────────────────────────
    //
    // Replace throw with code that multiplies BOTH Width and Height by factor:
    //   Width  *= factor;
    //   Height *= factor;
    //
    // This method returns void — it modifies the object's own fields IN PLACE.
    //
    // Example:
    //   r.Width = 3; r.Height = 4;
    //   r.Scale(2);
    //   r.Width → 6, r.Height → 8
    public void Scale(double factor)
    {
        throw new NotImplementedException();
    }

    // ── TODO 6 — Describe() ──────────────────────────────────────────────────
    //
    // Replace throw with:
    //   return $"Rectangle {Width:F1} x {Height:F1}, area={Area():F1}";
    //
    // ":F1" formats a double to ONE decimal place.
    // Area() is a method call inside the interpolation — perfectly legal.
    //
    // Expected output for Width=4, Height=5:
    //   "Rectangle 4.0 x 5.0, area=20.0"
    public string Describe()
    {
        throw new NotImplementedException();
    }
}
