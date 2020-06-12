using Microsoft.Extensions.Logging;

namespace NullableLogger.Benchmarks.Logger
{
    public static class ColorConsoleLoggerExtensions
    {
        public static ILoggerFactory AddTraceLogger(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new CustomLoggerProvider(LogLevel.Trace));
            return loggerFactory;
        }

        public static ILoggerFactory AddDebugLogger(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new CustomLoggerProvider(LogLevel.Debug));
            return loggerFactory;
        }

        public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory, LogLevel logLevel)
        {
            loggerFactory.AddProvider(new CustomLoggerProvider(logLevel));
            return loggerFactory;
        }
    }
}