using System;
using Microsoft.Extensions.Logging;

namespace NullableLogger.Benchmarks.Logger
{
    public class CustomLogger : ILogger
    {
        private readonly LogLevel _logLevel;

        public CustomLogger(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _logLevel;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NullScope.Instance;
        }
    }
}