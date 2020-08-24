// <copyright file="MouseWheelEventArgsTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Tests
{
    using FinalEngine.Input.Mouse;
    using NUnit.Framework;

    public sealed class MouseWheelEventArgsTests
    {
        [Test]
        public void Location_Property_Test_Should_Be_12()
        {
            // Arrange
            const int Expected = 12;

            var mouseWheelEventArgs = new MouseWheelEventArgs(Expected);

            // Act
            float actual = mouseWheelEventArgs.Delta;

            // Assert
            Assert.AreEqual(Expected, actual);
        }
    }
}