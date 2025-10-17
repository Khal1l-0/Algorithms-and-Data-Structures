namespace Queue;

/// <summary>
/// Main program demonstrating the usage of queue and stack implementations,
/// as well as algorithmic solutions.
/// </summary>
static class Program
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    /// <param name="args">Command line arguments (not used).</param>
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("=== Queue and Stack Implementation Examples ===\n");

            // Example 1: FIFO Queue
            Console.WriteLine("1. FIFO Queue Example:");
            DemonstrateFifoQueue();

            // Example 2: LIFO Stack
            Console.WriteLine("\n2. LIFO Stack Example:");
            DemonstrateLifoStack();

            // Example 3: Queue via Two Stacks
            Console.WriteLine("\n3. Queue via Two Stacks Example:");
            DemonstrateQueueViaStacks();

            // Example 4: Number of Islands Algorithm
            Console.WriteLine("\n4. Number of Islands Algorithm Example:");
            DemonstrateIslandsCount();

            // Example 5: Knight Traversal Algorithm
            Console.WriteLine("\n5. Knight Traversal Algorithm Example:");
            DemonstrateKnightMoves();

            Console.WriteLine("\nAll examples completed successfully!");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error: Invalid input - {ex.Message}");
            Console.WriteLine("Please check that all input parameters are not null.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: Invalid argument - {ex.Message}");
            Console.WriteLine("Please check the input data format.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: Invalid operation - {ex.Message}");
            Console.WriteLine("Please check the state of the data structure before performing the operation.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error occurred: {ex.Message}");
            Console.WriteLine("Please contact support if this error persists.");
        }
    }

    /// <summary>
    /// Demonstrates the usage of FIFO queue implementation.
    /// </summary>
    private static void DemonstrateFifoQueue()
    {
        try
        {
            var fifoInt = new FifoImpl<int>();

            Console.WriteLine("  Adding elements: 1, 2, 3, 4, 5");
            fifoInt.Enqueue(1);
            fifoInt.Enqueue(2);
            fifoInt.Enqueue(3);
            fifoInt.Enqueue(4);
            fifoInt.Enqueue(5);

            Console.WriteLine($"  Queue size: {fifoInt.Count}");
            Console.WriteLine($"  Is empty: {fifoInt.IsEmpty}");

            Console.WriteLine("  Removing elements (FIFO order):");
            while (!fifoInt.IsEmpty)
            {
                Console.WriteLine($"    Dequeued: {fifoInt.Dequeue()}");
            }

            Console.WriteLine($"  Final queue size: {fifoInt.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error in FIFO demonstration: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Demonstrates the usage of LIFO stack implementation.
    /// </summary>
    private static void DemonstrateLifoStack()
    {
        try
        {
            var lifoInt = new LifoImpl<int>();

            Console.WriteLine("  Adding elements: 1, 2, 3, 4, 5");
            lifoInt.Push(1);
            lifoInt.Push(2);
            lifoInt.Push(3);
            lifoInt.Push(4);
            lifoInt.Push(5);

            Console.WriteLine($"  Stack size: {lifoInt.Count}");
            Console.WriteLine($"  Is empty: {lifoInt.IsEmpty}");

            Console.WriteLine("  Removing elements (LIFO order):");
            while (!lifoInt.IsEmpty)
            {
                Console.WriteLine($"    Popped: {lifoInt.Pop()}");
            }

            Console.WriteLine($"  Final stack size: {lifoInt.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error in LIFO demonstration: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Demonstrates the usage of queue implemented via two stacks.
    /// </summary>
    private static void DemonstrateQueueViaStacks()
    {
        try
        {
            var queueViaStacks = new QueueViaStacks<int>();

            Console.WriteLine("  Adding elements: 10, 20, 30");
            queueViaStacks.Enqueue(10);
            queueViaStacks.Enqueue(20);
            queueViaStacks.Enqueue(30);

            Console.WriteLine($"  Queue size: {queueViaStacks.Count}");
            Console.WriteLine($"  Peek at first element: {queueViaStacks.Peek()}");

            Console.WriteLine("  Removing elements (FIFO order):");
            while (!queueViaStacks.IsEmpty)
            {
                Console.WriteLine($"    Dequeued: {queueViaStacks.Dequeue()}");
            }

            Console.WriteLine($"  Final queue size: {queueViaStacks.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error in Queue via Stacks demonstration: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Demonstrates the Number of Islands algorithm.
    /// </summary>
    private static void DemonstrateIslandsCount()
    {
        try
        {
            int[][] grid = {
                new int[] {1, 1, 0, 0, 0},
                new int[] {1, 1, 0, 0, 0},
                new int[] {0, 0, 1, 0, 0},
                new int[] {0, 0, 0, 1, 1}
            };

            Console.WriteLine("  Input grid:");
            for (int i = 0; i < grid.Length; i++)
            {
                Console.WriteLine($"    [{string.Join(", ", grid[i])}]");
            }

            int islands = Solution.GetIslandsCount(grid);
            Console.WriteLine($"  Number of islands: {islands}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error in Islands Count demonstration: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Demonstrates the Knight Traversal algorithm.
    /// </summary>
    private static void DemonstrateKnightMoves()
    {
        try
        {
            char[][] chessboard = {
                "K...".ToCharArray(),
                "....".ToCharArray(),
                "..D.".ToCharArray(),
                "....".ToCharArray()
            };

            Console.WriteLine("  Input chessboard:");
            for (int i = 0; i < chessboard.Length; i++)
            {
                Console.WriteLine($"    {string.Join("", chessboard[i])}");
            }

            int moves = Solution.GetMinimumKnightMoves(chessboard);
            Console.WriteLine($"  Minimum knight moves: {moves}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error in Knight Moves demonstration: {ex.Message}");
            throw;
        }
    }
} 