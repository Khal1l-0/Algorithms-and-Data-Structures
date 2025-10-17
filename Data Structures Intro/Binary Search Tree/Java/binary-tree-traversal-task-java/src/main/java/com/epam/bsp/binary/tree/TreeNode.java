package com.epam.bsp.binary.tree;

import java.util.*;

public class TreeNode<E> {

    private E element;
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

    /**
     * Checks whether two given binary trees are the same.
     */
    public boolean check(TreeNode<E> treeNode) {
        if (treeNode == null) return false;
        return isSame(this, treeNode);
    }

    private boolean isSame(TreeNode<E> t1, TreeNode<E> t2) {
        if (t1 == null && t2 == null) return true;
        if (t1 == null || t2 == null) return false;
        if (!(Objects.equals(t1.element, t2.element))) return false;
        return isSame(t1.left, t2.left) && isSame(t1.right, t2.right);
    }

    /**
     * Inorder traversal: left → root → right
     */
    public List<E> getInorderTraversal() {
        List<E> res = new ArrayList<>();
        inorder(this, res);
        return res;
    }

    private void inorder(TreeNode<E> node, List<E> res) {
        if (node == null) return;
        inorder(node.left, res);
        res.add(node.element);
        inorder(node.right, res);
    }

    /**
     * Postorder traversal: left → right → root
     */
    public List<E> getPostorderTraversal() {
        List<E> res = new ArrayList<>();
        postorder(this, res);
        return res;
    }

    private void postorder(TreeNode<E> node, List<E> res) {
        if (node == null) return;
        postorder(node.left, res);
        postorder(node.right, res);
        res.add(node.element);
    }

    /**
     * Preorder traversal: root → left → right
     */
    public List<E> getPreorderTraversal() {
        List<E> res = new ArrayList<>();
        preorder(this, res);
        return res;
    }

    private void preorder(TreeNode<E> node, List<E> res) {
        if (node == null) return;
        res.add(node.element);
        preorder(node.left, res);
        preorder(node.right, res);
    }

    /**
     * Level order traversal (BFS)
     */
    public List<E> getLevelOrderTraversal() {
        List<E> res = new ArrayList<>();
        if (this == null) return res;

        Queue<TreeNode<E>> queue = new LinkedList<>();
        queue.add(this);

        while (!queue.isEmpty()) {
            TreeNode<E> node = queue.poll();
            if (node == null) continue;
            res.add(node.element);
            if (node.left != null) queue.add(node.left);
            if (node.right != null) queue.add(node.right);
        }

        return res;
    }
}
