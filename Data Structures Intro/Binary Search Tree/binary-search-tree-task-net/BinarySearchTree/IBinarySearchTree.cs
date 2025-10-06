namespace BinarySearchTreeTask;

/// <summary>
/// Interface for binary search tree operations
/// </summary>
/// <typeparam name="T">The type of elements stored in the tree, must implement IComparable</typeparam>
public interface IBinarySearchTree<T> where T : IComparable<T>
{
    /// <summary>
    /// Checks whether the binary tree is height-balanced.
    /// A height-balanced binary tree is defined as a binary tree in which 
    /// the left and right subtrees of every node differ in height by no more than 1.
    /// </summary>
    /// <returns>True if the tree is height-balanced, false otherwise</returns>
    bool IsBalanced();

    /// <summary>
    /// Checks whether the binary tree is a valid BST.
    /// A valid BST is defined as follows:
    /// - The left subtree of a node contains only nodes with keys less than the node's key.
    /// - The right subtree of a node contains only nodes with keys greater than the node's key.
    /// - Both the left and right subtrees must also be BSTs.
    /// </summary>
    /// <returns>True if the tree is a valid BST, false otherwise</returns>
    bool IsBinarySearchTree();

    /// <summary>
    /// Searches for an element in the BST.
    /// </summary>
    /// <param name="element">The element to search for</param>
    /// <returns>The node containing the element, or null if not found</returns>
    /// <exception cref="ArgumentNullException">Thrown when element is null</exception>
    TreeNode<T>? Search(T element);

    /// <summary>
    /// Inserts an element into the BST.
    /// </summary>
    /// <param name="element">The element to insert</param>
    /// <returns>The root of the BST after insertion</returns>
    /// <exception cref="ArgumentNullException">Thrown when element is null</exception>
    TreeNode<T> Insert(T element);
} 