// <copyright file="Point.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing
{
    using System;

    /// <summary>
    ///   Represents a pair of integer coordinates that defines a point on a two-dimensional plane.
    /// </summary>
    /// <seealso cref="IEquatable{Point}"/>
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        ///   Represents a <see cref="Point"/> where all coordinates have been set to zero.
        /// </summary>
        public static readonly Point Empty = new Point(0, 0);

        /// <summary>
        ///   Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="int"/> that represents the X coordinate of this <see cref="Point"/>.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="int"/> that represents the Y coordinate of this <see cref="Point"/>.
        /// </param>
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="Point"/> is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="Point"/> is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty
        {
            get { return this.Equals(Empty); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="int"/> that represents the X coordinate of this <see cref="Point"/>.
        /// </summary>
        /// <value>
        ///   The X coordinate of this <see cref="Point"/>.
        /// </value>
        public int X { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="int"/> that represents the Y coordinate of this <see cref="Point"/>.
        /// </summary>
        /// <value>
        ///   The Y coordinate of this <see cref="Point"/>.
        /// </value>
        public int Y { get; set; }

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
            if (!(obj is Point))
            {
                return false;
            }

            return this.Equals((Point)obj);
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
        public bool Equals(Point other)
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