package com.epam.bsp;

import java.util.*;

public class Solution {

    /**
     * Representation of a pair of indices.
     */
    public static class Pair {
        private int i;
        private int j;

        public Pair(int i, int j) {
            this.i = i;
            this.j = j;
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;
            Pair pair = (Pair) o;
            return (i == pair.i && j == pair.j) || (i == pair.j && j == pair.i);
        }

        @Override
        public int hashCode() {
            return Objects.hash(i, j);
        }
    }

    /**
     * Exercise 2: Two Sum
     */
    public static Pair findTargetSum(List<Integer> values, int target) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int i = 0; i < values.size(); i++) {
            int complement = target - values.get(i);
            if (map.containsKey(complement)) {
                return new Pair(map.get(complement), i);
            }
            map.put(values.get(i), i);
        }
        return null;
    }

    private final static String DNA_ALPHABET = "ATGC";

    /**
     * Exercise 3: Find repeated 8-letter DNA sequences.
     */
    public static Set<String> findRepeatedDnaSequences(String dnaSequence) {
        Set<String> seen = new HashSet<>();
        Set<String> repeated = new HashSet<>();

        int n = dnaSequence.length();
        if (n < 8) return repeated;

        for (int i = 0; i <= n - 8; i++) {
            String sub = dnaSequence.substring(i, i + 8);
            if (!seen.add(sub)) {
                repeated.add(sub);
            }
        }

        return repeated;
    }
}
