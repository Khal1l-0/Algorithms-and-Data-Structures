namespace Queue;

/// <summary>
/// Represents a Last-In-First-Out (LIFO) stack data structure.
/// Elements are added and removed from the top of the stack.
/// </summary>
/// <typeparam name="T">The type of elements in the stack.</typeparam>
/// <remarks>
/// This interface provides the standard stack operations with O(1) time complexity
/// for push, pop, and peek operations. The stack follows the LIFO principle
/// where the last element added is the first one to be removed.
/// </remarks>
/// <example>
/// <code>
/// var stack = new LifoImpl&lt;int&gt;();
/// stack.Push(1);
/// stack.Push(2);
/// stack.Push(3);
/// 
/// Console.WriteLine(stack.Pop());  // Output: 3
/// Console.WriteLine(stack.Peek()); // Output: 2
/// Console.WriteLine(stack.Count);  // Output: 2
/// </code>
/// </example>
public interface ILifo<T>
{
    /// <summary>
    /// Gets a value indicating whether the stack is empty.
    /// </summary>
    /// <value><c>true</c> if the stack contains no elements; otherwise, <c>false</c>.</value>
    /// <remarks>
    /// This property has O(1) time complexity.
    /// </remarks>
    bool IsEmpty { get; }

    /// <summary>
    /// Gets the number of elements contained in the stack.
    /// </summary>
    /// <value>The number of elements in the stack.</value>
    /// <remarks>
    /// This property has O(1) time complexity.
    /// </remarks>
    int Count { get; }

    /// <summary>
    /// Adds an element to the top of the stack.
    /// </summary>
    /// <param name="element">The element to add to the stack.</param>
    /// <returns>The element that was added to the stack.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <c>null</c>.</exception>
    /// <remarks>
    /// This operation has O(1) time complexity.
    /// The element becomes the top element in the stack and will be the first one removed.
    /// </remarks>
    T Push(T element);

    /// <summary>
    /// Removes and returns the element at the top of the stack.
    /// </summary>
    /// <returns>The element that was removed from the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
    /// <remarks>
    /// This operation has O(1) time complexity.
    /// The element returned is the one that was most recently added to the stack (LIFO principle).
    /// </remarks>
    T Pop();

    /// <summary>
    /// Returns the element at the top of the stack without removing it.
    /// </summary>
    /// <returns>The element at the top of the stack.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the stack is empty.</exception>
    /// <remarks>
    /// This operation has O(1) time complexity.
    /// The element returned is the one that will be removed next by a call to <see cref="Pop"/>.
    /// </remarks>
    T Peek();
} 