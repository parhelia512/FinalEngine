// <copyright file="KeyEventArgsTests.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Tests
{
    using System;
    using FinalEngine.Input.Events;
    using Moq;
    using NUnit.Framework;

    public sealed class KeyEventArgsTests
    {
        [Test]
        public void AltModifier_Test_Should_Be_True()
        {
            // Act
            var keyEventArgs = new KeyEventArgs(
                It.IsAny<Key>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<bool>(),
                true,
                It.IsAny<bool>());

            // Assert
            Assert.IsTrue(keyEventArgs.AltModifier);
        }

        [Test]
        public void CapsLockState_Property_Test()
        {
            // Arrange
            Array values = Enum.GetValues(typeof(LockableKeyState));
            var expected = (LockableKeyState)values.GetValue(new Random().Next(values.Length));

            var keyEventArgs = new KeyEventArgs(
                It.IsAny<Key>(),
                expected,
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<bool>(),
                It.IsAny<bool>(),
                It.IsAny<bool>());

            // Act
            LockableKeyState actual = keyEventArgs.CapsLockState;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ControlModifier_Test_Should_Be_True()
        {
            // Act
            var keyEventArgs = new KeyEventArgs(
                It.IsAny<Key>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<bool>(),
                It.IsAny<bool>(),
                true);

            // Assert
            Assert.IsTrue(keyEventArgs.ControlModifier);
        }

        [Test]
        public void Key_Property_Test()
        {
            // Arrange
            Array values = Enum.GetValues(typeof(Key));
            var expected = (Key)values.GetValue(new Random().Next(values.Length));

            var keyEventArgs = new KeyEventArgs(
                expected,
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<bool>(),
                It.IsAny<bool>(),
                It.IsAny<bool>());

            // Act
            Key actual = keyEventArgs.Key;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShiftModifier_Test_Should_Be_True()
        {
            // Act
            var keyEventArgs = new KeyEventArgs(
                It.IsAny<Key>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                It.IsAny<LockableKeyState>(),
                true,
                It.IsAny<bool>(),
                It.IsAny<bool>());

            // Assert
            Assert.IsTrue(keyEventArgs.ShiftModifier);
        }
    }
}