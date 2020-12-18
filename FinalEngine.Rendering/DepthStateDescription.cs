// <copyright file="DepthStateDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;

    public struct DepthStateDescription : IEquatable<DepthStateDescription>
    {
        private ComparisonMode? comparisonMode;

        private bool? writeEnabled;

        public ComparisonMode ComparisonMode
        {
            get { return this.comparisonMode ?? ComparisonMode.Less; }
            set { this.comparisonMode = value; }
        }

        public bool ReadEnabled { get; set; }

        public bool WriteEnabled
        {
            get { return this.writeEnabled ?? true; }
            set { this.writeEnabled = value; }
        }

        public static bool operator !=(DepthStateDescription left, DepthStateDescription right)
        {
            return !(left == right);
        }

        public static bool operator ==(DepthStateDescription left, DepthStateDescription right)
        {
            return left.Equals(right);
        }

        public bool Equals(DepthStateDescription other)
        {
            return this.ComparisonMode == other.ComparisonMode &&
                   this.ReadEnabled == other.ReadEnabled &&
                   this.WriteEnabled == other.WriteEnabled;
        }

        public override bool Equals(object? obj)
        {
            return obj is DepthStateDescription description && this.Equals(description);
        }

        public override int GetHashCode()
        {
            const int Accumulator = 17;

            return (this.ComparisonMode.GetHashCode() * Accumulator) +
                   (this.ReadEnabled.GetHashCode() * Accumulator) +
                   (this.WriteEnabled.GetHashCode() * Accumulator);
        }
    }
}