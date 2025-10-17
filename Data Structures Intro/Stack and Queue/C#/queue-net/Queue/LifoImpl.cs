using System;
using System.Collections.Generic;

namespace Queue;

/// <summary>
/// Implementation of a Last-In-First-Out (LIFO) stack using <see cref="LinkedList{T}"/>.
/// Provides O(1) complexity for all operations.
/// </summary>
/// <typeparam name="T">The type of elements in the stack.</typeparam>
public class LifoImpl<T> : ILifo<T>
{
    private readonly LinkedList<T> _list = new();

    /// <summary>
    /// Gets a value indicating whether the stack is empty.
    /// </summary>
    public bool IsEmpty => _list.Count == 0;

    /// <summary>
    /// Gets the number of elements contained in the stack.
    /// </summary>
    public int Count => _list.Count;

    /// <summary>
    /// Adds an element to the top of the stack.
    /// </summary>
    /// <param name="element">The element to add to the stack.</param>
    /// <returns>The element that was added to the stack.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <c>null</c>.</exception>
    public T Push(T element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        _list.AddFirst(element);
        return element;
    }

    /// <summary>
    /// Removes and returns the element at the top of the stack.
    /// </summary>
    /// <returns>The element that was removed from the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        T value = _list.First!.Value;
        _list.RemoveFirst();
        return value;
    }

    /// <summary>
    /// Returns the element at the top of the stack without removing it.
    /// </summary>
    /// <returns>The element at the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _list.First!.Value;
    }
}