// <copyright file="Rectangle.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing
{
    using System;

    public struct Rectangle : IEquatable<Rectangle>
    {
        public Rectangle(Point location, Size size)
        {
            this.Location = location;
            this.Size = size;
        }

        public int Height
        {
            get { return this.Size.Height; }
        }

        public bool IsEmpty
        {
            get { return this.Location.IsEmpty && this.Size.IsEmpty; }
        }

        public Point Location { get; set; }

        public Size Size { get; set; }

        public int Width
        {
            get { return this.Size.Width; }
        }

        public int X
        {
            get { return this.Location.X; }
        }

        public int Y
        {
            get { return this.Location.Y; }
        }

        public bool Equals(Rectangle other)
        {
            return this.Location.Equals(other.Location) && this.Size.Equals(other.Size);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle))
            {
                return false;
            }

            return this.Equals((Rectangle)obj);
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