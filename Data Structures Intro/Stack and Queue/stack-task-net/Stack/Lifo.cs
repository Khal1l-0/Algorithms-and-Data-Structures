using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    /// <summary>
    /// Represents a last-in, first-out (LIFO) stack of elements implemented using a list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public sealed class Lifo<T> : IStack<T>
    {
        private readonly List<T> _items;

        public Lifo()
        {
            _items = new List<T>();
        }

        public bool IsEmpty => _items.Count == 0;

        public int Count => _items.Count;

        public void Push(T element)
        {
            if (element == null && default(T) == null)
                throw new ArgumentNullException(nameof(element));

            _items.Add(element);
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            int lastIndex = _items.Count - 1;
            T value = _items[lastIndex];
            _items.RemoveAt(lastIndex);
            return value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            return _items[_items.Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            // Итератор возвращает элементы в LIFO порядке
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}