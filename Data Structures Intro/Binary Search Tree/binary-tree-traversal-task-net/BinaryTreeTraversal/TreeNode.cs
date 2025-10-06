using System;
using System.Collections.Generic;

namespace BinaryTreeTraversal
{
    /// <summary>
    /// Represents a node in a binary tree.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the node.</typeparam>
    public class TreeNode<T>
    {
        private T element;
        private TreeNode<T>? left;
        private TreeNode<T>? right;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode{T}"/> class with a value and optional children.
        /// </summary>
        /// <param name="element">The value to store in this node.</param>
        /// <param name="left">The left child node (or null).</param>
        /// <param name="right">The right child node (or null).</param>
        public TreeNode(T element, TreeNode<T>? left, TreeNode<T>? right)
        {
            this.element = element;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode{T}"/> class with a value.
        /// </summary>
        /// <param name="element">The value to store in this node.</param>
        public TreeNode(T element) : this(element, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNode{T}"/> class with a value and left child.
        /// </summary>
        /// <param name="element">The value to store in this node.</param>
        /// <param name="left">The left child node (or null).</param>
        public TreeNode(T element, TreeNode<T>? left) : this(element, left, null) { }

        /// <summary>
        /// Gets the data element stored in this node.
        /// </summary>
        public T Element => element;

        /// <summary>
        /// Gets the left child node.
        /// </summary>
        public TreeNode<T>? Left => left;

        /// <summary>
        /// Gets the right child node.
        /// </summary>
        public TreeNode<T>? Right => right;

        /// <summary>
        /// Checks whether this tree is structurally and semantically identical to another tree.
        /// </summary>
        /// <param name="treeNode">Root node of the second given tree.</param>
        /// <returns>True if the trees are identical; otherwise false.</returns>
        public bool Check(TreeNode<T>? treeNode)
        {
            if (treeNode == null) return false; // comparing non-null (this) to null -> false

            if (!EqualityComparer<T>.Default.Equals(this.element, treeNode.element))
                return false;

            bool leftEqual = (this.left == null && treeNode.left == null)
                             || (this.left != null && this.left.Check(treeNode.left));
            bool rightEqual = (this.right == null && treeNode.right == null)
                              || (this.right != null && this.right.Check(treeNode.right));

            return leftEqual && rightEqual;
        }

        /// <summary>
        /// Returns elements of this binary tree using inorder traversal (Left, Root, Right).
        /// </summary>
        /// <returns>List with elements in inorder order.</returns>
        public List<T> GetInorderTraversal()
        {
            var result = new List<T>();
            void Traverse(TreeNode<T>? node)
            {
                if (node == null) return;
                Traverse(node.left);
                result.Add(node.element);
                Traverse(node.right);
            }
            Traverse(this);
            return result;
        }

        /// <summary>
        /// Returns elements of this binary tree using postorder traversal (Left, Right, Root).
        /// </summary>
        /// <returns>List with elements in postorder order.</returns>
        public List<T> GetPostorderTraversal()
        {
            var result = new List<T>();
            void Traverse(TreeNode<T>? node)
            {
                if (node == null) return;
                Traverse(node.left);
                Traverse(node.right);
                result.Add(node.element);
            }
            Traverse(this);
            return result;
        }

        /// <summary>
        /// Returns elements of this binary tree using preorder traversal (Root, Left, Right).
        /// </summary>
        /// <returns>List with elements in preorder order.</returns>
        public List<T> GetPreorderTraversal()
        {
            var result = new List<T>();
            void Traverse(TreeNode<T>? node)
            {
                if (node == null) return;
                result.Add(node.element);
                Traverse(node.left);
                Traverse(node.right);
            }
            Traverse(this);
            return result;
        }

        /// <summary>
        /// Returns elements of this binary tree using level-order traversal (breadth-first).
        /// </summary>
        /// <returns>List with elements in level-order.</returns>
        public List<T> GetLevelOrderTraversal()
        {
            var result = new List<T>();
            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current.element);
                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }

            return result;
        }
    }
}