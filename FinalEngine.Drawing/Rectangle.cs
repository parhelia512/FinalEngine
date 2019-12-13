﻿namespace FinalEngine.Drawing
{
    using System;

    /// <summary>
    ///   Represents a rectangular region (defined by four integers) on a two dimensional plane.
    /// </summary>
    /// <seealso cref="System.IEquatable{FinalEngine.Drawing.Rectangle}"/>
    public struct Rectangle : IEquatable<Rectangle>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="int"/> that represents the X coordinate of this <see cref="Rectangle"/>.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="int"/> that represents the Y coordinate of this <see cref="Rectangle"/>.
        /// </param>
        /// <param name="width">
        ///   Specifies a <see cref="int"/> that represents the width of this <see cref="Rectangle"/>.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="int"/> that represents the height of this <see cref="Rectangle"/>.
        /// </param>
        public Rectangle(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="location">
        ///   Specifies a <see cref="Point"/> that represents the location of this <see cref="Rectangle"/>.
        /// </param>
        /// <param name="size">
        ///   Specifies a <see cref="Size"/> that represents the size of this <see cref="Rectangle"/>.
        /// </param>
        public Rectangle(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        /// <summary>
        ///   Gets a <see cref="int"/> that represents the height of this <see cref="Rectangle"/>.
        /// </summary>
        /// <value>
        ///   The height of this <see cref="Rectangle"/>.
        /// </value>
        public int Height
        {
            get { return Size.Height; }
        }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="Rectangle"/> is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="Rectangle"/> is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty
        {
            get { return Location.IsEmpty && Size.IsEmpty; }
        }

        /// <summary>
        ///   Gets or sets a <see cref="Point"/> that represents the location of this <see cref="Rectangle"/>.
        /// </summary>
        /// <value>
        ///   The location of this <see cref="Rectangle"/>.
        /// </value>
        public Point Location { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="Size"/> that represents the size of this <see cref="Rectangle"/>.
        /// </summary>
        /// <value>
        ///   The size of this <see cref="Rectangle"/>.
        /// </value>
        public Size Size { get; set; }

        /// <summary>
        ///   Gets a <see cref="int"/> that represents the width of this <see cref="Rectangle"/>.
        /// </summary>
        /// <value>
        ///   The width of this <see cref="Rectangle"/>.
        /// </value>
        public int Width
        {
            get { return Size.Width; }
        }

        /// <summary>
        ///   Gets a <see cref="int"/> that represents the X coordinate of this <see cref="Rectangle"/>.
        /// </summary>
        /// <value>
        ///   The X coordinate of this <see cref="Rectangle"/>.
        /// </value>
        public int X
        {
            get { return Location.X; }
        }

        /// <summary>
        ///   Gets a <see cref="int"/> that represents the Y coordinate of this <see cref="Rectangle"/>.
        /// </summary>
        /// <value>
        ///   The Y coordinate of this <see cref="Rectangle"/>.
        /// </value>
        public int Y
        {
            get { return Location.Y; }
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
        public bool Equals(Rectangle other)
        {
            return Location.Equals(other.Location) && Size.Equals(other.Size);
        }

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
            if (!(obj is Rectangle))
            {
                return false;
            }

            return Equals((Rectangle)obj);
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return new { Location, Size }.GetHashCode();
        }

        /// <summary>
        ///   Converts to string.
        /// </summary>
        /// <returns>
        ///   A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"({ Location }, { Size }";
        }
    }
}