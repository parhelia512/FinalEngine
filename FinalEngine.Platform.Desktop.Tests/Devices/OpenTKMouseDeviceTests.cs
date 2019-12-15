namespace FinalEngine.Platform.Desktop.Tests.Devices
{
    using System;
    using FinalEngine.Platform.Desktop.Devices;
    using Moq;
    using NUnit.Framework;
    using OpenTK;
    using OpenTK.Input;

    public sealed class OpenTKMouseDeviceTests
    {
        [Test]
        public void ButtonPressed_Event_Should_Be_Raised()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();
            var mouseDevice = new OpenTKMouseDevice(mockNativeWindow.Object);

            bool eventWasCalled = false;

            mouseDevice.ButtonPressed += (s, e) =>
            {
                eventWasCalled = true;
            };

            // Act
            mockNativeWindow.Raise(x => x.MouseDown += null, new MouseButtonEventArgs());

            // Assert
            Assert.IsTrue(eventWasCalled);
        }

        [Test]
        public void ButtonReleased_Event_Should_Be_Raised()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();
            var mouseDevice = new OpenTKMouseDevice(mockNativeWindow.Object);

            bool eventWasCalled = false;

            mouseDevice.ButtonReleased += (s, e) =>
            {
                eventWasCalled = true;
            };

            // Act
            mockNativeWindow.Raise(x => x.MouseUp += null, new MouseButtonEventArgs());

            // Assert
            Assert.IsTrue(eventWasCalled);
        }

        [Test]
        public void Constructor_Test_NativeWindowMouseDown_Event_Should_Be_Added()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();

            mockNativeWindow.SetupAdd(x => x.MouseDown += (s, e) => { });

            // Act
            var mouseDevice = new OpenTKMouseDevice(mockNativeWindow.Object);

            // Assert
            mockNativeWindow.VerifyAdd(x => x.MouseDown += It.IsAny<EventHandler<MouseButtonEventArgs>>(), Times.Once);
        }

        [Test]
        public void Constructor_Test_NativeWindowMouseMove_Event_Should_Be_Added()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();

            mockNativeWindow.SetupAdd(x => x.MouseMove += (s, e) => { });

            // Act
            var mouseDevice = new OpenTKMouseDevice(mockNativeWindow.Object);

            // Assert
            mockNativeWindow.VerifyAdd(x => x.MouseMove += It.IsAny<EventHandler<MouseMoveEventArgs>>(), Times.Once);
        }

        [Test]
        public void Constructor_Test_NativeWindowMouseUp_Event_Should_Be_Added()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();

            mockNativeWindow.SetupAdd(x => x.MouseUp += (s, e) => { });

            // Act
            var mouseDevice = new OpenTKMouseDevice(mockNativeWindow.Object);

            // Assert
            mockNativeWindow.VerifyAdd(x => x.MouseUp += It.IsAny<EventHandler<MouseButtonEventArgs>>(), Times.Once);
        }

        [Test]
        public void Constructor_Test_NativeWindowMouseWheel_Event_Should_Be_Added()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();

            mockNativeWindow.SetupAdd(x => x.MouseWheel += (s, e) => { });

            // Act
            var mouseDevice = new OpenTKMouseDevice(mockNativeWindow.Object);

            // Assert
            mockNativeWindow.VerifyAdd(x => x.MouseWheel += It.IsAny<EventHandler<MouseWheelEventArgs>>(), Times.Once);
        }

        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception_When_NativeWindow_Parameter_Is_Not_Null()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();

            // Act and assert
            Assert.DoesNotThrow(() => new OpenTKMouseDevice(mockNativeWindow.Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_NativeWindow_Parameter_Is_Null()
        {
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new OpenTKMouseDevice(null));
        }

        [Test]
        public void PositionChanged_Event_Should_Be_Raised()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();
            var mouseDevice = new OpenTKMouseDevice(mockNativeWindow.Object);

            bool eventWasCalled = false;

            mouseDevice.PositionChanged += (s, e) =>
            {
                eventWasCalled = true;
            };

            // Act
            mockNativeWindow.Raise(x => x.MouseMove += null, new MouseMoveEventArgs());

            // Assert
            Assert.IsTrue(eventWasCalled);
        }

        [Test]
        public void WheelPositionChanged_Event_Should_Be_Raised()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();
            var mouseDevice = new OpenTKMouseDevice(mockNativeWindow.Object);

            bool eventWasCalled = false;

            mouseDevice.WheelPositionChanged += (s, e) =>
            {
                eventWasCalled = true;
            };

            // Act
            mockNativeWindow.Raise(x => x.MouseWheel += null, new MouseWheelEventArgs());

            // Assert
            Assert.IsTrue(eventWasCalled);
        }
    }
}