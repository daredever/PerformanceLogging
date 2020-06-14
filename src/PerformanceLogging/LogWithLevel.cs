using Microsoft.Extensions.Logging;

namespace PerformanceLogging
{
    /// <summary>
    /// Special struct for using shortcut:
    /// <code>
    ///   logger.Trace()?.Log($"message: {GetMessage()}");
    ///   logger.Debug()?.Log($"message: {GetMessage()}");
    /// </code>
    /// </summary>
    public readonly struct LogWithLevel
    {
        internal readonly ILogger Logger;
        internal readonly LogLevel LogLevel;

        private LogWithLevel(ILogger logger, LogLevel logLevel)
        {
            Logger = logger;
            LogLevel = logLevel;
        }

        /// <summary>
        /// Creates <see cref="LogWithLevel"/> only if provided level for given logger is enabled.
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <paramref name="logLevel"/>)
        ///   if log is enabled for given level; null otherwise
        /// </returns>
        public static LogWithLevel? CreateIfEnabled(ILogger logger, LogLevel logLevel) =>
            logger?.IsEnabled(logLevel) != true ? (LogWithLevel?) null : new LogWithLevel(logger, logLevel);
    }
}