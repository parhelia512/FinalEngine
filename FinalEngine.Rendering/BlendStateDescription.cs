// <copyright file="BlendStateDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using System.Drawing;

    /// <summary>
    ///   Specifies the Enumerates the available blend equation modes that determine how the source and destination factors are combined in a blend operation.
    /// </summary>
    public enum BlendEquationMode
    {
        /// <summary>
        ///   Specifies the source and destination are added.
        /// </summary>
        Add,

        /// <summary>
        ///   Specifies the destination is subtracted from source.
        /// </summary>
        Subtract,

        /// <summary>
        ///   Specifies the source is subtracted from destination.
        /// </summary>
        ReverseSubtract,

        /// <summary>
        ///   Specifies the minimum of source and destination is selected.
        /// </summary>
        Min,

        /// <summary>
        ///   Specifies the maximum of source and destination is selected.
        /// </summary>
        Max,
    }

    /// <summary>
    ///   Enumerates the available blend modes that determine the influence of components in a blend operation.
    /// </summary>
    public enum BlendMode
    {
        /// <summary>
        ///   Specifies each component is multiplied by zero.
        /// </summary>
        Zero,

        /// <summary>
        ///   Specifies each component is multiplied by one.
        /// </summary>
        One,

        /// <summary>
        ///   Specifies each component is multiplied by the matching component of the source color.
        /// </summary>
        SourceColor,

        /// <summary>
        ///   Specifies each component is multiplied by (1 - the matching component of the source color).
        /// </summary>
        OneMinusSourceColor,

        /// <summary>
        ///   Specifies each component is multiplied by the matching component of the destination color.
        /// </summary>
        DestinationColor,

        /// <summary>
        ///   Specifies each component is multiplied by (1 - the matching component of the destination color).
        /// </summary>
        OneMinusDestinationColor,

        /// <summary>
        ///   Specifies each component is multiplied by the source alpha component.
        /// </summary>
        SourceAlpha,

        /// <summary>
        ///   Specifies each component is multiplied by (1 - source alpha).
        /// </summary>
        OneMinusSourceAlpha,

        /// <summary>
        ///   Specifies each component is multiplied by the destination alpha component.
        /// </summary>
        DestinationAlpha,

        /// <summary>
        ///   Specifies the component is multiplied by (1 - destination alpha).
        /// </summary>
        OneMinusDestinationAlpha,
    }

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