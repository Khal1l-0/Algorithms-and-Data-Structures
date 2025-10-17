package com.epam.bsp.linked.list;

import java.util.List;

public class CustomLinkedList<E> {

    protected static class CustomListNode<E> {
        protected E element;
        protected CustomListNode<E> next;

        public CustomListNode(E element, CustomListNode<E> next) {
            this.element = element;
            this.next = next;
        }
    }

    protected CustomListNode<E> head;

    /**
     * Constructor: create linked list from given list of elements
     */
    public CustomLinkedList(List<E> elements) {
        head = null;
        if (elements == null || elements.isEmpty()) return;

        CustomListNode<E> current = null;
        for (E e : elements) {
            CustomListNode<E> newNode = new CustomListNode<>(e, null);
            if (head == null) {
                head = newNode;
                current = head;
            } else {
                current.next = newNode;
                current = newNode;
            }
        }
    }

    /**
     * Removes all nodes that contain given element
     */
    public CustomLinkedList<E> removeNodes(E element) {
        // Remove from head while needed
        while (head != null && (head.element == null ? element == null : head.element.equals(element))) {
            head = head.next;
        }

        CustomListNode<E> current = head;
        while (current != null && current.next != null) {
            if (current.next.element == null ? element == null : current.next.element.equals(element)) {
                current.next = current.next.next;
            } else {
                current = current.next;
            }
        }
        return this;
    }

    /**
     * Reverses the linked list
     */
    public CustomLinkedList<E> reverse() {
        CustomListNode<E> prev = null;
        CustomListNode<E> curr = head;
        while (curr != null) {
            CustomListNode<E> next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        head = prev;
        return this;
    }

    /**
     * Returns the linked list starting from the middle (if two middles, use second)
     */
    public CustomLinkedList<E> getRightMiddle() {
        if (head == null) return this;

        CustomListNode<E> slow = head;
        CustomListNode<E> fast = head;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        CustomLinkedList<E> result = new CustomLinkedList<>(List.of());
        result.head = slow;
        return result;
    }

    /**
     * Checks if linked list elements equal to given list elements (order matters)
     */
    public boolean check(List<E> elements) {
        CustomListNode<E> curr = head;
        for (E element : elements) {
            if (curr == null) return false;
            if (!(element == null ? curr.element == null : element.equals(curr.element))) {
                return false;
            }
            curr = curr.next;
        }
        return curr == null;
    }
}
