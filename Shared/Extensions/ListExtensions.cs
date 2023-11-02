namespace Shared.Extensions
{
    public static class ListExtensions
    {
        public static int Mult(this IEnumerable<int> values)
        {
            return values.Aggregate((cur, val) => cur * val);
        }

        public static long Mult(this IEnumerable<long> values)
        {
            return values.Aggregate((cur, val) => cur * val);
        }

        public static double Mult(this IEnumerable<double> values)
        {
            return values.Aggregate((cur, val) => cur * val);
        }
    }
}
