// <copyright file="OpenGLRenderContextTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using Moq;
    using NUnit.Framework;
    using OpenTK;
    using OpenTK.Windowing.Common;

    [ExcludeFromCodeCoverage]
    public class OpenGLRenderContextTests
    {
        private Mock<IBindingsContext> bindings;

        private Mock<IGraphicsContext> context;

        private Mock<IOpenGLInvoker> invoker;

        private OpenGLRenderContext renderContext;

        [Test]
        public void ConstructorShouldInvokeContextMakeCurrentWhenParametersAreNotNull()
        {
            // Assert
            this.context.Verify(x => x.MakeCurrent(), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeInvokeLoadBindingsWhenParametersAreNotNull()
        {
            // Assert
            this.invoker.Verify(x => x.LoadBindings(this.bindings.Object), Times.Once);
        }

        [Test]
        public void ConstructorShouldNotThrowExceptionWhenParametersAreNotNull()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new OpenGLRenderContext(new Mock<IOpenGLInvoker>().Object, new Mock<IBindingsContext>().Object, new Mock<IGraphicsContext>().Object));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenBindingsIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLRenderContext(new Mock<IOpenGLInvoker>().Object, null, new Mock<IGraphicsContext>().Object));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenContextIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLRenderContext(new Mock<IOpenGLInvoker>().Object, new Mock<IBindingsContext>().Object, null));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLRenderContext(null, new Mock<IBindingsContext>().Object, new Mock<IGraphicsContext>().Object));
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.bindings = new Mock<IBindingsContext>();
            this.context = new Mock<IGraphicsContext>();
            this.renderContext = new OpenGLRenderContext(this.invoker.Object, this.bindings.Object, this.context.Object);
        }

        [Test]
        public void SwapBuffersShouldInvokeContextSwapBuffersWhenContextIsCurrent()
        {
            // Arrange
            this.context.SetupGet(x => x.IsCurrent).Returns(true);

            // Act
            this.renderContext.SwapBuffers();

            // Assert
            this.context.Verify(x => x.SwapBuffers(), Times.Once);
        }

        [Test]
        public void SwapBuffersShouldNotInvokeContextSwapBuffersWhenContextIsNotCurrent()
        {
            // Arrange
            this.context.SetupGet(x => x.IsCurrent).Returns(false);

            // Act
            this.renderContext.SwapBuffers();

            // Assert
            this.context.Verify(x => x.SwapBuffers(), Times.Never);
        }
    }
}