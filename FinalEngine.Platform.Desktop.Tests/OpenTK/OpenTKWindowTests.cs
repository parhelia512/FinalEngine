// <copyright file="OpenTKWindowTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.Tests.OpenTK
{
    using System;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using Moq;
    using Xunit;

    public class OpenTKWindowTests
    {
        [Fact]
        public void ConstructorShouldNotThrowException()
        {
            // Arrange
            var nativeWindow = new Mock<INativeWindowInvoker>();

            // Act
            Exception exception = Record.Exception(() => new OpenTKWindow(nativeWindow.Object));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void ConstructorShouldThrowArgumentNullExceptionWhenNativeWindowIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenTKWindow(null));
        }
    }
}