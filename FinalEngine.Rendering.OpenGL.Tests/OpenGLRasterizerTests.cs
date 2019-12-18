namespace FinalEngine.Rendering.OpenGL.Tests
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invoking;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL;

    public sealed class OpenGLRasterizerTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception_When_Invoker_Parameter_Is_Not_Null()
        {
            // Arrange
            var mockInvoker = new Mock<IOpenGLInvoker>();

            // Act and assert
            Assert.DoesNotThrow(() => new OpenGLRasterizer(mockInvoker.Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNull_Exception_When_Invoker_Parameter_Is_Null()
        {
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLRasterizer(null));
        }

        [Test]
        public void SetRasterState_Test_1()
        {
            // Arrange
            var mockInvoker = new Mock<IOpenGLInvoker>();
            var rasterizer = new OpenGLRasterizer(mockInvoker.Object);

            var description = new RasterStateDescription()
            {
                CullEnabled = true,
                FaceCullMode = FaceCullMode.Back,
                FillMode = RasterMode.Solid,
                WindingDirection = WindingDirection.Clockwise
            };

            // Act
            rasterizer.SetRasterState(description);

            // Assert
            mockInvoker.Verify(i => i.Enable(EnableCap.CullFace), Times.Once);
            mockInvoker.Verify(i => i.CullFace(CullFaceMode.Back), Times.Once);
            mockInvoker.Verify(i => i.FrontFace(FrontFaceDirection.Cw), Times.Once);
            mockInvoker.Verify(i => i.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill), Times.Once);
        }

        [Test]
        public void SetRasterState_Test_2()
        {
            // Arrange
            var mockInvoker = new Mock<IOpenGLInvoker>();
            var rasterizer = new OpenGLRasterizer(mockInvoker.Object);

            var description = new RasterStateDescription()
            {
                CullEnabled = false,
                FaceCullMode = FaceCullMode.Front,
                FillMode = RasterMode.Wireframe,
                WindingDirection = WindingDirection.CounterClockwise
            };

            // Act
            rasterizer.SetRasterState(description);

            // Assert
            mockInvoker.Verify(i => i.Disable(EnableCap.CullFace), Times.Once);
            mockInvoker.Verify(i => i.CullFace(CullFaceMode.Front), Times.Once);
            mockInvoker.Verify(i => i.FrontFace(FrontFaceDirection.Ccw), Times.Once);
            mockInvoker.Verify(i => i.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line), Times.Once);
        }

        [Test]
        public void SetViewport_Test_Should_Call_Invoker_Method_Once()
        {
            // Arrange
            var mockInvoker = new Mock<IOpenGLInvoker>();
            var rasterizer = new OpenGLRasterizer(mockInvoker.Object);

            // Act
            rasterizer.SetViewport(10, 20, 30, 40);

            // Assert
            mockInvoker.Verify(i => i.Viewport(10, 20, 30, 40), Times.Once);
        }
    }
}