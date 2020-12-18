// <copyright file="OpenGLIndexBufferTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL.Buffers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is done in TearDown.")]
    public class OpenGLIndexBufferTests
    {
        private const int ID = 10;

        private readonly int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        private OpenGLIndexBuffer<int> indexBuffer;

        private Mock<IOpenGLInvoker> invoker;

        [Test]
        public void BindShouldInvokeBindBufferIdentifierWhenBufferIsNotDisposed()
        {
            // Arrange
            this.invoker.Reset();

            // Act
            this.indexBuffer.Bind();

            // Assert
            this.invoker.Verify(x => x.BindBuffer(BufferTarget.ElementArrayBuffer, ID), Times.Once);
        }

        [Test]
        public void BindShouldThrowObjectDisposedExceptionWhenBufferIsDisposed()
        {
            // Arrange
            this.indexBuffer.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.indexBuffer.Bind());
        }

        [Test]
        public void ConstructorShouldInvokeBindBufferIdentifierWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.BindBuffer(BufferTarget.ElementArrayBuffer, ID), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeBindBufferZeroWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.BindBuffer(BufferTarget.ElementArrayBuffer, 0), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeBufferDataWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.BufferData(BufferTarget.ElementArrayBuffer, this.data.Length * sizeof(int), this.data, BufferUsageHint.StaticDraw), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeGenBufferWhenInvoked()
        {
            // Assert
            this.invoker.Verify(x => x.GenBuffer(), Times.Once);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenDataIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLIndexBuffer<int>(this.invoker.Object, null, 0));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLIndexBuffer<int>(null, this.data, 0));
        }

        [Test]
        public void DisposeShouldInvokeDeleteBufferIdentifierWhenBufferIsNotDisposed()
        {
            // Act
            this.indexBuffer.Dispose();

            // Assert
            this.invoker.Verify(x => x.DeleteBuffer(ID), Times.Once);
        }

        [Test]
        public void LengthShouldReturnSameAsDataLength()
        {
            // Assert
            Assert.AreEqual(this.data.Length, this.indexBuffer.Length);
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.invoker.Setup(x => x.GenBuffer()).Returns(ID);
            this.indexBuffer = new OpenGLIndexBuffer<int>(this.invoker.Object, this.data, this.data.Length * sizeof(int));
        }

        [TearDown]
        public void Teardown()
        {
            this.indexBuffer.Dispose();
        }
    }
}