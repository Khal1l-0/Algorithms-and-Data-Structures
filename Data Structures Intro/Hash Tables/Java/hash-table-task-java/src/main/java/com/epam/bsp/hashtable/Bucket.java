package com.epam.bsp.hashtable;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * Represents a set of (K,V) pairs that were assigned to the same bin/chain/bucket.
 * @param <K> type of key
 * @param <V> type of value
 */
public class Bucket<K, V> {

    /**
     * List of KeyValueData in the bucket.
     */
    private List<KeyValueData<K, V>> elements;

    public Bucket() {
        this.elements = new ArrayList<>();
    }

    public List<KeyValueData<K, V>> getElements() {
        return elements;
    }

    /**
     * Searches a value on a given key in the bucket
     * @param key the key for search
     * @return the value for a given key; otherwise null, if no corresponding (K,V) is found.
     */
    public V get(K key) {
        for (KeyValueData<K, V> kv : elements) {
            if (kv.getKey().equals(key)) {
                return kv.getValue();
            }
        }
        return null;
    }

    /**
     * Puts a given (K,V) pair into the bucket.
     * If the key already exists, replaces the value.
     */
    public void put(K key, V value) {
        for (int i = 0; i < elements.size(); i++) {
            if (elements.get(i).getKey().equals(key)) {
                elements.set(i, new KeyValueData<>(key, value));
                return;
            }
        }
        elements.add(new KeyValueData<>(key, value));
    }

    /**
     * Removes the (K,V) pair for a given key
     * @param key the key
     * @return whether an element for a given key was really removed
     */
    public boolean remove(K key) {
        Iterator<KeyValueData<K, V>> iterator = elements.iterator();
        while (iterator.hasNext()) {
            KeyValueData<K, V> kv = iterator.next();
            if (kv.getKey().equals(key)) {
                iterator.remove();
                return true;
            }
        }
        return false;
    }
}
