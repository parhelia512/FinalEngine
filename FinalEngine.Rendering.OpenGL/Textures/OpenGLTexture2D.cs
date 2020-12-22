// <copyright file="OpenGLTexture2D.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Textures
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Textures;
    using FinalEngine.Utilities;
    using OpenTK.Graphics.OpenGL4;
    using PixelFormat = FinalEngine.Rendering.Textures.PixelFormat;
    using TKPixelForamt = OpenTK.Graphics.OpenGL4.PixelFormat;
    using TKPixelType = OpenTK.Graphics.OpenGL4.PixelType;
    using TKTextureWrapMode = OpenTK.Graphics.OpenGL4.TextureWrapMode;

    public class OpenGLTexture2D : ITexture2D, IOpenGLTexture
    {
        private readonly IOpenGLInvoker invoker;

        private int id;

        public OpenGLTexture2D(IOpenGLInvoker invoker, IEnumMapper mapper, Texture2DDescription description, PixelFormat format, SizedFormat internalFormat, IntPtr data)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper), $"The specified {nameof(mapper)} parameter cannot be null.");
            }

            this.id = invoker.CreateTexture(TextureTarget.Texture2D);

            this.Format = format;
            this.InternalFormat = internalFormat;

            this.Description = description;

            invoker.TextureStorage2D(this.id, 1, mapper.Forward<SizedInternalFormat>(this.InternalFormat), description.Width, description.Height);

            invoker.TextureParameter(this.id, TextureParameterName.TextureMinFilter, (int)mapper.Forward<TextureMinFilter>(description.MinFilter));
            invoker.TextureParameter(this.id, TextureParameterName.TextureMagFilter, (int)mapper.Forward<TextureMagFilter>(description.MagFilter));
            invoker.TextureParameter(this.id, TextureParameterName.TextureWrapS, (int)mapper.Forward<TKTextureWrapMode>(description.WrapS));
            invoker.TextureParameter(this.id, TextureParameterName.TextureWrapT, (int)mapper.Forward<TKTextureWrapMode>(description.WrapT));

            invoker.TextureSubImage2D(
                texture: this.id,
                level: 0,
                xoffset: 0,
                yoffset: 0,
                width: description.Width,
                height: description.Height,
                format: mapper.Forward<TKPixelForamt>(this.Format),
                type: mapper.Forward<TKPixelType>(description.PixelType),
                pixels: data);
        }

        ~OpenGLTexture2D()
        {
            this.Dispose(false);
        }

        public Texture2DDescription Description { get; }

        public PixelFormat Format { get; }

        public SizedFormat InternalFormat { get; }

        protected bool IsDisposed { get; private set; }

        public void Bind()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLTexture2D));
            }

            this.invoker.BindTexture(TextureTarget.Texture2D, this.id);
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
                throw new ObjectDisposedException(nameof(OpenGLTexture2D));
            }

            this.invoker.ActiveTexture(TextureUnit.Texture0 + index);
        }

        public void Unbind()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLTexture2D));
            }

            this.invoker.BindTexture(TextureTarget.Texture2D, 0);
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