// <copyright file="OpenTKKeyboardDeviceTests.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Core.Platform.Desktop.OpenTK
{
    using System;
    using FinalEngine.Input.Keyboard;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using Moq;
    using NUnit.Framework;
    using TKKeyboardKeyEventArgs = global::OpenTK.Windowing.Common.KeyboardKeyEventArgs;
    using TKKeys = global::OpenTK.Windowing.GraphicsLibraryFramework.Keys;
    using TKModifiers = global::OpenTK.Windowing.GraphicsLibraryFramework.KeyModifiers;

    public class OpenTKKeyboardDeviceTests
    {
        [Test]
        public void ConstructorShouldHookOntoNativeWindowKeyDownEventWhenNativeWindowIsNotNull()
        {
            // Arrange
            var nativeWindow = new Mock<INativeWindowInvoker>();

            // Act
            _ = new OpenTKKeyboardDevice(nativeWindow.Object);

            // Assert
            nativeWindow.VerifyAdd(x => x.KeyDown += It.IsAny<Action<TKKeyboardKeyEventArgs>>(), Times.Once);
        }

        [Test]
        public void ConstructorShouldHookOntoNativeWindowKeyUpEventWhenNativeWindowIsNotNull()
        {
            // Arrange
            var nativeWindow = new Mock<INativeWindowInvoker>();

            // Act
            _ = new OpenTKKeyboardDevice(nativeWindow.Object);

            // Assert
            nativeWindow.VerifyAdd(x => x.KeyUp += It.IsAny<Action<TKKeyboardKeyEventArgs>>(), Times.Once);
        }

        [Test]
        public void ConstructorShouldNotThrowExceptionWhenNativeWindowIsNotNull()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new OpenTKKeyboardDevice(new Mock<INativeWindowInvoker>().Object));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenNativeWindowIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenTKKeyboardDevice(null));
        }

        [Test]
        public void NativeWindowKeyDownEventShouldRaiseKeyDownEventWhenRaised()
        {
            // Arrange
            var nativeWindow = new Mock<INativeWindowInvoker>();
            var keyboardDevice = new OpenTKKeyboardDevice(nativeWindow.Object);

            keyboardDevice.KeyDown += (s, e) =>
            {
                Assert.AreEqual(s, keyboardDevice);
                Assert.AreEqual(Key.A, e.Key);
                Assert.AreEqual(KeyModifiers.Alt, e.Modifiers);
            };

            // Act
            nativeWindow.Raise(x => x.KeyDown += null, new TKKeyboardKeyEventArgs(TKKeys.A, 0, TKModifiers.Alt, false));
        }

        [Test]
        public void NativeWindowKeyUpEventShouldRaiseKeyUpEventWhenRaised()
        {
            // Arrange
            var nativeWindow = new Mock<INativeWindowInvoker>();
            var keyboardDevice = new OpenTKKeyboardDevice(nativeWindow.Object);

            keyboardDevice.KeyUp += (s, e) =>
            {
                Assert.AreEqual(s, keyboardDevice);
                Assert.AreEqual(Key.A, e.Key);
                Assert.AreEqual(KeyModifiers.Alt, e.Modifiers);
            };

            // Act
            nativeWindow.Raise(x => x.KeyUp += null, new TKKeyboardKeyEventArgs(TKKeys.A, 0, TKModifiers.Alt, false));
        }
    }
}