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
        public void DeviceKeyDownShouldThrowArgumentNullExceptionWhenEventDataIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.keyboardDevice.Raise(x => x.KeyDown += null, new object[] { new object(), null }));
        }

        [Test]
        public void DeviceKeyUpShouldThrowArgumentNullExceptionWhenEventDataIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.keyboardDevice.Raise(x => x.KeyUp += null, new object[] { new object(), null }));
        }

        [Test]
        public void IsKeyDownShouldReturnFalseWhenKeyIsNotDownDuringCurrentFrame()
        {
            // Act
            bool actual = this.keyboard.IsKeyDown(Key.V);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyDownShouldReturnTrueWhenKeyIsDownDuringCurrentFrame()
        {
            // Arrange
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
        public void IsKeyPressedShouldReturnFalseWhenKeyIsNotDownDuringCurrentFrameAndDownDuringPreviousFrame()
        {
            // Act
            bool actual = this.keyboard.IsKeyPressed(Key.LeftAlt);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyPressedShouldReturnTrueWhenKeyIsDownDuringCurrentFrameAndNotDownDuringPreviousFrame()
        {
            // Arrange
            this.keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.G,
            });

            // Act
            bool actual = this.keyboard.IsKeyPressed(Key.G);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void IsKeyReleasedShouldReturnFalseWhenKeyIsDownDuringCurrentFrameAndNotDownDuringPreviousFrame()
        {
            // Arrange
            this.keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.LeftBracket,
            });

            // Act
            bool actual = this.keyboard.IsKeyReleased(Key.LeftBracket);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyReleasedShouldReturnTrueWhenKeyIsNotDownDuringCurrentFrameAndDownDuringPreviousFrame()
        {
            // Arrange
            this.keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.Apostrophe,
            });

            this.keyboard.Update();

            this.keyboardDevice.Raise(x => x.KeyUp += null, new KeyEventArgs()
            {
                Key = Key.Apostrophe,
            });

            // Act
            bool actual = this.keyboard.IsKeyReleased(Key.Apostrophe);

            // Assert
            Assert.True(actual);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.keyboardDevice = new Mock<IKeyboardDevice>();
            this.keyboard = new Keyboard(this.keyboardDevice.Object);
        }
    }
}