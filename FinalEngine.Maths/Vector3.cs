// <copyright file="Vector3.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///   Represents a 3D vector with three single-precision floating points.
    /// </summary>
    /// <seealso cref="IEquatable{Vector3}"/>
    public struct Vector3 : IEquatable<Vector3>
    {
        /// <summary>
        ///   Represents a <see cref="Vector3"/> that points backwards (0, 0, -1).
        /// </summary>
        public static readonly Vector3 Back = new Vector3(0, 0, -1);

        /// <summary>
        ///   Represents a <see cref="Vector3"/> that points down (0, -1, 0).
        /// </summary>
        public static readonly Vector3 Down = new Vector3(0, -1, 0);

        /// <summary>
        ///   Represents a <see cref="Vector3"/> that points forward (0, 0, 1).
        /// </summary>
        public static readonly Vector3 Forward = new Vector3(0, 0, 1);

        /// <summary>
        ///   Represents a <see cref="Vector3"/> that points left (-1, 0, 0).
        /// </summary>
        public static readonly Vector3 Left = new Vector3(-1, 0, 0);

        /// <summary>
        ///   Represent a <see cref="Vector3"/> where each component is set to <see cref="float.NegativeInfinity"/>.
        /// </summary>
        public static readonly Vector3 NegativeInfinity = new Vector3(
            float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity);

        /// <summary>
        ///   Represents a <see cref="Vector3"/> where each component is set to one.
        /// </summary>
        public static readonly Vector3 One = new Vector3(1, 1, 1);

        /// <summary>
        ///   Represents a <see cref="Vector3"/> where each component is set to <see cref="float.PositiveInfinity"/>.
        /// </summary>
        public static readonly Vector3 PositiveInfinity = new Vector3(
            float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity);

        /// <summary>
        ///   Represents a <see cref="Vector3"/> that points right (1, 0, 0).
        /// </summary>
        public static readonly Vector3 Right = new Vector3(1, 0, 0);

        /// <summary>
        ///   Represents a <see cref="Vector3"/> that points up (0, 1, 0).
        /// </summary>
        public static readonly Vector3 Up = new Vector3(0, 1, 0);

        /// <summary>
        ///   Represents a <see cref="Vector3"/> where each component is set to zero.
        /// </summary>
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Vector3"/> struct.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="float"/> that represents the X coordinate of this <see cref="Vector3"/>.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="float"/> that represents the Y coordinate of this <see cref="Vector3"/>.
        /// </param>
        /// <param name="z">
        ///   Specifies a <see cref="float"/> that represents the Z coordinate of this <see cref="Vector3"/>.
        /// </param>
        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the X coordinate of this <see cref="Vector3"/>.
        /// </summary>
        /// <value>
        ///   The X coordinate of this <see cref="Vector3"/>.
        /// </value>
        public float X { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the Y coordinate of this <see cref="Vector3"/>.
        /// </summary>
        /// <value>
        ///   The Y coordinate of this <see cref="Vector3"/>.
        /// </value>
        public float Y { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the Z coordinate of this <see cref="Vector3"/>.
        /// </summary>
        /// <value>
        ///   The Z coordinate of this <see cref="Vector3"/>.
        /// </value>
        public float Z { get; set; }

        /// <summary>
        ///   Performs an implicit conversion from <see cref="Vector2"/> to <see cref="Vector3"/>.
        /// </summary>
        /// <param name="vector">
        ///   Specifies a <see cref="Vector2"/> that represents the vector.
        /// </param>
        /// <returns>
        ///   The result of the conversion.
        /// </returns>
        public static implicit operator Vector3(Vector2 vector)
        {
            return new Vector3(vector.X, vector.Y, 0);
        }

        /// <summary>
        ///   Performs an implicit conversion from <see cref="Vector4"/> to <see cref="Vector3"/>.
        /// </summary>
        /// <param name="vector">
        ///   Specifies a <see cref="Vector4"/> that represents the vector.
        /// </param>
        /// <returns>
        ///   The result of the conversion.
        /// </returns>
        public static implicit operator Vector3(Vector4 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        ///   Implements the operator -.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector3"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector3"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            float x = left.X - right.X;
            float y = left.Y - right.Y;
            float z = left.Z - right.Z;

            return new Vector3(x, y, z);
        }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector3"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector3"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///   Implements the operator *.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector3"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector3"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            float x = left.X * right.X;
            float y = left.Y * right.Y;
            float z = left.Z * right.Z;

            return new Vector3(x, y, z);
        }

        /// <summary>
        ///   Implements the operator /.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector3"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector3"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static Vector3 operator /(Vector3 left, Vector3 right)
        {
            float x = left.X / right.X;
            float y = left.Y / right.Y;
            float z = left.Z / right.Z;

            return new Vector3(x, y, z);
        }

        /// <summary>
        ///   Implements the operator +.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector3"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector3"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            float x = left.X + right.X;
            float y = left.Y + right.Y;
            float z = left.Z + right.Z;

            return new Vector3(x, y, z);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector3"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector3"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///   Determines whether the specified <see cref="object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">
        ///   The <see cref="object"/> to compare with this instance.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3))
            {
                return false;
            }

            return this.Equals((Vector3)obj);
        }

        /// <summary>
        ///   Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">
        ///   An object to compare with this object.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Vector3 other)
        {
            return this.X == other.X &&
                   this.Y == other.Y &&
                   this.Z == other.Z;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { this.X, this.Y, this.Z }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({this.X}, {this.Y}, {this.Z})";
        }
    }
}