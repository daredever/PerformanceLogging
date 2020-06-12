using Microsoft.Extensions.Logging;

namespace NullableLogger.Benchmarks.Logger
{
    public static class ColorConsoleLoggerExtensions
    {
        public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory, LogLevel logLevel)
        {
            loggerFactory.AddProvider(new CustomLoggerProvider(logLevel));
            return loggerFactory;
        }
    }
}