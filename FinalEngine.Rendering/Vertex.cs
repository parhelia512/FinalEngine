// <copyright file="Vertex.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using System.Numerics;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct Vertex : IEquatable<Vertex>
    {
        /// <summary>
        ///   The size in bytes of a <see cref="Vertex"/>.
        /// </summary>
        public static readonly int SizeInBytes = Marshal.SizeOf<Vertex>();

        internal const int PositionRelativeOffset = 0;

        internal const int ColorRelativeOffset = 12;

        internal const int TextureCoordinateRelativeOffset = 28;

        [FieldOffset(PositionRelativeOffset)]
        private Vector3 position;

        [FieldOffset(ColorRelativeOffset)]
        private Vector4 color;

        [FieldOffset(TextureCoordinateRelativeOffset)]
        private Vector2 textureCoordinate;

        public Vertex(Vector3 position, Vector4 color, Vector2 textureCoordinate)
        {
            this.position = position;
            this.color = color;
            this.textureCoordinate = textureCoordinate;
        }

        public Vector3 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Vector4 Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public Vector2 TextureCoordinate
        {
            get { return this.textureCoordinate; }
            set { this.textureCoordinate = value; }
        }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vertex"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vertex"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator !=(Vertex left, Vertex right)
        {
            return !(left == right);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="Vertex"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="Vertex"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator ==(Vertex left, Vertex right)
        {
            return left.Equals(right);
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
            return obj is Vertex vertex && this.Equals(vertex);
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

            return (this.Position.GetHashCode() * Accumulator) +
                   (this.Color.GetHashCode() * Accumulator) +
                   (this.TextureCoordinate.GetHashCode() * Accumulator);
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
        public bool Equals(Vertex other)
        {
            return this.Position == other.Position &&
                   this.Color == other.Color &&
                   this.TextureCoordinate == other.TextureCoordinate;
        }
    }
}