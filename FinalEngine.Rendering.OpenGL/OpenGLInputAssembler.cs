// <copyright file="OpenGLInputAssembler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL.Buffers;

    public class OpenGLInputAssembler : IInputAssembler
    {
        private IOpenGLInputLayout? boundLayout;

        public void SetIndexBuffer(IIndexBuffer buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (buffer is not IOpenGLIndexBuffer glIndexBuffer)
            {
                throw new ArgumentException($"The specified {nameof(buffer)} parameter is not of type {nameof(IOpenGLIndexBuffer)}.");
            }

            glIndexBuffer.Bind();
        }

        public void SetInputLayout(IInputLayout layout)
        {
            if (layout == null)
            {
                throw new ArgumentNullException(nameof(layout));
            }

            if (layout is not IOpenGLInputLayout glInputLayout)
            {
                throw new ArgumentException($"The specified {nameof(layout)} parameter is not of type {nameof(IOpenGLInputLayout)}.");
            }

            this.boundLayout?.Reset();

            this.boundLayout = glInputLayout;
            this.boundLayout.Bind();
        }

        public void SetVertexBuffer(IVertexBuffer buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (buffer is not IOpenGLVertexBuffer glVertexBuffer)
            {
                throw new ArgumentException($"The specified {nameof(buffer)} parameter is not of type {nameof(IOpenGLVertexBuffer)}.");
            }

            glVertexBuffer.Bind();
        }
    }
}