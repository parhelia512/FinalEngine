// <copyright file="MouseMoveEventArgsTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Tests
{
    using FinalEngine.Drawing;
    using FinalEngine.Input.Mouse;
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