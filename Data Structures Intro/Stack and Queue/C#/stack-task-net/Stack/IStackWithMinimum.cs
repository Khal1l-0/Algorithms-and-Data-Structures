namespace Stack;

/// <summary>
/// Represents a stack that supports retrieving the minimum element.
/// </summary>
/// <typeparam name="T">The type of elements in the stack, which must be comparable.</typeparam>
public interface IStackWithMinimum<T> : IStack<T> where T : IComparable<T>
{
    /// <summary>
    /// Attempts to get the minimum element in the stack.
    /// </summary>
    /// <param name="minimum">When this method returns, contains the minimum element if the stack is not empty; otherwise, the default value for type T.</param>
    /// <returns>true if the stack is not empty and a minimum element was found; otherwise, false.</returns>
    bool TryGetMinimum(out T minimum);
} 