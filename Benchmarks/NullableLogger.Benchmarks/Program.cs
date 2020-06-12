using BenchmarkDotNet.Running;

namespace NullableLogger.Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TraceLogging>();
        }
    }
}