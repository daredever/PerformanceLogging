using System;
using Microsoft.Extensions.Logging;

namespace PerformanceLogging
{
    /// <summary>
    /// ILogger extension methods to get logging shortcuts.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Wrap default logger to get shortcuts with all log levels.
        /// Example:
        /// <code>
        ///   logger.Trace?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        /// <returns>Wrapped logger</returns>
        /// <exception cref="ArgumentNullException">if logger is null</exception>
        public static IPerformanceLogger Wrap(this ILogger logger) =>
            new PerformanceLogger(logger);

        /// <summary>
        /// One-line shortcut builder. Usage:
        /// <code>
        ///   logger.Trace()?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <see cref="LogLevel.Trace"/>)
        ///   if Trace is enabled; null otherwise
        /// </returns>
        public static LogWithLevel? Trace(this ILogger logger) =>
            LogWithLevel.CreateIfEnabled(logger, LogLevel.Trace);

        /// <summary>
        /// One-line shortcut builder. Usage:
        /// <code>
        ///   logger.Debug()?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <see cref="LogLevel.Debug"/>)
        ///   if Debug is enabled; null otherwise
        /// </returns>
        public static LogWithLevel? Debug(this ILogger logger) =>
            LogWithLevel.CreateIfEnabled(logger, LogLevel.Debug);

        /// <summary>
        /// One-line shortcut builder. Usage:
        /// <code>
        ///   logger.Info()?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <see cref="LogLevel.Information"/>)
        ///   if Information is enabled; null otherwise
        /// </returns>
        public static LogWithLevel? Info(this ILogger logger) =>
            LogWithLevel.CreateIfEnabled(logger, LogLevel.Information);

        /// <summary>
        /// One-line shortcut builder. Usage:
        /// <code>
        ///   logger.Error()?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <see cref="LogLevel.Error"/>)
        ///   if Error is enabled; null otherwise
        /// </returns>
        public static LogWithLevel? Error(this ILogger logger) =>
            LogWithLevel.CreateIfEnabled(logger, LogLevel.Error);

        /// <summary>
        /// One-line shortcut builder. Usage:
        /// <code>
        ///   logger.Warn()?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <see cref="LogLevel.Warning"/>)
        ///   if Warning is enabled; null otherwise
        /// </returns>
        public static LogWithLevel? Warn(this ILogger logger) =>
            LogWithLevel.CreateIfEnabled(logger, LogLevel.Warning);

        /// <summary>
        /// One-line shortcut builder. Usage:
        /// <code>
        ///   logger.Critical()?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        /// <returns>
        ///   struct <see cref="LogWithLevel"/>(<paramref name="logger"/>, <see cref="LogLevel.Critical"/>)
        ///   if Critical is enabled; null otherwise
        /// </returns>
        public static LogWithLevel? Critical(this ILogger logger) =>
            LogWithLevel.CreateIfEnabled(logger, LogLevel.Critical);
    }
}