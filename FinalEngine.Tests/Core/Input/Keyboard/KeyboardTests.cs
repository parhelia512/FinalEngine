// <copyright file="KeyboardTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Core.Input.Keyboard
{
    using System;
    using FinalEngine.Input.Keyboard;
    using Moq;
    using NUnit.Framework;

    public class KeyboardTests
    {
        private Keyboard keyboard;

        private Mock<IKeyboardDevice> keyboardDevice;

        [Test]
        public void DeviceKeyDownShouldThrowArgumentNullExceptionWhenEIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.keyboardDevice.Raise(x => x.KeyDown += null, new object[] { new object(), null }));
        }

        [Test]
        public void DeviceKeyUpShouldThrowArgumentNullExceptionWhenEIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.keyboardDevice.Raise(x => x.KeyUp += null, new object[] { new object(), null }));
        }

        [Test]
        public void IsKeyDownShouldReturnFalseWhenDeviceKeyDownEventNotRaised()
        {
            // Act
            bool actual = this.keyboard.IsKeyDown(Key.A);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyDownShouldReturnTrueWhenDeviceKeyUpEventRaised()
        {
            this.keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.A,
            });

            // Act
            bool actual = this.keyboard.IsKeyDown(Key.A);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void IsKeyPressedShouldReturnFalseWhenKeyNotDownDuringCurrentFrameAndDownDuringPreviousFrame()
        {
            this.keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.C,
            });

            // Simulate frame processing.
            this.keyboard.Update();

            this.keyboardDevice.Raise(x => x.KeyUp += null, new KeyEventArgs()
            {
                Key = Key.C,
            });

            // Act
            bool actual = this.keyboard.IsKeyPressed(Key.C);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyPressedShouldReturnTrueWhenKeyDownDuringCurrentFrameAndNotPreviousFrame()
        {
            this.keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.C,
            });

            // Act
            bool actual = this.keyboard.IsKeyPressed(Key.C);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void IsKeyReleasedShouldReturnFalseWhenKeyDownDuringCurrentFrameAndKeyNotDownDuringPreviousFrame()
        {
            // Key has now been released.
            this.keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.H,
            });

            // Act
            bool actual = this.keyboard.IsKeyReleased(Key.H);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyReleasedShouldReturnTrueWhenKeyDownDuringPreviousFrameAndNotDownDuringCurrentFrame()
        {
            // Key down during the previous frame
            this.keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.G,
            });

            // Simulate frame processing
            this.keyboard.Update();

            // Key has now been released.
            this.keyboardDevice.Raise(x => x.KeyUp += null, new KeyEventArgs()
            {
                Key = Key.G,
            });

            // Act
            bool actual = this.keyboard.IsKeyReleased(Key.G);

            // Assert
            Assert.True(actual);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.keyboardDevice = new Mock<IKeyboardDevice>();
            this.keyboard = new Keyboard(this.keyboardDevice.Object);
        }

        [Test]
        public void UpdateShouldNotThrowExceptionWhenDeviceIsNull()
        {
            // Arrange
            var keyboard = new Keyboard(null);

            // Act and assert
            Assert.DoesNotThrow(() => keyboard.Update());
        }
    }
}