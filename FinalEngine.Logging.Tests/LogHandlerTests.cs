namespace FinalEngine.Logging.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;

    public sealed class LogHandlerTests
    {
        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNulLException_When_LogFormatter_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new Mock<LogHandler>(null));
        }
    }
}