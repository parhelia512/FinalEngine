// <copyright file="OpenGLRasterizerTests.cs" company="Software Antics">
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
    public class OpenGLRasterizerTests
    {
        private Mock<IOpenGLInvoker> invoker;

        private OpenGLRasterizer rasterizer;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLRasterizer(null));
        }

        [Test]
        public void SetRasterShouldInvokeDisableScissorTestWhenScissorEnabledFalse()
        {
            // Arrange
            RasterStateDescription description = default;

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.Disable(EnableCap.ScissorTest), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokeCullFaceBackWhenCullModeBack()
        {
            // Arrange
            var description = new RasterStateDescription()
            {
                CullMode = FaceCullMode.Back,
            };

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.CullFace(CullFaceMode.Back), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokeCullFaceFrontWhenCullModeFront()
        {
            // Arrange
            var description = new RasterStateDescription()
            {
                CullMode = FaceCullMode.Front,
            };

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.CullFace(CullFaceMode.Front), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokeDisableCullFaceWhenCullEnabledFalse()
        {
            // Arrange
            RasterStateDescription description = default;

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.Disable(EnableCap.CullFace), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokeEnableCullFaceWhenCullEnabledTrue()
        {
            // Arrange
            var description = new RasterStateDescription()
            {
                CullEnabled = true,
            };

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.Enable(EnableCap.CullFace), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokeEnableScissorTestWhenScissorEnabledTrue()
        {
            // Arrange
            var description = new RasterStateDescription()
            {
                ScissorEnabled = true,
            };

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.Enable(EnableCap.ScissorTest), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokeFrontFaceClockwiseWhenDirectionClockwise()
        {
            // Arrange
            var description = new RasterStateDescription()
            {
                WindingDirection = WindingDirection.Clockwise,
            };

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.FrontFace(FrontFaceDirection.Cw), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokeFrontFaceCounterClockwiseWhenDirectionCounterClockwise()
        {
            // Arrange
            var description = new RasterStateDescription()
            {
                WindingDirection = WindingDirection.CounterClockwise,
            };

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.FrontFace(FrontFaceDirection.Ccw), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokePolygonModeFillWhenRasterModeSolid()
        {
            // Arrange
            var description = new RasterStateDescription()
            {
                FillMode = RasterMode.Solid,
            };

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill), Times.Once);
        }

        [Test]
        public void SetRasterStateShouldInvokePolygonModeLineWhenRasterModeWireframe()
        {
            // Arrange
            var description = new RasterStateDescription()
            {
                FillMode = RasterMode.Wireframe,
            };

            // Act
            this.rasterizer.SetRasterState(description);

            // Assert
            this.invoker.Verify(x => x.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line), Times.Once);
        }

        [Test]
        public void SetScissorShouldInvokeScissorWhenInvoked()
        {
            // Arrange
            var rectangle = new Rectangle(10, 10, 400, 632);

            // Act
            this.rasterizer.SetScissor(rectangle);

            // Assert
            this.invoker.Verify(x => x.Scissor(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), Times.Once);
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.rasterizer = new OpenGLRasterizer(this.invoker.Object);
        }

        [Test]
        public void SetViewportShouldnvokeInvokeSetViewportWhenInvoked()
        {
            // Arrange
            var rectangle = new Rectangle(1, 2, 4, 6);

            // Act
            this.rasterizer.SetViewport(rectangle);

            // Assert
            this.invoker.Verify(x => x.Viewport(rectangle));
        }
    }
}