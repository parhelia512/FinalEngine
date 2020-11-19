// <copyright file="Matrix3.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///     Represents a 3x3 matrix.
    /// </summary>
    /// <seealso cref="IEquatable{Matrix3}"/>
    public struct Matrix3 : IEquatable<Matrix3>
    {
        /// <summary>
        ///     Represents a <see cref="Matrix3"/> that is an identity matrix.
        /// </summary>
        public static readonly Matrix3 Identity = new Matrix3(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1));

        /// <summary>
        ///     Represents a <see cref="Matrix3"/> where each row is set to <see cref="Vector3.One"/>.
        /// </summary>
        public static readonly Matrix3 One = new Matrix3(Vector3.One, Vector3.One, Vector3.One);

        /// <summary>
        ///     Represents a <see cref="Matrix3"/> where each row is set to <see cref="Vector3.Zero"/>.
        /// </summary>
        public static readonly Matrix3 Zero = new Matrix3(Vector3.Zero, Vector3.Zero, Vector3.Zero);

        /// <summary>
        ///     Initializes a new instance of the <see cref="Matrix3"/> struct.
        /// </summary>
        /// <param name="row0">
        ///     Specifies a <see cref="Vector3"/> that represents the first row of this <see cref="Matrix3"/>.
        /// </param>
        /// <param name="row1">
        ///     Specifies a <see cref="Vector3"/> that represents the second row of this <see cref="Matrix3"/>.
        /// </param>
        /// <param name="row2">
        ///     Specifies a <see cref="Vector3"/> that represents the third row of this <see cref="Matrix3"/>.
        /// </param>
        public Matrix3(Vector3 row0, Vector3 row1, Vector3 row2)
        {
            this.Row0 = row0;
            this.Row1 = row1;
            this.Row2 = row2;
        }

        /// <summary>
        ///     Gets or sets a <see cref="Vector3"/> that represents the first row of this <see cref="Matrix3"/>.
        /// </summary>
        /// <value>
        ///     The first row of this <see cref="Matrix3"/>.
        /// </value>
        public Vector3 Row0 { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="Vector3"/> that represents the second row of this <see cref="Matrix3"/>.
        /// </summary>
        /// <value>
        ///     The second row of this <see cref="Matrix3"/>.
        /// </value>
        public Vector3 Row1 { get; set; }

        /// <summary>
        ///     Gets or sets a <see cref="Vector3"/> that represents the third row of this <see cref="Matrix3"/>.
        /// </summary>
        /// <value>
        ///     The third row of this <see cref="Matrix3"/>.
        /// </value>
        public Vector3 Row2 { get; set; }

        /// <summary>
        ///     Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///     Specifies a <see cref="Matrix3"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///     Specifies a <see cref="Matrix3"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator !=(Matrix3 left, Matrix3 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///     Specifies a <see cref="Matrix3"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///     Specifies a <see cref="Matrix3"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///     The result of the operator.
        /// </returns>
        public static bool operator ==(Matrix3 left, Matrix3 right)
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
            if (!(obj is Matrix3))
            {
                return false;
            }

            return this.Equals((Matrix3)obj);
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
        public bool Equals(Matrix3 other)
        {
            return this.Row0 == other.Row0 &&
                   this.Row1 == other.Row1 &&
                   this.Row2 == other.Row2;
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
            return new { this.Row0, this.Row1, this.Row2 }.GetHashCode();
        }

        /// <summary>
        ///     Converts to string.
        /// </summary>
        /// <returns>
        ///     A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({this.Row0}\n{this.Row1}\n{this.Row2})";
        }
    }
}