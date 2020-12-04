// <copyright file="OpenGLShaderTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL.Pipeline
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Pipeline;
    using FinalEngine.Rendering.Pipeline;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is done in TearDown.")]
    public class OpenGLShaderTests
    {
        private Mock<IOpenGLInvoker> invoker;

        private OpenGLShader shader;

        [Test]
        public void AttachShouldInvokeAttachShaderWhenInvoked()
        {
            // Act
            this.shader.Attach(1);

            // Assert
            this.invoker.Verify(x => x.AttachShader(1, 0), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeCompileShaderWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.CompileShader(0), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeCreateShaderWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.CreateShader(ShaderType.VertexShader), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeGetShaderInfoLogWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.GetShaderInfoLog(0), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeShaderSourceWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.ShaderSource(0, "test"), Times.Once);
        }

        [Test]
        public void ConstructorShouldNotThrowExceptionWhenTargetIsFragment()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new OpenGLShader(new Mock<IOpenGLInvoker>().Object, PipelineTarget.Fragment, "test"));
        }

        [Test]
        public void ConstructorShouldNotThrowExceptionWhenTargetIsVertex()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new OpenGLShader(new Mock<IOpenGLInvoker>().Object, PipelineTarget.Vertex, "test"));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLShader(null, PipelineTarget.Vertex, "test"));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenSourceCodeIsEmpty()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLShader(new Mock<IOpenGLInvoker>().Object, PipelineTarget.Vertex, string.Empty));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenSourceCodeIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLShader(new Mock<IOpenGLInvoker>().Object, PipelineTarget.Vertex, null));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenSourceCodeIsWhiteSpace()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLShader(new Mock<IOpenGLInvoker>().Object, PipelineTarget.Vertex, "\t\r\n"));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenGetShaderInfoLogReturnsString()
        {
            // Arrange
            var invoker = new Mock<IOpenGLInvoker>();

            invoker.Setup(x => x.GetShaderInfoLog(0)).Returns("test");

            // Act and assert
            Assert.Throws<Exception>(() => new OpenGLShader(invoker.Object, PipelineTarget.Vertex, "test"));
        }

        [Test]
        public void ConstructorShouldThrowNotSupportedExceptionWhenShaderTypeIsNotDefined()
        {
            // Arrange
            Assert.IsFalse(Enum.IsDefined(typeof(PipelineTarget), int.MaxValue));

            var invoker = new Mock<IOpenGLInvoker>();

            // Act and assert
            Assert.Throws<NotSupportedException>(() => new OpenGLShader(invoker.Object, (PipelineTarget)int.MaxValue, "test"));
        }

        [Test]
        public void DisposeShouldInvokeDeletShaderWhenInvoked()
        {
            // Act
            this.shader.Dispose();

            // Assert
            this.invoker.Verify(x => x.DeleteShader(0), Times.Once);
        }

        [Test]
        public void EntryPointShouldReturnSameAsConstructorWhenRetrieved()
        {
            // Act
            PipelineTarget actual = this.shader.EntryPoint;

            // Assert
            Assert.AreEqual(PipelineTarget.Vertex, actual);
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.shader = new OpenGLShader(this.invoker.Object, PipelineTarget.Vertex, "test");
        }

        [TearDown]
        public void Teardown()
        {
            this.shader.Dispose();
        }
    }
}