// <copyright file="Vertex.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Numerics;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        public static readonly int SizeInBytes = Marshal.SizeOf<Vertex>();

        public Vertex(Vector3 position, Vector4 color, Vector2 textureCoordinate)
        {
            this.Position = position;
            this.Color = color;
            this.TextureCoordinate = textureCoordinate;
        }

        public Vector3 Position { get; set; }

        public Vector4 Color { get; set; }

        public Vector2 TextureCoordinate { get; set; }
    }
}