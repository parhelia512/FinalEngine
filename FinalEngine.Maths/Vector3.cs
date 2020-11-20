// <copyright file="Vector3.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    public struct Vector3 : IEquatable<Vector3>
    {
        public static readonly Vector3 Back = new Vector3(0, 0, -1);

        public static readonly Vector3 Down = new Vector3(0, -1, 0);

        public static readonly Vector3 Forward = new Vector3(0, 0, 1);

        public static readonly Vector3 Left = new Vector3(-1, 0, 0);

        public static readonly Vector3 NegativeInfinity = new Vector3(
            float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity);

        public static readonly Vector3 One = new Vector3(1, 1, 1);

        public static readonly Vector3 PositiveInfinity = new Vector3(
            float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity);

        public static readonly Vector3 Right = new Vector3(1, 0, 0);

        public static readonly Vector3 Up = new Vector3(0, 1, 0);

        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public static implicit operator Vector3(Vector2 vector)
        {
            return new Vector3(vector.X, vector.Y, 0);
        }

        public static implicit operator Vector3(Vector4 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            float x = left.X - right.X;
            float y = left.Y - right.Y;
            float z = left.Z - right.Z;

            return new Vector3(x, y, z);
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !left.Equals(right);
        }

        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            float x = left.X * right.X;
            float y = left.Y * right.Y;
            float z = left.Z * right.Z;

            return new Vector3(x, y, z);
        }

        public static Vector3 operator /(Vector3 left, Vector3 right)
        {
            float x = left.X / right.X;
            float y = left.Y / right.Y;
            float z = left.Z / right.Z;

            return new Vector3(x, y, z);
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            float x = left.X + right.X;
            float y = left.Y + right.Y;
            float z = left.Z + right.Z;

            return new Vector3(x, y, z);
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector3))
            {
                return false;
            }

            return this.Equals((Vector3)obj);
        }

        public bool Equals(Vector3 other)
        {
            return this.X == other.X &&
                   this.Y == other.Y &&
                   this.Z == other.Z;
        }

        public override int GetHashCode()
        {
            return new { this.X, this.Y, this.Z }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y}, {this.Z})";
        }
    }
}