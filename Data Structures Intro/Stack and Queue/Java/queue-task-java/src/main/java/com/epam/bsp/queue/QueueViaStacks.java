package com.epam.bsp.queue;

import java.util.NoSuchElementException;

public class QueueViaStacks<E> implements Fifo<E> {
    private final Lifo<E> stack1 = new LifoImpl<>();
    private final Lifo<E> stack2 = new LifoImpl<>();

    @Override
    public boolean empty() {
        return stack1.empty() && stack2.empty();
    }

    @Override
    public int size() {
        return stack1.size() + stack2.size();
    }

    @Override
    public E push(E e) {
        stack1.push(e);
        return e;
    }

    private void moveIfNeeded() {
        if (stack2.empty()) {
            while (!stack1.empty()) {
                stack2.push(stack1.pop());
            }
        }
    }

    @Override
    public E pop() {
        if (empty()) throw new NoSuchElementException("Queue is empty");
        moveIfNeeded();
        return stack2.pop();
    }

    @Override
    public E peek() {
        if (empty()) throw new NoSuchElementException("Queue is empty");
        moveIfNeeded();
        return stack2.peek();
    }
}
