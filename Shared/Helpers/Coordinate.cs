using System.Diagnostics.CodeAnalysis;

namespace Shared.Helpers
{
    public class Coordinate<T> : IEqualityComparer<Coordinate<T>?>, ICloneable
    {
        public T? X { get; set; }
        public T? Y { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Coordinate<T> coordinate &&
                   EqualityComparer<T?>.Default.Equals(X, coordinate.X) &&
                   EqualityComparer<T?>.Default.Equals(Y, coordinate.Y);
        }

        public bool Equals(Coordinate<T>? x, Coordinate<T>? y)
        {
            return x == y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public int GetHashCode([DisallowNull] Coordinate<T>? obj)
        {
            return HashCode.Combine(obj.X, obj.Y);
        }

        public static bool operator ==(Coordinate<T>? left, Coordinate<T>? right)
        {
            return EqualityComparer<Coordinate<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(Coordinate<T>? left, Coordinate<T>? right)
        {
            return !(left == right);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"X: {X} Y: {Y}";
        }
    }
}
