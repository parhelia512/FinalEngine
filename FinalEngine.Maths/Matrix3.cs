// <copyright file="Matrix3.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    public struct Matrix3 : IEquatable<Matrix3>
    {
        public static readonly Matrix3 Identity = new Matrix3(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1));

        public static readonly Matrix3 One = new Matrix3(Vector3.One, Vector3.One, Vector3.One);

        public static readonly Matrix3 Zero = new Matrix3(Vector3.Zero, Vector3.Zero, Vector3.Zero);

        public Matrix3(Vector3 row0, Vector3 row1, Vector3 row2)
        {
            this.Row0 = row0;
            this.Row1 = row1;
            this.Row2 = row2;
        }

        public Vector3 Row0 { get; set; }

        public Vector3 Row1 { get; set; }

        public Vector3 Row2 { get; set; }

        public static bool operator !=(Matrix3 left, Matrix3 right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Matrix3 left, Matrix3 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix3))
            {
                return false;
            }

            return this.Equals((Matrix3)obj);
        }

        public bool Equals(Matrix3 other)
        {
            return this.Row0 == other.Row0 &&
                   this.Row1 == other.Row1 &&
                   this.Row2 == other.Row2;
        }

        public override int GetHashCode()
        {
            return new { this.Row0, this.Row1, this.Row2 }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.Row0}\n{this.Row1}\n{this.Row2})";
        }
    }
}