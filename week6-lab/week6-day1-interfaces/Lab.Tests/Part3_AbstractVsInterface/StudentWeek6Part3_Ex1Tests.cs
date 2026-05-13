using OopCsharp.Week6.Part3_AbstractVsInterface.Exercises;
using Xunit;

namespace OopCsharp.Week6.Tests.Part3_AbstractVsInterface;

// 14 tests
public class StudentWeek6Part3_Ex1Tests
{
    // ── MemoryLogger ─────────────────────────────────────────────────────

    [Fact]
    public void MemoryLogger_Log_AddsEntry()
    {
        var logger = new MemoryLogger();
        logger.Log("hello");
        Assert.Equal(1, logger.EntryCount);
    }

    [Fact]
    public void MemoryLogger_Log_StoresMessage()
    {
        var logger = new MemoryLogger();
        logger.Log("hello");
        Assert.Equal("hello", logger.GetEntries()[0]);
    }

    [Fact]
    public void MemoryLogger_MultipleEntries_CountIsCorrect()
    {
        var logger = new MemoryLogger();
        logger.Log("one");
        logger.Log("two");
        logger.Log("three");
        Assert.Equal(3, logger.EntryCount);
    }

    [Fact]
    public void MemoryLogger_LogError_PrependsSuffix()
    {
        var logger = new MemoryLogger();
        logger.LogError("something went wrong");
        Assert.Single(logger.GetEntries());
        Assert.StartsWith("[ERROR]", logger.GetEntries()[0]);
        Assert.Contains("something went wrong", logger.GetEntries()[0]);
    }

    [Fact]
    public void MemoryLogger_GetLastEntry_ReturnsLastMessage()
    {
        var logger = new MemoryLogger();
        logger.Log("first");
        logger.Log("second");
        Assert.Equal("second", logger.GetLastEntry());
    }

    [Fact]
    public void MemoryLogger_GetLastEntry_EmptyLogger_ReturnsEmpty()
    {
        var logger = new MemoryLogger();
        Assert.Equal("", logger.GetLastEntry());
    }

    [Fact]
    public void MemoryLogger_GetEntries_ReturnsAll()
    {
        var logger = new MemoryLogger();
        logger.Log("a");
        logger.Log("b");
        var entries = logger.GetEntries();
        Assert.Equal(2, entries.Count);
        Assert.Equal("a", entries[0]);
        Assert.Equal("b", entries[1]);
    }

    [Fact]
    public void MemoryLogger_GetEntries_IsReadOnly()
    {
        var logger = new MemoryLogger();
        logger.Log("x");
        var entries = logger.GetEntries();
        // IReadOnlyList<string> — cannot call .Add() on it
        Assert.IsAssignableFrom<IReadOnlyList<string>>(entries);
    }

    // ── ConsoleLogger ─────────────────────────────────────────────────────

    [Fact]
    public void ConsoleLogger_Log_IncrementsEntryCount()
    {
        var logger = new ConsoleLogger();
        logger.Log("test");
        Assert.Equal(1, logger.EntryCount);
    }

    [Fact]
    public void ConsoleLogger_LogError_IncrementsEntryCount()
    {
        var logger = new ConsoleLogger();
        logger.LogError("boom");
        Assert.Equal(1, logger.EntryCount);
    }

    [Fact]
    public void ConsoleLogger_MultipleEntries_Counted()
    {
        var logger = new ConsoleLogger();
        for (int i = 0; i < 5; i++)
            logger.Log($"msg {i}");
        Assert.Equal(5, logger.EntryCount);
    }

    // ── ILogger interface ────────────────────────────────────────────────

    [Fact]
    public void MemoryLogger_ImplementsILogger()
    {
        Assert.IsAssignableFrom<ILogger>(new MemoryLogger());
    }

    [Fact]
    public void ConsoleLogger_ImplementsILogger()
    {
        Assert.IsAssignableFrom<ILogger>(new ConsoleLogger());
    }

    [Fact]
    public void ILogger_Polymorphism_LogThroughInterface()
    {
        ILogger logger = new MemoryLogger();
        logger.Log("via interface");
        Assert.Equal(1, logger.EntryCount);
    }
}
