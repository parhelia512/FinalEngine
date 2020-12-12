// <copyright file="BlendStateDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    public enum BlendEquationMode
    {
        Add,

        Subtract,

        ReverseSubstract,

        Min,

        Max,
    }

    public enum BlendMode
    {
        Zero,

        One,

        SourceColor,

        OneMinusSourceColor,

        DestinationColor,

        OneMinusDestinationColor,

        SourceAlpha,

        OneMinusSourceAlpha,

        DestinationAlpha,

        OneMinusDestinationAlpha,

        OneMinusConstantColor,

        ConstantAlpha,

        OneMinusConstantAlpha,

        SourceAlphaSaturate,
    }

    //// TODO: Unit Tests

    [ExcludeFromCodeCoverage]
    public struct BlendStateDescription : IEquatable<BlendStateDescription>
    {
        private Color? color;

        private BlendMode? destinationMode;

        private BlendEquationMode? equationMode;

        private BlendMode? sourceMode;

        public Color Color
        {
            get { return this.color ?? Color.Black; }
            set { this.color = value; }
        }

        public BlendMode DestinationMode
        {
            get { return this.destinationMode ?? BlendMode.Zero; }
            set { this.destinationMode = value; }
        }

        public bool Enabled { get; set; }

        public BlendEquationMode EquationMode
        {
            get { return this.equationMode ?? BlendEquationMode.Add; }
            set { this.equationMode = value; }
        }

        public BlendMode SourceMode
        {
            get { return this.sourceMode ?? BlendMode.One; }
            set { this.sourceMode = value; }
        }

        public static bool operator !=(BlendStateDescription left, BlendStateDescription right)
        {
            return !(left == right);
        }

        public static bool operator ==(BlendStateDescription left, BlendStateDescription right)
        {
            return left.Equals(right);
        }

        public bool Equals(BlendStateDescription other)
        {
            return this.Color == other.Color &&
                   this.DestinationMode == other.DestinationMode &&
                   this.Enabled == other.Enabled &&
                   this.EquationMode == other.EquationMode &&
                   this.SourceMode == other.SourceMode;
        }

        public override bool Equals(object? obj)
        {
            return obj is BlendStateDescription description && this.Equals(description);
        }

        public override int GetHashCode()
        {
            const int Accumulator = 17;

            return (this.Color.GetHashCode() * Accumulator) +
                   (this.DestinationMode.GetHashCode() * Accumulator) +
                   (this.Enabled.GetHashCode() * Accumulator) +
                   (this.EquationMode.GetHashCode() * Accumulator) +
                   (this.SourceMode.GetHashCode() * Accumulator);
        }
    }
}