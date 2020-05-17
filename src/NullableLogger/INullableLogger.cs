using Microsoft.Extensions.Logging;

namespace NullableLogger
{
    public interface INullableLogger : ILogger
    {
        LogWithLevel? Trace { get; }
        LogWithLevel? Debug { get; }
        LogWithLevel? Info { get; }
        LogWithLevel? Warn { get; }
        LogWithLevel? Error { get; }
        LogWithLevel? Critical { get; }
    }
}