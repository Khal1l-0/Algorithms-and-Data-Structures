namespace Queue;

/// <summary>
/// Represents a First-In-First-Out (FIFO) queue data structure.
/// Elements are added to the end of the queue and removed from the front.
/// </summary>
/// <typeparam name="T">The type of elements in the queue.</typeparam>
/// <remarks>
/// This interface provides the standard queue operations with O(1) time complexity
/// for enqueue, dequeue, and peek operations. The queue follows the FIFO principle
/// where the first element added is the first one to be removed.
/// </remarks>
/// <example>
/// <code>
/// var queue = new FifoImpl&lt;int&gt;();
/// queue.Enqueue(1);
/// queue.Enqueue(2);
/// queue.Enqueue(3);
/// 
/// Console.WriteLine(queue.Dequeue()); // Output: 1
/// Console.WriteLine(queue.Peek());    // Output: 2
/// Console.WriteLine(queue.Count);     // Output: 2
/// </code>
/// </example>
public interface IFifo<T>
{
    /// <summary>
    /// Gets a value indicating whether the queue is empty.
    /// </summary>
    /// <value><c>true</c> if the queue contains no elements; otherwise, <c>false</c>.</value>
    /// <remarks>
    /// This property has O(1) time complexity.
    /// </remarks>
    bool IsEmpty { get; }

    /// <summary>
    /// Gets the number of elements contained in the queue.
    /// </summary>
    /// <value>The number of elements in the queue.</value>
    /// <remarks>
    /// This property has O(1) time complexity.
    /// </remarks>
    int Count { get; }

    /// <summary>
    /// Adds an element to the end of the queue.
    /// </summary>
    /// <param name="element">The element to add to the queue.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="element"/> is <c>null</c>.</exception>
    /// <remarks>
    /// This operation has O(1) time complexity.
    /// The element becomes the last element in the queue and will be the last one removed.
    /// </remarks>
    void Enqueue(T element);

    /// <summary>
    /// Removes and returns the element at the beginning of the queue.
    /// </summary>
    /// <returns>The element that was removed from the beginning of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    /// <remarks>
    /// This operation has O(1) time complexity.
    /// The element returned is the one that has been in the queue the longest (FIFO principle).
    /// </remarks>
    T Dequeue();

    /// <summary>
    /// Returns the element at the beginning of the queue without removing it.
    /// </summary>
    /// <returns>The element at the beginning of the queue.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
    /// <remarks>
    /// This operation has O(1) time complexity.
    /// The element returned is the one that will be removed next by a call to <see cref="Dequeue"/>.
    /// </remarks>
    T Peek();
} 