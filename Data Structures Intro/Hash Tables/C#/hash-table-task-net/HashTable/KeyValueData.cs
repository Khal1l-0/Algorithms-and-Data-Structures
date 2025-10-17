namespace HashTable
{
    public class KeyValueData<K, V>
    {
        public K Key { get; }
        public V Value { get; set; }  // <-- исправлено, добавлен set

        public KeyValueData(K key, V value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Key = key;
            Value = value;
        }
    }
}