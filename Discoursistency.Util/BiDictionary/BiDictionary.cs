using System.Collections.Generic;

namespace Discoursistency.Util.BiDictionary
{
    /// <summary>
    /// A bi-directional dictionary class. Ensures amortized O(1) lookup both by-key and by-value
    /// at the cost of doubling memory requirements and insertion time.
    /// </summary>
    /// <typeparam name="TKey">Type of the dictionary key</typeparam>
    /// <typeparam name="TValue">Type of the dictionary value</typeparam>
    public class BiDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _normalDictionary = new Dictionary<TKey, TValue>();
        private readonly Dictionary<TValue, TKey> _invertedDictionary = new Dictionary<TValue, TKey>();

        /// <summary>
        /// Retrieves or sets a value by key, using the [] operator.
        /// </summary>
        /// <param name="id">A key to lookup/insert.</param>
        /// <returns>Value under said key.</returns>
        public TValue this[TKey id]
        {
            get { return _normalDictionary[id]; }
            set { this.Add(id, value); }
        }

        /// <summary>
        /// Retrieves or sets a key by value, using the [] operator.
        /// </summary>
        /// <param name="id">A value to lookup/insert.</param>
        /// <returns>Key for said value.</returns>
        public TKey this[TValue id]
        {
            get { return _invertedDictionary[id]; }
            set { this.Add(value, id); }
        }

        /// <summary>
        /// Retrieves a value by key explicitly.
        /// </summary>
        /// <param name="id">A key to lookup.</param>
        /// <returns>Value under said key.</returns>
        public TValue GetByKey(TKey id)
        {
            return _normalDictionary[id];
        }

        /// <summary>
        /// Retrieves a key by value explicitly.
        /// </summary>
        /// <param name="val">A value to lookup.</param>
        /// <returns>Key for said value.</returns>
        public TKey GetByValue(TValue val)
        {
            return _invertedDictionary[val];
        }

        /// <summary>
        /// Inserts a new entry into the dictionary.
        /// </summary>
        /// <param name="pair">A key-value pair to insert.</param>
        public void Add(KeyValuePair<TKey, TValue> pair)
        {
            _normalDictionary.Add(pair.Key, pair.Value);
            _invertedDictionary.Add(pair.Value, pair.Key);
        }

        /// <summary>
        /// Inserts a new entry into the dictionary.
        /// </summary>
        /// <param name="key">A key to insert.</param>
        /// <param name="value">A value to insert under that key.</param>
        public void Add(TKey key, TValue value)
        {
            _normalDictionary.Add(key, value);
            _invertedDictionary.Add(value, key);
        }

        /// <summary>
        /// Represents a collection of keys in the dictionary.
        /// </summary>
        public IEnumerable<TKey> Keys { get { return _normalDictionary.Keys; } }
        /// <summary>
        /// Represents a collection of values in the dictionary.
        /// </summary>
        public IEnumerable<TValue> Values { get { return _invertedDictionary.Keys; } } 
        /// <summary>
        /// Represents a number of dictionary items.
        /// </summary>
        public int Count { get { return _normalDictionary.Count; } }
    }
}
