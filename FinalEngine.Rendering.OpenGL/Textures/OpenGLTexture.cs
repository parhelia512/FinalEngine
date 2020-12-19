// <copyright file="OpenGLTexture.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Textures
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Textures;
    using OpenTK.Graphics.OpenGL4;
    using PixelFormat = FinalEngine.Rendering.Textures.PixelFormat;

    //// TODO: Seriously, this should be abstract.

    public class OpenGLTexture : IOpenGLTexture
    {
        private readonly IOpenGLInvoker invoker;

        private readonly TextureTarget target;

        public OpenGLTexture(IOpenGLInvoker invoker, TextureTarget target, PixelFormat format, SizedFormat internalFormat)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            this.ID = invoker.CreateTexture(target);
            this.target = target;

            this.Format = format;
            this.InternalFormat = internalFormat;
        }

        ~OpenGLTexture()
        {
            this.Dispose(false);
        }

        public PixelFormat Format { get; }

        public SizedFormat InternalFormat { get; }

        protected int ID { get; private set; }

        protected bool IsDisposed { get; private set; }

        public void Bind()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLTexture));
            }

            this.invoker.BindTexture(this.target, this.ID);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Slot(int index)
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLTexture));
            }

            this.invoker.ActiveTexture(TextureUnit.Texture0 + index);
        }

        public void Unbind()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLTexture));
            }

            this.invoker.BindTexture(this.target, 0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing && this.ID != -1)
            {
                this.invoker.DeleteTexture(this.ID);
                this.ID = -1;
            }

            this.IsDisposed = true;
        }
    }
}