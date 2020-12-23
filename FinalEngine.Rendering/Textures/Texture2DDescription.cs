// <copyright file="Texture2DDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Textures
{
    using System;

    public struct Texture2DDescription : IEquatable<Texture2DDescription>
    {
        private TextureFilterMode? magFilter;

        private TextureFilterMode? minFilter;

        private PixelType? pixelType;

        private TextureWrapMode? wrapS;

        private TextureWrapMode? wrapT;

        public int Height { get; set; }

        public TextureFilterMode MagFilter
        {
            get { return this.magFilter ?? TextureFilterMode.Linear; }
            set { this.magFilter = value; }
        }

        public TextureFilterMode MinFilter
        {
            get { return this.minFilter ?? TextureFilterMode.Linear; }
            set { this.minFilter = value; }
        }

        public PixelType PixelType
        {
            get { return this.pixelType ?? PixelType.Byte; }
            set { this.pixelType = value; }
        }

        public int Width { get; set; }

        public TextureWrapMode WrapS
        {
            get { return this.wrapS ?? TextureWrapMode.Repeat; }
            set { this.wrapS = value; }
        }

        public TextureWrapMode WrapT
        {
            get { return this.wrapT ?? TextureWrapMode.Repeat; }
            set { this.wrapT = value; }
        }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Texture2DDescription"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Texture2DDescription"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator !=(Texture2DDescription left, Texture2DDescription right)
        {
            return !(left == right);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Texture2DDescription"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Texture2DDescription"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator ==(Texture2DDescription left, Texture2DDescription right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///   Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">
        ///   An object to compare with this object.
        /// </param>
        /// <returns>
        ///   <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
        /// </returns>
        public bool Equals(Texture2DDescription other)
        {
            return this.MinFilter == other.MinFilter &&
                   this.MagFilter == other.magFilter &&
                   this.WrapS == other.WrapS &&
                   this.WrapT == other.WrapT &&
                   this.PixelType == other.PixelType &&
                   this.Width == other.Width &&
                   this.Height == other.Height;
        }

        /// <summary>
        ///   Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">
        ///   The object to compare with the current instance.
        /// </param>
        /// <returns>
        ///   <see langword="true"/> if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, <see langword="false"/>.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return obj is Texture2DDescription description && this.Equals(description);
        }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            const int Accumulator = 17;

            return (this.MinFilter.GetHashCode() * Accumulator) +
                   (this.MagFilter.GetHashCode() * Accumulator) +
                   (this.WrapS.GetHashCode() * Accumulator) +
                   (this.WrapT.GetHashCode() * Accumulator) +
                   (this.PixelType.GetHashCode() * Accumulator) +
                   (this.Width.GetHashCode() * Accumulator) +
                   (this.Height.GetHashCode() * Accumulator);
        }
    }
}