namespace FinalEngine.Input.Tests
{
    using System;
    using FinalEngine.Input.Events;
    using Moq;
    using NUnit.Framework;

    public sealed class KeyEventArgsTests
    {
        [Test]
        public void CapsLockState_Property_Test()
        {
            // Arrange
            Array values = Enum.GetValues(typeof(LockableKeyState));
            var expected = (LockableKeyState)values.GetValue(new Random().Next(values.Length));

            var keyEventArgs = new KeyEventArgs(It.IsAny<Key>(),
                                                expected,
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<KeyModifier>());

            // Act
            LockableKeyState actual = keyEventArgs.CapsLockState;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Key_Property_Test()
        {
            // Arrange
            Array values = Enum.GetValues(typeof(Key));
            var expected = (Key)values.GetValue(new Random().Next(values.Length));

            var keyEventArgs = new KeyEventArgs(expected,
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<KeyModifier>());

            // Act
            Key actual = keyEventArgs.Key;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void KeyModifiers_Property_Test_Should_Be_Control_And_Alt()
        {
            // Arrange
            const KeyModifier Expected = KeyModifier.Control | KeyModifier.Alt;

            var keyEventArgs = new KeyEventArgs(It.IsAny<Key>(),
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<LockableKeyState>(),
                                                Expected);

            // Act
            KeyModifier actual = keyEventArgs.KeyModifiers;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void NumLockState_Property_Test()
        {
            // Arrange
            Array values = Enum.GetValues(typeof(LockableKeyState));
            var expected = (LockableKeyState)values.GetValue(new Random().Next(values.Length));

            var keyEventArgs = new KeyEventArgs(It.IsAny<Key>(),
                                                It.IsAny<LockableKeyState>(),
                                                expected,
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<KeyModifier>());

            // Act
            LockableKeyState actual = keyEventArgs.NumLockState;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ScrollLockState_Property_Test()
        {
            // Arrange
            Array values = Enum.GetValues(typeof(LockableKeyState));
            var expected = (LockableKeyState)values.GetValue(new Random().Next(values.Length));

            var keyEventArgs = new KeyEventArgs(It.IsAny<Key>(),
                                                It.IsAny<LockableKeyState>(),
                                                It.IsAny<LockableKeyState>(),
                                                expected,
                                                It.IsAny<KeyModifier>());

            // Act
            LockableKeyState actual = keyEventArgs.ScrollLockState;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}