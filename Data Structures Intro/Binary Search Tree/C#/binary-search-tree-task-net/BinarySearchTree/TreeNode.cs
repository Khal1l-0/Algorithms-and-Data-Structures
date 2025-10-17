using System;

namespace BinarySearchTreeTask;

/// <summary>
/// Represents a node in a binary tree with generic type support
/// </summary>
/// <typeparam name="T">The type of the element stored in the node, must implement IComparable</typeparam>
public class TreeNode<T> : IBinarySearchTree<T> where T : IComparable<T>
{
    private T element;
    private TreeNode<T>? left;
    private TreeNode<T>? right;

    public TreeNode(T element, TreeNode<T>? left, TreeNode<T>? right)
    {
        Element = element ?? throw new ArgumentNullException(nameof(element));
        Left = left;
        Right = right;
    }

    public TreeNode(T element) : this(element, null, null) { }

    public TreeNode(T element, TreeNode<T>? left) : this(element, left, null) { }

    public T Element
    {
        get => element;
        private set => element = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TreeNode<T>? Left
    {
        get => left;
        private set => left = value;
    }

    public TreeNode<T>? Right
    {
        get => right;
        private set => right = value;
    }

    public bool IsBalanced()
    {
        return CheckBalance(this).isBalanced;
    }

    private (bool isBalanced, int height) CheckBalance(TreeNode<T>? node)
    {
        if (node == null)
            return (true, 0);

        var leftResult = CheckBalance(node.Left);
        if (!leftResult.isBalanced)
            return (false, 0);

        var rightResult = CheckBalance(node.Right);
        if (!rightResult.isBalanced)
            return (false, 0);

        bool balanced = Math.Abs(leftResult.height - rightResult.height) <= 1;
        int height = Math.Max(leftResult.height, rightResult.height) + 1;
        return (balanced, height);
    }

    public bool IsBinarySearchTree()
    {
        return ValidateBst(this, default, default, false, false);
    }

    private bool ValidateBst(TreeNode<T>? node, T? min, T? max, bool hasMin, bool hasMax)
    {
        if (node == null)
            return true;

        // node.Element must be > min (strictly greater)
        if (hasMin && node.Element.CompareTo(min!) < 0)
            return false;

        // node.Element must be <= max (allow duplicates on right)
        if (hasMax && node.Element.CompareTo(max!) > 0)
            return false;

        return ValidateBst(node.Left, min, node.Element, hasMin, true)
            && ValidateBst(node.Right, node.Element, max, true, hasMax);
    }

    public TreeNode<T>? Search(T element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        TreeNode<T>? current = this;
        while (current != null)
        {
            int cmp = element.CompareTo(current.Element);
            if (cmp == 0)
                return current;
            else if (cmp < 0)
                current = current.Left;
            else
                current = current.Right;
        }
        return null;
    }

    public TreeNode<T>? SearchInBst(T element) => Search(element);

    public TreeNode<T> Insert(T element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        InsertRecursive(this, element);
        return this;
    }

    private TreeNode<T> InsertRecursive(TreeNode<T> node, T element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));

        int cmp = element.CompareTo(node.Element);

        if (cmp < 0)
        {
            node.Left = node.Left == null ? new TreeNode<T>(element) : InsertRecursive(node.Left, element);
        }
        else if (cmp > 0)
        {
            node.Right = node.Right == null ? new TreeNode<T>(element) : InsertRecursive(node.Right, element);
        }
        else
        {
            return node;
        }

        return node;
    }

    public TreeNode<T> InsertInBst(T element) => Insert(element);
}