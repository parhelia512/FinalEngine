namespace FinalEngine.Logging.Tests.Mocks
{
    /*
     * TODO: There really should be a better way to do this.
     *
     * The whole reason of using MOQ is to not have to create classes like this.
     */

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