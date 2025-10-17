using System;
using System.Collections.Generic;

namespace Queue;

/// <summary>
/// Implementation of a First-In-First-Out (FIFO) queue using <see cref="Queue{T}"/>.
/// Provides O(1) complexity for all operations.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public class FifoImpl<T> : IFifo<T>
{
    private readonly Queue<T> _queue = new();

    /// <summary>
    /// Gets a value indicating whether the queue is empty.
    /// </summary>
    public bool IsEmpty => _queue.Count == 0;

    /// <summary>
    /// Gets the number of elements contained in the queue.
    /// </summary>
    public int Count => _queue.Count;

    /// <summary>
    /// Adds an element to the end of the queue.
    /// </summary>
    /// <param name="element">The element to add to the queue.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <c>null</c>.</exception>
    public void Enqueue(T element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        _queue.Enqueue(element);
    }

    /// <summary>
    /// Removes and returns the element at the beginning of the queue.
    /// </summary>
    /// <returns>The element that was removed from the beginning of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    public T Dequeue()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Queue is empty.");

        return _queue.Dequeue();
    }

    /// <summary>
    /// Returns the element at the beginning of the queue without removing it.
    /// </summary>
    /// <returns>The element at the beginning of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Queue is empty.");

        return _queue.Peek();
    }
}