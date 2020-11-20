// <copyright file="RectangleF.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing
{
    using System;

    public struct RectangleF : IEquatable<RectangleF>
    {
        public RectangleF(PointF location, SizeF size)
        {
            this.Location = location;
            this.Size = size;
        }

        public float Height
        {
            get { return this.Size.Height; }
        }

        public bool IsEmpty
        {
            get { return this.Location.IsEmpty && this.Size.IsEmpty; }
        }

        public PointF Location { get; set; }

        public SizeF Size { get; set; }

        public float Width
        {
            get { return this.Size.Width; }
        }

        public float X
        {
            get { return this.Location.X; }
        }

        public float Y
        {
            get { return this.Location.Y; }
        }

        public bool Equals(RectangleF other)
        {
            return this.Location.Equals(other.Location) && this.Size.Equals(other.Size);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is RectangleF))
            {
                return false;
            }

            return this.Equals((RectangleF)obj);
        }

        public override int GetHashCode()
        {
            return new { this.Location, this.Size }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.Location}, {this.Size}";
        }
    }
}