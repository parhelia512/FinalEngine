// <copyright file="Vector4.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///     Represents a 4D vector with four single-precision floating point numbers.
    /// </summary>
    /// <seealso cref="IEquatable{Vector4}"/>
    public struct Vector4 : IEquatable<Vector4>
    {
        /// <summary>
        ///     Represents a <see cref="Vector4"/> where each component is set to <see cref="float.NegativeInfinity"/>.
        /// </summary>
        public static readonly Vector4 NegativeInfinity = new Vector4(
            float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity);

        /// <summary>
        ///     Represents a <see cref="Vector4"/> where each component is set to one.
        /// </summary>
        public static readonly Vector4 One = new Vector4(1, 1, 1, 1);

        /// <summary>
        ///     Represents a <see cref="Vector4"/> where each component is set to <see cref="float.PositiveInfinity"/>.
        /// </summary>
        public static readonly Vector4 PositiveInfinity = new Vector4(
            float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity);

        /// <summary>
        ///     Represents a <see cref="Vector4"/> where each component is set to zero.
        /// </summary>
        public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);

        /// <summary>
        ///     Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="x">
        ///     Specifies a <see cref="float"/> that represents the X coordinate of this <see cref="Vector4"/>.
        /// </param>
        /// <param name="y">
        ///     Specifies a <see cref="float"/> that represents the Y coordinate of this <see cref="Vector4"/>..
        /// </param>
        /// <param name="z">
        ///     Specifies a <see cref="float"/> that represents the Z coordinate of this <see cref="Vector4"/>.
        /// </param>
        /// <param name="w">
        ///     Specifies a <see cref="float"/> that represents the W coordinate of this <see cref="Vector4"/>.
        /// </param>
        public Vector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        /// <summary>
        ///     Gets or sets a <see cref="float"/> that represents the W coordinate of this <see cref="Vector4"/>.
        /// </summary>
        /// <value>
        ///     The W coordinate of this <see cref="Vector4"/>.
        /// </value>
        public float W { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="float"/> that represents the X coordinate of this <see cref="Vector4"/>.
        /// </summary>
        /// <value>
        ///     The X coordinate of this <see cref="Vector4"/>.
        /// </value>
        public float X { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="float"/> that represents the Y coordinate of this <see cref="Vector4"/>.
        /// </summary>
        /// <value>
        ///     The Y coordinate of this <see cref="Vector4"/>.
        /// </value>
        public float Y { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="float"/> that represents the Z coordinate of this <see cref="Vector4"/>.
        /// </summary>
        /// <value>
        ///     The Z coordinate of this <see cref="Vector4"/>.
        /// </value>
        public float Z { get; set; }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Vector2"/> to <see cref="Vector4"/>.
        /// </summary>
        /// <param name="vector">
        ///     Specifies a <see cref="Vector2"/> that represents the vector.
        /// </param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator Vector4(Vector2 vector)
        {
            return new Vector4(vector.X, vector.Y, 0, 0);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Vector3"/> to <see cref="Vector4"/>.
        /// </summary>
        /// <param name="vector">
        ///     Specifies a <see cref="Vector3"/> that represents the vector.
        /// </param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator Vector4(Vector3 vector)
        {
            return new Vector4(vector.X, vector.Y, vector.Z, 0);
        }

        /// <summary>
        ///     Implements the operator -.
        /// </summary>
        /// <param name="left">
        ///     Specifies a <see cref="Vector4"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///     Specifies a <see cref="Vector4"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            float x = left.X - right.X;
            float y = left.Y - right.Y;
            float z = left.Z - right.Z;
            float w = left.W - right.W;

            return new Vector4(x, y, z, w);
        }

        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///     Specifies a <see cref="Vector4"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///     Specifies a <see cref="Vector4"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="left">
        ///     Specifies a <see cref="Vector4"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///     Specifies a <see cref="Vector4"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static Vector4 operator *(Vector4 left, Vector4 right)
        {
            float x = left.X * right.X;
            float y = left.Y * right.Y;
            float z = left.Z * right.Z;
            float w = left.W * right.W;

            return new Vector4(x, y, z, w);
        }

        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="left">
        ///     Specifies a <see cref="Vector4"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///     Specifies a <see cref="Vector4"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static Vector4 operator /(Vector4 left, Vector4 right)
        {
            float x = left.X / right.X;
            float y = left.Y / right.Y;
            float z = left.Z / right.Z;
            float w = left.W / right.W;

            return new Vector4(x, y, z, w);
        }

        /// <summary>
        ///     Implements the operator +.
        /// </summary>
        /// <param name="left">
        ///     Specifies a <see cref="Vector4"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///     Specifies a <see cref="Vector4"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            float x = left.X + right.X;
            float y = left.Y + right.Y;
            float z = left.Z + right.Z;
            float w = left.W + right.W;

            return new Vector4(x, y, z, w);
        }

        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///     Specifies a <see cref="Vector4"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///     Specifies a <see cref="Vector4"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">
        ///     The <see cref="object"/> to compare with this instance.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object"/> is equal to this instance;
        ///     otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector4))
            {
                return false;
            }

            return this.Equals((Vector4)obj);
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">
        ///     An object to compare with this object.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the current object is equal to the <paramref
        ///     name="other">other</paramref> parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Vector4 other)
        {
            return this.X == other.X &&
                   this.Y == other.Y &&
                   this.Z == other.Z &&
                   this.W == other.W;
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data
        ///     structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { this.X, this.Y, this.Z, this.W }.GetHashCode();
        }

        /// <summary>
        ///     Converts to string.
        /// </summary>
        /// <returns>
        ///     A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({this.X}, {this.Y}, {this.Z}, {this.W})";
        }
    }
}