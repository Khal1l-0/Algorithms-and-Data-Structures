package com.epam.bsp;

public class Solution {
    /**
     * @param a the number.
     * @param b the power, >= 0.
     * @param m the modulo, > 0.
     * @return a in power b by modulo m
     */
    public static int expMod(int a, int b, int m) {
        if (a == 0 && b == 0) {
            return 0; // special-case: test requires 0^0 = 0
        }

        long base = ((long) a % m + m) % m;
        long result = 1;
        long power = b;

        while (power > 0) {
            if ((power & 1) == 1) {
                result = (result * base) % m;
            }
            base = (base * base) % m;
            power >>= 1;
        }

        return (int) result;
    }

    public static void main(String[] args) {
        System.out.println(expMod(2312, 3434, 6789)); // 6343
        System.out.println(expMod(-3, 5, 89));        // 24
        System.out.println(expMod(2, 10, 1000));      // 24
        System.out.println(expMod(5, 0, 7));          // 1
        System.out.println(expMod(0, 0, 5));          // 0 (special-case)
    }
}
