using DisjointSet.Interfaces;

namespace DisjointSet.DisjointSet;

/// <summary>
/// Implementation of disjoint sets data structure with path compression and union by rank optimizations.
/// </summary>
/// <typeparam name="T">Type of elements in the sets</typeparam>
public class DisjointSets<T> : IDisjointSets<T> where T : notnull
{
    // parent хранит "родителя" для каждого элемента
    private readonly Dictionary<T, T> _parent = new();
    // rank хранит "высоту дерева" (или размер множества)
    private readonly Dictionary<T, int> _rank = new();

    /// <summary>
    /// Creates a new set that is associated with a given key.
    /// </summary>
    /// <param name="key">The key to create a set for</param>
    /// <exception cref="ArgumentNullException">Thrown when key is null</exception>
    public void MakeSet(T key)
    {
        if (key is null)
            throw new ArgumentNullException(nameof(key));

        if (_parent.ContainsKey(key))
            return; // уже существует — игнорируем

        _parent[key] = key;
        _rank[key] = 0; // изначально "ранг" = 0
    }

    /// <summary>
    /// Returns a unique set identifier (key) of a given's key set.
    /// Uses path compression.
    /// </summary>
    /// <param name="key">The key to find the set for</param>
    /// <returns>The unique set identifier</returns>
    /// <exception cref="KeyNotFoundException">Thrown when key was not added by MakeSet</exception>
    public T FindSet(T key)
    {
        if (!_parent.ContainsKey(key))
            throw new KeyNotFoundException($"Key '{key}' was not found.");

        if (!EqualityComparer<T>.Default.Equals(_parent[key], key))
            _parent[key] = FindSet(_parent[key]); // рекурсивная компрессия пути

        return _parent[key];
    }

    /// <summary>
    /// Joins two given sets into a new one using union by rank heuristic.
    /// If ranks are equal, prefer second set as the root.
    /// </summary>
    public void UnionSets(T firstKey, T secondKey)
    {
        T root1 = FindSet(firstKey);
        T root2 = FindSet(secondKey);

        if (EqualityComparer<T>.Default.Equals(root1, root2))
            return; // уже в одном множестве

        int rank1 = _rank[root1];
        int rank2 = _rank[root2];

        if (rank1 < rank2)
        {
            _parent[root1] = root2;
        }
        else if (rank1 > rank2)
        {
            _parent[root2] = root1;
        }
        else
        {
            // ранги равны — выбираем второй как root (согласно комментарию в задании)
            _parent[root1] = root2;
            _rank[root2]++; // увеличиваем ранг root2
        }
    }
}