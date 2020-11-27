// <copyright file="KeyboardTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Core.Input.Keyboard
{
    using System;
    using System.Reflection;
    using FinalEngine.Input.Keyboard;
    using Moq;
    using NUnit.Framework;

    //// TODO: OneTimeSetup

    public class KeyboardTests
    {
        [Test]
        public void DeviceKeyDownShouldThrowArgumentNullExceptionWhenEIsNull()
        {
            // Arrange
            var keyboardDevice = new Mock<IKeyboardDevice>();
            var keyboard = Keyboard.Create(keyboardDevice.Object);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => keyboardDevice.Raise(x => x.KeyDown += null, new object[] { new object(), null }));
        }

        [Test]
        public void DeviceKeyDownShouldThrowNullReferenceExceptionWhenKeysDownIsNull()
        {
            // Arrange
            var keyboard = Keyboard.Create(null);

            MethodInfo method = keyboard.GetType().GetMethod("Device_KeyDown", BindingFlags.NonPublic | BindingFlags.Instance);

            try
            {
                // Act
                method.Invoke(keyboard, new object[] { new object(), new KeyEventArgs() });
            }
            catch (TargetInvocationException e)
            {
                // Assert
                Assert.AreEqual(typeof(NullReferenceException), e.InnerException.GetType());
            }
        }

        [Test]
        public void DeviceKeyUpShouldThrowArgumentNullExceptionWhenEIsNull()
        {
            // Arrange
            var keyboardDevice = new Mock<IKeyboardDevice>();
            var keyboard = Keyboard.Create(keyboardDevice.Object);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => keyboardDevice.Raise(x => x.KeyUp += null, new object[] { new object(), null }));
        }

        [Test]
        public void DeviceKeyUpShouldThrowNullReferenceExceptionWhenKeysDownIsNull()
        {
            // Arrange
            var keyboard = Keyboard.Create(null);

            MethodInfo method = keyboard.GetType().GetMethod("Device_KeyUp", BindingFlags.NonPublic | BindingFlags.Instance);

            try
            {
                // Act
                method.Invoke(keyboard, new object[] { new object(), new KeyEventArgs() });
            }
            catch (TargetInvocationException e)
            {
                // Assert
                Assert.AreEqual(typeof(NullReferenceException), e.InnerException.GetType());
            }
        }

        [Test]
        public void IsKeyDownShouldReturnFalseWhenDeviceIsNull()
        {
            // Arrange
            var keyboard = Keyboard.Create(null);

            // Act
            bool actual = keyboard.IsKeyDown(Key.A);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyDownShouldReturnFalseWhenDeviceKeyDownEventNotRaised()
        {
            // Arrange
            var keyboardDevice = new Mock<IKeyboardDevice>();
            var keyboard = Keyboard.Create(keyboardDevice.Object);

            // Act
            bool actual = keyboard.IsKeyDown(Key.A);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyDownShouldReturnTrueWhenDeviceKeyUpEventRaised()
        {
            // Arrange
            var keyboardDevice = new Mock<IKeyboardDevice>();
            var keyboard = Keyboard.Create(keyboardDevice.Object);

            keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.A,
            });

            // Act
            bool actual = keyboard.IsKeyDown(Key.A);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void IsKeyPressedShouldReturnFalseWhenDeviceIsNull()
        {
            // Arrange
            var keyboard = Keyboard.Create(null);

            // Act
            bool actual = keyboard.IsKeyPressed(Key.A);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyPressedShouldReturnFalseWhenKeyNotDownDuringCurrentFrameAndDownDuringPreviousFrame()
        {
            // Arrange
            var keyboardDevice = new Mock<IKeyboardDevice>();
            var keyboard = Keyboard.Create(keyboardDevice.Object);

            keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.C,
            });

            // Simulate frame processing.
            keyboard.Update();

            // Act
            bool actual = keyboard.IsKeyPressed(Key.C);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyPressedShouldReturnTrueWhenKeyDownDuringCurrentFrameAndNotPreviousFrame()
        {
            // Arrange
            var keyboardDevice = new Mock<IKeyboardDevice>();
            var keyboard = Keyboard.Create(keyboardDevice.Object);

            keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.C,
            });

            // Act
            bool actual = keyboard.IsKeyPressed(Key.C);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void IsKeyReleasedShouldReturnFalseWhenDeviceIsNull()
        {
            // Arrange
            var keyboard = Keyboard.Create(null);

            // Act
            bool actual = keyboard.IsKeyReleased(Key.D);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyReleasedShouldReturnFalseWhenKeyDownDuringCurrentFrameAndKeyNotDownDuringPreviousFrame()
        {
            // Arrange
            var keyboardDevice = new Mock<IKeyboardDevice>();
            var keyboard = Keyboard.Create(keyboardDevice.Object);

            // Key has now been released.
            keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.H,
            });

            // Act
            bool actual = keyboard.IsKeyReleased(Key.H);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void IsKeyReleasedShouldReturnTrueWhenKeyDownDuringPreviousFrameAndNotDownDuringCurrentFrame()
        {
            // Arrange
            var keyboardDevice = new Mock<IKeyboardDevice>();
            var keyboard = Keyboard.Create(keyboardDevice.Object);

            // Key down during the previous frame
            keyboardDevice.Raise(x => x.KeyDown += null, new KeyEventArgs()
            {
                Key = Key.G,
            });

            // Simulate frame processing
            keyboard.Update();

            // Key has now been released.
            keyboardDevice.Raise(x => x.KeyUp += null, new KeyEventArgs()
            {
                Key = Key.G,
            });

            // Act
            bool actual = keyboard.IsKeyReleased(Key.G);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void UpdateShouldNotThrowExceptionWhenDeviceIsNull()
        {
            // Arrange
            var keyboard = Keyboard.Create(null);

            // Act and assert
            Assert.DoesNotThrow(() => keyboard.Update());
        }
    }
}