// <copyright file="Vector2.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    public struct Vector2 : IEquatable<Vector2>
    {
        public static Vector2 Down = new Vector2(0, -1);

        public static Vector2 Left = new Vector2(-1, 0);

        public static Vector2 NegativeInfinity = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        public static Vector2 One = new Vector2(1, 1);

        public static Vector2 PositiveInfinity = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        public static Vector2 Right = new Vector2(1, 0);

        public static Vector2 Up = new Vector2(0, 1);

        public static Vector2 Zero = new Vector2(0, 0);

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public static implicit operator Vector2(Vector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        public static implicit operator Vector2(Vector4 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            float x = left.X - right.X;
            float y = left.Y - right.Y;

            return new Vector2(x, y);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !left.Equals(right);
        }

        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            float x = left.X * right.X;
            float y = left.Y * right.Y;

            return new Vector2(x, y);
        }

        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            float x = left.X / right.X;
            float y = left.Y / right.Y;

            return new Vector2(x, y);
        }

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            float x = left.X + right.X;
            float y = left.Y + right.Y;

            return new Vector2(x, y);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
            {
                return false;
            }

            return this.Equals((Vector2)obj);
        }

        public bool Equals(Vector2 other)
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