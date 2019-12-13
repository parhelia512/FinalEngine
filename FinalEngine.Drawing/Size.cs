namespace FinalEngine.Drawing
{
    using System;

    public struct Size : IEquatable<Size>
    {
        public static readonly Size Empty = new Size(0, 0);

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Height { get; set; }

        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        public int Width { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Size))
            {
                return false;
            }

            return Equals((Size)obj);
        }

        public bool Equals(Size other)
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