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
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public class OpenGLInputAssemblerTests
    {
        private OpenGLInputAssembler inputAssembler;

        [Test]
        public void SetIndexBufferShouldInvokeBindWhenBufferIsOpenGLIndexBuffer()
        {
            // Arrange
            var buffer = new Mock<IOpenGLIndexBuffer>();

            // Act
            this.inputAssembler.SetIndexBuffer(buffer.Object);

            // Assert
            buffer.Verify(x => x.Bind(), Times.Once);
        }

        [Test]
        public void SetIndexBufferShouldThrowArgumentExceptionWhenBufferIsNotOpenGLIndexBuffer()
        {
            // Act and assert
            Assert.Throws<ArgumentException>(() => this.inputAssembler.SetIndexBuffer(new Mock<IIndexBuffer>().Object));
        }

        [Test]
        public void SetIndexBufferShouldThrowArgumentNullExceptionWhenBufferIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.inputAssembler.SetIndexBuffer(null));
        }

        [Test]
        public void SetInputLayoutShouldInvokeBindWhenLayoutIsOpenGLInputLayout()
        {
            // Arrange
            var layout = new Mock<IOpenGLInputLayout>();

            // Act
            this.inputAssembler.SetInputLayout(layout.Object);

            // Assert
            layout.Verify(x => x.Bind(), Times.Once);
        }

        [Test]
        public void SetInputLayoutShouldInvokeResetWhenSetInputLayoutPreviouslyCalled()
        {
            // Arrange
            var layout = new Mock<IOpenGLInputLayout>();
            this.inputAssembler.SetInputLayout(layout.Object);

            // Act
            this.inputAssembler.SetInputLayout(layout.Object);

            // Assert
            layout.Verify(x => x.Reset(), Times.Once);
        }

        [Test]
        public void SetInputLayoutShouldThrowArgumentExceptionWhenBufferIsNotOpenGLInputLayout()
        {
            // Act and assert
            Assert.Throws<ArgumentException>(() => this.inputAssembler.SetInputLayout(new Mock<IInputLayout>().Object));
        }

        [Test]
        public void SetInputLayoutShouldThrowArgumentNullExceptionWhenBufferIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.inputAssembler.SetInputLayout(null));
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.inputAssembler = new OpenGLInputAssembler();
        }

        [Test]
        public void SetVertexBufferShouldInvokeBindWhenBufferIsOpenGLVertexBuffer()
        {
            // Arrange
            var buffer = new Mock<IOpenGLVertexBuffer>();

            // Act
            this.inputAssembler.SetVertexBuffer(buffer.Object);

            // Assert
            buffer.Verify(x => x.Bind(), Times.Once);
        }

        [Test]
        public void SetVertexBufferShouldThrowArgumentExceptionWhenBufferIsNotOpenGLVertexBuffer()
        {
            // Act and assert
            Assert.Throws<ArgumentException>(() => this.inputAssembler.SetVertexBuffer(new Mock<IVertexBuffer>().Object));
        }

        [Test]
        public void SetVertexBufferShouldThrowArgumentNullExceptionWhenBufferIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.inputAssembler.SetVertexBuffer(null));
        }
    }
}