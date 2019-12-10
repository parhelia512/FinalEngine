namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///   Represents a 2x2 matrix.
    /// </summary>
    /// <seealso cref="System.IEquatable{FinalEngine.Maths.Matrix2}"/>
    public struct Matrix2 : IEquatable<Matrix2>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="Matrix2"/> struct.
        /// </summary>
        /// <param name="row0">
        ///   The first row of this <see cref="Matrix2"/>.
        /// </param>
        /// <param name="row1">
        ///   The second row of this <see cref="Matrix2"/>.
        /// </param>
        public Matrix2(Vector2 row0, Vector2 row1)
        {
            Row0 = row0;
            Row1 = row1;
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
        ///   The left operand.
        /// </param>
        /// <param name="right">
        ///   The right operand.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="left"/> and <paramref name="right"/> parameters are not equal.
        /// </returns>
        public static bool operator !=(Matrix2 left, Matrix2 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   The left operand.
        /// </param>
        /// <param name="right">
        ///   The right operand.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="left"/> and <paramref name="right"/> parameters are equal.
        /// </returns>
        public static bool operator ==(Matrix2 left, Matrix2 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">
        ///   Specifies the <see cref="System.Object"/> to compare with this instance.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Matrix2))
            {
                return false;
            }

            return Equals((Matrix2)obj);
        }

        /// <summary>
        ///   Determines whether the specified <paramref name="other"/> parameter, is equal to this <see cref="Matrix2"/>.
        /// </summary>
        /// <param name="other">
        ///   Specifies the <see cref="Matrix2"/> to compare with this <see cref="Matrix2"/>.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="other"/> parameter is equal to this <see cref="Matrix2"/>; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Matrix2 other)
        {
            return Row0 == other.Row0 &&
                   Row1 == other.Row1;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { Row0, Row1 }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({ Row0 }\n{ Row1 })";
        }
    }
}