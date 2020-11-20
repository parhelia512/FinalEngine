// <copyright file="TaskExecuterTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Tests.Threading
{
    using System.Threading;
    using System.Threading.Tasks;
    using FinalEngine.Core.Threading;
    using NUnit.Framework;

    public class TaskExecuterTests
    {
        [Test]
        public void Constructor_Test_Should_Not_Throw_ExceptioN()
        {
            // Arrange, act and assert
            Assert.DoesNotThrow(() => new TaskExecuter());
        }

        [Test]
        public void Execute_Test_Should_Pass()
        {
            // Arrange
            var executer = new TaskExecuter();
            var threadStart = new ThreadStart(this.DoTask);

            // Act and assert
            executer.Execute(threadStart);
        }

        private void DoTask()
        {
            Task.Delay(1);
            Assert.Pass();
        }
    }
}