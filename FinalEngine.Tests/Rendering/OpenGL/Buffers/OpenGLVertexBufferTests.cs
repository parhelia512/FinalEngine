// <copyright file="OpenGLVertexBufferTests.cs" company="Software Antics">
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
    public class OpenGLVertexBufferTests
    {
        private const int ID = 42;

        private const int Stride = 32;

        private readonly int[] data = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };

        private Mock<IOpenGLInvoker> invoker;

        private OpenGLVertexBuffer<int> vertexBuffer;

        [Test]
        public void BindShouldInvokeBindVertexBufferIDWhenVertexBufferIsNotDisposed()
        {
            // Act
            this.vertexBuffer.Bind();

            // Assert
            this.invoker.Verify(x => x.BindVertexBuffer(0, ID, IntPtr.Zero, this.vertexBuffer.Stride), Times.Once);
        }

        [Test]
        public void BindShouldThrowObjectDisposedExceptionWhenVertexBufferIsDisposed()
        {
            // Arrange
            this.vertexBuffer.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.vertexBuffer.Bind());
        }

        [Test]
        public void ConstructorShouldInvokeBindBufferIDWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.BindBuffer(BufferTarget.ArrayBuffer, ID), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeBindBufferZeroWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.BindBuffer(BufferTarget.ArrayBuffer, 0), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeBufferDataWhenParametersAreNotNulL()
        {
            // Assert
            this.invoker.Verify(x => x.BufferData(BufferTarget.ArrayBuffer, this.data.Length * sizeof(int), this.data, BufferUsageHint.StaticDraw), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeGenBufferWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.GenBuffer(), Times.Once);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenDataIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLVertexBuffer<int>(new Mock<IOpenGLInvoker>().Object, null, 0, 0));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLVertexBuffer<int>(null, Array.Empty<int>(), 0, 0));
        }

        [Test]
        public void DisposeShouldInvokeDeleteBufferWhenInvoked()
        {
            // Act
            this.vertexBuffer.Dispose();

            // Assert
            this.invoker.Verify(x => x.DeleteBuffer(ID), Times.Once);
        }

        [SetUp]
        public void Setup()
        {
            this.invoker = new Mock<IOpenGLInvoker>();
            this.invoker.Setup(x => x.GenBuffer()).Returns(ID);

            this.vertexBuffer = new OpenGLVertexBuffer<int>(this.invoker.Object, this.data, this.data.Length * sizeof(int), Stride);
        }

        [Test]
        public void StrideShouldReturnSameAsConstructorInputWhenInvoked()
        {
            // Act
            int actual = this.vertexBuffer.Stride;

            // Assert
            Assert.AreEqual(Stride, actual);
        }

        [TearDown]
        public void Teardown()
        {
            this.vertexBuffer.Dispose();
        }
    }
}