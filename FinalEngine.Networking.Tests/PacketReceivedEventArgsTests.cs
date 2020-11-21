// <copyright file="PacketReceivedEventArgsTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tests
{
    using System;
    using Moq;
    using NUnit.Framework;

    public class PacketReceivedEventArgsTests
    {
        [Test]
        public void Bytes_Property_Test_Should_Return_Same_As_Constructor()
        {
            // Arrange
            IClientConnection connection = new Mock<IClientConnection>().Object;
            byte[] expected = new byte[] { 1, 2, 3, 4, 5 };

            var eventArgs = new PacketReceivedEventArgs(connection, expected);

            // Act
            byte[] actual = eventArgs.Bytes;

            // Assert
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void Connection_Property_Test_Should_Return_Same_As_Constructor()
        {
            // Arrange
            IClientConnection expected = new Mock<IClientConnection>().Object;
            byte[] bytes = new byte[] { };

            var eventArgs = new PacketReceivedEventArgs(expected, bytes);

            // Act
            IClientConnection actual = eventArgs.Connection;

            // Assert
            Assert.AreSame(expected, actual);
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Bytes_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new PacketReceivedEventArgs(new Mock<IClientConnection>().Object, null));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Connection_Is_Null()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new PacketReceivedEventArgs(null, new byte[] { }));
        }
    }
}