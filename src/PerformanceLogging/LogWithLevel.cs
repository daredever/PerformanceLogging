using Microsoft.Extensions.Logging;

namespace PerformanceLogging
{
    /// <summary>
    /// Special struct for using shortcut:
    /// <code>
    ///   logger.Trace()?.Log($"message: {GetMessage()}");
    /// </code>
    /// </summary>
    public readonly struct LogWithLevel
    {
        private readonly ILogger _logger;
        private readonly LogLevel _logLevel;

        private LogWithLevel(ILogger logger, LogLevel logLevel)
        {
            _logger = logger;
            _logLevel = logLevel;
        }

        /// <summary>
        /// Writes a log message.
        /// </summary>
        /// <param name="message">Log message</param>
        public void Log(string message) => _logger.Log(_logLevel, message);

        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public void Log(string message, params object[] args) => _logger.Log(_logLevel, message, args);

        /// <summary>
        /// Creates <see cref="LogWithLevel"/> only if provided level for given logger is enabled.
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <paramref name="logLevel"/>)
        ///   if log is enabled for given level; null otherwise
        /// </returns>
        public static LogWithLevel? CreateIfEnabled(ILogger logger, LogLevel logLevel)
        {
            if (logger is null || logger.IsEnabled(logLevel) != true)
            {
                return null;
            }

            return new LogWithLevel(logger, logLevel);
        }
    }
}