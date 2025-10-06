using System;
using System.Collections.Generic;

namespace ModularArithmetic
{
    public static class Solution
    {
        /// <summary>
        /// Extended Euclidean Algorithm.
        /// Returns gcd(a, b) and coefficients x, y such that: a*x + b*y = gcd(a, b).
        /// </summary>
        private static (int gcd, int x, int y) ExtendedGcd(int a, int b)
        {
            if (b == 0)
                return (Math.Abs(a), a >= 0 ? 1 : -1, 0);

            var (gcd, x1, y1) = ExtendedGcd(b, a % b);
            int x = y1;
            int y = x1 - (a / b) * y1;
            return (gcd, x, y);
        }

        /// <summary>
        /// Finds all roots of the modular equation a * x = b (mod m)
        /// </summary>
        public static List<int> ModularLinear(int a, int b, int m)
        {
            var result = new List<int>();

            var (d, x0, _) = ExtendedGcd(a, m);

            if (b % d != 0)
                return result;

            int x = (int)((long)x0 * (b / d) % m);
            x = Normalize(x, m);

            int step = m / d;
            for (int i = 0; i < d; i++)
            {
                int solution = (x + i * step) % m;
                result.Add(Normalize(solution, m));
            }

            return result;
        }

        /// <summary>
        /// Finds the modular inverse of a modulo m if it exists
        /// </summary>
        public static int? ModularInverse(int a, int m)
        {
            var (d, x, _) = ExtendedGcd(a, m);
            if (d != 1)
                return null; // inverse does not exist

            return Normalize(x, m);
        }

        /// <summary>
        /// Ensures value is in range 0..m-1
        /// </summary>
        private static int Normalize(int value, int m)
        {
            int result = value % m;
            if (result < 0)
                result += m;
            return result;
        }
    }
}
