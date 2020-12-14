// <copyright file="OpenGLTexture2DTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL.Textures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Textures;
    using FinalEngine.Rendering.Textures;
    using FinalEngine.Utilities;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;
    using PixelFormat = FinalEngine.Rendering.Textures.PixelFormat;
    using PixelType = FinalEngine.Rendering.Textures.PixelType;
    using TextureWrapMode = FinalEngine.Rendering.Textures.TextureWrapMode;
    using TKPixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;
    using TKPixelType = OpenTK.Graphics.OpenGL4.PixelType;
    using TKTextureWrapMode = OpenTK.Graphics.OpenGL4.TextureWrapMode;

    [ExcludeFromCodeCoverage]
    public class OpenGLTexture2DTests
    {
        private Texture2DDescription description;

        private Mock<IOpenGLInvoker> invoker;

        private Mock<IEnumMapper> mapper;

        private OpenGLTexture2D texture;

        [Test]
        public void ConstructorShouldInvokeTexImage2DWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.TexImage2D(TextureTarget.Texture2D, 0, this.mapper.Object.Forward<PixelInternalFormat>(this.texture.InternalForamt), 20, 30, 0, this.mapper.Object.Forward<TKPixelFormat>(this.texture.Format), this.mapper.Object.Forward<TKPixelType>(this.description.PixelType), new IntPtr(1)), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeTexParameterMagFilterWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)this.mapper.Object.Forward<TextureMagFilter>(this.description.MagFilter)), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeTexParameterMinFilterWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)this.mapper.Object.Forward<TextureMinFilter>(this.description.MinFilter)), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeTexParameterWrapSWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)this.mapper.Object.Forward<TKTextureWrapMode>(this.description.WrapS)), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeTexParameterWrapTWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)this.mapper.Object.Forward<TKTextureWrapMode>(this.description.WrapT)), Times.Once);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenDataIsIntPtrZero()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLTexture2D(this.invoker.Object, this.mapper.Object, this.description, PixelFormat.Rgba, PixelFormat.Rgba, IntPtr.Zero));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenMapperIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLTexture2D(this.invoker.Object, null, default, PixelFormat.Depth, PixelFormat.Depth, new IntPtr(1)));
        }

        [Test]
        public void DescriptionShouldReturnSameAsConstructorWhenInvoked()
        {
            // Act
            var actual = this.texture.Description;

            // Assert
            Assert.AreSame(this.description, actual);
        }

        [SetUp]
        public void Setup()
        {
            this.invoker = new Mock<IOpenGLInvoker>();
            this.mapper = new Mock<IEnumMapper>();

            this.description = new Texture2DDescription()
            {
                Width = 20,
                Height = 30,
                MinFilter = TextureFilterMode.Linear,
                MagFilter = TextureFilterMode.Nearest,
                PixelType = PixelType.Short,
                WrapS = TextureWrapMode.Clamp,
                WrapT = TextureWrapMode.Repeat,
            };

            this.texture = new OpenGLTexture2D(this.invoker.Object, this.mapper.Object, this.description, PixelFormat.Rgba, PixelFormat.Rgb, new IntPtr(1));
        }
    }
}