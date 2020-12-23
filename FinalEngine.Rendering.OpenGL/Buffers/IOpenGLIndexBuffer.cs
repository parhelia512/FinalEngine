// <copyright file="IOpenGLIndexBuffer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Buffers
{
    using System;
    using FinalEngine.Rendering.Buffers;

    /// <summary>
    ///   Defines an interface that represents an OpenGL index buffer.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.Buffers.IIndexBuffer"/>
    public interface IOpenGLIndexBuffer : IIndexBuffer
    {
        /// <summary>
        ///   Binds this <see cref="IOpenGLIndexBuffer"/> to the graphics processing unit.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The <see cref="IOpenGLIndexBuffer"/> has been disposed.
        /// </exception>
        void Bind();
    }
}