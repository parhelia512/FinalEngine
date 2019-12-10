namespace FinalEngine.Maths
{
    using System;

    public struct Vector2 : IEquatable<Vector2>
    {
        public static Vector2 Down = new Vector2(0, -1);

        public static Vector2 Left = new Vector2(-1, 0);

        public static Vector2 NegativeInfinity = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        public static Vector2 One = new Vector2(1, 1);

        public static Vector2 PositiveInfinity = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        public static Vector2 Right = new Vector2(1, 0);

        public static Vector2 Up = new Vector2(0, 1);

        public static Vector2 Zero = new Vector2(0, 0);

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
            return $"({ X }, { Y })";
        }
    }
}