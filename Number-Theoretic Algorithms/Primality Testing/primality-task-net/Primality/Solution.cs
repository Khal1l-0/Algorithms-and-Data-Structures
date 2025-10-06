using System;
using System.Collections.Generic;

namespace Primality
{
    /// <summary>
    /// Solution class for primality and factorization tasks
    /// </summary>
    public static class Solution
    {
        /// <summary>
        /// Gets the list of primes less than or equal to n
        /// </summary>
        /// <param name="n">The upper bound for primes, where 2 <= n < 2^30 = 1073741824</param>
        /// <returns>The list of primes less than or equal to n</returns>
        public static List<int> GetPrimes(int n)
        {
            var primes = new List<int>();
            if (n <= 2) return primes;

            // Sieve of Eratosthenes up to n-1 (strictly less than n)
            int limit = n - 1;
            bool[] isComposite = new bool[limit + 1];
            for (int i = 2; i * i <= limit; i++)
            {
                if (!isComposite[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        isComposite[j] = true;
                    }
                }
            }

            for (int i = 2; i <= limit; i++)
            {
                if (!isComposite[i])
                    primes.Add(i);
            }

            return primes;
        }

        /// <summary>
        /// Gets the prime factorization of a number
        /// </summary>
        /// <param name="n">The number for factorization, n >= 2</param>
        /// <returns>The dictionary where the key is a factor and the value is the power of the factor</returns>
        public static Dictionary<int, int> GetFactors(int n)
        {
            var factors = new Dictionary<int, int>();

            int divisor = 2;
            while (divisor * divisor <= n)
            {
                int count = 0;
                while (n % divisor == 0)
                {
                    count++;
                    n /= divisor;
                }
                if (count > 0)
                {
                    factors[divisor] = count;
                }
                divisor++;
            }

            // If n is still > 1, then it is a prime factor itself
            if (n > 1)
            {
                factors[n] = 1;
            }

            return factors;
        }
    }
}