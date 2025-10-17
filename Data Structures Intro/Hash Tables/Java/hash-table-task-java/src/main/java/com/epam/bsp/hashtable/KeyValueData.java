package com.epam.bsp.hashtable;

/**
 * Data that will be stored in hash table.
 * NOTE: no need to change this class.
 * @param <K> type of key
 * @param <V> type of value
 */
public class KeyValueData<K, V> {

    private K key;
    private V value;

    public KeyValueData(K key, V value) {
        this.key = key;
        this.value = value;
    }

    public K getKey() {
        return key;
    }

    public V getValue() {
        return value;
    }

}
