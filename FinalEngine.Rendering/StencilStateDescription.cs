// <copyright file="StencilStateDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;

    public enum StencilOperation
    {
        Keep,

        Zero,

        Replace,

        Increment,

        IncrementWrap,

        Decrement,

        DecrementWrap,

        Invert,
    }

    public struct StencilStateDescription : IEquatable<StencilStateDescription>
    {
        private ComparisonMode? comparisonMode;

        private StencilOperation? depthFail;

        private StencilOperation? pass;

        private int? readMask;

        private StencilOperation? stencilFail;

        private int? writeMask;

        public ComparisonMode ComparisonMode
        {
            get { return this.comparisonMode ?? ComparisonMode.Always; }
            set { this.comparisonMode = value; }
        }

        public StencilOperation DepthFail
        {
            get { return this.depthFail ?? StencilOperation.Keep; }
            set { this.depthFail = value; }
        }

        public bool Enabled { get; set; }

        public StencilOperation Pass
        {
            get { return this.pass ?? StencilOperation.Keep; }
            set { this.pass = value; }
        }

        public int ReadMask
        {
            get { return this.readMask ?? 0; }
            set { this.readMask = value; }
        }

        public int ReferenceValue { get; set; }

        public StencilOperation StencilFail
        {
            get { return this.stencilFail ?? StencilOperation.Keep; }
            set { this.stencilFail = value; }
        }

        public int WriteMask
        {
            get { return this.writeMask ?? -1; }
            set { this.writeMask = value; }
        }

        public static bool operator !=(StencilStateDescription left, StencilStateDescription right)
        {
            return !(left == right);
        }

        public static bool operator ==(StencilStateDescription left, StencilStateDescription right)
        {
            return left.Equals(right);
        }

        public bool Equals(StencilStateDescription other)
        {
            return this.ComparisonMode == other.comparisonMode &&
                   this.DepthFail == other.DepthFail &&
                   this.Enabled == other.Enabled &&
                   this.Pass == other.pass &&
                   this.ReadMask == other.ReadMask &&
                   this.ReferenceValue == other.ReferenceValue &&
                   this.StencilFail == other.StencilFail &&
                   this.WriteMask == other.WriteMask;
        }

        public override bool Equals(object? obj)
        {
            return obj is StencilStateDescription description && this.Equals(description);
        }

        public override int GetHashCode()
        {
            const int Accumulator = 17;

            return (this.ComparisonMode.GetHashCode() * Accumulator) +
                   (this.DepthFail.GetHashCode() * Accumulator) +
                   (this.Enabled.GetHashCode() * Accumulator) +
                   (this.Pass.GetHashCode() * Accumulator) +
                   (this.ReadMask.GetHashCode() * Accumulator) +
                   (this.ReferenceValue.GetHashCode() * Accumulator) +
                   (this.StencilFail.GetHashCode() * Accumulator) +
                   (this.WriteMask.GetHashCode() * Accumulator);
        }
    }
}