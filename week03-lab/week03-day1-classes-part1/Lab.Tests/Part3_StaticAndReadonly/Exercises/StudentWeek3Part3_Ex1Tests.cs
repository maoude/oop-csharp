/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     3 — Classes in C# (Part 1)
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Grading tests for W3.P3.Ex1 — StudentRegistry.
 *           Tests verify sequential ID assignment, static EnrolledCount,
 *           Unenroll idempotency, ResetRegistry, and Describe format.
 *           Each test resets the registry first to prevent order-dependency.
 *           Do NOT modify this file.
 */
namespace OopCsharp.Week3.Part3_StaticAndReadonly.Exercises;

using Xunit;

/// <summary>Grading tests for <see cref="StudentRegistry"/> (W3.P3.Ex1).</summary>
public class StudentWeek3Part3_Ex1Tests
{
    // Helper: always reset before each test so static state is clean.
    private static void Reset() => StudentRegistry.ResetRegistry();

    // ── Sequential IDs ────────────────────────────────────────────────────────

    [Fact]
    public void First_student_gets_id_one()
    {
        Reset();
        var s = new StudentRegistry("Alice");
        Assert.Equal(1, s.Id);
    }

    [Fact]
    public void Sequential_students_get_incrementing_ids()
    {
        Reset();
        var s1 = new StudentRegistry("Alice");
        var s2 = new StudentRegistry("Bob");
        var s3 = new StudentRegistry("Carol");
        Assert.Equal(1, s1.Id);
        Assert.Equal(2, s2.Id);
        Assert.Equal(3, s3.Id);
    }

    // ── Id is readonly ────────────────────────────────────────────────────────
    // (Verified behaviourally: Id must not change after construction.)
    [Fact]
    public void Id_does_not_change_after_construction()
    {
        Reset();
        var s = new StudentRegistry("Dave");
        int idAtCreation = s.Id;
        // No way to set Id from outside — just verify it reads the same value.
        Assert.Equal(idAtCreation, s.Id);
    }

    // ── EnrolledCount ─────────────────────────────────────────────────────────

    [Fact]
    public void EnrolledCount_starts_at_zero_after_reset()
    {
        Reset();
        Assert.Equal(0, StudentRegistry.EnrolledCount);
    }

    [Fact]
    public void EnrolledCount_increments_with_each_new_student()
    {
        Reset();
        Assert.Equal(0, StudentRegistry.EnrolledCount);
        new StudentRegistry("A");
        Assert.Equal(1, StudentRegistry.EnrolledCount);
        new StudentRegistry("B");
        Assert.Equal(2, StudentRegistry.EnrolledCount);
    }

    // ── Unenroll ──────────────────────────────────────────────────────────────

    [Fact]
    public void Unenroll_sets_enrolled_to_false()
    {
        Reset();
        var s = new StudentRegistry("Eve");
        Assert.True(s.Enrolled);
        s.Unenroll();
        Assert.False(s.Enrolled);
    }

    [Fact]
    public void Unenroll_decrements_enrolled_count()
    {
        Reset();
        var s = new StudentRegistry("Frank");
        Assert.Equal(1, StudentRegistry.EnrolledCount);
        s.Unenroll();
        Assert.Equal(0, StudentRegistry.EnrolledCount);
    }

    [Fact]
    public void Unenroll_is_idempotent()
    {
        Reset();
        var s = new StudentRegistry("Grace");
        s.Unenroll();
        s.Unenroll();   // calling again must not crash or double-decrement
        Assert.Equal(0, StudentRegistry.EnrolledCount);
        Assert.False(s.Enrolled);
    }

    // ── ResetRegistry ─────────────────────────────────────────────────────────

    [Fact]
    public void ResetRegistry_resets_id_counter_to_one()
    {
        Reset();
        new StudentRegistry("Temp");
        new StudentRegistry("Temp");
        Reset();
        var s = new StudentRegistry("After Reset");
        Assert.Equal(1, s.Id);
    }

    [Fact]
    public void ResetRegistry_resets_enrolled_count_to_zero()
    {
        Reset();
        new StudentRegistry("H");
        new StudentRegistry("I");
        Assert.Equal(2, StudentRegistry.EnrolledCount);
        Reset();
        Assert.Equal(0, StudentRegistry.EnrolledCount);
    }

    // ── Describe ──────────────────────────────────────────────────────────────

    [Fact]
    public void Describe_enrolled_format()
    {
        Reset();
        var s = new StudentRegistry("Alice");
        Assert.Equal("Student #1 Alice [enrolled]", s.Describe());
    }

    [Fact]
    public void Describe_unenrolled_format()
    {
        Reset();
        var s = new StudentRegistry("Bob");
        s.Unenroll();
        Assert.Equal("Student #1 Bob [unenrolled]", s.Describe());
    }

    [Fact]
    public void Describe_reflects_correct_id()
    {
        Reset();
        new StudentRegistry("First");
        new StudentRegistry("Second");
        var s3 = new StudentRegistry("Third");
        Assert.Equal("Student #3 Third [enrolled]", s3.Describe());
    }
}
