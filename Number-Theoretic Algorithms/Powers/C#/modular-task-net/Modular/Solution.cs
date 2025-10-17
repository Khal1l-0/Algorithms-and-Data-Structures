namespace Modular
{
    public static class Solution
    {
        /// <summary>
        /// Calculates a^b mod m using fast modular exponentiation.
        /// </summary>
        /// <param name="a">The base number</param>
        /// <param name="b">The exponent, must be >= 0</param>
        /// <param name="m">The modulus, must be > 0</param>
        /// <returns>a^b mod m</returns>
        public static int ExpMod(int a, int b, int m)
        {
            if (b < 0)
                throw new ArgumentException("Exponent must be non-negative", nameof(b));

            if (m <= 0)
                throw new ArgumentException("Modulus must be positive", nameof(m));

            // Special case: 0^0 = 0
            if (a == 0 && b == 0)
                return 0;

            long baseVal = ((long)a % m + m) % m; // handle negative a
            long result = 1;

            while (b > 0)
            {
                if ((b & 1) == 1)
                    result = (result * baseVal) % m;

                baseVal = (baseVal * baseVal) % m;
                b >>= 1;
            }

            return (int)result;
        }
    }
}
