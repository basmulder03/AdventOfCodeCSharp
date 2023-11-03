namespace Shared.Extensions
{
    public static class HashSetExtensions
    {
        public static T GetOrAdd<T>(this HashSet<T> set, T value) where T : IEquatable<T>
        {
            if (set.Add(value)) return value;
            else return set.First(setValue => setValue.Equals(value));
        }
    }
}
