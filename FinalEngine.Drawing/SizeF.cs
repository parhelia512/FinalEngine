// <copyright file="SizeF.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing
{
    using System;

    public struct SizeF : IEquatable<SizeF>
    {
        public static readonly SizeF Empty = new SizeF(0, 0);

        public SizeF(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        public float Height { get; set; }

        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        public float Width { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is SizeF))
            {
                return false;
            }

            return this.Equals((SizeF)obj);
        }

        public bool Equals(SizeF other)
        {
            return this.Width == other.Width &&
                   this.Height == other.Height;
        }

        public override int GetHashCode()
        {
            return new { this.Width, this.Height }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.Width}, {this.Height})";
        }
    }
}