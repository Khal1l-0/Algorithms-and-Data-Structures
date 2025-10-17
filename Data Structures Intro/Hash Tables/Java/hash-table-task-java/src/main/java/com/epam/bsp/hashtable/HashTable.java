package com.epam.bsp.hashtable;

/**
 * Simple hash table implementation
 * @param <K> type of key
 * @param <V> type of value
 */
public class HashTable<K, V> {

    /**
     * Number of buckets
     */
    private int nBuckets;
    /**
     * Array of buckets
     */
    private Bucket<K, V>[] buckets;

    @SuppressWarnings("unchecked")
    public HashTable(int nBuckets) {
        this.nBuckets = nBuckets;
        this.buckets = (Bucket<K, V>[]) new Bucket[nBuckets];
        for (int i = 0; i < nBuckets; i++) {
            buckets[i] = new Bucket<>();
        }
    }

    public HashTable() {
        this(100);
    }

    public Bucket<K, V>[] getBuckets() {
        return buckets;
    }

    private int h(K key) {
        return (key.hashCode() % nBuckets + nBuckets) % nBuckets;
    }

    public Bucket<K, V> getBucket(K key) {
        return buckets[h(key)];
    }

    /**
     * Inserts or replaces a (K,V) pair.
     */
    public void set(K key, V value) {
        getBucket(key).put(key, value);
    }

    /**
     * Retrieves a value by key.
     */
    public V get(K key) {
        return getBucket(key).get(key);
    }

    /**
     * Removes a (K,V) pair.
     */
    public boolean remove(K key) {
        return getBucket(key).remove(key);
    }
}
