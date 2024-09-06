using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDevices
{
    public class CustomDictionary<TKey, TValue>
    {
        private List<TKey> keys;
        private List<TValue> values;

        public CustomDictionary()
        {
            keys = new List<TKey>();
            values = new List<TValue>();
        }

        // Add a key-value pair
        public void Add(TKey key, TValue value)
        {
            if (keys.Contains(key))
            {
                throw new ArgumentException("Key already exists.");
            }

            keys.Add(key);
            values.Add(value);
        }

        // Update a value given a key
        public void Update(TKey key, TValue value)
        {
            int index = keys.IndexOf(key);

            if (index == -1)
            {
                throw new KeyNotFoundException("Key not found.");
            }

            values[index] = value;
        }

        // Remove an item given a key
        public void Remove(TKey key)
        {
            int index = keys.IndexOf(key);

            if (index == -1)
            {
                throw new KeyNotFoundException("Key not found.");
            }

            keys.RemoveAt(index);
            values.RemoveAt(index);
        }

        // Get a value given a key
        public TValue Get(TKey key)
        {
            int index = keys.IndexOf(key);

            if (index == -1)
            {
                throw new KeyNotFoundException("Key not found.");
            }

            return values[index];
        }

        // Check for a given key
        public bool ContainsKey(TKey key)
        {
            return keys.Contains(key);
        }

        // Receive all dictionary items as a collection
        public IEnumerable<KeyValuePair<TKey, TValue>> GetAllItems()
        {
            return keys.Zip(values, (key, value) => new KeyValuePair<TKey, TValue>(key, value));
        }
    }
}
