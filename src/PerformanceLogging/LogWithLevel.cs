using System;
using Microsoft.Extensions.Logging;

namespace PerformanceLogging
{
    /// <summary>
    /// Special struct for using shortcuts:
    /// <code>
    ///   logger.Trace()?.Log($"message: {GetMessage()}");
    ///   logger.Debug()?.Log($"message: {GetMessage()}");
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
        /// Creates <see cref="LogWithLevel"/> only if provided level for given logger is enabled.
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <paramref name="logLevel"/>)
        ///   if log is enabled for given level; null otherwise
        /// </returns>
        public static LogWithLevel? CreateIfEnabled(ILogger logger, LogLevel logLevel) =>
            logger?.IsEnabled(logLevel) != true ? (LogWithLevel?) null : new LogWithLevel(logger, logLevel);

        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logger.Trace()?.Log(0, exception, "Error while processing request from {Address}", address)</example>
        public void Log(EventId eventId, Exception exception, string message, params object[] args) =>
            _logger.Log(_logLevel, eventId, exception, message, args);

        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logger.Trace()?.Log(0, "Processing request from {Address}", address)</example>
        public void Log(EventId eventId, string message, params object[] args) =>
            _logger.Log(_logLevel, eventId, message, args);

        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logger.Trace()?.Log(exception, "Error while processing request from {Address}", address)</example>
        public void Log(Exception exception, string message, params object[] args) =>
            _logger.Log(_logLevel, exception, message, args);

        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logger.Trace()?.Log("Processing request from {Address}", address)</example>
        public void Log(string message, params object[] args) =>
            _logger.Log(_logLevel, message, args);
    }
}