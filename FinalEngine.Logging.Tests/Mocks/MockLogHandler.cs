// <copyright file="MockLogHandler.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Logging.Tests.Mocks
{
    public sealed class MockLogHandler : LogHandler
    {
        public MockLogHandler(ILogFormatter formatter)
            : base(formatter)
        {
        }

        internal ILogFormatter InternalFormatter
        {
            get { return this.Formatter; }
        }

        public override void Log(LogType type, string message)
        {
        }
    }
}