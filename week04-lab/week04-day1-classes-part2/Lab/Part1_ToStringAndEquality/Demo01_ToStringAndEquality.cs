/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    4 — Classes in C# (Part 2)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Instructor demo — overriding ToString(), Equals(), and
 *          GetHashCode(); reference equality vs value equality;
 *          and the contract that links the three methods.
 *          Read this file completely before starting Exercise 1.
 */

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 1 — Why override ToString()?
// ══════════════════════════════════════════════════════════════════════════════
//
// Every class in C# inherits from 'object'.  'object' provides a default
// ToString() that returns the fully-qualified type name:
//
//   new Point(3, 4).ToString()  →  "OopCsharp.Week4.Part1_ToStringAndEquality.Point"
//
// That is useless for debugging.  Override ToString() to return something
// meaningful.  C# calls ToString() automatically in:
//   - string interpolation: $"Position: {point}"
//   - Console.WriteLine(point)
//   - Debugger watch windows

namespace OopCsharp.Week4.Part1_ToStringAndEquality;

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 2 — Overriding ToString()
// ══════════════════════════════════════════════════════════════════════════════

/// <summary>
/// An immutable 2D point.  Demonstrates ToString(), Equals(), and
/// GetHashCode() overrides.
/// </summary>
public class Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y) { X = x; Y = y; }

    // Override ToString() — called automatically in string contexts.
    // 'override' keyword is required; it replaces the base class version.
    public override string ToString() => $"({X}, {Y})";

    // ══════════════════════════════════════════════════════════════════════════
    // SECTION 3 — Reference equality vs value equality
    // ══════════════════════════════════════════════════════════════════════════
    //
    // By default, == and Equals() for classes compare REFERENCES (addresses).
    // Two different objects with the same field values are NOT equal by default:
    //
    //   Point a = new Point(3, 4);
    //   Point b = new Point(3, 4);
    //   a == b          → false   (different objects in memory)
    //   a.Equals(b)     → false   (same as ==, by default for classes)
    //   object.ReferenceEquals(a, b) → false (always uses address)
    //
    // To make Equals() compare VALUES, you must override it.

    // Override Equals() — defines what it means for two Points to be "equal".
    // The parameter type is 'object?' because we might be compared to anything.
    public override bool Equals(object? obj)
    {
        // Step 1: null or wrong type → not equal
        if (obj is not Point other) return false;

        // Step 2: compare the actual data
        return X == other.X && Y == other.Y;
        // Note: for doubles, == is exact. In real code you might use
        // Math.Abs(X - other.X) < 1e-10 to handle floating-point imprecision.
    }

    // ══════════════════════════════════════════════════════════════════════════
    // SECTION 4 — The Equals/GetHashCode contract
    // ══════════════════════════════════════════════════════════════════════════
    //
    // RULE (enforced by the C# compiler as a warning):
    //   If you override Equals(), you MUST also override GetHashCode().
    //
    // WHY: Dictionary<K,V> and HashSet<T> use hash codes to find objects quickly.
    // The contract is:
    //   If a.Equals(b) is true, then a.GetHashCode() == b.GetHashCode() MUST be true.
    //
    // Violating this breaks Dictionary lookups — objects become "lost" in the table.
    //
    // How to implement: combine the hash codes of the fields that Equals uses.
    // HashCode.Combine() does this correctly.
    public override int GetHashCode() => HashCode.Combine(X, Y);
}

// ══════════════════════════════════════════════════════════════════════════════
// SECTION 5 — Demo runner
// ══════════════════════════════════════════════════════════════════════════════

public static class Demo01_ToStringAndEquality
{
    public static void Run()
    {
        Point a = new Point(3, 4);
        Point b = new Point(3, 4);
        Point c = a;               // c and a refer to the SAME object

        // ── ToString ──────────────────────────────────────────────────────────
        Console.WriteLine(a);                    // (3, 4)  — automatic ToString()
        Console.WriteLine($"Point is: {a}");     // (3, 4)  — interpolation calls ToString()

        // ── Reference equality (always uses address) ──────────────────────────
        Console.WriteLine(object.ReferenceEquals(a, b));  // False — different objects
        Console.WriteLine(object.ReferenceEquals(a, c));  // True  — same object

        // ── Value equality (our override) ─────────────────────────────────────
        Console.WriteLine(a.Equals(b));   // True  — same X and Y
        Console.WriteLine(a.Equals(c));   // True  — same object, trivially equal

        // ── In a Dictionary (hash code matters!) ─────────────────────────────
        var dict = new Dictionary<Point, string>();
        dict[a] = "origin-ish";
        Console.WriteLine(dict[b]);   // "origin-ish" — b has same hash as a

        // ── Comparing to null and wrong type ──────────────────────────────────
        Console.WriteLine(a.Equals(null));     // False
        Console.WriteLine(a.Equals("hello"));  // False — wrong type

        // ══════════════════════════════════════════════════════════════════════
        // SECTION 6 — A note on records
        // ══════════════════════════════════════════════════════════════════════
        //
        // C# 9 introduced 'record' types.  A record automatically generates
        // ToString(), Equals(), GetHashCode(), and == based on all properties.
        //
        //   public record PointRecord(double X, double Y);
        //   PointRecord r1 = new(3, 4);
        //   PointRecord r2 = new(3, 4);
        //   r1 == r2   → True   (value equality, generated automatically)
        //   r1.ToString() → "PointRecord { X = 3, Y = 4 }"
        //
        // In this course we override manually so you understand what records do
        // under the hood.  In production code, prefer records for immutable data.
    }
}
