// <copyright file="IInputAssembler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using FinalEngine.Rendering.Buffers;

    /// <summary>
    ///   Defines an interface that represents the input-assembly stage of a graphics pipeline.
    /// </summary>
    public interface IInputAssembler
    {
        /// <summary>
        ///   Sets the specified <paramref name="buffer"/>, binding it to the GPU.
        /// </summary>
        /// <param name="buffer">
        ///   Specifies a <see cref="Nullable{IIndexBuffer}"/> that represents the index buffer to bind.
        /// </param>
        /// <remarks>
        ///   Passing <c>null</c> to the <paramref name="buffer"/> parameter will unbind the previously bound index buffer.
        /// </remarks>
        /// <exception cref="ArgumentException">
        ///   The specified <paramref name="buffer"/> is not the correct implementation. If this exception occurs, you're attempting to bind an index buffer that was created with a different rendering API than the one that's currently in use.
        /// </exception>
        void SetIndexBuffer(IIndexBuffer? buffer);

        /// <summary>
        ///   Sets the specified <paramref name="layout"/>, binding it to the GPU.
        /// </summary>
        /// <param name="layout">
        ///   Specifies an <see cref="IInputLayout"/> that represents the layout to bind.
        /// </param>
        /// <remarks>
        ///   Passing <c>null</c> to the <paramref name="layout"/> parameter will unbind the previously bound input layout.
        /// </remarks>
        /// <exception cref="ArgumentException">
        ///   The specified <paramref name="layout"/> is not the correct implementation. If this exception occurs, you're attempting to bind an input layout that was created with a different rendering API than the one that's currently in use.
        /// </exception>
        void SetInputLayout(IInputLayout? layout);

        /// <summary>
        ///   Sets the specified <paramref name="buffer"/>, binding it to the GPU.
        /// </summary>
        /// <param name="buffer">
        ///   Specifies a <see cref="Nullable{IVertexBuffer}"/> that represents the vertex buffer to bind.
        /// </param>
        /// <remarks>
        ///   Passing <c>null</c> to the <paramref name="buffer"/> parameter will unbind the previously bound vertex buffer.
        /// </remarks>
        /// <exception cref="ArgumentException">
        ///   The specified <paramref name="buffer"/> is not the correct implementation. If this exception occurs, you're attempting to bind an vertex buffer that was created with a different rendering API than the one that's currently in use.
        /// </exception>
        void SetVertexBuffer(IVertexBuffer? buffer);
    }
}