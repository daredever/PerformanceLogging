using System;

namespace Benchmarks.Common.Logging
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