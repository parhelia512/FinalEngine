// <copyright file="OpenGLInputAssemblerTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;

    [ExcludeFromCodeCoverage]
    public class OpenGLInputAssemblerTests
    {
        private OpenGLInputAssembler inputAssembler;

        private Mock<IOpenGLInvoker> invoker;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLInputAssembler(null));
        }

        [Test]
        public void SetIndexBufferShouldInvokeBindBufferZeroWhenBufferIsNull()
        {
            // Act
            this.inputAssembler.SetIndexBuffer(null);

            // Assert
            this.invoker.Verify(x => x.BindBuffer(BufferTarget.ElementArrayBuffer, 0), Times.Once);
        }

        [Test]
        public void SetIndexBufferShouldInvokeBindWhenInvoked()
        {
            // Arrange
            var indexBuffer = new Mock<IOpenGLIndexBuffer>();

            // Act
            this.inputAssembler.SetIndexBuffer(indexBuffer.Object);

            // Assert
            indexBuffer.Verify(x => x.Bind(), Times.Once);
        }

        [Test]
        public void SetIndexBufferShouldThrowArgumentExceptionWhenBufferIsNotIOpenGLIndexBuffer()
        {
            // Act and assert
            Assert.Throws<ArgumentException>(() => this.inputAssembler.SetIndexBuffer(Mock.Of<IIndexBuffer>()));
        }

        [Test]
        public void SetInputLayoutShouldInvokeBindWhenInvoked()
        {
            // Arrange
            var layout = new Mock<IOpenGLInputLayout>();

            // Act
            this.inputAssembler.SetInputLayout(layout.Object);

            // Assert
            layout.Verify(x => x.Bind(), Times.Once);
        }

        [Test]
        public void SetInputLayoutShouldInvokeBoundLayoutResetWhenInvokedAndLayoutHasBeenPreviouslyBound()
        {
            // Arrange
            var layout = new Mock<IOpenGLInputLayout>();

            this.inputAssembler.SetInputLayout(layout.Object);

            layout.Reset();

            // Act
            this.inputAssembler.SetInputLayout(layout.Object);

            // Assert
            layout.Verify(x => x.Reset(), Times.Once);
        }

        [Test]
        public void SetInputLayoutShouldInvokeBoundLayoutResetWhenLayoutIsNullAndLayoutHasPreviouslyBeenBound()
        {
            // Arrange
            var layout = new Mock<IOpenGLInputLayout>();

            this.inputAssembler.SetInputLayout(layout.Object);

            layout.Reset();

            // Act
            this.inputAssembler.SetInputLayout(null);

            // Assert
            layout.Verify(x => x.Reset(), Times.Once);
        }

        [Test]
        public void SetInputLayoutShouldNotInvokeBoundLayoutResetWhenLayoutIsNullAndLayoutHasNotBeenPreviouslyBound()
        {
            // Act
            this.inputAssembler.SetInputLayout(null);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void SetInputLayoutShouldThrowArgumentExceptionWhenLayoutIsNotIOpenGLInputLayout()
        {
            // Act and assert
            Assert.Throws<ArgumentException>(() => this.inputAssembler.SetInputLayout(Mock.Of<IInputLayout>()));
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.inputAssembler = new OpenGLInputAssembler(this.invoker.Object);
        }

        [Test]
        public void SetVertexBufferShouldInvokeBindVertexBuffersWhenBufferIsNull()
        {
            // Act
            this.inputAssembler.SetVertexBuffer(null);

            // Assert
            this.invoker.Verify(x => x.BindVertexBuffers(0, 1, new int[] { 0 }, new IntPtr[] { IntPtr.Zero }, new int[] { 0 }), Times.Once);
        }

        [Test]
        public void SetVertexBufferShouldInvokeBindWhenInvoked()
        {
            // Arrange
            var vertexBuffer = new Mock<IOpenGLVertexBuffer>();

            // Act
            this.inputAssembler.SetVertexBuffer(vertexBuffer.Object);

            // Assert
            vertexBuffer.Verify(x => x.Bind(), Times.Once);
        }

        [Test]
        public void SetVertexBufferShouldThrowArgumentExceptionWhenBufferIsNotIOpenGLVertexBuffer()
        {
            // Act and assert
            Assert.Throws<ArgumentException>(() => this.inputAssembler.SetVertexBuffer(Mock.Of<IVertexBuffer>()));
        }
    }
}