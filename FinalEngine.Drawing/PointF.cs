namespace FinalEngine.Drawing
{
    using System;

    public struct PointF : IEquatable<PointF>
    {
        public static readonly PointF Empty = new PointF(0, 0);

        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }

        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        public float X { get; set; }

        public float Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is PointF))
            {
                return false;
            }

            return Equals((PointF)obj);
        }

        public bool Equals(PointF other)
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