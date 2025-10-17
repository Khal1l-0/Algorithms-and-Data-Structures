using System;
using System.Collections.Generic;

namespace HashTable
{
    /// <summary>
    /// Simple hash table implementation using chaining for collision resolution.
    /// </summary>
    /// <typeparam name="K">The type of the key</typeparam>
    /// <typeparam name="V">The type of the value</typeparam>
    public class HashTable<K, V>
    {
        private const int DefaultBucketCount = 100;
        private const int MinimumBucketCount = 1;

        /// <summary>
        /// Number of buckets in the hash table.
        /// </summary>
        private readonly int _bucketCount;

        /// <summary>
        /// Array of buckets for storing key-value pairs.
        /// </summary>
        private readonly Bucket<K, V>[] _buckets;

        /// <summary>
        /// Gets the buckets array. This is exposed for testing purposes only.
        /// </summary>
        public IReadOnlyList<Bucket<K, V>> Buckets => _buckets;

        /// <summary>
        /// Initializes a new instance of the HashTable class with the specified number of buckets.
        /// </summary>
        /// <param name="bucketCount">The number of buckets to create</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when bucketCount is less than 1.</exception>
        public HashTable(int bucketCount)
        {
            if (bucketCount < MinimumBucketCount)
                throw new ArgumentOutOfRangeException(nameof(bucketCount), $"Bucket count must be >= {MinimumBucketCount}");

            _bucketCount = bucketCount;
            _buckets = new Bucket<K, V>[_bucketCount];
            for (int i = 0; i < _bucketCount; i++)
                _buckets[i] = new Bucket<K, V>();
        }

        /// <summary>
        /// Initializes a new instance of the HashTable class with the default number of buckets.
        /// </summary>
        public HashTable() : this(DefaultBucketCount)
        {
        }

        /// <summary>
        /// Computes the hash value for the given key and maps it to a bucket index.
        /// </summary>
        private int GetBucketIndex(K key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return Math.Abs(key.GetHashCode()) % _bucketCount;
        }

        /// <summary>
        /// Gets the bucket for the given key.
        /// </summary>
        public Bucket<K, V> GetBucket(K key)
        {
            return _buckets[GetBucketIndex(key)];
        }

        /// <summary>
        /// Adds or updates a key-value pair in the hash table.
        /// </summary>
        public void Set(K key, V value)
        {
            GetBucket(key).Put(key, value);
        }

        /// <summary>
        /// Retrieves the value associated with the given key.
        /// </summary>
        public V Get(K key)
        {
            return GetBucket(key).Get(key);
        }

        /// <summary>
        /// Removes the key-value pair associated with the given key.
        /// </summary>
        public bool Remove(K key)
        {
            return GetBucket(key).Remove(key);
        }

        /// <summary>
        /// Gets the total number of key-value pairs in the hash table.
        /// </summary>
        public int Count
        {
            get
            {
                int total = 0;
                foreach (var bucket in _buckets)
                    total += bucket.Count;
                return total;
            }
        }
    }
}