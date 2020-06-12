using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace NullableLogger.Benchmarks.Logger
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly LogLevel _logLevel;

        private readonly ConcurrentDictionary<string, CustomLogger> _loggers =
            new ConcurrentDictionary<string, CustomLogger>();

        public CustomLoggerProvider(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new CustomLogger(_logLevel));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}