namespace FinalEngine.Logging.Tests.Handlers
{
    using System;
    using System.IO;
    using FinalEngine.Logging.Handlers;
    using Moq;
    using NUnit.Framework;

    public sealed class TextWriterLogHandlerTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Exception_When_All_Parameters_Are_Not_Null()
        {
            // Arrange
            ILogFormatter logFormatter = new Mock<ILogFormatter>().Object;
            TextWriter textWriter = new Mock<TextWriter>().Object;

            // Act and assert
            Assert.DoesNotThrow(() => new TextWriterLogHandler(logFormatter, textWriter));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_LogFormatter_Parameter_Is_Null()
        {
            // Arrange
            TextWriter textWriter = new Mock<TextWriter>().Object;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TextWriterLogHandler(null, textWriter));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_TextWriter_Parameter_Is_Null()
        {
            // Arrange
            ILogFormatter logFormatter = new Mock<ILogFormatter>().Object;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TextWriterLogHandler(logFormatter, null));
        }

        [Test]
        public void Log_Test_Should_Call_TextWriter_WriteLine_Once()
        {
            // Arrange
            var mockLogFormatter = new Mock<ILogFormatter>();
            var mockTextWriter = new Mock<TextWriter>();

            var logHandler = new TextWriterLogHandler(mockLogFormatter.Object, mockTextWriter.Object);

            // Act
            logHandler.Log(It.IsAny<LogType>(), "Some String");

            // Assert
            mockTextWriter.Verify(t => t.WriteLine(It.IsAny<string>()), Times.Once);
            mockLogFormatter.Verify(f => f.GetFormattedLog(It.IsAny<LogType>(), "Some String"), Times.Once);
        }
        
        [Test]
        public void Log_Test_Should_Throw_ArgumentNullException_When_Message_Is_Null()
        {
            // Arrange
            var mockLogFormatter = new Mock<ILogFormatter>();
            var mockTextWriter = new Mock<TextWriter>();

            var logHandler = new TextWriterLogHandler(mockLogFormatter.Object, mockTextWriter.Object);
            
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => logHandler.Log(It.IsAny<LogType>(), null));
        }
        
        [Test]
        public void Log_Test_Should_Throw_ArgumentNullException_When_Message_Is_Empty()
        {
            // Arrange
            var mockLogFormatter = new Mock<ILogFormatter>();
            var mockTextWriter = new Mock<TextWriter>();

            var logHandler = new TextWriterLogHandler(mockLogFormatter.Object, mockTextWriter.Object);
            
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => logHandler.Log(It.IsAny<LogType>(), string.Empty));
        }
    }
}
