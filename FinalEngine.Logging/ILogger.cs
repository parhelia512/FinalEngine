namespace FinalEngine.Logging
{
    using System.Collections.Generic;

    public interface ILogger : ILogHandler
    {
        ICollection<ILogHandler> Handlers { get; }
    }
}