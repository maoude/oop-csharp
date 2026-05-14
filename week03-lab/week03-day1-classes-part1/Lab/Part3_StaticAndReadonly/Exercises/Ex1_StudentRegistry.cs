/*
 * Course:  Introduction to Object-Oriented Programming with C#
 * Week:    3 — Classes in C# (Part 1)
 * Author:  Dr. Mohamad AOUDE
 * Purpose: Exercise W3.P3.Ex1 — StudentRegistry.
 *          Practise static fields (shared state), static methods, readonly
 *          fields (immutable per-instance data), and the difference between
 *          instance and static members.
 */
namespace OopCsharp.Week3.Part3_StaticAndReadonly.Exercises;

/// <summary>
/// Exercise W3.P3.Ex1 — StudentRegistry.
///
/// Every student gets a unique sequential ID assigned automatically.
/// The registry tracks how many students are currently enrolled.
/// Read every TODO carefully — order matters.
/// </summary>
public class StudentRegistry
{
    // ── TODO 1 — Static counter field ────────────────────────────────────────
    //
    // This is already declared correctly — leave it as is:
    //   private static int _nextId = 1;
    //
    // This ONE field is shared by ALL StudentRegistry objects.
    // Each new student increments it so the next student gets a higher ID.
    private static int _nextId = 1;

    // ── TODO 2 — Static enrolled count ───────────────────────────────────────
    //
    // Already declared — leave it:
    //   private static int _enrolledCount = 0;
    private static int _enrolledCount = 0;

    // ── TODO 3 — Readonly instance field Id ──────────────────────────────────
    //
    // Already declared — leave it:
    //   public readonly int Id;
    //
    // 'readonly' means it can only be set in the constructor.
    // After construction, Id never changes — it is the student's permanent ID.
    public readonly int Id;

    // ── TODO 4 — Instance properties ─────────────────────────────────────────
    //
    // Already declared — leave them:
    public string Name     { get; private set; } = string.Empty;
    public bool   Enrolled { get; private set; }

    // ── TODO 5 — Static property EnrolledCount ───────────────────────────────
    //
    // Replace throw with:
    //   return _enrolledCount;
    //
    // This is a STATIC property — accessed via StudentRegistry.EnrolledCount,
    // not via an instance variable.
    public static int EnrolledCount
    {
        get { throw new NotImplementedException(); }
    }

    // ── TODO 6 — Constructor ─────────────────────────────────────────────────
    //
    // Replace throw with:
    //   Id      = _nextId++;   // assigns current _nextId to Id, THEN increments
    //   Name    = name;
    //   Enrolled = true;
    //   _enrolledCount++;
    //
    // The post-increment operator ++ is key:
    //   Id = _nextId++;
    //   means: Id gets the CURRENT value, then _nextId increases by 1.
    //   So student 1 gets Id=1, student 2 gets Id=2, and so on.
    public StudentRegistry(string name)
    {
        throw new NotImplementedException();
    }

    // ── TODO 7 — Unenroll() ──────────────────────────────────────────────────
    //
    // Replace throw with:
    //   if (!Enrolled) return;   // already unenrolled — do nothing (idempotent)
    //   Enrolled = false;
    //   _enrolledCount--;
    //
    // 'idempotent' means: calling it twice has the same effect as calling it once.
    // Without the guard, a second Unenroll() would decrement _enrolledCount below
    // the real number of enrolled students.
    public void Unenroll()
    {
        throw new NotImplementedException();
    }

    // ── TODO 8 — Static method ResetRegistry() ───────────────────────────────
    //
    // Replace throw with:
    //   _nextId        = 1;
    //   _enrolledCount = 0;
    //
    // This is a STATIC method — it can only access static members (_nextId,
    // _enrolledCount).  It has no 'this' and cannot read Id, Name, or Enrolled.
    // Tests call this at the start of each test to get a clean slate.
    public static void ResetRegistry()
    {
        throw new NotImplementedException();
    }

    // ── TODO 9 — Describe() ──────────────────────────────────────────────────
    //
    // Replace throw with:
    //   string status = Enrolled ? "enrolled" : "unenrolled";
    //   return $"Student #{Id} {Name} [{status}]";
    //
    // Expected outputs:
    //   "Student #3 Alice [enrolled]"
    //   "Student #3 Alice [unenrolled]"
    public string Describe()
    {
        throw new NotImplementedException();
    }
}
