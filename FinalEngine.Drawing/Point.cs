// <copyright file="Point.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing
{
    using System;

    public struct Point : IEquatable<Point>
    {
        public static readonly Point Empty = new Point(0, 0);

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }

            return this.Equals((Point)obj);
        }

        public bool Equals(Point other)
        {
            return this.X == other.X &&
                   this.Y == other.Y;
        }

        public override int GetHashCode()
        {
            return new { this.X, this.Y }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }
    }
}