namespace FinalEngine.Platform.Desktop.Tests.Devices
{
    using System;
    using FinalEngine.Platform.Desktop.Devices;
    using Moq;
    using NUnit.Framework;
    using OpenTK;
    using OpenTK.Input;

    public sealed class OpenTKKeyboardDeviceTests
    {
        [Test]
        public void Constructor_Test_NativeWindowKeyDown_Event_Should_Be_Added()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();

            mockNativeWindow.SetupAdd(x => x.KeyDown += (s, e) => { });

            // Act
            var keyboardDevice = new OpenTKKeyboardDevice(mockNativeWindow.Object);

            // Assert
            mockNativeWindow.VerifyAdd(x => x.KeyDown += It.IsAny<EventHandler<KeyboardKeyEventArgs>>(), Times.Once);
        }

        [Test]
        public void Constructor_Test_NativeWindowKeyUp_Event_Should_Be_Added()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();

            mockNativeWindow.SetupAdd(x => x.KeyUp += (s, e) => { });

            // Act
            var keyboardDevice = new OpenTKKeyboardDevice(mockNativeWindow.Object);

            // Assert
            mockNativeWindow.VerifyAdd(x => x.KeyUp += It.IsAny<EventHandler<KeyboardKeyEventArgs>>(), Times.Once);
        }

        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception_When_NativeWindow_Parameter_Is_Not_Null()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();

            // Act and assert
            Assert.DoesNotThrow(() => new OpenTKKeyboardDevice(mockNativeWindow.Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_NativeWindow_Parameter_Is_Null()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenTKKeyboardDevice(null));
        }

        [Test]
        public void KeyPressed_Event_Should_Be_Raised()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();
            var keyboardDevice = new OpenTKKeyboardDevice(mockNativeWindow.Object);

            bool eventWasCalled = false;

            keyboardDevice.KeyPressed += (s, e) => eventWasCalled = true;

            // Act
            mockNativeWindow.Raise(x => x.KeyDown += null, new KeyboardKeyEventArgs());

            // Assert
            Assert.IsTrue(eventWasCalled);
        }

        [Test]
        public void KeyReleased_Event_Should_Be_Raised()
        {
            // Arrange
            var mockNativeWindow = new Mock<INativeWindow>();
            var keyboardDevice = new OpenTKKeyboardDevice(mockNativeWindow.Object);

            bool eventWasCalled = false;

            keyboardDevice.KeyReleased += (s, e) => eventWasCalled = true;

            // Act
            mockNativeWindow.Raise(x => x.KeyUp += null, new KeyboardKeyEventArgs());

            // Assert
            Assert.IsTrue(eventWasCalled);
        }
    }
}