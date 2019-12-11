namespace FinalEngine.Logging
{
    /// <summary>
    ///   Enumerates the available log message types.
    /// </summary>
    public enum LogType
    {
        /// <summary>
        ///   Specifies the log message is an error.
        /// </summary>
        Error,

        /// <summary>
        ///   Specifies the log message is a warning.
        /// </summary>
        Warning,

        /// <summary>
        ///   Specifies the log message contains helpful information.
        /// </summary>
        Information,

        /// <summary>
        ///   Specifies the log message contains helpful debugging information.
        /// </summary>
        Debug
    }
}