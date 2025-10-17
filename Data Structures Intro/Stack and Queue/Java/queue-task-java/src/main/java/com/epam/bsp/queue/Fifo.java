package com.epam.bsp.queue;

/**
 * Default interface for Queue data structure
 * @param <E> the type of elements in this data structure
 */
public interface Fifo<E> {

    /**
     * Returns true if the queue is empty.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return whether the queue is empty.
     */
    boolean empty();

    /**
     * Returns the number of elements within the queue.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return the number of elements within the queue.
     */
    int size();

    /**
     * Adds a given element to the queue's tail.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @param e element to be added
     * @return the added element.
     */
    E push(E e);

    /**
     * Returns the head element and removes it.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return the head element
     * @throws java.util.NoSuchElementException if the queue is empty.
     */
    E pop();

    /**
     * Returns the head element.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return the head element
     * @throws java.util.NoSuchElementException if the queue is empty.
     */
    E peek();
}
