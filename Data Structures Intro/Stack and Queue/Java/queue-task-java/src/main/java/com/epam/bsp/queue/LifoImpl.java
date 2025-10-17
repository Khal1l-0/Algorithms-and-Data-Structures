package com.epam.bsp.queue;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

public class LifoImpl<E> implements Lifo<E> {
    private final List<E> stack = new ArrayList<>();

    @Override
    public boolean empty() {
        return stack.isEmpty();
    }

    @Override
    public int size() {
        return stack.size();
    }

    @Override
    public E push(E e) {
        stack.add(e);
        return e;
    }

    @Override
    public E pop() {
        if (empty()) throw new NoSuchElementException("Stack is empty");
        return stack.remove(stack.size() - 1);
    }

    @Override
    public E peek() {
        if (empty()) throw new NoSuchElementException("Stack is empty");
        return stack.get(stack.size() - 1);
    }
}
