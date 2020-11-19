// <copyright file="TcpConnectionHandlerTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Tests
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;
    using Moq;
    using NUnit.Framework;

    public class TcpConnectionHandlerTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new TcpConnectionHandler(new Mock<ITcpListenerInvoker>().Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Listener_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new TcpConnectionHandler(null));
        }

        [Test]
        public void Handle_Test_Should_Invoke_Listener_AcceptTcpClient_When_IsRunning_Is_True()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var server = new Mock<IServer>();

            var handler = new TcpConnectionHandler(listener.Object);

            server.SetupSequence(i => i.IsRunning)
                .Returns(true)
                .Returns(false);

            // Act
            handler.Handle(server.Object);

            // Assert
            listener.Verify(i => i.AcceptTcpClient(), Times.Once);
        }

        [Test]
        public void Handle_Test_Should_Throw_ArgumentNullException_When_Server_Is_Null()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var handler = new TcpConnectionHandler(listener.Object);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => handler.Handle(null));
        }
    }
}