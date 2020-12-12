// <copyright file="OpenGLInputAssembler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLInputAssembler : IInputAssembler
    {
        private readonly IOpenGLInvoker invoker;

        private IOpenGLInputLayout? boundLayout;

        public OpenGLInputAssembler(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        }

        public void SetIndexBuffer(IIndexBuffer? buffer)
        {
            if (buffer == null)
            {
                this.invoker.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

                return;
            }

            if (buffer is not IOpenGLIndexBuffer glIndexBuffer)
            {
                throw new ArgumentException($"The specified {nameof(buffer)} parameter is not of type {nameof(IOpenGLIndexBuffer)}.");
            }

            glIndexBuffer.Bind();
        }

        public void SetInputLayout(IInputLayout? layout)
        {
            if (layout == null)
            {
                this.boundLayout?.Reset();

                return;
            }

            if (layout is not IOpenGLInputLayout glInputLayout)
            {
                throw new ArgumentException($"The specified {nameof(layout)} parameter is not of type {nameof(IOpenGLInputLayout)}.");
            }

            this.boundLayout?.Reset();
            this.boundLayout = glInputLayout;

            this.boundLayout.Bind();
        }

        public void SetVertexBuffer(IVertexBuffer? buffer)
        {
            if (buffer == null)
            {
                this.invoker.BindVertexBuffer(0, 0, IntPtr.Zero, 0);

                return;
            }

            if (buffer is not IOpenGLVertexBuffer glVertexBuffer)
            {
                throw new ArgumentException($"The specified {nameof(buffer)} parameter is not of type {nameof(IOpenGLVertexBuffer)}.");
            }

            glVertexBuffer.Bind();
        }
    }
}