using OopCsharp.Week7.Part3_BestPractices.Exercises;
using Xunit;

namespace OopCsharp.Week7.Tests.Part3_BestPractices;

// 12 tests
public class StudentWeek7Part3_Ex1Tests
{
    // ── Count & IsEmpty ───────────────────────────────────────────────────

    [Fact]
    public void NewQueue_Count_IsZero()
    {
        var q = new SafeQueue<string>();
        Assert.Equal(0, q.Count);
    }

    [Fact]
    public void NewQueue_IsEmpty_IsTrue()
    {
        var q = new SafeQueue<string>();
        Assert.True(q.IsEmpty);
    }

    // ── Enqueue ───────────────────────────────────────────────────────────

    [Fact]
    public void Enqueue_NullItem_ThrowsArgumentNullException()
    {
        var q = new SafeQueue<string>();
        Assert.Throws<ArgumentNullException>(() => q.Enqueue(null!));
    }

    [Fact]
    public void Enqueue_ValidItem_IncreasesCount()
    {
        var q = new SafeQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        Assert.Equal(2, q.Count);
    }

    [Fact]
    public void Enqueue_ValidItem_IsEmptyBecomesFalse()
    {
        var q = new SafeQueue<string>();
        q.Enqueue("hello");
        Assert.False(q.IsEmpty);
    }

    // ── Dequeue ───────────────────────────────────────────────────────────

    [Fact]
    public void Dequeue_ReturnsItemsInFifoOrder()
    {
        var q = new SafeQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        Assert.Equal(1, q.Dequeue());
        Assert.Equal(2, q.Dequeue());
        Assert.Equal(3, q.Dequeue());
    }

    [Fact]
    public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
    {
        var q = new SafeQueue<string>();
        Assert.Throws<InvalidOperationException>(() => q.Dequeue());
    }

    [Fact]
    public void Dequeue_EmptyQueue_ExceptionMessageContainsEmpty()
    {
        var q  = new SafeQueue<string>();
        var ex = Assert.Throws<InvalidOperationException>(() => q.Dequeue());
        Assert.Contains("empty", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    // ── TryDequeue ────────────────────────────────────────────────────────

    [Fact]
    public void TryDequeue_ValidItem_ReturnsTrueAndItem()
    {
        var q = new SafeQueue<string>();
        q.Enqueue("world");
        bool ok = q.TryDequeue(out string? value);
        Assert.True(ok);
        Assert.Equal("world", value);
    }

    [Fact]
    public void TryDequeue_EmptyQueue_ReturnsFalse()
    {
        var q = new SafeQueue<string>();
        bool ok = q.TryDequeue(out _);
        Assert.False(ok);
    }

    [Fact]
    public void TryDequeue_EmptyQueue_DoesNotThrow()
    {
        var q = new SafeQueue<string>();
        var ex = Record.Exception(() => q.TryDequeue(out _));
        Assert.Null(ex);
    }

    // ── Clear ─────────────────────────────────────────────────────────────

    [Fact]
    public void Clear_ResetsCountToZero()
    {
        var q = new SafeQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Clear();
        Assert.Equal(0, q.Count);
    }
}
