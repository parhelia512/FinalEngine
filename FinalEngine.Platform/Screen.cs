// <copyright file="Screen.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform
{
    using FinalEngine.Drawing;

    /// <summary>
    ///   Represents a display device (such as a monitor or screen on a mobile phone).
    /// </summary>
    public struct Screen
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="Screen"/> struct.
        /// </summary>
        /// <param name="size">
        ///   Specifies a <see cref="Size"/> that represents the size (in pixels) of this <see cref="Screen"/>.
        /// </param>
        public Screen(Size size)
        {
            this.Size = size;
        }

        /// <summary>
        ///   Gets a <see cref="Size"/> that represents the size (in pixels) of this <see cref="Screen"/>.
        /// </summary>
        /// <value>
        ///   The size (in pixels) of this <see cref="Screen"/>.
        /// </value>
        public Size Size { get; }
    }
}