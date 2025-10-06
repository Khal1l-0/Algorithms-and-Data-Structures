namespace DisjointSet.Interfaces;

/// <summary>
/// Interface for disjoint sets data structure.
/// </summary>
/// <typeparam name="T">Type of elements in the sets</typeparam>
public interface IDisjointSets<T> where T : notnull
{
    /// <summary>
    /// Creates a new set that is associated with a given key.
    /// </summary>
    /// <param name="key">The key to create a set for</param>
    void MakeSet(T key);

    /// <summary>
    /// Returns a unique set identifier (key) of a given's key set.
    /// NOTE: "path compression" heuristic should be used.
    /// </summary>
    /// <param name="key">The key to find the set for</param>
    /// <returns>The unique set identifier</returns>
    T FindSet(T key);

    /// <summary>
    /// Joins two given sets into a new one.
    /// NOTE: "union by rank" heuristic should be used (based on sets size).
    /// NOTE: if the sets that correspond to the given keys are of the same rank,
    /// it is preferable to use the second set when deciding what set is to be used as a new 'root'.
    /// </summary>
    /// <param name="firstKey">The key of a first set</param>
    /// <param name="secondKey">The key of a second set</param>
    void UnionSets(T firstKey, T secondKey);
} 