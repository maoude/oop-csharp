/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Reference solution for W3.P3.Ex1 — StudentRegistry.
 *          Do NOT share with students before the submission deadline.
 */
namespace OopCsharp.Week3.Part3_StaticAndReadonly.Solutions;

/// <summary>Reference solution for StudentRegistry (W3.P3.Ex1).</summary>
public class Sol1_StudentRegistry
{
    // Static fields — ONE copy shared by all instances.
    private static int _nextId        = 1;
    private static int _enrolledCount = 0;

    // readonly instance field — set once in constructor, immutable thereafter.
    public readonly int Id;

    public string Name     { get; private set; }
    public bool   Enrolled { get; private set; }

    // Static property — accessed via the class, not an instance.
    public static int EnrolledCount => _enrolledCount;

    public Sol1_StudentRegistry(string name)
    {
        Id      = _nextId++;   // assign current, then increment for the next student
        Name    = name;
        Enrolled = true;
        _enrolledCount++;
    }

    public void Unenroll()
    {
        if (!Enrolled) return;   // idempotent — safe to call multiple times
        Enrolled = false;
        _enrolledCount--;
    }

    public static void ResetRegistry()
    {
        _nextId        = 1;
        _enrolledCount = 0;
        // Cannot access Id, Name, Enrolled here — those are instance members.
    }

    public string Describe()
    {
        string status = Enrolled ? "enrolled" : "unenrolled";
        return $"Student #{Id} {Name} [{status}]";
    }
}
