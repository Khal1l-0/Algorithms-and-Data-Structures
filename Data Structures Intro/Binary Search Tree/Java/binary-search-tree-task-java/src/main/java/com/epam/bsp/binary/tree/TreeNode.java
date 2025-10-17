package com.epam.bsp.binary.tree;

public class TreeNode<E extends Comparable<E>> {

    /**
     * Data part
     */
    private E element;
    /**
     * Links to the left and right nodes
     */
    private TreeNode<E> left;
    private TreeNode<E> right;

    public TreeNode(E element, TreeNode<E> left, TreeNode<E> right) {
        this.element = element;
        this.left = left;
        this.right = right;
    }

    public TreeNode(E element) {
        this(element, null, null);
    }

    public TreeNode(E element, TreeNode<E> left) {
        this(element, left, null);
    }

    public E getElement() {
        return element;
    }

    public TreeNode<E> getLeft() {
        return left;
    }

    public TreeNode<E> getRight() {
        return right;
    }

    public void setElement(E element) {
        this.element = element;
    }

    public void setLeft(TreeNode<E> left) {
        this.left = left;
    }

    public void setRight(TreeNode<E> right) {
        this.right = right;
    }

    /**
     * Checks whether the tree is height-balanced.
     * A tree is balanced if the height difference of left and right subtrees
     * of every node is not more than 1.
     */
    public boolean isBalanced() {
        return checkBalance(this) != -1;
    }

    private int checkBalance(TreeNode<E> node) {
        if (node == null) return 0;
        int leftHeight = checkBalance(node.left);
        if (leftHeight == -1) return -1;
        int rightHeight = checkBalance(node.right);
        if (rightHeight == -1) return -1;

        if (Math.abs(leftHeight - rightHeight) > 1) return -1;
        return Math.max(leftHeight, rightHeight) + 1;
    }

    /**
     * Checks whether the tree is a valid Binary Search Tree.
     */
    public boolean isBinarySearchTree() {
        return isBST(this, null, null);
    }

    private boolean isBST(TreeNode<E> node, E min, E max) {
        if (node == null) return true;

        E val = node.getElement();
        if ((min != null && val.compareTo(min) <= 0) ||
            (max != null && val.compareTo(max) >= 0)) {
            return false;
        }

        return isBST(node.left, min, val) && isBST(node.right, val, max);
    }

    /**
     * Searches for an element in the BST and returns the node containing it.
     */
    public TreeNode<E> searchInBst(E element) {
        if (this == null) return null;
        int cmp = element.compareTo(this.element);

        if (cmp == 0) return this;
        else if (cmp < 0 && left != null) return left.searchInBst(element);
        else if (cmp > 0 && right != null) return right.searchInBst(element);
        return null;
    }

    /**
     * Inserts a new element into the BST and returns the root of the tree.
     */
    public TreeNode<E> insertInBst(E element) {
        if (element.compareTo(this.element) < 0) {
            if (this.left == null) {
                this.left = new TreeNode<>(element);
            } else {
                this.left.insertInBst(element);
            }
        } else if (element.compareTo(this.element) > 0) {
            if (this.right == null) {
                this.right = new TreeNode<>(element);
            } else {
                this.right.insertInBst(element);
            }
        }
        return this;
    }
}
