// <copyright file="OpenTKWindowTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.Tests.OpenTK
{
    using System;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using Moq;
    using NUnit.Framework;

    public class OpenTKWindowTests
    {
        private Mock<INativeWindowInvoker> nativeWindow;

        private OpenTKWindow window;

        [Test]
        public void CloseShouldInvokeNativeWindowCloseWhenNativeWindowIsNotDisposed()
        {
            // Act
            this.window.Close();

            // Assert
            this.nativeWindow.Verify(x => x.Close(), Times.Once);
        }

        [Test]
        public void CloseShouldThrowObjectDisposedExceptionWhenNativeWindowIsDisposed()
        {
            // Arrange
            this.nativeWindow.SetupGet(x => x.IsDisposed).Returns(true);

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.window.Close());
        }

        [Test]
        public void ConstructorShouldNotThrowException()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new OpenTKWindow(new Mock<INativeWindowInvoker>().Object));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenNativeWindowIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenTKWindow(null));
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            this.window.Dispose();
        }

        [Test]
        public void IsExitingShouldInvokeNativeWindowIsExiting()
        {
            // Act
            _ = this.window.IsExiting;

            // Assert
            this.nativeWindow.VerifyGet(x => x.IsExiting, Times.Once);
        }

        [Test]
        public void IsExitingShouldReturnSameAsNativeWindowIsExiting()
        {
            // Arrange
            this.nativeWindow.SetupGet(x => x.IsExiting).Returns(true);

            // Act
            bool actual = this.window.IsExiting;

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void ProcessEventsShouldInvokeNativeWindowProcessEventsWhenNativeWindowIsNotDisposed()
        {
            // Arrange
            this.nativeWindow.SetupGet(x => x.IsDisposed).Returns(false);

            // Act
            this.window.ProcessEvents();

            // Assert
            this.nativeWindow.Verify(x => x.ProcessEvents(), Times.Once);
        }

        [Test]
        public void ProcessEventsShouldThrowObjectDisposedExceptionWhenNativeWindowIsDisposed()
        {
            // Arrange
            this.nativeWindow.SetupGet(x => x.IsDisposed).Returns(true);

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.window.ProcessEvents());
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.nativeWindow = new Mock<INativeWindowInvoker>();
            this.window = new OpenTKWindow(this.nativeWindow.Object);
        }

        [Test]
        public void TitleGetShouldInvokeNativeWindowTitle()
        {
            // Act
            _ = this.window.Title;

            // Assert
            this.nativeWindow.VerifyGet(x => x.Title, Times.Once);
        }

        [Test]
        public void TitleSetShouldSetNativeWindowTitleWhenNativeWindowIsNotDisposed()
        {
            // Arrange
            const string Expected = "Testing";
            this.nativeWindow.SetupGet(x => x.IsDisposed).Returns(false);

            // Act
            this.window.Title = Expected;

            // Assert
            this.nativeWindow.VerifySet(x => x.Title = Expected, Times.Once);
        }

        [Test]
        public void TitleSetShouldThrowObjectDisposedExceptionWhenNativeWindowIsDisposed()
        {
            // Arrange
            this.nativeWindow.SetupGet(x => x.IsDisposed).Returns(true);

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.window.Title = null);
        }

        [Test]
        public void VisibleGetShouldInvokeNativeWindowIsVisible()
        {
            // Act
            _ = this.window.Visible;

            // Assert
            this.nativeWindow.VerifyGet(x => x.IsVisible, Times.Once);
        }

        [Test]
        public void VisibleSetShouldSetNativeWindwoIsVisibleWhenNativeWindowIsNotDisposed()
        {
            // Arrange
            const bool Expected = true;
            this.nativeWindow.SetupGet(x => x.IsDisposed).Returns(false);

            // Act
            this.window.Visible = Expected;

            // Assert
            this.nativeWindow.VerifySet(x => x.IsVisible = Expected, Times.Once);
        }

        [Test]
        public void VisibleSetShouldThrowObjectDisposedExceptionWhenNativeWindowIsDisposed()
        {
            // Arrange
            this.nativeWindow.SetupGet(x => x.IsDisposed).Returns(true);

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.window.Visible = false);
        }
    }
}