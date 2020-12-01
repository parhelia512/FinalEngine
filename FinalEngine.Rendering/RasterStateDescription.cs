// <copyright file="RasterStateDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;

    public enum FaceCullMode
    {
        Front,

        Back,
    }

    public enum RasterMode
    {
        Solid,

        Wireframe,
    }

    public enum WindingDirection
    {
        Clockwise,

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

        public static bool operator !=(RasterStateDescription left, RasterStateDescription right)
        {
            return !(left == right);
        }

        public static bool operator ==(RasterStateDescription left, RasterStateDescription right)
        {
            return left.Equals(right);
        }

        public bool Equals(RasterStateDescription other)
        {
            return this.CullEnabled == other.CullEnabled &&
                   this.CullMode == other.CullMode &&
                   this.FillMode == other.FillMode &&
                   this.ScissorEnabled == other.ScissorEnabled &&
                   this.WindingDirection == other.WindingDirection;
        }

        public override bool Equals(object? obj)
        {
            return obj is RasterStateDescription description && this.Equals(description);
        }

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