// <copyright file="OpenGLTextureBase.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Textures
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;
    using PixelFormat = FinalEngine.Rendering.Textures.PixelFormat;

    public class OpenGLTextureBase : IOpenGLTexture
    {
        private readonly IOpenGLInvoker invoker;

        private readonly TextureTarget target;

        private int id;

        public OpenGLTextureBase(IOpenGLInvoker invoker, TextureTarget target)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            this.id = invoker.GenTexture();
        }

        ~OpenGLTextureBase()
        {
            this.Dispose(false);
        }

        public PixelFormat Format { get; }

        public PixelFormat InternalForamt { get; }

        protected bool IsDisposed { get; private set; }

        public void Bind()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLTextureBase));
            }

            this.invoker.BindTexture(this.target, this.id);
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
                throw new ObjectDisposedException(nameof(OpenGLTextureBase));
            }

            this.invoker.ActiveTexture(TextureUnit.Texture0 + index);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing && this.id != -1)
            {
                this.invoker.DeleteTexture(this.id);
                this.id = -1;
            }

            this.IsDisposed = true;
        }
    }
}