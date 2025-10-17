using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    /// <summary>
    /// Contains utility methods for solving algorithmic problems.
    /// </summary>
    public class Solution
    {
        private const int DnaSequenceLength = 8;
        private const string DnaAlphabet = "ATGC";

        /// <summary>
        /// Represents a pair of indices.
        /// </summary>
        public class Pair
        {
            private readonly int _i;
            private readonly int _j;

            public Pair(int i, int j)
            {
                _i = i;
                _j = j;
            }

            public override bool Equals(object? obj)
            {
                if (obj is not Pair other) return false;
                return _i == other._i && _j == other._j;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (_i * 397) ^ _j;
                }
            }

            public override string ToString()
            {
                return $"({_i}, {_j})";
            }
        }

        /// <summary>
        /// Returns a pair of indices so that the corresponding values add up to a given target.
        /// </summary>
        public static Pair? FindTargetSum(List<int> values, int target)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            if (values.Count < 2)
                throw new ArgumentException("List must contain at least two elements.", nameof(values));

            var dict = new Dictionary<int, int>(); // value -> index
            for (int i = 0; i < values.Count; i++)
            {
                int complement = target - values[i];
                if (dict.TryGetValue(complement, out int j))
                {
                    return new Pair(j, i);
                }

                if (!dict.ContainsKey(values[i]))
                    dict[values[i]] = i;
            }

            return null;
        }

        /// <summary>
        /// Returns all 8-letter-long substrings that occur more than once.
        /// </summary>
        public static HashSet<string> FindRepeatedDnaSequences(string dnaSequence)
        {
            if (dnaSequence == null)
                throw new ArgumentNullException(nameof(dnaSequence));

            // Проверка на допустимые символы
            foreach (char c in dnaSequence)
            {
                if (!DnaAlphabet.Contains(c))
                    throw new ArgumentException("DNA sequence contains invalid characters.", nameof(dnaSequence));
            }

            var result = new HashSet<string>();
            if (dnaSequence.Length < DnaSequenceLength)
                return result;

            var seen = new HashSet<string>();

            for (int i = 0; i <= dnaSequence.Length - DnaSequenceLength; i++)
            {
                string substring = dnaSequence.Substring(i, DnaSequenceLength);
                if (!seen.Add(substring)) // Если уже встречали
                {
                    result.Add(substring);
                }
            }

            return result;
        }
    }
}