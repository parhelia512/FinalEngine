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

    public class OpenGLTexture2D : OpenGLTextureBase, ITexture2D
    {
        public OpenGLTexture2D(IOpenGLInvoker invoker, IEnumMapper mapper, Texture2DDescription description, int width, int height, PixelFormat format, PixelFormat internalFormat, IntPtr data)
            : base(invoker, TextureTarget.Texture2D, format, internalFormat)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper), $"The specified {nameof(mapper)} parameter cannot be null.");
            }

            if (data == IntPtr.Zero)
            {
                throw new ArgumentNullException(nameof(data), $"The specified {nameof(data)} parameter cannto be null.");
            }

            this.Width = width;
            this.Height = height;
            this.Description = description;

            this.Bind();

            invoker.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)mapper.Forward<TextureMinFilter>(description.MinFilter));
            invoker.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)mapper.Forward<TextureMagFilter>(description.MagFilter));
            invoker.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)mapper.Forward<TKTextureWrapMode>(description.WrapS));
            invoker.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)mapper.Forward<TKTextureWrapMode>(description.WrapT));

            invoker.TexImage2D(
                target: TextureTarget.Texture2D,
                level: 0,
                internalForamt: mapper.Forward<PixelInternalFormat>(internalFormat),
                width: width,
                height: height,
                border: 0,
                format: mapper.Forward<TKPixelForamt>(format),
                type: mapper.Forward<TKPixelType>(description.PixelType),
                pixels: data);

            this.Unbind();
        }

        public Texture2DDescription Description { get; }

        public int Height { get; }

        public int Width { get; }
    }
}