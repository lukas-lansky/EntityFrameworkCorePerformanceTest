using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lansky.EntityFrameworkCorePerformanceTest.EfCore
{
    public class EfCoreWithTrackingBenchmark : TheBenchmark
    {
        public EfCoreWithTrackingBenchmark() : base(new EfCoreQueries(true))
        {
        }
    }
}
