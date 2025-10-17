package com.epam.bsp.stack;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;

public class LifoWithMinimumImpl<E extends Comparable<E>> implements LifoWithMinimum<E> {

    private final List<E> stack = new ArrayList<>();
    private final List<E> minStack = new ArrayList<>();

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
        if (minStack.isEmpty() || e.compareTo(minStack.get(minStack.size() - 1)) <= 0) {
            minStack.add(e);
        }
        return e;
    }

    @Override
    public E pop() {
        if (stack.isEmpty()) {
            throw new NoSuchElementException("Stack is empty");
        }
        E removed = stack.remove(stack.size() - 1);
        if (removed.equals(minStack.get(minStack.size() - 1))) {
            minStack.remove(minStack.size() - 1);
        }
        return removed;
    }

    @Override
    public E peek() {
        if (stack.isEmpty()) {
            throw new NoSuchElementException("Stack is empty");
        }
        return stack.get(stack.size() - 1);
    }

    @Override
    public Optional<E> getMinimum() {
        if (minStack.isEmpty()) return Optional.empty();
        return Optional.of(minStack.get(minStack.size() - 1));
    }
}
