using System;
using Microsoft.Extensions.Logging;

namespace CommonBenchmarks.Logging
{
    public class Logger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            // Do nothing.
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => Scope.Instance;
    }
}