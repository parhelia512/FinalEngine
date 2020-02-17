// <copyright file="MouseWheelEventArgsTests.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Tests
{
    using FinalEngine.Input.Events;
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