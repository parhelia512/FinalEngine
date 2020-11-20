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
        public void Client_Disconnect_Should_Raise_ClientDisconnected_Event()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var factory = new Mock<ITcpClientConnectionFactory>();
            var client = new Mock<ITcpClientInvoker>();
            var connection = new TcpClientConnection(client.Object, Guid.NewGuid());
            var server = new Mock<IServer>();

            server.SetupSequence(i => i.IsRunning).Returns(true).Returns(false);
            listener.Setup(i => i.AcceptTcpClient()).Returns(client.Object);
            factory.Setup(i => i.CreateClientConnection(client.Object)).Returns(connection);

            var handler = new TcpConnectionHandler(listener.Object, factory.Object);

            handler.ClientDisconnected += (s, e) =>
            {
                // Assert
                Assert.AreSame(connection, e.Connection);
            };

            handler.Handle(server.Object);

            // Act
            client.Object.Close();
        }

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
            var connection = new TcpClientConnection(client.Object, Guid.NewGuid());

            var server = new Mock<IServer>();

            server.SetupSequence(i => i.IsRunning).Returns(true).Returns(false);
            listener.Setup(i => i.AcceptTcpClient()).Returns(client.Object);
            factory.Setup(i => i.CreateClientConnection(client.Object)).Returns(connection);

            var handler = new TcpConnectionHandler(listener.Object, factory.Object);

            // Act
            handler.Handle(server.Object);

            // Assert
            factory.Verify(i => i.CreateClientConnection(client.Object), Times.Once);
        }

        [Test]
        public void Handle_Test_Should_Invoke_Listener_AcceptTcpClient()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var factory = new Mock<ITcpClientConnectionFactory>();

            var client = new Mock<ITcpClientInvoker>();
            var connection = new TcpClientConnection(client.Object, Guid.NewGuid());

            var server = new Mock<IServer>();

            server.SetupSequence(i => i.IsRunning).Returns(true).Returns(false);
            listener.Setup(i => i.AcceptTcpClient()).Returns(client.Object);
            factory.Setup(i => i.CreateClientConnection(client.Object)).Returns(connection);

            var handler = new TcpConnectionHandler(listener.Object, factory.Object);

            // Act
            handler.Handle(server.Object);

            // Assert
            listener.Verify(i => i.AcceptTcpClient(), Times.Once);
        }

        [Test]
        public void Handle_Test_Should_Raise_ClientConnected_Event()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var factory = new Mock<ITcpClientConnectionFactory>();
            var client = new Mock<ITcpClientInvoker>();
            var connection = new TcpClientConnection(client.Object, Guid.NewGuid());
            var server = new Mock<IServer>();

            server.SetupSequence(i => i.IsRunning).Returns(true).Returns(false);

            listener.Setup(i => i.AcceptTcpClient()).Returns(client.Object);
            factory.Setup(i => i.CreateClientConnection(client.Object)).Returns(connection);

            var handler = new TcpConnectionHandler(listener.Object, factory.Object);

            handler.ClientConnected += (s, e) =>
            {
                // Assert
                Assert.AreSame(connection, e.Connection);
            };

            // Act
            handler.Handle(server.Object);
        }

        [Test]
        public void Handle_Test_Should_Throw_ArgumentNullException_When_Server_Is_Null()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var factory = new Mock<ITcpClientConnectionFactory>();
            var handler = new TcpConnectionHandler(listener.Object, factory.Object);

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => handler.Handle(null));
        }

        [Test]
        public void Handle_Test_Should_Throw_Exception_When_Factory_CreateClientConnection_Returns_Null()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var factory = new Mock<ITcpClientConnectionFactory>();
            var client = new Mock<ITcpClientInvoker>();
            var server = new Mock<IServer>();

            server.SetupSequence(i => i.IsRunning).Returns(true).Returns(false);
            listener.Setup(i => i.AcceptTcpClient()).Returns(client.Object);

            var handler = new TcpConnectionHandler(listener.Object, factory.Object);

            // Act and assert
            Assert.Throws<Exception>(() => handler.Handle(server.Object));
        }
    }
}