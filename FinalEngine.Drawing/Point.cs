namespace FinalEngine.Drawing
{
    using System;

    public struct Point : IEquatable<Point>
    {
        public static readonly Point Empty = new Point(0, 0);

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }

            return Equals((Point)obj);
        }

        public bool Equals(Point other)
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