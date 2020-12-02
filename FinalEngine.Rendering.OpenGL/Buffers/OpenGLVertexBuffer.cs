// <copyright file="OpenGLVertexBuffer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Buffers
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLVertexBuffer<T> : IOpenGLVertexBuffer
        where T : struct
    {
        private readonly IOpenGLInvoker invoker;

        private int id;

        public OpenGLVertexBuffer(IOpenGLInvoker invoker, T[] data, int sizeInBytes, int stride)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), $"The specified {nameof(data)} parameter cannot be null.");
            }

            this.Stride = stride;

            this.id = invoker.GenBuffer();

            invoker.BindBuffer(BufferTarget.ArrayBuffer, this.id);
            invoker.BufferData(BufferTarget.ArrayBuffer, sizeInBytes, data, BufferUsageHint.StaticDraw);
            invoker.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        ~OpenGLVertexBuffer()
        {
            this.Dispose(false);
        }

        public int Stride { get; }

        protected bool IsDisposed { get; private set; }

        public void Bind()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLVertexBuffer<T>));
            }

            this.invoker.BindVertexBuffer(0, this.id, IntPtr.Zero, this.Stride);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing && this.id != -1)
            {
                this.invoker.DeleteBuffer(this.id);
                this.id = -1;
            }

            this.IsDisposed = true;
        }
    }
}