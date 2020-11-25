// <copyright file="MouseScrollEventArgsTests.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Core.Input.Mouse
{
    using FinalEngine.Input.Mouse;
    using NUnit.Framework;

    public class MouseScrollEventArgsTests
    {
        [Test]
        public void DeltaShouldReturnSameAsInputWhenSet()
        {
            // Arrange
            const double Expected = 124.0d;

            // Act
            var eventArgs = new MouseScrollEventArgs()
            {
                Delta = Expected,
            };

            // Assert
            Assert.AreEqual(Expected, eventArgs.Delta);
        }
    }
}