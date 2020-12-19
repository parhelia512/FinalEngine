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

    public class OpenGLTexture2D : OpenGLTexture, ITexture2D
    {
        public OpenGLTexture2D(IOpenGLInvoker invoker, IEnumMapper mapper, Texture2DDescription description, PixelFormat format, SizedFormat internalFormat, IntPtr data)
            : base(invoker, TextureTarget.Texture2D, format, internalFormat)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper), $"The specified {nameof(mapper)} parameter cannot be null.");
            }

            this.Description = description;

            invoker.TextureStorage2D(this.ID, 1, mapper.Forward<SizedInternalFormat>(this.InternalFormat), description.Width, description.Height);

            invoker.TextureParameter(this.ID, TextureParameterName.TextureMinFilter, (int)mapper.Forward<TextureMinFilter>(description.MinFilter));
            invoker.TextureParameter(this.ID, TextureParameterName.TextureMagFilter, (int)mapper.Forward<TextureMagFilter>(description.MagFilter));
            invoker.TextureParameter(this.ID, TextureParameterName.TextureWrapS, (int)mapper.Forward<TKTextureWrapMode>(description.WrapS));
            invoker.TextureParameter(this.ID, TextureParameterName.TextureWrapT, (int)mapper.Forward<TKTextureWrapMode>(description.WrapT));

            invoker.TextureSubImage2D(
                texture: this.ID,
                level: 0,
                xoffset: 0,
                yoffset: 0,
                width: description.Width,
                height: description.Height,
                format: mapper.Forward<TKPixelForamt>(this.Format),
                type: mapper.Forward<TKPixelType>(description.PixelType),
                pixels: data);
        }

        public Texture2DDescription Description { get; }
    }
}