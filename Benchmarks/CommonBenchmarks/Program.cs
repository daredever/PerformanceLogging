using BenchmarkDotNet.Running;
using CommonBenchmarks.Trace;

namespace CommonBenchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<TraceLogging>();
            BenchmarkRunner.Run<TraceLoggingWithFormat>();
        }
    }
}