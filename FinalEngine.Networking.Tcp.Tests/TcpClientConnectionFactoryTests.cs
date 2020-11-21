// <copyright file="TcpClientConnectionFactoryTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Tests
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;
    using Moq;
    using NUnit.Framework;

    public class TcpClientConnectionFactoryTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new TcpClientConnectionFactory());
        }

        [Test]
        public void CreateClientConnection_Test_Should_Not_Return_Null()
        {
            // Arrange
            var factory = new TcpClientConnectionFactory();
            var client = new Mock<ITcpClientInvoker>();

            // Act
            ITcpClientConnection actual = factory.CreateClientConnection(client.Object);

            // Assert
            Assert.NotNull(actual);
        }

        [Test]
        public void CreateClientConnection_Test_Should_Throw_ArgumentNullException_When_Client_Is_Null()
        {
            // Arrange
            var factory = new TcpClientConnectionFactory();

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => factory.CreateClientConnection(null));
        }
    }
}