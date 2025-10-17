package com.epam.bsp;

import com.epam.bsp.disjoint.set.DisjointSets;
import java.util.List;

public class Solution {

    /**
     * Representation of a pair of integer numbers.
     */
    public static class Pair {
        private int i;
        private int j;

        public Pair(int i, int j) {
            this.i = i;
            this.j = j;
        }
    }

    /**
     * Checks whether a given graph is a valid tree.
     *
     * @param n number of vertexes in a given graph.
     * @param edges list of edges of a given graph.
     * @return whether a given graph is a valid tree.
     */
    public static boolean isValidTree(int n, List<Pair> edges) {
        // A tree must have exactly n - 1 edges
        if (edges.size() != n - 1) return false;

        DisjointSets<Integer> ds = new DisjointSets<>();

        // make sets for all nodes
        for (int i = 0; i < n; i++) {
            ds.makeSet(i);
        }

        // For each edge, check if it creates a cycle
        for (Pair edge : edges) {
            Integer root1 = ds.findSet(edge.i);
            Integer root2 = ds.findSet(edge.j);

            if (root1.equals(root2)) {
                // cycle found
                return false;
            }
            ds.unionSets(edge.i, edge.j);
        }

        // check connectivity (all nodes share the same root)
        Integer root = ds.findSet(0);
        for (int i = 1; i < n; i++) {
            if (!root.equals(ds.findSet(i))) {
                return false; // not connected
            }
        }

        return true;
    }
}
