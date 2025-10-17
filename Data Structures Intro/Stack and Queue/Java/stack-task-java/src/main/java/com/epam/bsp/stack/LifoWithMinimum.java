package com.epam.bsp.stack;

import java.util.Optional;

/**
 * Extended `Lifo` interface that supports `getMinimum` operation.
 * @param `<E>` the type of elements in this list that implements the interface `Comparable<E>`
 */
public interface LifoWithMinimum<E extends Comparable<E>> extends Lifo<E> {

    /**
     * Returns the minimum element in the stack.
     * NOTE: O(1) complexity is expected for this operation.
     *
     * @return the minimum element in the stack.
     */
    Optional<E> getMinimum();

}
