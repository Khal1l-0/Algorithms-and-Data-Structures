using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomLinkedList
{
    /// <summary>
    /// Basic data structure for custom Linked List representation
    /// </summary>
    public class CustomLinkedList<T>
    {
        /// <summary>
        /// Internal class for representing a linked list node
        /// </summary>
        protected class CustomListNode
        {
            public T Element { get; set; }
            public CustomListNode? Next { get; set; }

            public CustomListNode(T element, CustomListNode? next)
            {
                Element = element;
                Next = next;
            }
        }

        /// <summary>
        /// Linked List head
        /// </summary>
        protected CustomListNode? Head { get; set; }

        /// <summary>
        /// Constructor from a list instance.
        /// </summary>
        /// <param name="elements">Elements that should be inserted into the result linked list.</param>
        public CustomLinkedList(IEnumerable<T> elements)
        {
            Head = null;
            CustomListNode? current = null;
            foreach (var element in elements)
            {
                var newNode = new CustomListNode(element, null);
                if (Head == null)
                {
                    Head = newNode;
                    current = Head;
                }
                else
                {
                    current!.Next = newNode;
                    current = newNode;
                }
            }
        }

        /// <summary>
        /// Removes all nodes containing the given element
        /// </summary>
        public CustomLinkedList<T> RemoveNodes(T element)
        {
            // Remove matching nodes from the head first
            while (Head != null && EqualityComparer<T>.Default.Equals(Head.Element, element))
            {
                Head = Head.Next;
            }

            var current = Head;
            while (current != null && current.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Next.Element, element))
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }
            return this;
        }

        /// <summary>
        /// Reverses the linked list in-place
        /// </summary>
        public CustomLinkedList<T> Reverse()
        {
            CustomListNode? prev = null;
            var current = Head;

            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            Head = prev;
            return this;
        }

        /// <summary>
        /// Returns the list starting from the right middle node.
        /// If even number of nodes, choose the second middle.
        /// </summary>
        public CustomLinkedList<T> GetRightMiddle()
        {
            if (Head == null)
                return new CustomLinkedList<T>(Enumerable.Empty<T>());

            var slow = Head;
            var fast = Head;

            // fast moves twice as fast as slow
            while (fast != null && fast.Next != null)
            {
                slow = slow!.Next;
                fast = fast.Next.Next;
            }

            // Build new linked list from slow to the end
            var resultElements = new List<T>();
            var current = slow;
            while (current != null)
            {
                resultElements.Add(current.Element);
                current = current.Next;
            }

            return new CustomLinkedList<T>(resultElements);
        }

        /// <summary>
        /// Returns whether `this` instance is identical to `list` one, order of elements matters
        /// </summary>
        public bool Check(IEnumerable<T> elements)
        {
            if (Head == null)
                return !elements.Any();

            var curr = Head;
            foreach (var element in elements)
            {
                if (curr == null)
                    return false;
                if (!EqualityComparer<T>.Default.Equals(element, curr.Element))
                    return false;
                curr = curr.Next;
            }
            return curr == null;
        }
    }
}