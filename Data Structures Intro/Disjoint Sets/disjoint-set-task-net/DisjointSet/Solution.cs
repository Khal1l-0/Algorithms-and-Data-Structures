using DisjointSet.Models;

namespace DisjointSet;

/// <summary>
/// Main solution class containing the graph validation logic.
/// </summary>
public static class Solution
{
    /// <summary>
    /// Checks whether a given graph is a valid tree.
    /// A graph is a valid tree if it is connected and has no cycles.
    /// </summary>
    /// <param name="n">Number of vertices in the graph (0 to n-1)</param>
    /// <param name="edges">List of edges in the graph</param>
    /// <returns>True if the graph is a valid tree, false otherwise</returns>
    public static bool IsValidTree(int n, List<Pair> edges)
    {
        if (edges == null)
            throw new ArgumentNullException(nameof(edges));

        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Number of vertices cannot be negative.");

        // A valid tree with n nodes must have exactly n-1 edges
        if (edges.Count != n - 1)
            return false;

        var dsu = new DisjointSetUnion(n);

        foreach (var edge in edges)
        {
            if (edge.First < 0 || edge.First >= n || edge.Second < 0 || edge.Second >= n)
                throw new KeyNotFoundException($"Edge contains invalid vertex index: ({edge.First}, {edge.Second})");

            // Если две вершины уже соединены → это цикл
            if (!dsu.Union(edge.First, edge.Second))
                return false;
        }

        return dsu.Count == 1;
    }
}

/// <summary>
/// Disjoint Set Union (Union-Find) data structure with path compression and union by rank.
/// </summary>
internal class DisjointSetUnion
{
    private readonly int[] parent;
    private readonly int[] rank;

    /// <summary>
    /// Gets the current number of disjoint sets (connected components).
    /// </summary>
    public int Count { get; private set; }

    public DisjointSetUnion(int n)
    {
        parent = new int[n];
        rank = new int[n];
        Count = n;

        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    private int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]); // path compression
        return parent[x];
    }

    internal bool Union(int first, int second)
    {
        int rootA = Find(first);
        int rootB = Find(second);

        if (rootA == rootB)
            return false; // уже соединены → цикл

        // union by rank
        if (rank[rootA] < rank[rootB])
            parent[rootA] = rootB;
        else if (rank[rootA] > rank[rootB])
            parent[rootB] = rootA;
        else
        {
            parent[rootB] = rootA;
            rank[rootA]++;
        }

        Count--;
        return true;
    }
}