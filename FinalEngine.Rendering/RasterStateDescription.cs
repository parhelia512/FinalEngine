// <copyright file="RasterStateDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;

    /// <summary>
    ///   Enumerates the available cull modes that determine which faces will be culled.
    /// </summary>
    public enum FaceCullMode
    {
        /// <summary>
        ///   Specifies front face culling.
        /// </summary>
        Front,

        /// <summary>
        ///   Specifies back face culling.
        /// </summary>
        Back,
    }

    /// <summary>
    ///   Enumerates the available rasterization modes that determine how a rasterizer will fill polygons.
    /// </summary>
    public enum RasterMode
    {
        /// <summary>
        ///   Specifies solid-filled polygons.
        /// </summary>
        Solid,

        /// <summary>
        ///   Specifies outlined/wire-frame polygons.
        /// </summary>
        Wireframe,
    }

    /// <summary>
    ///   Enumerates the available winding directions used to determine the front face of a primitive.
    /// </summary>
    public enum WindingDirection
    {
        /// <summary>
        ///   Specifies clockwise winding order.
        /// </summary>
        Clockwise,

        /// <summary>
        ///   Specifies counter-clockwise winding order.
        /// </summary>
        CounterClockwise,
    }

    public struct RasterStateDescription : IEquatable<RasterStateDescription>
    {
        private FaceCullMode? cullMode;

        private RasterMode? fillMode;

        private WindingDirection? windingDirection;

        public bool CullEnabled { get; set; }

        public FaceCullMode CullMode
        {
            get { return this.cullMode ?? FaceCullMode.Back; }
            set { this.cullMode = value; }
        }

        public RasterMode FillMode
        {
            get { return this.fillMode ?? RasterMode.Solid; }
            set { this.fillMode = value; }
        }

        public bool ScissorEnabled { get; set; }

        public WindingDirection WindingDirection
        {
            get { return this.windingDirection ?? WindingDirection.CounterClockwise; }
            set { this.windingDirection = value; }
        }

        /// <summary>
        ///   Implements the operator !=.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="RasterStateDescription"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="RasterStateDescription"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator !=(RasterStateDescription left, RasterStateDescription right)
        {
            return !(left == right);
        }

        /// <summary>
        ///   Implements the operator ==.
        /// </summary>
        /// <param name="left">
        ///   Specifies a <see cref="RasterStateDescription"/> that represents the left operand.
        /// </param>
        /// <param name="right">
        ///   Specifies a <see cref="RasterStateDescription"/> that represents the right operand.
        /// </param>
        /// <returns>
        ///   The result of the operator.
        /// </returns>
        public static bool operator ==(RasterStateDescription left, RasterStateDescription right)
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
        public bool Equals(RasterStateDescription other)
        {
            return this.CullEnabled == other.CullEnabled &&
                   this.CullMode == other.CullMode &&
                   this.FillMode == other.FillMode &&
                   this.ScissorEnabled == other.ScissorEnabled &&
                   this.WindingDirection == other.WindingDirection;
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
            return obj is RasterStateDescription description && this.Equals(description);
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

            return (this.CullEnabled.GetHashCode() * Accumulator) +
                   (this.CullMode.GetHashCode() * Accumulator) +
                   (this.FillMode.GetHashCode() * Accumulator) +
                   (this.ScissorEnabled.GetHashCode() * Accumulator) +
                   (this.WindingDirection.GetHashCode() * Accumulator);
        }
    }
}