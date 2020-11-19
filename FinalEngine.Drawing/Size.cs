// <copyright file="Size.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing
{
    using System;

    /// <summary>
    ///     Represents a pair of integers that defines a two dimensional space.
    /// </summary>
    /// <seealso cref="IEquatable{Size}"/>
    public struct Size : IEquatable<Size>
    {
        /// <summary>
        ///     Represents a <see cref="Size"/> where the dimensions have been set to zero.
        /// </summary>
        public static readonly Size Empty = new Size(0, 0);

        /// <summary>
        ///     Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">
        ///     Specifies a <see cref="int"/> that represents the width of this <see cref="Size"/>.
        /// </param>
        /// <param name="height">
        ///     Specifies a <see cref="int"/> that represents the height of this <see cref="Size"/>.
        /// </param>
        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        ///     Gets or sets a <see cref="int"/> that represents the height of this <see cref="Size"/>.
        /// </summary>
        /// <value>
        ///     The height of this <see cref="Size"/>.
        /// </value>
        public int Height { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="Size"/> is empty.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this <see cref="Size"/> is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        /// <summary>
        ///     Gets or sets a <see cref="int"/> that represents the width of this <see cref="Size"/>.
        /// </summary>
        /// <value>
        ///     The width of this <see cref="Size"/>.
        /// </value>
        public int Width { get; set; }

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
            if (!(obj is Size))
            {
                return false;
            }

            return this.Equals((Size)obj);
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
        public bool Equals(Size other)
        {
            return this.Width == other.Width &&
                   this.Height == other.Height;
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
            return new { this.Width, this.Height }.GetHashCode();
        }

        /// <summary>
        ///     Converts to string.
        /// </summary>
        /// <returns>
        ///     A <see cref="string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({this.Width}, {this.Height})";
        }
    }
}