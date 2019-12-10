namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///   Represents a 4x4 matrix.
    /// </summary>
    /// <seealso cref="System.IEquatable{FinalEngine.Maths.Matrix4}"/>
    public struct Matrix4 : IEquatable<Matrix4>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="Matrix4"/> struct.
        /// </summary>
        /// <param name="row0">
        ///   Specifies the first row of this <see cref="Matrix4"/>.
        /// </param>
        /// <param name="row1">
        ///   Specifies the second row of this <see cref="Matrix4"/>.
        /// </param>
        /// <param name="row2">
        ///   Specifies the third row of this <see cref="Matrix4"/>.
        /// </param>
        /// <param name="row3">
        ///   Specifies the fourth row of this <see cref="Matrix4"/>.
        /// </param>
        public Matrix4(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
            Row3 = row3;
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
        ///   The left operand.
        /// </param>
        /// <param name="right">
        ///   The right operand.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="left"/> and <paramref name="right"/> parameters are not equal.
        /// </returns>
        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return !left.Equals(right);
        }

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
        ///   <c>true</c> if the specified <paramref name="left"/> and <paramref name="right"/> parameters are equal.
        /// </returns>
        public static bool operator ==(Matrix4 left, Matrix4 right)
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
            if (!(obj is Matrix4))
            {
                return false;
            }

            return Equals((Matrix4)obj);
        }

        /// <summary>
        ///   Determines whether the specified <paramref name="other"/> parameter, is equal to this <see cref="Matrix4"/>.
        /// </summary>
        /// <param name="other">
        ///   Specifies the <see cref="Matrix4"/> to compare with this <see cref="Matrix4"/>.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="other"/> parameter is equal to this <see cref="Matrix4"/>; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Matrix4 other)
        {
            return Row0 == other.Row0 &&
                   Row1 == other.Row1 &&
                   Row2 == other.Row2 &&
                   Row3 == other.Row3;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { Row0, Row1, Row2, Row3 }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({ Row0 }\n{ Row1 }\n{ Row2 }\n{ Row3 })";
        }
    }
}