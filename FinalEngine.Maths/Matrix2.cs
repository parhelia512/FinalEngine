// <copyright file="Matrix2.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///   Represents a 2x2 matrix.
    /// </summary>
    /// <seealso cref="IEquatable{Matrix2}"/>
    public struct Matrix2 : IEquatable<Matrix2>
    {
        /// <summary>
        ///   Represents a <see cref="Matrix2"/> that is an identity matrix.
        /// </summary>
        public static readonly Matrix2 Identity = new Matrix2(new Vector2(1, 0), new Vector2(0, 1));

        /// <summary>
        ///   Represents a <see cref="Matrix2"/> where each row is set to <see cref="Vector2.One"/>.
        /// </summary>
        public static readonly Matrix2 One = new Matrix2(Vector2.One, Vector2.One);

        /// <summary>
        ///   Represents a <see cref="Matrix2"/> where each row is set to <see cref="Vector2.Zero"/>.
        /// </summary>
        public static readonly Matrix2 Zero = new Matrix2(Vector2.Zero, Vector2.Zero);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Matrix2"/> struct.
        /// </summary>
        /// <param name="row0">
        ///   Specifies a <see cref="Vector2"/> that represents the first row of this <see cref="Matrix2"/>.
        /// </param>
        /// <param name="row1">
        ///   Specifies a <see cref="Vector2"/> that represents the second row of this <see cref="Matrix2"/>.
        /// </param>
        public Matrix2(Vector2 row0, Vector2 row1)
        {
            this.Row0 = row0;
            this.Row1 = row1;
        }

        /// <summary>
        ///   Gets or sets a <see cref="Vector2"/> that represents the first row of this <see cref="Matrix2"/>.
        /// </summary>
        /// <value>
        ///   The first row of this <see cref="Matrix2"/>.
        /// </value>
        public Vector2 Row0 { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="Vector2"/> that represents the second row of this <see cref="Matrix2"/>.
        /// </summary>
        /// <value>
        ///   The second row of this <see cref="Matrix2"/>.
        /// </value>
        public Vector2 Row1 { get; set; }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Matrix2"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Matrix2"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator !=(Matrix2 left, Matrix2 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Matrix2"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Matrix2"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator ==(Matrix2 left, Matrix2 right)
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
            if (!(obj is Matrix2))
            {
                return false;
            }

            return this.Equals((Matrix2)obj);
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
        public bool Equals(Matrix2 other)
        {
            return this.Row0 == other.Row0 &&
                   this.Row1 == other.Row1;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { this.Row0, this.Row1 }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({this.Row0}\n{this.Row1})";
        }
    }
}