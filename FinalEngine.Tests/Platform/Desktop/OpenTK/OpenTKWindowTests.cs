// <copyright file="OpenTKWindowTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Platform.Desktop.OpenTK
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is done in TearDown.")]
    public class OpenTKWindowTests
    {
        private Mock<INativeWindowInvoker> nativeWindow;

        private OpenTKWindow window;

        [Test]
        public void CloseShouldInvokeNativeWindowCloseWhenNativeWindowIsNotDisposed()
        {
            // Arrange
            this.nativeWindow.SetupGet(x => x.IsDisposed).Returns(false);

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
        public void ConstructorShouldNotThrowExceptionWhenNativeWindowIsNotNull()
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

        [Test]
        public void DisposeShouldInvokeNativeWindowDisposeWhenNotDisposed()
        {
            // Arrange
            this.nativeWindow.Setup(x => x.IsDisposed).Returns(false);

            // Act
            this.window.Dispose();

            // Assert
            this.nativeWindow.Verify(x => x.Dispose(), Times.Once);
        }

        [Test]
        public void IsExitingShouldInvokeNativeWindowIsExitingWhenRead()
        {
            // Act
            _ = this.window.IsExiting;

            // Assert
            this.nativeWindow.VerifyGet(x => x.IsExiting, Times.Once);
        }

        [Test]
        public void IsExitingShouldReturnSameAsNativeWindowIsExitingWhenRead()
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

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.nativeWindow = new Mock<INativeWindowInvoker>();
            this.window = new OpenTKWindow(this.nativeWindow.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.window.Dispose();
        }

        [Test]
        public void TitleGetShouldInvokeNativeWindowTitleWhenRead()
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
        public void VisibleGetShouldInvokeNativeWindowIsVisibleWhenRead()
        {
            // Act
            _ = this.window.Visible;

            // Assert
            this.nativeWindow.VerifyGet(x => x.IsVisible, Times.Once);
        }

        [Test]
        public void VisibleSetShouldSetNativeWindowIsVisibleWhenNativeWindowIsNotDisposed()
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