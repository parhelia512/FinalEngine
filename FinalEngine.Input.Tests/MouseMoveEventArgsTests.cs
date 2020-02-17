// <copyright file="MouseMoveEventArgsTests.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Tests
{
    using FinalEngine.Drawing;
    using FinalEngine.Input.Events;
    using NUnit.Framework;

    public sealed class MouseMoveEventArgsTests
    {
        [Test]
        public void Location_Property_Test()
        {
            // Arrange
            var expected = new PointF(34, 21);

            var mouseMoveEventArgs = new MouseMoveEventArgs(expected);

            // Act
            PointF actual = mouseMoveEventArgs.Location;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}