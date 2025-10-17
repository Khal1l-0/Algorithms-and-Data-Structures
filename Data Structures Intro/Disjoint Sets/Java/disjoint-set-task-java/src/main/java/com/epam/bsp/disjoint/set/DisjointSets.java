package com.epam.bsp.disjoint.set;

import java.util.HashMap;
import java.util.Map;

/**
 * Class for supporting disjoint sets.
 * NOTE: the expected implementation should contain:
 * "path compression" heuristic
 * "union by rank" heuristic (based on sets size)
 *
 * @param <K> type of key
 */
public class DisjointSets<K> {

    private Map<K, K> parent; // parent map
    private Map<K, Integer> size; // size (rank) map

    public DisjointSets() {
        parent = new HashMap<>();
        size = new HashMap<>();
    }

    /**
     * Creates a new set that is associated with a given key.
     * @param key the key
     */
    public void makeSet(K key) {
        parent.put(key, key);
        size.put(key, 1);
    }

    /**
     * Returns a unique set identifier (key) of a given's key set.
     * NOTE: "path compression" heuristic should be used.
     *
     * @param key the key
     * @return the unique set identifier
     */
    public K findSet(K key) {
        K p = parent.get(key);
        if (p == null) return null; // key not found
        if (!p.equals(key)) {
            parent.put(key, findSet(p)); // path compression
        }
        return parent.get(key);
    }

    /**
     * Joins two given sets into a new one.
     * NOTE: "union by rank" heuristic should be used (based on sets size).
     * NOTE: if the sets that correspond to the given keys are of the same rank,
     * it is preferable to use the second set when deciding what set is to be used as a new 'root'.
     *
     * @param firstKey the key of a first set
     * @param secondKey the key of a second set
     */
    public void unionSets(K firstKey, K secondKey) {
        K root1 = findSet(firstKey);
        K root2 = findSet(secondKey);

        if (root1 == null || root2 == null) return;
        if (root1.equals(root2)) return; // already in same set

        int size1 = size.get(root1);
        int size2 = size.get(root2);

        // union by size (rank)
        if (size1 > size2) {
            parent.put(root2, root1);
            size.put(root1, size1 + size2);
        } else {
            parent.put(root1, root2);
            size.put(root2, size1 + size2);
        }
    }
}
