// <copyright file="StandardLogFormatterTests.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Logging.Tests.Formatters
{
    using FinalEngine.Logging.Formatters;
    using NUnit.Framework;

    public sealed class StandardLogFormatterTests
    {
        [Test]
        public void GetFormattedLog_Debug_Test()
        {
            // Arrange
            var logFormatter = new StandardLogFormatter();
            const string expected = "[DEBUG] This Is A Test";

            // Act
            string actual = logFormatter.GetFormattedLog(LogType.Debug, "This Is A Test");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFormattedLog_Error_Test()
        {
            // Arrange
            var logFormatter = new StandardLogFormatter();
            const string expected = "[ERROR] This Is A Test";

            // Act
            string actual = logFormatter.GetFormattedLog(LogType.Error, "This Is A Test");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFormattedLog_Information_Test()
        {
            // Arrange
            var logFormatter = new StandardLogFormatter();
            const string expected = "[INFORMATION] This Is A Test";

            // Act
            string actual = logFormatter.GetFormattedLog(LogType.Information, "This Is A Test");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFormattedLog_Warning_Test()
        {
            // Arrange
            var logFormatter = new StandardLogFormatter();
            const string expected = "[WARNING] This Is A Test";

            // Act
            string actual = logFormatter.GetFormattedLog(LogType.Warning, "This Is A Test");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}