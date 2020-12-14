// <copyright file="OpenGLGPUResourceFactoryTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Pipeline;
    using FinalEngine.Rendering.Pipeline;
    using FinalEngine.Utilities;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public class OpenGLGPUResourceFactoryTests
    {
        private OpenGLGPUResourceFactory factory;

        private Mock<IOpenGLInvoker> invoker;

        private Mock<IEnumMapper> mapper;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLGPUResourceFactory(null, this.mapper.Object));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenMapperIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLGPUResourceFactory(this.invoker.Object, null));
        }

        [Test]
        public void CreateIndexBufferShouldReturnOpenGLIndexBufferWhenInvoked()
        {
            // Act
            IIndexBuffer actual = this.factory.CreateIndexBuffer<int>(Array.Empty<int>(), 0);

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
        public void CreateInputLayoutShouldReturnOpenGLInputLayoutWhenInvoked()
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
        public void CreateShaderProgramShouldReturnOpenGLShaderProgramWhenInvoked()
        {
            // Act
            IShaderProgram actual = this.factory.CreateShaderProgram(Enumerable.Empty<IOpenGLShader>());

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
        public void CreateShaderShouldReturnOpenGLShaderWhenInvoked()
        {
            // Act
            IShader actual = this.factory.CreateShader(PipelineTarget.Vertex, "test");

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
            Assert.Throws<ArgumentNullException>(() => this.factory.CreateShader(PipelineTarget.Vertex, "\r\n\t"));
        }

        [Test]
        public void CreateVertexBufferShouldReturnOpenGLVertexBufferWhenInvoked()
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
            this.invoker = new Mock<IOpenGLInvoker>();
            this.mapper = new Mock<IEnumMapper>();

            this.factory = new OpenGLGPUResourceFactory(this.invoker.Object, this.mapper.Object);
        }
    }
}