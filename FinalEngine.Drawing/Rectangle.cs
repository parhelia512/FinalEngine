namespace FinalEngine.Drawing
{
    using System;

    public struct Rectangle : IEquatable<Rectangle>
    {
        public Rectangle(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public int Height
        {
            get { return Size.Height; }
        }

        public bool IsEmpty
        {
            get { return Location.IsEmpty && Size.IsEmpty; }
        }

        public Point Location { get; set; }

        public Size Size { get; set; }

        public int Width
        {
            get { return Size.Width; }
        }

        public int X
        {
            get { return Location.X; }
        }

        public int Y
        {
            get { return Location.Y; }
        }

        public bool Equals(Rectangle other)
        {
            return Location.Equals(other.Location) && Size.Equals(other.Size);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle))
            {
                return false;
            }

            return Equals((Rectangle)obj);
        }

        public override int GetHashCode()
        {
            return new { Location, Size }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({ Location }, { Size }";
        }
    }
}