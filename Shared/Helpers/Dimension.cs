namespace Shared.Helpers
{
    public class Dimension<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }

        public static Dimension<T> FromXYZ(T x, T y, T z)
        {
            return new Dimension<T>
            {
                X = x,
                Y = y,
                Z = z
            };
        }

        public static Dimension<int> FromString(string str, string delimiter)
        {
            var dim = str.Split(delimiter).Select(t => int.Parse(t));
            return new Dimension<int>
            {
                X = dim.ElementAt(0),
                Y = dim.ElementAt(1),
                Z = dim.ElementAt(2)
            };
        }

        public IEnumerable<T> ToList()
        {
            return new List<T> { this.X, this.Y, this.Z };
        }
    }
}
