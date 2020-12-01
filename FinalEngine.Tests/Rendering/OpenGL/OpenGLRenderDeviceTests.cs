// <copyright file="OpenGLRenderDeviceTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public class OpenGLRenderDeviceTests
    {
        private Mock<IOpenGLInvoker> invoker;

        private OpenGLRenderDevice renderDevice;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLRenderDevice(null));
        }

        [Test]
        public void RasterizerShouldReturnOpenGLRasterizer()
        {
            // Act
            IRasterizer actual = this.renderDevice.Rasterizer;

            // Assert
            Assert.IsInstanceOf(typeof(OpenGLRasterizer), actual);
        }

        [SetUp]
        public void Setup()
        {
            this.invoker = new Mock<IOpenGLInvoker>();
            this.renderDevice = new OpenGLRenderDevice(this.invoker.Object);
        }
    }
}