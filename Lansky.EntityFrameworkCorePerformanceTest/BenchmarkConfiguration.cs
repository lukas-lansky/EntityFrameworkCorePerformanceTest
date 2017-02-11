using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
