// <copyright file="Matrix4.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///   Represents a 4x4 matrix.
    /// </summary>
    /// <seealso cref="IEquatable{Matrix4}"/>
    public struct Matrix4 : IEquatable<Matrix4>
    {
        /// <summary>
        ///   Represents a <see cref="Matrix4"/> that is an identity matrix.
        /// </summary>
        public static readonly Matrix4 Identity = new Matrix4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1));

        /// <summary>
        ///   Represents a <see cref="Matrix4"/> where each row is set to <see cref="Vector4.One"/>.
        /// </summary>
        public static readonly Matrix4 One = new Matrix4(Vector4.One, Vector4.One, Vector4.One, Vector4.One);

        /// <summary>
        ///   Represents a <see cref="Matrix4"/> where each row is set to <see cref="Vector4.Zero"/>.
        /// </summary>
        public static readonly Matrix4 Zero = new Matrix4(Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Matrix4"/> struct.
        /// </summary>
        /// <param name="row0">
        ///   Specifies a <see cref="Vector4"/> that represents the first row of this <see cref="Matrix4"/>.
        /// </param>
        /// <param name="row1">
        ///   Specifies a <see cref="Vector4"/> that represents the second row of this <see cref="Matrix4"/>.
        /// </param>
        /// <param name="row2">
        ///   Specifies a <see cref="Vector4"/> that represents the third row of this <see cref="Matrix4"/>.
        /// </param>
        /// <param name="row3">
        ///   Specifies a <see cref="Vector4"/> that represents the fourth row of this <see cref="Matrix4"/>.
        /// </param>
        public Matrix4(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
        {
            this.Row0 = row0;
            this.Row1 = row1;
            this.Row2 = row2;
            this.Row3 = row3;
        }

        /// <summary>
        ///   Gets or sets a <see cref="Vector4"/> that represents the first row of this <see cref="Matrix4"/>.
        /// </summary>
        /// <value>
        ///   The first row of this <see cref="Matrix4"/>.
        /// </value>
        public Vector4 Row0 { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="Vector4"/> that represents the second row of this <see cref="Matrix4"/>.
        /// </summary>
        /// <value>
        ///   The second row of this <see cref="Matrix4"/>.
        /// </value>
        public Vector4 Row1 { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="Vector4"/> that represents the third row of this <see cref="Matrix4"/>.
        /// </summary>
        /// <value>
        ///   The third row of this <see cref="Matrix4"/>.
        /// </value>
        public Vector4 Row2 { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="Vector4"/> that represents the fourth row of this <see cref="Matrix4"/>.
        /// </summary>
        /// <value>
        ///   The fourth row of this <see cref="Matrix4"/>.
        /// </value>
        public Vector4 Row3 { get; set; }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Matrix4"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Matrix4"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Matrix4"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Matrix4"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator ==(Matrix4 left, Matrix4 right)
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
            if (!(obj is Matrix4))
            {
                return false;
            }

            return this.Equals((Matrix4)obj);
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
        public bool Equals(Matrix4 other)
        {
            return this.Row0 == other.Row0 &&
                   this.Row1 == other.Row1 &&
                   this.Row2 == other.Row2 &&
                   this.Row3 == other.Row3;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { this.Row0, this.Row1, this.Row2, this.Row3 }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({this.Row0}\n{this.Row1}\n{this.Row2}\n{this.Row3})";
        }
    }
}