using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;

namespace Lansky.EntityFrameworkCorePerformanceTest
{
    public class BenchmarkConfiguration : ManualConfig
    {
        public BenchmarkConfiguration()
        {
            Add(RPlotExporter.Default);

            Add(Job.LegacyJitX64);
            Add(Job.RyuJitX64);

            Add(new MemoryDiagnoser());
        }
    }
}
