package com.epam.bsp.stack;

/**
 * Default interface for Stack data structure
 * @param `<E>` the type of elements in this data structure
 */
public interface Lifo<E> {
    /**
     * Returns true if the stack is empty.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return whether the stack is empty.
     */
    boolean empty();

    /**
     * Returns the number of elements within the stack.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return the number of elements within the stack.
     */
    int size();

    /**
     * Adds a given element to the top of the stack.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @param e element to be added
     * @return the added element.
     */
    E push(E e);

    /**
     * Returns the top element and removes it.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return the top element
     * @throws java.util.NoSuchElementException if the stack is empty.
     */
    E pop();

    /**
     * Returns the top element.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return the top element
     * @throws java.util.NoSuchElementException if the stack is empty.
     */
    E peek();

}
