// <copyright file="OpenGLTextureTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL.Textures
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Textures;
    using FinalEngine.Rendering.Textures;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;
    using PixelFormat = FinalEngine.Rendering.Textures.PixelFormat;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is done in TearDown.")]
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
            this.invoker.Verify(x => x.CreateTexture(TextureTarget.Texture2D), Times.Once);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLTexture(null, TextureTarget.Texture2D, PixelFormat.Rgba, SizedFormat.R8));
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
            SizedFormat actual = this.texture.InternalFormat;

            // Assert
            Assert.AreEqual(SizedFormat.R8, actual);
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.invoker.Setup(x => x.CreateTexture(TextureTarget.Texture2D)).Returns(ID);

            this.texture = new OpenGLTexture(this.invoker.Object, TextureTarget.Texture2D, PixelFormat.Rgba, SizedFormat.R8);
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