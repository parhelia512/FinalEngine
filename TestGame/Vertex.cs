// <copyright file="Vertex.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace TestGame
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

        public Vertex(float x, float y, float z, float xt, float yt)
            : this(new Vector3(x, y, z), new Vector2(xt, yt))
        {
        }

        public Vertex(Vector3 position, Vector2 textureCoordinate)
            : this(position, Vector4.One, textureCoordinate)
        {
        }

        public Vertex(Vector3 position, Vector4 color, Vector2 textureCoordinate)
        {
            this.position = position;
            this.color = color;
            this.textureCoordinate = textureCoordinate;
        }

        public Vector3 Position
        {
            get { return this.position; }
        }

        public Vector4 Color
        {
            get { return this.color; }
        }

        public Vector2 TextureCoordinate
        {
            get { return this.textureCoordinate; }
        }

        public static bool operator ==(Vertex left, Vertex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vertex left, Vertex right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            return obj is Vertex vertex && this.Equals(vertex);
        }

        public override int GetHashCode()
        {
            return (this.position.GetHashCode() * 17) + this.color.GetHashCode();
        }

        public bool Equals(Vertex other)
        {
            return this.position == other.position && this.color == other.color;
        }
    }
}