// <copyright file="TcpServerTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tests
{
    using System;
    using FinalEngine.Networking.Tcp;
    using FinalEngine.Networking.Tcp.Invoking;
    using Moq;
    using NUnit.Framework;

    public class TcpServerTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new TcpServer(new Mock<ITcpListenerInvoker>().Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Listener_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new TcpServer(null));
        }

        [Test]
        public void IsRunning_Test_Should_Be_False_By_Default()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var server = new TcpServer(listener.Object);

            // Act
            bool actual = server.IsRunning;

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void Start_Test_Should_Invoke_AcceptTcpClient_When_Not_Running()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var server = new TcpServer(listener.Object);

            // Act
            server.Start();

            // Assert
            listener.Verify(i => i.AcceptTcpClient(), Times.Once);
        }

        [Test]
        public void Start_Test_Should_Invoke_Listener_Start_When_Not_Running()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var server = new TcpServer(listener.Object);

            // Act
            server.Start();

            // Assert
            listener.Verify(i => i.Start(), Times.Once);
        }

        [Test]
        public void Start_Test_Should_Not_Invoke_Listener_Start_When_Running()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var server = new TcpServer(listener.Object);

            server.Start();

            // Act
            server.Start();

            // Assert
            listener.Verify(i => i.Start(), Times.Once);
        }

        [Test]
        public void Stop_Test_Should_Invoke_Listener_Stop_When_Running()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var server = new TcpServer(listener.Object);

            server.Start();

            // Act
            server.Stop();

            // Assert
            listener.Verify(i => i.Stop(), Times.Once);
        }

        [Test]
        public void Stop_Test_Should_Not_Invoke_Listener_Stop_When_Not_Running()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var server = new TcpServer(listener.Object);

            // Act
            server.Stop();

            // Assert
            listener.Verify(i => i.Stop(), Times.Never);
        }

        [Test]
        public void Stop_Test_Should_Set_IsRunning_To_False_When_Running()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var server = new TcpServer(listener.Object);

            server.Start();

            // Act
            server.Stop();

            // Assert
            Assert.False(server.IsRunning);
        }
    }
}