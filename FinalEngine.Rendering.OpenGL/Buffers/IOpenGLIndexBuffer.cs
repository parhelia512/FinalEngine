// <copyright file="IOpenGLIndexBuffer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Buffers
{
    using FinalEngine.Rendering.Buffers;

    public interface IOpenGLIndexBuffer : IIndexBuffer
    {
        void Bind();
    }
}