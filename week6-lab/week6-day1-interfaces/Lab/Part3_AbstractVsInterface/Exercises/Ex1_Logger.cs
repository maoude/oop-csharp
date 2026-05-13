/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     6 — Interfaces & Abstract Classes
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: design a logger hierarchy combining interface contract
 *           with abstract base class implementation. Practice mixed hierarchies,
 *           default interface methods, and template method patterns.
 */
namespace OopCsharp.Week6.Part3_AbstractVsInterface.Exercises;

// ============================================================
// Exercise 1 — Logger hierarchy: abstract class + interface
//
// Build:
//   ILogger (interface)
//   abstract LoggerBase : ILogger  (abstract class)
//     ├─ ConsoleLogger : LoggerBase
//     └─ MemoryLogger  : LoggerBase
//
// Requirements:
// ============================================================

// TODO 1: Declare interface ILogger
//   Members:
//     void   Log(string message)
//     void   LogError(string message)   — default: Log("[ERROR] " + message)
//     int    EntryCount { get; }

// TODO 2: Declare abstract class LoggerBase : ILogger
//   Fields/properties:
//     protected List<string> _entries  (backing store, initialised in constructor)
//     public int EntryCount { get; }   → _entries.Count
//   Constructor: LoggerBase()  — initialises _entries
//   Implement: void Log(string message)
//     → appends the message to _entries, then calls  WriteEntry(message)
//   Implement: void LogError(string message)
//     → calls Log("[ERROR] " + message)
//   Abstract: protected abstract void WriteEntry(string message)
//     (derived classes decide how to output the entry)
//   Implement: IReadOnlyList<string> GetEntries() → _entries.AsReadOnly()

// TODO 3: Implement ConsoleLogger : LoggerBase
//   WriteEntry(string message) → Console.WriteLine(message)

// TODO 4: Implement MemoryLogger : LoggerBase
//   WriteEntry(string message) → does nothing extra (entries already stored)
//   Additional method: string GetLastEntry()
//     → returns the last entry, or "" if no entries exist

// Stubs so the project compiles:

public abstract class LoggerBase
{
    protected List<string> _entries = new();

    public int EntryCount => throw new NotImplementedException();

    public void Log(string message) => throw new NotImplementedException();

    public void LogError(string message) => throw new NotImplementedException();

    protected abstract void WriteEntry(string message);

    public IReadOnlyList<string> GetEntries() => throw new NotImplementedException();
}

public class ConsoleLogger : LoggerBase
{
    protected override void WriteEntry(string message) => throw new NotImplementedException();
}

public class MemoryLogger : LoggerBase
{
    protected override void WriteEntry(string message) { /* intentionally empty */ }

    public string GetLastEntry() => throw new NotImplementedException();
}
