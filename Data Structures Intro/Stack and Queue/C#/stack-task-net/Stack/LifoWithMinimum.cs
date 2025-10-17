using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack;

/// <summary>
/// Represents a last-in, first-out (LIFO) stack that tracks the minimum element.
/// </summary>
/// <typeparam name="T">The type of elements in the stack, which must be comparable.</typeparam>
public sealed class LifoWithMinimum<T> : IStackWithMinimum<T> where T : IComparable<T>
{
    private readonly List<T> _items;
    private readonly List<T> _minimums;

    public LifoWithMinimum()
    {
        _items = new List<T>();
        _minimums = new List<T>();
    }

    /// <inheritdoc />
    public bool IsEmpty => _items.Count == 0;

    /// <inheritdoc />
    public int Count => _items.Count;

    /// <inheritdoc />
    public void Push(T element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        _items.Add(element);

        if (_minimums.Count == 0 || element.CompareTo(_minimums[_minimums.Count - 1]) <= 0)
            _minimums.Add(element);
        else
            _minimums.Add(_minimums[_minimums.Count - 1]); // повторяем предыдущий минимум
    }

    /// <inheritdoc />
    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        var lastIndex = _items.Count - 1;
        var value = _items[lastIndex];

        _items.RemoveAt(lastIndex);
        _minimums.RemoveAt(lastIndex);

        return value;
    }

    /// <inheritdoc />
    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _items[_items.Count - 1];
    }

    /// <inheritdoc />
    public bool TryGetMinimum(out T minimum)
    {
        if (IsEmpty)
        {
            minimum = default!;
            return false;
        }

        minimum = _minimums[_minimums.Count - 1];
        return true;
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        // возвращаем элементы в LIFO порядке
        for (int i = _items.Count - 1; i >= 0; i--)
            yield return _items[i];
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}