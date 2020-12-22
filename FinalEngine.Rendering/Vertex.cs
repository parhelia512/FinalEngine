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
        public static readonly int SizeInBytes = Marshal.SizeOf<Vertex>();

        [FieldOffset(0)]
        private Vector3 position;

        [FieldOffset(12)]
        private Vector4 color;

        [FieldOffset(28)]
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

        public static bool operator !=(Vertex left, Vertex right)
        {
            return !(left == right);
        }

        public static bool operator ==(Vertex left, Vertex right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Vertex vertex && this.Equals(vertex);
        }

        public override int GetHashCode()
        {
            const int Accumulator = 17;

            return (this.Position.GetHashCode() * Accumulator) +
                   (this.Color.GetHashCode() * Accumulator) +
                   (this.TextureCoordinate.GetHashCode() * Accumulator);
        }

        public bool Equals(Vertex other)
        {
            return this.Position == other.Position &&
                   this.Color == other.Color &&
                   this.TextureCoordinate == other.TextureCoordinate;
        }
    }
}