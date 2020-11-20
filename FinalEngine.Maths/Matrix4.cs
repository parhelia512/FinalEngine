// <copyright file="Matrix4.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    public struct Matrix4 : IEquatable<Matrix4>
    {
        public static readonly Matrix4 Identity = new Matrix4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1));

        public static readonly Matrix4 One = new Matrix4(Vector4.One, Vector4.One, Vector4.One, Vector4.One);

        public static readonly Matrix4 Zero = new Matrix4(Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero);

        public Matrix4(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
        {
            this.Row0 = row0;
            this.Row1 = row1;
            this.Row2 = row2;
            this.Row3 = row3;
        }

        public Vector4 Row0 { get; set; }

        public Vector4 Row1 { get; set; }

        public Vector4 Row2 { get; set; }

        public Vector4 Row3 { get; set; }

        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Matrix4 left, Matrix4 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix4))
            {
                return false;
            }

            return this.Equals((Matrix4)obj);
        }

        public bool Equals(Matrix4 other)
        {
            return this.Row0 == other.Row0 &&
                   this.Row1 == other.Row1 &&
                   this.Row2 == other.Row2 &&
                   this.Row3 == other.Row3;
        }

        public override int GetHashCode()
        {
            return new { this.Row0, this.Row1, this.Row2, this.Row3 }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.Row0}\n{this.Row1}\n{this.Row2}\n{this.Row3})";
        }
    }
}