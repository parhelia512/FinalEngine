// <copyright file="TcpServerTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Tests
{
    using System;
    using System.Threading;
    using FinalEngine.Core.Threading;
    using FinalEngine.Networking.Tcp.Invoking;
    using Moq;
    using NUnit.Framework;

    public class TcpServerTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange
            ITcpListenerInvoker listener = new Mock<ITcpListenerInvoker>().Object;
            ITaskExecuter executer = new Mock<ITaskExecuter>().Object;
            IConnectionHandler handler = new Mock<IConnectionHandler>().Object;

            // Act and assert
            Assert.DoesNotThrow(() => new TcpServer(listener, executer, handler));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Executer_Is_Null()
        {
            // Arrange
            ITcpListenerInvoker listener = new Mock<ITcpListenerInvoker>().Object;
            ITaskExecuter executer = null;
            IConnectionHandler handler = new Mock<IConnectionHandler>().Object;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TcpServer(listener, executer, handler));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Handler_Is_Null()
        {
            // Arrange
            ITcpListenerInvoker listener = new Mock<ITcpListenerInvoker>().Object;
            ITaskExecuter executer = new Mock<ITaskExecuter>().Object;
            IConnectionHandler handler = null;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TcpServer(listener, executer, handler));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Listener_Is_Null()
        {
            // Arrange
            ITcpListenerInvoker listener = null;
            ITaskExecuter executer = new Mock<ITaskExecuter>().Object;
            IConnectionHandler handler = new Mock<IConnectionHandler>().Object;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => new TcpServer(listener, executer, handler));
        }

        [Test]
        public void IPAddress_Property_Test_Should_Invoke_Listener_Server_GetAddress_Local()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var socket = new Mock<ISocketInvoker>();
            listener.SetupGet(i => i.Server).Returns(socket.Object);

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);

            // Act
            _ = server.IPAddress;

            // Assert
            socket.Verify(i => i.GetAddress(AreaCode.Local), Times.Once);
        }

        [Test]
        public void IPAddress_Property_Test_Should_Return_LocalHost()
        {
            // Arrange
            const string Expected = "127.0.0.1";

            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var socket = new Mock<ISocketInvoker>();

            socket.Setup(i => i.GetAddress(AreaCode.Local)).Returns(Expected);
            listener.SetupGet(i => i.Server).Returns(socket.Object);

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);

            // Act
            string actual = server.IPAddress;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void IsRunning_Property_Test_Should_Return_False_By_Default()
        {
            // Arrange
            ITcpListenerInvoker listener = new Mock<ITcpListenerInvoker>().Object;
            ITaskExecuter executer = new Mock<ITaskExecuter>().Object;
            IConnectionHandler handler = new Mock<IConnectionHandler>().Object;

            var server = new TcpServer(listener, executer, handler);

            // Act
            bool actual = server.IsRunning;

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void Port_Property_Test_Should_Invoke_Listener_Server_GetPort_Local()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var socket = new Mock<ISocketInvoker>();
            listener.SetupGet(i => i.Server).Returns(socket.Object);

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);

            // Act
            _ = server.Port;

            // Assert
            socket.Verify(i => i.GetPort(AreaCode.Local), Times.Once);
        }

        [Test]
        public void Port_Property_Test_Should_Return_43594()
        {
            // Arrange
            const int Expected = 43594;

            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var socket = new Mock<ISocketInvoker>();

            socket.Setup(i => i.GetPort(AreaCode.Local)).Returns(43594);
            listener.SetupGet(i => i.Server).Returns(socket.Object);

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);

            // Act
            int actual = server.Port;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Start_Test_Should_Invoke_Executer_Execute_Once_When_Called_Twice()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);

            // Act
            server.Start();
            server.Start();

            // Assert
            executer.Verify(i => i.Execute(It.IsAny<ThreadStart>()), Times.Once);
        }

        [Test]
        public void Start_Test_Should_Invoke_Executer_Execute_When_Called_Once()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);

            // Act
            server.Start();

            // Assert
            executer.Verify(i => i.Execute(It.IsAny<ThreadStart>()), Times.Once);
        }

        [Test]
        public void Start_Test_Should_Invoke_Listener_Start_Once_When_Called_Twice()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);

            // Act
            server.Start();
            server.Start();

            // Assert
            listener.Verify(i => i.Start(), Times.Once);
        }

        [Test]
        public void Start_Test_Should_Invoke_Listener_Start_When_Called_Once()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);

            // Act
            server.Start();

            // Assert
            listener.Verify(i => i.Start(), Times.Once);
        }

        [Test]
        public void Start_Test_Should_Set_IsRunning_To_True_When_Called_Once()
        {
            // Arrange
            ITcpListenerInvoker listener = new Mock<ITcpListenerInvoker>().Object;
            ITaskExecuter executer = new Mock<ITaskExecuter>().Object;
            IConnectionHandler handler = new Mock<IConnectionHandler>().Object;

            var server = new TcpServer(listener, executer, handler);

            // Act
            server.Start();

            // Assert
            Assert.True(server.IsRunning);
        }

        [Test]
        public void Stop_Test_Should_Invoke_Listener_Stop_Once_When_Called_Twice()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);
            server.Start();

            // Act
            server.Stop();
            server.Stop();

            // Assert
            listener.Verify(i => i.Stop(), Times.Once);
        }

        [Test]
        public void Stop_Test_Should_Invoke_Listener_Stop_When_Start_Has_Been_Called()
        {
            // Arrange
            var listener = new Mock<ITcpListenerInvoker>();
            var executer = new Mock<ITaskExecuter>();
            var handler = new Mock<IConnectionHandler>();

            var server = new TcpServer(listener.Object, executer.Object, handler.Object);
            server.Start();

            // Act
            server.Stop();

            // Assert
            listener.Verify(i => i.Stop(), Times.Once);
        }

        [Test]
        public void Stop_Test_Should_Set_IsRunning_To_False_When_Start_Has_Been_Called()
        {
            // Arrange
            ITcpListenerInvoker listener = new Mock<ITcpListenerInvoker>().Object;
            ITaskExecuter executer = new Mock<ITaskExecuter>().Object;
            IConnectionHandler handler = new Mock<IConnectionHandler>().Object;

            var server = new TcpServer(listener, executer, handler);
            server.Start();

            // Act
            server.Stop();

            // Assert
            Assert.False(server.IsRunning);
        }
    }
}