using Microsoft.Extensions.Logging;

namespace NullableLogger.Benchmarks.Logging
{
    public static class LoggerExtensions
    {
        public static ILoggerFactory AddLogger(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new LoggerProvider());
            return loggerFactory;
        }
    }
}