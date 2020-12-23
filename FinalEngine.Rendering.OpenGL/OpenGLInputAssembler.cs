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
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");
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
                throw new ArgumentException($"The specified {nameof(buffer)} parameter is not of type {nameof(IOpenGLIndexBuffer)}.", nameof(buffer));
            }

            glIndexBuffer.Bind();
        }

        public void SetInputLayout(IInputLayout? layout)
        {
            if (layout == null)
            {
                this.boundLayout?.Unbind();

                return;
            }

            if (layout is not IOpenGLInputLayout glInputLayout)
            {
                throw new ArgumentException($"The specified {nameof(layout)} parameter is not of type {nameof(IOpenGLInputLayout)}.", nameof(layout));
            }

            this.boundLayout?.Unbind();
            this.boundLayout = glInputLayout;

            this.boundLayout.Bind();
        }

        public void SetVertexBuffer(IVertexBuffer? buffer)
        {
            if (buffer == null)
            {
                int[] buffers = new int[] { 0 };
                int[] strides = new int[] { 0 };
                var offsets = new IntPtr[] { IntPtr.Zero };

                this.invoker.BindVertexBuffers(0, 1, buffers, offsets, strides);

                return;
            }

            if (buffer is not IOpenGLVertexBuffer glVertexBuffer)
            {
                throw new ArgumentException($"The specified {nameof(buffer)} parameter is not of type {nameof(IOpenGLVertexBuffer)}.", nameof(buffer));
            }

            glVertexBuffer.Bind();
        }
    }
}