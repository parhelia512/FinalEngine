// <copyright file="OpenGLRenderDeviceTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;

    [ExcludeFromCodeCoverage]
    public class OpenGLRenderDeviceTests
    {
        private Mock<IOpenGLInvoker> invoker;

        private OpenGLRenderDevice renderDevice;

        [Test]
        public void ClearShouldInvokeClearColorWhenInvoked()
        {
            // Arrange
            Color color = Color.White;

            // Act
            this.renderDevice.Clear(color);

            // Assert
            this.invoker.Verify(x => x.ClearColor(color), Times.Once);
        }

        [Test]
        public void ClearShouldInvokeClearDepthWhenInvoked()
        {
            // Act
            this.renderDevice.Clear(Color.White);

            // Assert
            this.invoker.Verify(x => x.ClearDepth(1.0f), Times.Once);
        }

        [Test]
        public void ClearShouldInvokeClearStencilWhenInvoked()
        {
            // Act
            this.renderDevice.Clear(Color.White);

            // Assert
            this.invoker.Verify(x => x.ClearStencil(0), Times.Once);
        }

        [Test]
        public void ClearShouldInvokeClearWhenInvoked()
        {
            // Act
            this.renderDevice.Clear(Color.White);

            // Assert
            this.invoker.Verify(x => x.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit), Times.Once);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLRenderDevice(null));
        }

        [Test]
        public void DrawIndicesShouldInvokeDrawElementsLineStripWhenInvoked()
        {
            // Act
            this.renderDevice.DrawIndices(PrimitiveTopology.LineStrip, 0, 10);

            // Assert
            this.invoker.Verify(x => x.DrawElements(PrimitiveType.LineStrip, 10, DrawElementsType.UnsignedInt, 0), Times.Once);
        }

        [Test]
        public void DrawIndicesShouldInvokeDrawElementsLineWhenInvoked()
        {
            // Act
            this.renderDevice.DrawIndices(PrimitiveTopology.Line, 0, 10);

            // Assert
            this.invoker.Verify(x => x.DrawElements(PrimitiveType.Lines, 10, DrawElementsType.UnsignedInt, 0), Times.Once);
        }

        [Test]
        public void DrawIndicesShouldInvokeDrawElementsTriangleStripWhenInvoked()
        {
            // Act
            this.renderDevice.DrawIndices(PrimitiveTopology.TriangleStrip, 0, 10);

            // Assert
            this.invoker.Verify(x => x.DrawElements(PrimitiveType.TriangleStrip, 10, DrawElementsType.UnsignedInt, 0), Times.Once);
        }

        [Test]
        public void DrawIndicesShouldInvokeDrawElementsTrianglesWhenInvoked()
        {
            // Act
            this.renderDevice.DrawIndices(PrimitiveTopology.Triangle, 0, 10);

            // Assert
            this.invoker.Verify(x => x.DrawElements(PrimitiveType.Triangles, 10, DrawElementsType.UnsignedInt, 0), Times.Once);
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
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.renderDevice = new OpenGLRenderDevice(this.invoker.Object);
        }
    }
}