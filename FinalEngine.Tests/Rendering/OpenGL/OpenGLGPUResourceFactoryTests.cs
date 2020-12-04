// <copyright file="OpenGLGPUResourceFactoryTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Pipeline;
    using FinalEngine.Rendering.Pipeline;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public class OpenGLGPUResourceFactoryTests
    {
        private OpenGLGPUResourceFactory factory;

        private Mock<IOpenGLInvoker> invoker;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLGPUResourceFactory(null));
        }

        [Test]
        public void CreateIndexBufferShouldReturnOpenGLIndexBufferWhenDataIsNotNull()
        {
            // Act
            IIndexBuffer actual = this.factory.CreateIndexBuffer(Array.Empty<int>(), 0);

            // Assert
            Assert.IsInstanceOf(typeof(OpenGLIndexBuffer<int>), actual);
        }

        [Test]
        public void CreateIndexBufferShouldThrowArgumentNullExceptionWhenDataIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.factory.CreateIndexBuffer<int>(null, 0));
        }

        [Test]
        public void CreateInputLayoutShouldReturnOpenGLInputLayoutWhenElementsIsNotNull()
        {
            // Act
            IInputLayout actual = this.factory.CreateInputLayout(Enumerable.Empty<InputElement>());

            // Assert
            Assert.IsInstanceOf(typeof(OpenGLInputLayout), actual);
        }

        [Test]
        public void CreateInputLayoutShouldThrowArgumentNullExceptionWhenElementsIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.factory.CreateInputLayout(null));
        }

        [Test]
        public void CreateShaderProgramShouldReturnOpenGLShaderProgramWhenShadersIsNotNull()
        {
            // Arrange
            IEnumerable<IShader> shaders = new List<IShader>()
            {
                new OpenGLShader(this.invoker.Object, PipelineTarget.Vertex, "test"),
            };

            // Act
            IShaderProgram actual = this.factory.CreateShaderProgram(shaders);

            // Assert
            Assert.IsInstanceOf(typeof(OpenGLShaderProgram), actual);
        }

        [Test]
        public void CreateShaderProgramShouldThrowArgumentNullExceptionWhenShadersIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.factory.CreateShaderProgram(null));
        }

        [Test]
        public void CreateShaderProgramShouldThrowInvalidCastExceptionWhenShadersContainsNotOpenGLShader()
        {
            // Arrange
            IEnumerable<IShader> shaders = new List<IShader>()
            {
                new Mock<IShader>().Object,
                new OpenGLShader(this.invoker.Object, PipelineTarget.Vertex, "test"),
            };

            // Act and assert
            Assert.Throws<InvalidCastException>(() => this.factory.CreateShaderProgram(shaders));
        }

        [Test]
        public void CreateShaderShouldReturnOpenGLShaderWhenSourceCodeIsNotNull()
        {
            // Act
            IShader actual = this.factory.CreateShader(PipelineTarget.Vertex, "source code");

            // Assert
            Assert.IsInstanceOf(typeof(OpenGLShader), actual);
        }

        [Test]
        public void CreateShaderShouldThrowArgumentNullExceptionWhenSourceCodeIsEmpty()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.factory.CreateShader(PipelineTarget.Vertex, string.Empty));
        }

        [Test]
        public void CreateShaderShouldThrowArgumentNullExceptionWhenSourceCodeIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.factory.CreateShader(PipelineTarget.Vertex, null));
        }

        [Test]
        public void CreateShaderShouldThrowArgumentNullExceptionWhenSourceCodeIsWhitespace()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.factory.CreateShader(PipelineTarget.Vertex, "\t\r\n"));
        }

        [Test]
        public void CreateVertexBufferShouldReturnOpenGLVertexBufferWhenDataIsNotNull()
        {
            // Act
            IVertexBuffer actual = this.factory.CreateVertexBuffer(Array.Empty<int>(), 0, 0);

            // Assert
            Assert.IsInstanceOf(typeof(OpenGLVertexBuffer<int>), actual);
        }

        [Test]
        public void CreateVertexBufferShouldThrowArgumentNullExceptionWhenDataIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.factory.CreateVertexBuffer<int>(null, 0, 0));
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.factory = new OpenGLGPUResourceFactory(this.invoker.Object);
        }
    }
}