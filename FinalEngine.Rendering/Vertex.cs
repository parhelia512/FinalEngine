// <copyright file="Vertex.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Numerics;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct Vertex
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
        }

        public Vector4 Color
        {
            get { return this.color; }
        }

        public Vector2 TextureCoordinate
        {
            get { return this.textureCoordinate; }
        }
    }
}