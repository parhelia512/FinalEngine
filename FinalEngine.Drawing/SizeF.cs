namespace FinalEngine.Drawing
{
    using System;

    public struct SizeF : IEquatable<SizeF>
    {
        public static readonly SizeF Empty = new SizeF(0, 0);

        public SizeF(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Height { get; set; }

        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        public float Width { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is SizeF))
            {
                return false;
            }

            return Equals((SizeF)obj);
        }

        public bool Equals(SizeF other)
        {
            return Width == other.Width &&
                   Height == other.Height;
        }

        public override int GetHashCode()
        {
            return new { Width, Height }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({ Width }, { Height })";
        }
    }
}