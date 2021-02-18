// <copyright file="IOpenGLVertexBuffer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Buffers
{
    using System.Collections.Generic;
    using FinalEngine.Rendering.Buffers;

    /// <summary>
    ///   Defines an interface that represents an OpenGL vertex buffer.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.Buffers.IVertexBuffer"/>
    public interface IOpenGLVertexBuffer : IVertexBuffer
    {
        /// <summary>
        ///   Binds this <see cref="IOpenGLVertexBuffer"/> to the graphics processing unit.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The <see cref="IOpenGLVertexBuffer"/> has been disposed.
        /// </exception>
        void Bind();

        void Update<TData>(IReadOnlyCollection<TData> data)
            where TData : struct;
    }
}