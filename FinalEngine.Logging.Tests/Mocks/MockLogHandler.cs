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
            get { return Formatter; }
        }

        public override void Log(LogType type, string message)
        {
        }
    }
}