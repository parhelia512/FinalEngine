namespace FinalEngine.Maths
{
    using System;

    public struct Vector2 : IEquatable<Vector2>
    {
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
            {
                return false;
            }

            return Equals((Vector2)obj);
        }

        public bool Equals(Vector2 other)
        {
            return X == other.X &&
                   Y == other.Y;
        }

        public override int GetHashCode()
        {
            return new { X, Y }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}