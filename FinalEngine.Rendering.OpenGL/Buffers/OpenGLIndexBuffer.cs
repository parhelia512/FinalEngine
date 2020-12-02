// <copyright file="OpenGLIndexBuffer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Buffers
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLIndexBuffer<T> : IOpenGLIndexBuffer
        where T : struct
    {
        private readonly IOpenGLInvoker invoker;

        private int id;

        public OpenGLIndexBuffer(IOpenGLInvoker invoker, T[] data, int sizeInBytes)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), $"The specified {nameof(data)} parameter cannot be null.");
            }

            this.Length = data.Length;

            this.id = invoker.GenBuffer();

            invoker.BindBuffer(BufferTarget.ElementArrayBuffer, this.id);
            invoker.BufferData(BufferTarget.ElementArrayBuffer, sizeInBytes, data, BufferUsageHint.StaticDraw);
            invoker.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        ~OpenGLIndexBuffer()
        {
            this.Dispose(false);
        }

        public int Length { get; }

        protected bool IsDisposed { get; private set; }

        public void Bind()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLIndexBuffer<T>));
            }

            this.invoker.BindBuffer(BufferTarget.ElementArrayBuffer, this.id);
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