package com.epam.bsp.queue;

import java.util.LinkedList;
import java.util.NoSuchElementException;

public class FifoImpl<E> implements Fifo<E> {
    private final LinkedList<E> list = new LinkedList<>();

    @Override
    public boolean empty() {
        return list.isEmpty();
    }

    @Override
    public int size() {
        return list.size();
    }

    @Override
    public E push(E e) {
        list.addLast(e);
        return e;
    }

    @Override
    public E pop() {
        if (empty()) throw new NoSuchElementException("Queue is empty");
        return list.removeFirst();
    }

    @Override
    public E peek() {
        if (empty()) throw new NoSuchElementException("Queue is empty");
        return list.getFirst();
    }
}
