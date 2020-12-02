// <copyright file="OpenGLShaderProgramTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL.Pipeline
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Pipeline;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is done in TearDown.")]
    public class OpenGLShaderProgramTests
    {
        private Mock<IOpenGLInvoker> invoker;

        private OpenGLShaderProgram program;

        private Mock<IOpenGLShader> shader;

        private IOpenGLShader[] shaders;

        [Test]
        public void BindShouldInvokeUseProgramWhenInvoked()
        {
            // Act
            this.program.Bind();

            // Assert
            this.invoker.Verify(x => x.UseProgram(0), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeCreateProgramWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.CreateProgram(), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeGetProgramInfoLogWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.GetProgramInfoLog(0), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeLinkProgramWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.LinkProgram(0), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeShaderAttachWhenParametersAreNotNull()
        {
            // Assert
            this.shader.Verify(x => x.Attach(0), Times.Once);
        }

        public void ConstructorShouldInvokeValidateProgramWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.ValidateProgram(0), Times.Once);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLShaderProgram(null, Array.Empty<IOpenGLShader>()));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenShadersIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLShaderProgram(new Mock<IOpenGLInvoker>().Object, null));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenGetProgramInfoLogReturnsString()
        {
            // Arrange
            var invoker = new Mock<IOpenGLInvoker>();
            invoker.Setup(x => x.GetProgramInfoLog(0)).Returns("test");

            // Act and assert
            Assert.Throws<Exception>(() => new OpenGLShaderProgram(invoker.Object, this.shaders));
        }

        [Test]
        public void DisposeShouldInvokeDeleteProgramWhenInvoked()
        {
            // Act
            this.program.Dispose();

            // Assert
            this.invoker.Verify(x => x.DeleteProgram(0), Times.Once);
        }

        [Test]
        public void GetUniformLocationShouldInvokeGetUniformLocationWhenNameIsNotNull()
        {
            // Act
            this.program.GetUniformLocation("test");

            // Assert
            this.invoker.Verify(x => x.GetUniformLocation(0, "test"), Times.Once);
        }

        [Test]
        public void GetUniformLocationShouldReturnSameAsInvokerGetUniformLocationWhenInvoked()
        {
            // Arrange
            const int Expected = 12;

            this.invoker.Setup(x => x.GetUniformLocation(0, It.IsAny<string>())).Returns(Expected);

            // Act
            int actual = this.program.GetUniformLocation("test");

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void GetUniformLocationShouldThrowArgumentNullExceptionWhenNameIsEmpty()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.program.GetUniformLocation(string.Empty));
        }

        [Test]
        public void GetUniformLocationShouldThrowArgumentNullExceptionWhenNameIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.program.GetUniformLocation(null));
        }

        [Test]
        public void GetUniformLocationShouldThrowArgumentNullExceptionWhenNameIsWhitespace()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.program.GetUniformLocation("\t\r\n"));
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();

            this.shader = new Mock<IOpenGLShader>();
            this.shaders = new IOpenGLShader[]
            {
                null,
                this.shader.Object,
            };

            this.program = new OpenGLShaderProgram(this.invoker.Object, this.shaders);
        }

        [TearDown]
        public void Teardown()
        {
            this.program.Dispose();
        }
    }
}