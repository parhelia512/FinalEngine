namespace FinalEngine.Logging.Tests.Mocks
{
    public sealed class MockLogHandler : LogHandler
    {
        public MockLogHandler(ILogFormatter formatter)
            : base(formatter)
        {
        }

        public override void Log(LogType type, string message)
        {
        }
    }
}