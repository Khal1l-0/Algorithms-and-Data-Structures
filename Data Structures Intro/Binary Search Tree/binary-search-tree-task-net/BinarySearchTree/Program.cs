using BinarySearchTreeTask;

namespace BinarySearchTreeTask;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Binary Search Tree - .NET Implementation");
        Console.WriteLine("=========================================");
        
        // Example 1: Create a simple BST using interface
        Console.WriteLine("\nExample 1: Simple BST using Interface");
        IBinarySearchTree<int> root = new TreeNode<int>(10);
        root = root.Insert(5);
        root = root.Insert(15);
        root = root.Insert(3);
        root = root.Insert(7);
        
        Console.WriteLine($"Is Balanced: {root.IsBalanced()}");
        Console.WriteLine($"Is BST: {root.IsBinarySearchTree()}");
        
        // Example 2: Search for elements using interface
        Console.WriteLine("\nExample 2: Search Operations using Interface");
        var searchResult = root.Search(7);
        Console.WriteLine($"Search for 7: {(searchResult != null ? $"Found {searchResult.Element}" : "Not found")}");
        
        searchResult = root.Search(20);
        Console.WriteLine($"Search for 20: {(searchResult != null ? $"Found {searchResult.Element}" : "Not found")}");
        
        // Example 3: Unbalanced tree
        Console.WriteLine("\nExample 3: Unbalanced Tree");
        var unbalancedTree = new TreeNode<int>(1);
        unbalancedTree = unbalancedTree.InsertInBst(2);
        unbalancedTree = unbalancedTree.InsertInBst(3);
        unbalancedTree = unbalancedTree.InsertInBst(4);
        unbalancedTree = unbalancedTree.InsertInBst(5);
        
        Console.WriteLine($"Is Balanced: {unbalancedTree.IsBalanced()}");
        Console.WriteLine($"Is BST: {unbalancedTree.IsBinarySearchTree()}");
        
        // Example 4: Demonstrate null validation
        Console.WriteLine("\nExample 4: Null Validation");
        try
        {
            var tree = new TreeNode<string>("test");
            tree.Search(null!);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Caught ArgumentNullException: {ex.Message}");
        }
        
        // Example 5: Demonstrate pattern matching in search
        Console.WriteLine("\nExample 5: Pattern Matching Search");
        var patternTree = new TreeNode<int>(10);
        patternTree = patternTree.Insert(5);
        patternTree = patternTree.Insert(15);
        patternTree = patternTree.Insert(3);
        patternTree = patternTree.Insert(7);
        
        var found = patternTree.Search(7);
        Console.WriteLine($"Pattern matching search for 7: {(found != null ? "Found" : "Not found")}");
        
        // Example 6: Demonstrate BST property validation
        Console.WriteLine("\nExample 6: BST Property Validation");
        var validBst = new TreeNode<int>(10);
        validBst = validBst.Insert(5);
        validBst = validBst.Insert(15);
        validBst = validBst.Insert(3);
        validBst = validBst.Insert(7);
        
        Console.WriteLine($"Valid BST structure: {validBst.IsBinarySearchTree()}");
        Console.WriteLine($"Tree height balanced: {validBst.IsBalanced()}");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
} 