namespace FinalEngine.Rendering.Direct3D11.Tests
{
    using System;
    using FinalEngine.Rendering.Direct3D11.Invoking;
    using Moq;
    using NUnit.Framework;

    public sealed class Direct3D11RasterizerTests
    {
        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Device_Parameter_Is_Null()
        {
            // Arrange
            var mockDeviceContext = new Mock<ID3D11DeviceContextInvoker>();

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new Direct3D11Rasterizer(null, mockDeviceContext.Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_DeviceContext_Parameter_Is_Null()
        {
            // Arrange
            var mockDevice = new Mock<ID3D11DeviceInvoker>();

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new Direct3D11Rasterizer(mockDevice.Object, null));
        }

        [Test]
        public void SetViewport_Test_Should_Invoke_RSSetViewport()
        {
            // Arrange
            var mockDevice = new Mock<ID3D11DeviceInvoker>();
            var mockDeviceContext = new Mock<ID3D11DeviceContextInvoker>();

            var rasterizer = new Direct3D11Rasterizer(mockDevice.Object, mockDeviceContext.Object);

            // Act
            rasterizer.SetViewport(10, 20, 30, 40);

            // Assert
            mockDeviceContext.Verify(x => x.RSSetViewport(10, 20, 30, 40), Times.Once);
        }
    }
}