/*
 * Course:   Introduction to Object-Oriented Programming with C#
 * Week:     7 — Exception Handling · Best Practices
 * Author:   Dr. Mohamad AOUDE
 *
 * Purpose:  Reference solution for generic queue with exception handling best practices.
 *           Students compare their use of throw vs try-pattern against this model.
 */
namespace OopCsharp.Week7.Part3_BestPractices.Solutions;

public class SafeQueue<T>
{
    private readonly Queue<T> _queue = new();

    public int  Count   => _queue.Count;
    public bool IsEmpty => _queue.Count == 0;

    public void Enqueue(T item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        _queue.Enqueue(item);
    }

    public T Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("Queue is empty.");
        return _queue.Dequeue();
    }

    public bool TryDequeue(out T? item)
    {
        if (_queue.Count == 0)
        {
            item = default;
            return false;
        }
        item = _queue.Dequeue();
        return true;
    }

    public void Clear() => _queue.Clear();
}
