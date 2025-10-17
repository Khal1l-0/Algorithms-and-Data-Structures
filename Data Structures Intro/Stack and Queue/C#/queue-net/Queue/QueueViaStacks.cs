using System;
using System.Collections.Generic;

namespace Queue;

/// <summary>
/// Implementation of a queue using two stacks (FIFO via LIFO).
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
public class QueueViaStacks<T> : IFifo<T>
{
    private readonly Stack<T> _stack1 = new(); // для Enqueue
    private readonly Stack<T> _stack2 = new(); // для Dequeue/Peek

    /// <summary>
    /// Gets a value indicating whether the queue is empty.
    /// </summary>
    public bool IsEmpty => _stack1.Count == 0 && _stack2.Count == 0;

    /// <summary>
    /// Gets the number of elements contained in the queue.
    /// </summary>
    public int Count => _stack1.Count + _stack2.Count;

    /// <summary>
    /// Adds an element to the end of the queue.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when element is null.</exception>
    public void Enqueue(T element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        _stack1.Push(element);
    }

    /// <summary>
    /// Removes and returns the element at the beginning of the queue.
    /// </summary>
    /// <returns>The dequeued element.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    public T Dequeue()
    {
        MoveIfNeeded();

        if (_stack2.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _stack2.Pop();
    }

    /// <summary>
    /// Returns the element at the beginning of the queue without removing it.
    /// </summary>
    /// <returns>The first element.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    public T Peek()
    {
        MoveIfNeeded();

        if (_stack2.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return _stack2.Peek();
    }

    /// <summary>
    /// Moves elements from stack1 to stack2 if stack2 is empty.
    /// </summary>
    private void MoveIfNeeded()
    {
        if (_stack2.Count == 0)
        {
            while (_stack1.Count > 0)
            {
                _stack2.Push(_stack1.Pop());
            }
        }
    }
}