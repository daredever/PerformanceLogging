using System;

namespace NullableLogger.Benchmarks.Logging
{
    internal class Scope : IDisposable
    {
        public static Scope Instance { get; } = new Scope();

        private Scope()
        {
        }

        public void Dispose()
        {
        }
    }
}