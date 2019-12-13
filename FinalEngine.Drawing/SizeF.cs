namespace FinalEngine.Drawing
{
    using System;

    /// <summary>
    ///   Represents a pair of single precision floating-points that defines a two dimensional space.
    /// </summary>
    /// <seealso cref="System.IEquatable{FinalEngine.Drawing.SizeF}"/>
    public struct SizeF : IEquatable<SizeF>
    {
        /// <summary>
        ///   Represents a <see cref="SizeF"/> where the dimensions have been set to zero.
        /// </summary>
        public static readonly SizeF Empty = new SizeF(0, 0);

        /// <summary>
        ///   Initializes a new instance of the <see cref="SizeF"/> struct.
        /// </summary>
        /// <param name="width">
        ///   Specifies a <see cref="float"/> that represents the width of this <see cref="SizeF"/>.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="float"/> that represents the height of this <see cref="SizeF"/>.
        /// </param>
        public SizeF(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the height of this <see cref="SizeF"/>.
        /// </summary>
        /// <value>
        ///   The height of this <see cref="SizeF"/>.
        /// </value>
        public float Height { get; set; }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="SizeF"/> is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="SizeF"/> is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="float"/> that represents the width of this <see cref="SizeF"/>.
        /// </summary>
        /// <value>
        ///   The width of this <see cref="SizeF"/>.
        /// </value>
        public float Width { get; set; }

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
            if (!(obj is SizeF))
            {
                return false;
            }

            return Equals((SizeF)obj);
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
        public bool Equals(SizeF other)
        {
            return Width == other.Width &&
                   Height == other.Height;
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { Width, Height }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({ Width }, { Height })";
        }
    }
}