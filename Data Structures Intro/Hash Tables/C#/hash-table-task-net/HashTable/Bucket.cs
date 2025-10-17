using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    public class Bucket<K, V>
    {
        private readonly List<KeyValueData<K, V>> _elements;

        public Bucket()
        {
            _elements = new List<KeyValueData<K, V>>();
        }

        public IReadOnlyList<KeyValueData<K, V>> Elements => _elements;

        public V Get(K key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            var kv = _elements.FirstOrDefault(e => EqualityComparer<K>.Default.Equals(e.Key, key));
            return kv != null ? kv.Value : default!;
        }

        public void Put(K key, V value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            var kv = _elements.FirstOrDefault(e => EqualityComparer<K>.Default.Equals(e.Key, key));
            if (kv != null)
            {
                kv.Value = value;
            }
            else
            {
                _elements.Add(new KeyValueData<K, V>(key, value));
            }
        }

        public bool Remove(K key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            var kv = _elements.FirstOrDefault(e => EqualityComparer<K>.Default.Equals(e.Key, key));
            if (kv != null)
            {
                _elements.Remove(kv);
                return true;
            }
            return false;
        }

        public int Count => _elements.Count;
    }
}