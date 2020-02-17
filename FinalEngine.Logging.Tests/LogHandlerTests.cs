// <copyright file="LogHandlerTests.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Logging.Tests
{
    using System;
    using FinalEngine.Logging.Tests.Mocks;
    using Moq;
    using NUnit.Framework;

    public sealed class LogHandlerTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception_When_LogFormatter_Is_Not_Null()
        {
            // Arrange
            var mockLogFormatter = new Mock<ILogFormatter>();

            // Act and assert
            Assert.DoesNotThrow(() => new MockLogHandler(mockLogFormatter.Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_LogFormatter_Is_Null()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new MockLogHandler(null));
        }

        [Test]
        public void Formatter_Property_Test_Should_Not_Be_Null()
        {
            // Arrange
            var mockLogFormatter = new Mock<ILogFormatter>();
            var mockLogHandler = new MockLogHandler(mockLogFormatter.Object);

            // Act and assert
            Assert.IsNotNull(mockLogHandler.InternalFormatter);
        }
    }
}