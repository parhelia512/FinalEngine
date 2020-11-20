// <copyright file="PointF.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing
{
    using System;

    public struct PointF : IEquatable<PointF>
    {
        public static readonly PointF Empty = new PointF(0, 0);

        public PointF(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        public float X { get; set; }

        public float Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is PointF))
            {
                return false;
            }

            return this.Equals((PointF)obj);
        }

        public bool Equals(PointF other)
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