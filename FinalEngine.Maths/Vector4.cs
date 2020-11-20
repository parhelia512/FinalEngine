// <copyright file="Vector4.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    public struct Vector4 : IEquatable<Vector4>
    {
        public static readonly Vector4 NegativeInfinity = new Vector4(
            float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity);

        public static readonly Vector4 One = new Vector4(1, 1, 1, 1);

        public static readonly Vector4 PositiveInfinity = new Vector4(
            float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity);

        public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);

        public Vector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public float W { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public static implicit operator Vector4(Vector2 vector)
        {
            return new Vector4(vector.X, vector.Y, 0, 0);
        }

        public static implicit operator Vector4(Vector3 vector)
        {
            return new Vector4(vector.X, vector.Y, vector.Z, 0);
        }

        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            float x = left.X - right.X;
            float y = left.Y - right.Y;
            float z = left.Z - right.Z;
            float w = left.W - right.W;

            return new Vector4(x, y, z, w);
        }

        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !left.Equals(right);
        }

        public static Vector4 operator *(Vector4 left, Vector4 right)
        {
            float x = left.X * right.X;
            float y = left.Y * right.Y;
            float z = left.Z * right.Z;
            float w = left.W * right.W;

            return new Vector4(x, y, z, w);
        }

        public static Vector4 operator /(Vector4 left, Vector4 right)
        {
            float x = left.X / right.X;
            float y = left.Y / right.Y;
            float z = left.Z / right.Z;
            float w = left.W / right.W;

            return new Vector4(x, y, z, w);
        }

        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            float x = left.X + right.X;
            float y = left.Y + right.Y;
            float z = left.Z + right.Z;
            float w = left.W + right.W;

            return new Vector4(x, y, z, w);
        }

        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector4))
            {
                return false;
            }

            return this.Equals((Vector4)obj);
        }

        public bool Equals(Vector4 other)
        {
            return this.X == other.X &&
                   this.Y == other.Y &&
                   this.Z == other.Z &&
                   this.W == other.W;
        }

        public override int GetHashCode()
        {
            return new { this.X, this.Y, this.Z, this.W }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y}, {this.Z}, {this.W})";
        }
    }
}