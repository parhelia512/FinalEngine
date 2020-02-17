// <copyright file="ScreenTests.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Tests
{
    using FinalEngine.Drawing;
    using NUnit.Framework;

    public sealed class ScreenTests
    {
        public void Size_Property_Test()
        {
            // Arrange
            var expected = new Size(100, 300);
            var screen = new Screen(expected);

            // Act
            Size actual = screen.Size;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}