namespace FinalEngine.Maths
{
    using System;

    /// <summary>
    ///   Represents a 4D vector with four single-precision floating point numbers.
    /// </summary>
    /// <seealso cref="System.IEquatable{FinalEngine.Maths.Vector4}"/>
    public struct Vector4 : IEquatable<Vector4>
    {
        /// <summary>
        ///   Represents a <see cref="Vector4"/> where each component is set to <see cref="float.NegativeInfinity"/>.
        /// </summary>
        public static readonly Vector4 NegativeInfinity = new Vector4(float.NegativeInfinity,
                                                                      float.NegativeInfinity,
                                                                      float.NegativeInfinity,
                                                                      float.NegativeInfinity);

        /// <summary>
        ///   Represents a <see cref="Vector4"/> where each component is set to one.
        /// </summary>
        public static readonly Vector4 One = new Vector4(1, 1, 1, 1);

        /// <summary>
        ///   Represents a <see cref="Vector4"/> where each component is set to <see cref="float.PositiveInfinity"/>.
        /// </summary>
        public static readonly Vector4 PositiveInfinity = new Vector4(float.PositiveInfinity,
                                                                      float.PositiveInfinity,
                                                                      float.PositiveInfinity,
                                                                      float.PositiveInfinity);

        /// <summary>
        ///   Represents a <see cref="Vector4"/> where each component is set to zero.
        /// </summary>
        public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Vector4"/> struct.
        /// </summary>
        /// <param name="x">
        ///   The X-coordinate of this <see cref="Vector4"/>.
        /// </param>
        /// <param name="y">
        ///   The Y-coordinate of this <see cref="Vector4"/>.
        /// </param>
        /// <param name="z">
        ///   The Z-coordinate of this <see cref="Vector4"/>.
        /// </param>
        /// <param name="w">
        ///   The W-coordinate of this <see cref="Vector4"/>.
        /// </param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        ///   Gets or sets a value that represent the W-coordinate of this <see cref="Vector4"/>
        /// </summary>
        /// <value>
        ///   The W-coordinate of this <see cref="Vector4"/>
        /// </value>
        public float W { get; set; }

        /// <summary>
        ///   Gets or sets a value that represents the X-coordinate of this <see cref="Vector4"/>
        /// </summary>
        /// <value>
        ///   The X-coordinate of this <see cref="Vector4"/>.
        /// </value>
        public float X { get; set; }

        /// <summary>
        ///   Gets or sets a value that represents the Y-coordinate of this <see cref="Vector4"/>
        /// </summary>
        /// <value>
        ///   The Y-coordinate of this <see cref="Vector4"/>.
        /// </value>
        public float Y { get; set; }

        /// <summary>
        ///   Gets or sets a value that represents the Z-coordinate of this <see cref="Vector4"/>
        /// </summary>
        /// <value>
        ///   The Z-coordinate of this <see cref="Vector4"/>.
        /// </value>
        public float Z { get; set; }

        public static implicit operator Vector4(Vector2 vector)
        {
            return new Vector4(vector.X, vector.Y, 0, 0);
        }

        public static implicit operator Vector4(Vector3 vector)
        {
            return new Vector4(vector.X, vector.Y, vector.Z, 0);
        }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///   Specifies left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies right operand.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="left"/> and <paramref name="right"/> parameters are not equal.
        /// </returns>
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   Specifies left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies right operand.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="left"/> and <paramref name="right"/> parameters are equal.
        /// </returns>
        public static bool operator ==(Vector4 left, Vector4 right)
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
            if (!(obj is Vector4))
            {
                return false;
            }

            return Equals((Vector4)obj);
        }

        /// <summary>
        ///   Determines whether the specified <paramref name="other"/> parameter, is equal to this <see cref="Vector4"/>.
        /// </summary>
        /// <param name="other">
        ///   Specifies the <see cref="Vector4"/> to compare with this <see cref="Vector4"/>.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="other"/> parameter is equal to this <see cref="Vector4"/>; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Vector4 other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z &&
                   W == other.W;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { X, Y, Z, W }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({ X }, { Y }, { Z }, { W })";
        }
    }
}