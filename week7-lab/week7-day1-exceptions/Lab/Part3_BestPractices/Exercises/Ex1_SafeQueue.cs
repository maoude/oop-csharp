/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Best Practices
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Student exercise: implement a generic queue with proper exception handling.
 *           Practice: when to throw (Dequeue empty) vs when to return false (TryDequeue),
 *           null validation, and the no-throw (TryXxx) pattern.
 */
namespace OopCsharp.Week7.Part3_BestPractices.Exercises;

// ============================================================
// Exercise 1 — SafeQueue<T>
//
// Implement a generic queue wrapper that demonstrates:
//   • InvalidOperationException for wrong-state operations
//   • The TryXxx pattern (no exceptions for expected failure)
// ============================================================

// TODO 1: Implement class SafeQueue<T>
//
//   Internal storage: a Queue<T> (private field)
//
//   Properties:
//     int  Count   { get; }   — number of items in the queue
//     bool IsEmpty { get; }   — true when Count == 0
//
//   Methods:
//
//   void Enqueue(T item)
//     If item is null (for reference types), throw
//       ArgumentNullException(nameof(item)).
//     Otherwise add item to the queue.
//
//   T Dequeue()
//     If the queue is empty, throw
//       InvalidOperationException("Queue is empty.").
//     Otherwise remove and return the front item.
//
//   bool TryDequeue(out T? item)
//     If the queue is empty, set item = default and return false.
//     Otherwise remove and return the front item via 'item', return true.
//     MUST NOT throw.
//
//   void Clear()
//     Remove all items from the queue.

public class SafeQueue<T>
{
    private readonly Queue<T> _queue = new();

    public int  Count   => throw new NotImplementedException();
    public bool IsEmpty => throw new NotImplementedException();

    public void Enqueue(T item)       => throw new NotImplementedException();
    public T    Dequeue()             => throw new NotImplementedException();
    public bool TryDequeue(out T? item)
    {
        item = default;
        throw new NotImplementedException();
    }
    public void Clear() => throw new NotImplementedException();
}
