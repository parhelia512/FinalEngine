// <copyright file="Size.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing
{
    using System;

    public struct Size : IEquatable<Size>
    {
        public static readonly Size Empty = new Size(0, 0);

        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Height { get; set; }

        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        public int Width { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Size))
            {
                return false;
            }

            return this.Equals((Size)obj);
        }

        public bool Equals(Size other)
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