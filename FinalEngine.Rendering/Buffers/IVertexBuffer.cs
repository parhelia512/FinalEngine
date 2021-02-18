// <copyright file="IVertexBuffer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Buffers
{
    using System;

    /// <summary>
    ///   Defines an interface that represents a vertex buffer.
    /// </summary>
    /// <seealso cref="System.IDisposable"/>
    public interface IVertexBuffer : IDisposable
    {
        /// <summary>
        ///   Gets an <see cref="int"/> that represents the total number of bytes for a single vertex contained in this <see cref="IVertexBuffer"/>.
        /// </summary>
        /// <value>
        ///   The total number of bytes for a single vertex contained in this <see cref="IVertexBuffer"/>.
        /// </value>
        int Stride { get; }

        BufferUsageType Type { get; }
    }
}