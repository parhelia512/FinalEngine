// <copyright file="ClientConnectedEventArgsTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;

    public class ClientConnectedEventArgsTests
    {
        [Test]
        public void Connection_Property_Test_Should_Not_Return_Same_As_Input()
        {
            // Arrange
            IClientConnection connection = new Mock<IClientConnection>().Object;
            var eventArgs = new ClientConnectedEventArgs(connection);

            // Act
            IClientConnection actual = eventArgs.Connection;

            // Assert
            Assert.AreSame(connection, actual);
        }

        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new ClientConnectedEventArgs(new Mock<IClientConnection>().Object));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Client_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new ClientConnectedEventArgs(null));
        }
    }
}