namespace Shared.Helpers
{
    public class HashMap<T, K> where T : IEquatable<T>
    {
        private readonly Dictionary<T, K> _dictionary;

        public HashMap()
        {
            _dictionary = new Dictionary<T, K>();
        }

        public T[] Keys()
        {
            return _dictionary.Keys.ToArray();
        }

        public K[] Values()
        {
            return _dictionary.Values.ToArray();
        }

        public void Add(T key, K value)
        {
            _dictionary.Add(key, value);
        }

        public K Get(T key)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _dictionary.GetValueOrDefault(key);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public K GetOrAdd(T key, K value)
        {
            if (_dictionary.ContainsKey(key))
            {
                return _dictionary[key];
            }
            else
            {
                _dictionary[key] = value;
                return value;
            }
        }
    }
}
