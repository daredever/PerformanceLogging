using System;
using Microsoft.Extensions.Logging;

namespace PerformanceLogging
{
    /// <summary>
    /// LogWithLevel extension methods for common scenarios.
    /// </summary>
    public static class LogWithLevelExtensions
    {
        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="logWithLevel">The <see cref="LogWithLevel"/> to get Logger to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logWithLevel.Log(0, exception, "Error while processing request from {Address}", address)</example>
        public static void Log(this LogWithLevel logWithLevel, EventId eventId, Exception exception,
            string message, params object[] args)
        {
            logWithLevel.Logger.Log(logWithLevel.LogLevel, eventId, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="logWithLevel">The <see cref="LogWithLevel"/> to get Logger to write to.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logWithLevel.Log(0, "Processing request from {Address}", address)</example>
        public static void Log(this LogWithLevel logWithLevel, EventId eventId, string message,
            params object[] args)
        {
            logWithLevel.Logger.Log(logWithLevel.LogLevel, eventId, message, args);
        }

        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="logWithLevel">The <see cref="LogWithLevel"/> to get Logger to write to.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logWithLevel.Log(exception, "Error while processing request from {Address}", address)</example>
        public static void Log(this LogWithLevel logWithLevel, Exception exception, string message,
            params object[] args)
        {
            logWithLevel.Logger.Log(logWithLevel.LogLevel, exception, message, args);
        }

        /// <summary>
        /// Formats and writes a log message.
        /// </summary>
        /// <param name="logWithLevel">The <see cref="LogWithLevel"/> to get Logger to write to.</param>
        /// <param name="message">Format string of the log message in message template format. Example: <code>"User {User} logged in from {Address}"</code></param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <example>logWithLevel.Log("Processing request from {Address}", address)</example>
        public static void Log(this LogWithLevel logWithLevel, string message, params object[] args)
        {
            logWithLevel.Logger.Log(logWithLevel.LogLevel, message, args);
        }
    }
}