using Microsoft.Extensions.Logging;

namespace NullableLogger
{
    /// <summary>
    /// Logger wrapper for using shortcuts with all log levels.
    /// Example:
    /// <code>
    ///   logger.Trace?.Log($"message: {GetMessage()}");
    /// </code>
    /// </summary>
    public interface INullableLogger : ILogger
    {
        /// <summary>
        /// Trace level shortcut.
        /// Usage:
        /// <code>
        ///   logger.Trace?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        LogWithLevel? Trace { get; }

        /// <summary>
        /// Debug level shortcut.
        /// Usage:
        /// <code>
        ///   logger.Debug?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        LogWithLevel? Debug { get; }

        /// <summary>
        /// Info level shortcut.
        /// Usage:
        /// <code>
        ///   logger.Info?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        LogWithLevel? Info { get; }

        /// <summary>
        /// Warn level shortcut.
        /// Usage:
        /// <code>
        ///   logger.Warn?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        LogWithLevel? Warn { get; }

        /// <summary>
        /// Error level shortcut.
        /// Usage:
        /// <code>
        ///   logger.Error?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        LogWithLevel? Error { get; }

        /// <summary>
        /// Critical level shortcut.
        /// Usage:
        /// <code>
        ///   logger.Critical?.Log($"message: {GetMessage()}");
        /// </code>
        /// </summary>
        LogWithLevel? Critical { get; }
    }
}