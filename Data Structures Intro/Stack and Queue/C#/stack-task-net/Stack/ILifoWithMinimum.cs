using System;

namespace Stack;

/// <summary>
/// Represents a last-in-first-out (LIFO) collection of comparable objects that supports retrieving the minimum element.
/// </summary>
/// <typeparam name="T">The type of elements in the stack that implements <see cref="IComparable{T}"/>.</typeparam>
public interface ILifoWithMinimum<T> : IStack<T> where T : IComparable<T>
{
    /// <summary>
    /// Attempts to get the minimum element in the stack.
    /// </summary>
    /// <remarks>
    /// Time complexity: O(1)
    /// </remarks>
    /// <param name="minimum">When this method returns, contains the minimum element if the stack is not empty; otherwise, the default value for type <typeparamref name="T"/>.</param>
    /// <returns><see langword="true"/> if the stack is not empty and a minimum element was found; otherwise, <see langword="false"/>.</returns>
    bool TryGetMinimum(out T minimum);
} 