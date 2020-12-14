// <copyright file="OpenGLTextureTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL.Textures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Textures;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;
    using PixelFormat = FinalEngine.Rendering.Textures.PixelFormat;

    [ExcludeFromCodeCoverage]
    public class OpenGLTextureTests
    {
        private const int ID = 1045;

        private Mock<IOpenGLInvoker> invoker;

        private OpenGLTexture texture;

        [Test]
        public void BindShouldInvokeBindTextureWhenTextureIsNotDisposed()
        {
            // Act
            this.texture.Bind();

            // Assert
            this.invoker.Verify(x => x.BindTexture(TextureTarget.Texture2D, ID), Times.Once);
        }

        [Test]
        public void BindShouldThrowObjectDisposedExceptionWhenTextureIsDisposed()
        {
            // Arrange
            this.texture.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.texture.Bind());
        }

        [Test]
        public void ConstructorShouldInvokeGenTextureWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.GenTexture(), Times.Once);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLTexture(null, TextureTarget.Texture2D, PixelFormat.Rgba, PixelFormat.Rgba));
        }

        [Test]
        public void FormatShouldReturnRgbaWhenInvoked()
        {
            // Act
            PixelFormat actual = this.texture.Format;

            // Assert
            Assert.AreEqual(PixelFormat.Rgba, actual);
        }

        [Test]
        public void InternalFormatShouldReturnRgWhenInvoked()
        {
            // Act
            PixelFormat actual = this.texture.InternalForamt;

            // Assert
            Assert.AreEqual(PixelFormat.Rg, actual);
        }

        [SetUp]
        public void Setup()
        {
            this.invoker = new Mock<IOpenGLInvoker>();

            this.invoker.Setup(x => x.GenTexture()).Returns(ID);

            this.texture = new OpenGLTexture(this.invoker.Object, TextureTarget.Texture2D, PixelFormat.Rgba, PixelFormat.Rg);
        }

        [Test]
        public void SlotShouldInvokeActiveTextureWhenTextureIsNotDisposed()
        {
            // Act
            this.texture.Slot(15);

            // Assert
            this.invoker.Verify(x => x.ActiveTexture(TextureUnit.Texture0 + 15));
        }

        [Test]
        public void SlotShouldThrowObjectDisposedExceptionWhenTextureIsDisposed()
        {
            // Arrange
            this.texture.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.texture.Slot(3));
        }

        [TearDown]
        public void Teardown()
        {
            this.texture.Dispose();
        }

        [Test]
        public void UnbindShouldInvokeBindTextureWhenTextureIsNotDisposed()
        {
            // Act
            this.texture.Unbind();

            // Assert
            this.invoker.Verify(x => x.BindTexture(TextureTarget.Texture2D, 0), Times.Once);
        }

        [Test]
        public void UnbindShouldThrowObjectDisposedExceptionWhenTextureIsDisposed()
        {
            // Arrange
            this.texture.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.texture.Unbind());
        }
    }
}