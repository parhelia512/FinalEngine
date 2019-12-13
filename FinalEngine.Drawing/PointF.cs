namespace FinalEngine.Drawing
{
    using System;

    /// <summary>
    ///   Represents a pair of single-precision floating point coordinates that defines a point on a two-dimensional plane.
    /// </summary>
    /// <seealso cref="System.IEquatable{FinalEngine.Drawing.PointF}"/>
    public struct PointF : IEquatable<PointF>
    {
        /// <summary>
        ///   Represents a <see cref="PointF"/> where all coordinates have been set to zero.
        /// </summary>
        public static readonly PointF Empty = new PointF(0, 0);

        /// <summary>
        ///   Initializes a new instance of the <see cref="PointF"/> struct.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="float"/> that represents the X coordinate of this <see cref="PointF"/>.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="float"/> that represents the Y coordinate of this <see cref="PointF"/>.
        /// </param>
        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="PointF"/> is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="PointF"/> is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the X coordinate of this <see cref="PointF"/>.
        /// </summary>
        /// <value>
        ///   The X coordinate of this <see cref="PointF"/>.
        /// </value>
        public float X { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the Y coordinate of this <see cref="PointF"/>.
        /// </summary>
        /// <value>
        ///   The Y coordinate of this <see cref="PointF"/>.
        /// </value>
        public float Y { get; set; }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object"/>, is equal to this instance.
        /// </summary>
        /// <param name="obj">
        ///   The <see cref="System.Object"/> to compare with this instance.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is PointF))
            {
                return false;
            }

            return Equals((PointF)obj);
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
        public bool Equals(PointF other)
        {
            return X == other.X &&
                   Y == other.Y;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { X, Y }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({ X }, { Y })";
        }
    }
}