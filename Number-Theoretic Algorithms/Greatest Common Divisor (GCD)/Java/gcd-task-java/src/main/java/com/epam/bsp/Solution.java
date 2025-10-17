package com.epam.bsp;

public class Solution {
    public static int findLcm(int a, int b) {
        return (int) (Math.abs((long) a * b) / gcd(a, b));
    }

    private static int gcd(int a, int b) {
        while (b != 0) {
            int temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }

    public static Triple extendedEuclid(int a, int b) {
        if (b == 0) {
            return new Triple(a, 1, 0);
        }
        Triple t = extendedEuclid(b, a % b);
        int d = t.d;
        int x = t.y;
        int y = t.x - (a / b) * t.y;
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

        @Override
        public String toString() {
            return String.format("(%d, %d, %d)", d, x, y);
        }
    }
}
