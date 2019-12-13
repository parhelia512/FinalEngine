namespace FinalEngine.Drawing
{
    using System;

    public struct RectangleF : IEquatable<RectangleF>
    {
        public RectangleF(PointF location, SizeF size)
        {
            Location = location;
            Size = size;
        }

        public float Height
        {
            get { return Size.Height; }
        }

        public bool IsEmpty
        {
            get { return Location.IsEmpty && Size.IsEmpty; }
        }

        public PointF Location { get; set; }

        public SizeF Size { get; set; }

        public float Width
        {
            get { return Size.Width; }
        }

        public float X
        {
            get { return Location.X; }
        }

        public float Y
        {
            get { return Location.Y; }
        }

        public bool Equals(RectangleF other)
        {
            return Location.Equals(other.Location) && Size.Equals(other.Size);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RectangleF))
            {
                return false;
            }

            return Equals((RectangleF)obj);
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