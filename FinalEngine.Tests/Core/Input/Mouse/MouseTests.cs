// <copyright file="MouseTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Core.Input.Mouse
{
    using System;
    using System.Drawing;
    using FinalEngine.Input.Mouse;
    using Moq;
    using NUnit.Framework;

    public class MouseTests
    {
        private Mouse mouse;

        private Mock<IMouseDevice> mouseDevice;

        [Test]
        public void DeviceButtonDownShouldThrowArgumentNullExceptionWhenEventDataIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => this.mouseDevice.Raise(x => x.ButtonDown += null, new object[] { new object(), null }));
        }

        [Test]
        public void DeviceButtonUpShouldThrowArgumentNullExceptionWhenEventDataIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => this.mouseDevice.Raise(x => x.ButtonUp += null, new object[] { new object(), null }));
        }

        [Test]
        public void DeviceMoveShouldSetLocationToNewLocation()
        {
            // Arrange
            this.mouseDevice.Raise(x => x.Move += null, new MouseMoveEventArgs()
            {
                Location = new PointF(100, 400),
            });

            // Act
            PointF actual = this.mouse.Location;

            // Assert
            Assert.AreEqual(new PointF(100, 400), actual);
        }

        [Test]
        public void DeviceScrollShouldSetWheelOffsetToNewWheelOffset()
        {
            // Arrange
            this.mouseDevice.Raise(x => x.Scroll += null, new MouseScrollEventArgs()
            {
                Offset = 132.0d,
            });

            // Act
            double actual = this.mouse.WheelOffset;

            // Assert
            Assert.AreEqual(132.0d, actual);
        }

        [Test]
        public void IsButtonDownShouldReturnFalseWhenButtonNotDownDuringCurrentFrame()
        {
            // Act
            bool actual = this.mouse.IsButtonDown(MouseButton.Button1);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsButtonDownShouldReturnTrueWhenButtonDownDuringCurrentFrame()
        {
            // Arrange
            this.mouseDevice.Raise(x => x.ButtonDown += null, new MouseButtonEventArgs()
            {
                Button = MouseButton.Button3,
            });

            // Act
            bool actual = this.mouse.IsButtonDown(MouseButton.Button3);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void IsButtonPressedShouldReturnFalseWhenButtonIsNotDownDuringCurrentFrame()
        {
            // Arrange
            this.mouseDevice.Raise(x => x.ButtonDown += null, new MouseButtonEventArgs()
            {
                Button = MouseButton.Right,
            });

            this.mouse.Update();

            this.mouseDevice.Raise(x => x.ButtonUp += null, new MouseButtonEventArgs()
            {
                Button = MouseButton.Right,
            });

            // Act
            bool actual = this.mouse.IsButtonPressed(MouseButton.Right);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsButtonPressedShouldReturnTrueWhenButtonDownDuringCurrentFrameAndNotDownDuringPreviousFrame()
        {
            this.mouseDevice.Raise(x => x.ButtonDown += null, new MouseButtonEventArgs()
            {
                Button = MouseButton.Button3,
            });

            // Act
            bool actual = this.mouse.IsButtonPressed(MouseButton.Button3);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void IsButtonReleasedShouldReturnFalseWhenButtonDownDuringCurrentFrameAndNotDownDuringPreviousFrame()
        {
            // Arrange
            this.mouseDevice.Raise(x => x.ButtonDown += null, new MouseButtonEventArgs()
            {
                Button = MouseButton.Right,
            });

            // Act
            bool actual = this.mouse.IsButtonReleased(MouseButton.Right);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsButtonReleasedShouldReturnTrueWhenButtonNotDownDuringCurrentFrameAndButtonDownDuringPreviousFrame()
        {
            // Arrange
            this.mouseDevice.Raise(x => x.ButtonDown += null, new MouseButtonEventArgs()
            {
                Button = MouseButton.Left,
            });

            this.mouse.Update();

            this.mouseDevice.Raise(x => x.ButtonUp += null, new MouseButtonEventArgs()
            {
                Button = MouseButton.Left,
            });

            // Act
            bool actual = this.mouse.IsButtonReleased(MouseButton.Left);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void LocationGetShouldReturnEmptyPointByDefault()
        {
            // Act
            PointF actual = this.mouse.Location;

            // Assert
            Assert.AreEqual(PointF.Empty, actual);
        }

        [Test]
        public void LocationSetShouldInvokeDeviceSetCursorLocationWhenValueIsNotEqualToLocation()
        {
            // Act
            this.mouse.Location = new PointF(100, 200);

            // Assert
            this.mouseDevice.Verify(x => x.SetCursorLocation(new Point(100, 200)), Times.Once);
        }

        [Test]
        public void LocationSetShouldNotInvokeSetCursorLocationWhenValueIsEqualToLocation()
        {
            // Act
            this.mouse.Location = PointF.Empty;

            // Assert
            this.mouseDevice.Verify(x => x.SetCursorLocation(It.IsAny<PointF>()), Times.Never);
        }

        [SetUp]
        public void Setup()
        {
            this.mouseDevice = new Mock<IMouseDevice>();
            this.mouse = new Mouse(this.mouseDevice.Object);
        }

        [Test]
        public void WheelOffsetShouldBeZeroByDefault()
        {
            // Act
            double actual = this.mouse.WheelOffset;

            // Assert
            Assert.Zero(actual);
        }
    }
}