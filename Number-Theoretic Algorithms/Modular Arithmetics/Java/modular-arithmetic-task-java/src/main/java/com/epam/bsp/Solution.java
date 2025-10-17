package com.epam.bsp;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class Solution {
    public static List<Integer> modularLinear(int a, int b, int m) {
        List<Integer> roots = new ArrayList<>();
        Triple t = extendedEuclid(a, m);
        int d = t.getD();

        if (b % d != 0) {
            return roots; // no solutions
        }

        int a1 = a / d;
        int b1 = b / d;
        int m1 = m / d;

        Optional<Integer> invOpt = modularInverse(a1, m1);
        if (invOpt.isEmpty()) {
            return roots;
        }

        int x0 = (int) (((long) b1 * invOpt.get()) % m1);
        for (int k = 0; k < d; k++) {
            roots.add((x0 + k * m1) % m);
        }

        return roots;
    }

    public static Optional<Integer> modularInverse(int a, int m) {
        Triple t = extendedEuclid(a, m);
        if (t.getD() != 1) {
            return Optional.empty();
        }
        long x = t.getX();
        int inv = (int) ((x % m + m) % m); // normalize to [0, m-1]
        return Optional.of(inv);
    }

    private static Triple extendedEuclid(int a, int b) {
        if (b == 0) {
            return new Triple(a, 1, 0);
        }
        Triple t = extendedEuclid(b, a % b);
        int d = t.getD();
        int x = t.getY();
        int y = t.getX() - (a / b) * t.getY();
        return new Triple(d, x, y);
    }

    public static class Triple {
        private int d;
        private int x;
        private int y;

        public Triple(int d, int x, int y) {
            this.d = d;
            this.x = x;
            this.y = y;
        }

        public int getD() {
            return d;
        }

        public int getX() {
            return x;
        }

        public int getY() {
            return y;
        }

        @Override
        public String toString() {
            return String.format("(%d, %d, %d)", d, x, y);
        }
    }

    public static void main(String[] args) {
        System.out.println(modularLinear(3, 6, 15));   // [2, 7, 12]
        System.out.println(modularLinear(23, 1, 100)); // [87]

        System.out.println(modularInverse(3, 25)); // Optional[17]
        System.out.println(modularInverse(3, 15)); // Optional.empty
        System.out.println(modularInverse(2, 3));  // Optional[2]
        System.out.println(modularInverse(1, 2));  // Optional[1]
    }
}
