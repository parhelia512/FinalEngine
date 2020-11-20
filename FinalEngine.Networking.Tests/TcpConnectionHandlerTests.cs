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
            // Arrange
            ITcpListenerInvoker listener = new Mock<ITcpListenerInvoker>().Object;
            ITcpClientConnectionFactory factory = new Mock<ITcpClientConnectionFactory>().Object;

            // Act and assert
            Assert.DoesNotThrow(() => new TcpConnectionHandler(listener, factory));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Factory_Is_Null()
        {
            // Arrange
            ITcpListenerInvoker listener = null;
            ITcpClientConnectionFactory factory = new Mock<ITcpClientConnectionFactory>().Object;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TcpConnectionHandler(listener, factory));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Listener_Is_Null()
        {
            // Arrange
            ITcpListenerInvoker listener = new Mock<ITcpListenerInvoker>().Object;
            ITcpClientConnectionFactory factory = null;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TcpConnectionHandler(listener, factory));
        }

        [Test]
        public void Handle_Test_Should_Invoke_Factory_CreateClientConnection()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var factory = new Mock<ITcpClientConnectionFactory>();

            var client = new Mock<ITcpClientInvoker>();
            listener.Setup(i => i.AcceptTcpClient()).Returns(client.Object);

            var handler = new TcpConnectionHandler(listener.Object, factory.Object);

            // Act
            handler.Handle();

            // Assert
            factory.Verify(i => i.CreateClientConnection(client.Object), Times.Once);
        }

        [Test]
        public void Handle_Test_Should_Invoke_Listener_AcceptTcpClient()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var factory = new Mock<ITcpClientConnectionFactory>();

            var handler = new TcpConnectionHandler(listener.Object, factory.Object);

            // Act
            handler.Handle();

            // Assert
            listener.Verify(i => i.AcceptTcpClient(), Times.Once);
        }
    }
}