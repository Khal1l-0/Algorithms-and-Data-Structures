namespace gcd_task
{
    /// <summary>
    /// Represents a triple (gcd, x, y) for the Extended Euclidean algorithm
    /// </summary>
    public record Triple(int Gcd, int X, int Y)
    {
        public override string ToString()
        {
            return $"({Gcd}, {X}, {Y})";
        }
    }

    public static class Solution
    {
        /// <summary>
        /// Finds the least common multiple of two given numbers
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>The least common multiple of two given numbers</returns>
        public static int FindLcm(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            return Math.Abs(a / Gcd(a, b) * b);
        }

        /// <summary>
        /// Finds GCD and coefficients of the expression d = gcd(a, b) = a * x + b * y
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>A Triple instance: gcd and coefficients</returns>
        public static Triple ExtendedEuclid(int a, int b)
        {
            if (b == 0)
            {
                return new Triple(a, 1, 0);
            }

            var result = ExtendedEuclid(b, a % b);
            int d = result.Gcd;
            int x1 = result.X;
            int y1 = result.Y;

            int x = y1;
            int y = x1 - (a / b) * y1;

            return new Triple(d, x, y);
        }

        /// <summary>
        /// Helper function to find gcd using Euclidean algorithm
        /// </summary>
        private static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
    }
}
