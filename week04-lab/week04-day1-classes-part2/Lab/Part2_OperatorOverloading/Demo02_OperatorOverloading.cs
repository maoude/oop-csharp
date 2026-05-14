/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Instructor demo — operator overloading: binary arithmetic,
 *          equality operators, unary operators, and the rules that govern
 *          which operators can and cannot be overloaded.
 *          Read this file completely before starting Exercise 2.
 */

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 1 — Why overload operators?
// ══════════════════════════════════════════════════════════════════════════════
//
// Without operator overloading, adding two vectors looks like:
//   Vector result = Vector.Add(v1, v2);
//
// With operator overloading, it looks like:
//   Vector result = v1 + v2;
//
// The second form matches mathematical notation.  It makes the code easier
// to read when the type genuinely represents a mathematical concept.
//
// DON'T overload operators just because you can.  Ask: "Would a reader
// immediately understand what + means here?"  For Vector, yes.
// For DatabaseConnection, no.

namespace OopCsharp.Week4.Part2_OperatorOverloading;

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 2 — Binary operator overloading (+, -, *, /)
// ══════════════════════════════════════════════════════════════════════════════

/// <summary>
/// A 2D mathematical vector.  Demonstrates +, -, unary -, scalar *, ==, !=.
/// </summary>
public class Vector2D
{
    public double X { get; }
    public double Y { get; }

    public Vector2D(double x, double y) { X = x; Y = y; }

    // Magnitude (length) of the vector — a computed property, not an operator.
    public double Magnitude => Math.Sqrt(X * X + Y * Y);

    // ── Binary + ────────────────────────────────────────────────────────────
    //
    // Syntax rules:
    //   - Must be 'public static'
    //   - Returns the result type (usually the same class)
    //   - Parameters are the two operands
    //   - Cannot mutate a or b — operators should return NEW objects
    //
    // v1 + v2  →  the compiler rewrites this as  Vector2D.operator+(v1, v2)
    public static Vector2D operator +(Vector2D a, Vector2D b)
        => new Vector2D(a.X + b.X, a.Y + b.Y);

    // ── Binary - ─────────────────────────────────────────────────────────────
    public static Vector2D operator -(Vector2D a, Vector2D b)
        => new Vector2D(a.X - b.X, a.Y - b.Y);

    // ── Scalar multiplication — TWO overloads needed for commutativity ────────
    //
    // v * 3.0  uses the first overload (Vector2D left, double right)
    // 3.0 * v  uses the second overload (double left, Vector2D right)
    // Both produce the same result.  C# does NOT flip arguments automatically.
    public static Vector2D operator *(Vector2D v, double scalar)
        => new Vector2D(v.X * scalar, v.Y * scalar);

    public static Vector2D operator *(double scalar, Vector2D v)
        => new Vector2D(v.X * scalar, v.Y * scalar);   // delegate to the other

    // ══════════════════════════════════════════════════════════════════════════
    // SECTION 3 — Unary operators
    // ══════════════════════════════════════════════════════════════════════════
    //
    // Unary operators take ONE operand (the operand IS the receiver here).
    // -v  negates both components.

    public static Vector2D operator -(Vector2D v)
        => new Vector2D(-v.X, -v.Y);

    // ══════════════════════════════════════════════════════════════════════════
    // SECTION 4 — Equality operators (== and !=)
    // ══════════════════════════════════════════════════════════════════════════
    //
    // RULE: == and != must be overloaded in PAIRS — you cannot do one without
    //       the other.  The compiler enforces this.
    //
    // RULE: When you overload ==, you MUST also override Equals() and
    //       GetHashCode() for consistency.  If == returns true, Equals()
    //       must return true for the same pair, and vice versa.

    public static bool operator ==(Vector2D a, Vector2D b)
        => a.X == b.X && a.Y == b.Y;

    public static bool operator !=(Vector2D a, Vector2D b)
        => !(a == b);   // delegate to == and negate — avoids duplicating logic

    // Required because we overloaded ==
    public override bool Equals(object? obj)
        => obj is Vector2D other && this == other;

    public override int GetHashCode() => HashCode.Combine(X, Y);

    // ══════════════════════════════════════════════════════════════════════════
    // SECTION 5 — ToString for readable output
    // ══════════════════════════════════════════════════════════════════════════
    public override string ToString() => $"({X:F2}, {Y:F2})";
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 6 — Prefix and postfix ++ / --
// ══════════════════════════════════════════════════════════════════════════════
//
// Both prefix (++x) and postfix (x++) use the same operator keyword.
// C# uses a DUMMY int parameter to distinguish them at the call site:
//
//   operator ++(Counter c)          →  prefix  ++c
//   operator ++(Counter c, int _)   →  postfix  c++
//
// The dummy parameter is NEVER used inside the method body.
// By convention it is named '_' or 'unused'.

/// <summary>A simple step counter that supports prefix and postfix ++.</summary>
public class StepCounter
{
    public int Value { get; private set; }

    public StepCounter(int value) { Value = value; }

    // Prefix ++c  →  increments c, returns the NEW (incremented) value
    public static StepCounter operator ++(StepCounter c)
        => new StepCounter(c.Value + 1);

    // Postfix c++  →  returns the OLD value, THEN increments
    // (The dummy int parameter signals postfix to the compiler.)
    // NOTE: in C# the postfix behaviour for user-defined types works differently
    // from primitives — the compiler handles saving the old value automatically
    // when you use it in an expression like  result = c++;
    // You just need to define the operator; the compiler does the rest.
    // Both prefix and postfix share the same operator definition in C#.
    // The distinction below is shown for education — in practice you only
    // define ONE ++ operator and the compiler handles both usages.
    public override string ToString() => $"StepCounter({Value})";
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 7 — Operators you CANNOT overload
// ══════════════════════════════════════════════════════════════════════════════
//
// Cannot overload: =, &&, ||, ?:, ??, =>, new, typeof, sizeof, is, as
//
// = (assignment) cannot be overloaded because it would break the language.
// &&/|| are short-circuit operators — to get them to work on your type,
//   overload & and | plus operator true/operator false (advanced).

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 8 — Demo runner
// ══════════════════════════════════════════════════════════════════════════════

public static class Demo02_OperatorOverloading
{
    public static void Run()
    {
        Vector2D v1 = new Vector2D(1, 2);
        Vector2D v2 = new Vector2D(3, 4);

        Console.WriteLine(v1 + v2);       // (4.00, 6.00)
        Console.WriteLine(v2 - v1);       // (2.00, 2.00)
        Console.WriteLine(v1 * 3.0);      // (3.00, 6.00)
        Console.WriteLine(2.0 * v1);      // (2.00, 4.00)  — commutativity
        Console.WriteLine(-v1);           // (-1.00, -2.00)
        Console.WriteLine(v1.Magnitude);  // 2.236...

        // Equality
        Vector2D v3 = new Vector2D(1, 2);
        Console.WriteLine(v1 == v3);   // True  — same components
        Console.WriteLine(v1 == v2);   // False

        // StepCounter
        StepCounter c = new StepCounter(0);
        ++c;
        Console.WriteLine(c);   // StepCounter(1)
        ++c;
        Console.WriteLine(c);   // StepCounter(2)
    }
}
