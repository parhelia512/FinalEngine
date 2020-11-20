// <copyright file="TcpClientConnectionTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Tests
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;
    using Moq;
    using NUnit.Framework;

    public class TcpClientConnectionTests
    {
        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Client_Is_Null()
        {
            // Arrange
            ITcpClientInvoker client = null;
            var guid = Guid.NewGuid();

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TcpClientConnection(client, guid));
        }

        [Test]
        public void Disconnect_Test_Should_Invoke_Client_Close()
        {
            // Arrange
            var client = new Mock<ITcpClientInvoker>();
            var connection = new TcpClientConnection(client.Object, Guid.NewGuid());

            // Act
            connection.Disconnect();

            // Assert
            client.Verify(i => i.Close(), Times.Once);
        }

        [Test]
        public void Disconnect_Test_Should_Raise_Disconnect_Event()
        {
            // Arrange
            var client = new Mock<ITcpClientInvoker>();
            var connection = new TcpClientConnection(client.Object, Guid.NewGuid());

            connection.Disconnected += (s, e) =>
            {
                // Assert
                Assert.AreSame(connection, e.Connection);
            };

            // Act
            connection.Disconnect();
        }

        [Test]
        public void Guid_Test_Should_Not_Return_Default()
        {
            // Arrange
            ITcpClientInvoker client = new Mock<ITcpClientInvoker>().Object;
            var expected = Guid.NewGuid();

            var connection = new TcpClientConnection(client, expected);

            // Act
            Guid actual = connection.Guid;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IPAddress_Test_Should_Invoke_Client_Socket_GetAddress_Local()
        {
            // Arrange
            var client = new Mock<ITcpClientInvoker>();
            var socket = new Mock<ISocketInvoker>();

            client.SetupGet(i => i.Socket).Returns(socket.Object);

            var expected = Guid.NewGuid();

            var connection = new TcpClientConnection(client.Object, expected);

            // Act
            _ = connection.IPAddress;

            // Assert
            socket.Verify(i => i.GetAddress(AreaCode.Remote), Times.Once);
        }

        [Test]
        public void IPAddress_Test_Should_Return_LocalHost()
        {
            // Arrange
            const string Expected = "127.0.0.1";

            var client = new Mock<ITcpClientInvoker>();
            var socket = new Mock<ISocketInvoker>();

            client.SetupGet(i => i.Socket).Returns(socket.Object);
            socket.Setup(i => i.GetAddress(AreaCode.Remote)).Returns(Expected);

            var expected = Guid.NewGuid();

            var connection = new TcpClientConnection(client.Object, expected);

            // Act
            string actual = connection.IPAddress;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Port_Test_Should_Invoke_Client_Socket_GetPort_Local()
        {
            // Arrange
            var client = new Mock<ITcpClientInvoker>();
            var socket = new Mock<ISocketInvoker>();

            client.SetupGet(i => i.Socket).Returns(socket.Object);

            var expected = Guid.NewGuid();

            var connection = new TcpClientConnection(client.Object, expected);

            // Act
            _ = connection.Port;

            // Assert
            socket.Verify(i => i.GetPort(AreaCode.Remote), Times.Once);
        }

        [Test]
        public void Port_Test_Should_Return_43594()
        {
            // Arrange
            const int Expected = 43594;

            var client = new Mock<ITcpClientInvoker>();
            var socket = new Mock<ISocketInvoker>();

            client.SetupGet(i => i.Socket).Returns(socket.Object);
            socket.Setup(i => i.GetPort(AreaCode.Remote)).Returns(Expected);

            var expected = Guid.NewGuid();

            var connection = new TcpClientConnection(client.Object, expected);

            // Act
            int actual = connection.Port;

            // Assert
            Assert.AreEqual(Expected, actual);
        }
    }
}