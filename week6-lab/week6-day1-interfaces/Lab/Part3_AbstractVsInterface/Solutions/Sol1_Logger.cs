/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for mixed interface + abstract class hierarchy.
 *           Students compare their logger design against this model.
 */
namespace OopCsharp.Week6.Part3_AbstractVsInterface.Solutions;

public interface ILogger
{
    void Log(string message);
    void LogError(string message) => Log("[ERROR] " + message);
    int  EntryCount { get; }
}

public abstract class LoggerBase : ILogger
{
    protected List<string> _entries = new();

    public int EntryCount => _entries.Count;

    public void Log(string message)
    {
        _entries.Add(message);
        WriteEntry(message);
    }

    public void LogError(string message) => Log("[ERROR] " + message);

    protected abstract void WriteEntry(string message);

    public IReadOnlyList<string> GetEntries() => _entries.AsReadOnly();
}

public class ConsoleLogger : LoggerBase
{
    protected override void WriteEntry(string message) => Console.WriteLine(message);
}

public class MemoryLogger : LoggerBase
{
    protected override void WriteEntry(string message) { /* no extra output */ }

    public string GetLastEntry()
        => _entries.Count == 0 ? "" : _entries[^1];
}
