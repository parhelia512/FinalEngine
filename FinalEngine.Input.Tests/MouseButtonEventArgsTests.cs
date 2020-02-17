// <copyright file="MouseButtonEventArgsTests.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Tests
{
    using System;
    using FinalEngine.Input.Events;
    using NUnit.Framework;

    public sealed class MouseButtonEventArgsTests
    {
        [Test]
        public void MouseButton_Property_Test()
        {
            // Arrange
            Array values = Enum.GetValues(typeof(MouseButton));
            var expected = (MouseButton)values.GetValue(new Random().Next(values.Length));

            var mouseButtonEventArgs = new MouseButtonEventArgs(expected);

            // Act
            MouseButton actual = mouseButtonEventArgs.Button;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}