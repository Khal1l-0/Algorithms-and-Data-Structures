using System;
using System.Collections.Generic;

namespace Stack;

/// <summary>
/// Represents a last-in, first-out (LIFO) stack of elements.
/// </summary>
/// <typeparam name="T">The type of elements in the stack.</typeparam>
public interface IStack<T> : IEnumerable<T>
{
    /// <summary>
    /// Gets a value indicating whether the stack is empty.
    /// </summary>
    /// <value><c>true</c> if the stack is empty; otherwise, <c>false</c>.</value>
    bool IsEmpty { get; }

    /// <summary>
    /// Gets the number of elements contained in the stack.
    /// </summary>
    /// <value>The number of elements in the stack.</value>
    int Count { get; }

    /// <summary>
    /// Inserts an element at the top of the stack.
    /// </summary>
    /// <param name="element">The element to add to the stack.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="element"/> is <c>null</c> and <typeparamref name="T"/> is a reference type.
    /// </exception>
    void Push(T element);

    /// <summary>
    /// Removes and returns the element at the top of the stack.
    /// </summary>
    /// <returns>The element removed from the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the stack is empty.
    /// </exception>
    T Pop();

    /// <summary>
    /// Returns the element at the top of the stack without removing it.
    /// </summary>
    /// <returns>The element at the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the stack is empty.
    /// </exception>
    T Peek();
}