// <copyright file="LoggerTests.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Logging.Tests
{
    using Moq;
    using NUnit.Framework;

    public sealed class LoggerTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Act and assert
            Assert.DoesNotThrow(() => new Logger());
        }

        [Test]
        public void Handlers_Property_Test_Should_Not_Be_Null()
        {
            // Arrange
            var logger = new Logger();

            // Act and assert
            Assert.IsNotNull(logger.Handlers);
        }

        [Test]
        public void Instance_Property_Test_Should_Not_Be_Null()
        {
            // Act and assert
            Assert.IsNotNull(Logger.Instance);
        }

        [Test]
        public void Log_Test_Should_Log_To_All_Handlers()
        {
            // Arrange
            var mockLogHandler1 = new Mock<ILogHandler>();
            var mockLogHandler2 = new Mock<ILogHandler>();
            var mockLogHandler3 = new Mock<ILogHandler>();

            var logger = new Logger();

            logger.Handlers.Add(mockLogHandler1.Object);
            logger.Handlers.Add(mockLogHandler2.Object);
            logger.Handlers.Add(mockLogHandler3.Object);

            // Act
            logger.Log(It.IsAny<LogType>(), It.IsAny<string>());

            // Assert
            mockLogHandler1.Verify(h => h.Log(It.IsAny<LogType>(), It.IsAny<string>()), Times.Once);
            mockLogHandler2.Verify(h => h.Log(It.IsAny<LogType>(), It.IsAny<string>()), Times.Once);
            mockLogHandler3.Verify(h => h.Log(It.IsAny<LogType>(), It.IsAny<string>()), Times.Once);
        }
    }
}