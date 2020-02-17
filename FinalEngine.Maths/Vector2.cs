// <copyright file="Vector2.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///   Represents a 2D vector with two single-precision floating points.
    /// </summary>
    /// <seealso cref="IEquatable{Vector2}"/>
    public struct Vector2 : IEquatable<Vector2>
    {
        /// <summary>
        ///   Represents a <see cref="Vector2"/> that points down (0, -1).
        /// </summary>
        public static Vector2 Down = new Vector2(0, -1);

        /// <summary>
        ///   Represents a <see cref="Vector2"/> that points left (-1, 0).
        /// </summary>
        public static Vector2 Left = new Vector2(-1, 0);

        /// <summary>
        ///   Represents a <see cref="Vector2"/> where each component is set to <see cref="float.NegativeInfinity"/>.
        /// </summary>
        public static Vector2 NegativeInfinity = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        /// <summary>
        ///   Represents a <see cref="Vector2"/> where each component is set to one.
        /// </summary>
        public static Vector2 One = new Vector2(1, 1);

        /// <summary>
        ///   Represents a <see cref="Vector2"/> where each component is set to <see cref="float.PositiveInfinity"/>.
        /// </summary>
        public static Vector2 PositiveInfinity = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        /// <summary>
        ///   Represents a <see cref="Vector2"/> that points right (1, 0).
        /// </summary>
        public static Vector2 Right = new Vector2(1, 0);

        /// <summary>
        ///   Represents a <see cref="Vector2"/> that points up (0, 1).
        /// </summary>
        public static Vector2 Up = new Vector2(0, 1);

        /// <summary>
        ///   Represents a <see cref="Vector2"/> where each component is set to zero.
        /// </summary>
        public static Vector2 Zero = new Vector2(0, 0);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Vector2"/> struct.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="float"/> that represents the X coordinate of this <see cref="Vector2"/>.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="float"/> that represents the Y coordinate of this <see cref="Vector2"/>.
        /// </param>
        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the X coordinate of this <see cref="Vector2"/>.
        /// </summary>
        /// <value>
        ///   The X coordinate of this <see cref="Vector2"/>.
        /// </value>
        public float X { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the Y coordinate of this <see cref="Vector2"/>.
        /// </summary>
        /// <value>
        ///   The Y coordinate of this <see cref="Vector2"/>.
        /// </value>
        public float Y { get; set; }

        /// <summary>
        ///   Performs an implicit conversion from <see cref="Vector3"/> to <see cref="Vector2"/>.
        /// </summary>
        /// <param name="vector">
        ///   Specifies a <see cref="Vector3"/> that represents the vector.
        /// </param>
        /// <returns>
        ///   The result of the conversion.
        /// </returns>
        public static implicit operator Vector2(Vector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        /// <summary>
        ///   Performs an implicit conversion from <see cref="Vector4"/> to <see cref="Vector2"/>.
        /// </summary>
        /// <param name="vector">
        ///   Specifies a <see cref="Vector4"/> that represents the vector.
        /// </param>
        /// <returns>
        ///   The result of the conversion.
        /// </returns>
        public static implicit operator Vector2(Vector4 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        /// <summary>
        ///   Implements the operator -.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector2"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector2"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            float x = left.X - right.X;
            float y = left.Y - right.Y;

            return new Vector2(x, y);
        }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector2"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector2"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///   Implements the operator *.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector2"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector2"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            float x = left.X * right.X;
            float y = left.Y * right.Y;

            return new Vector2(x, y);
        }

        /// <summary>
        ///   Implements the operator /.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector2"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector2"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            float x = left.X / right.X;
            float y = left.Y / right.Y;

            return new Vector2(x, y);
        }

        /// <summary>
        ///   Implements the operator +.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector2"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector2"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            float x = left.X + right.X;
            float y = left.Y + right.Y;

            return new Vector2(x, y);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vector2"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vector2"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator ==(Vector2 left, Vector2 right)
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
            if (!(obj is Vector2))
            {
                return false;
            }

            return this.Equals((Vector2)obj);
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
        public bool Equals(Vector2 other)
        {
            return this.X == other.X &&
                   this.Y == other.Y;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { this.X, this.Y }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }
    }
}