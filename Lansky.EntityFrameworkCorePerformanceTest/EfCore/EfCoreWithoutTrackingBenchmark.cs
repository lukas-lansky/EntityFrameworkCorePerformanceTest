using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lansky.EntityFrameworkCorePerformanceTest.EfCore
{
    public class EfCoreWithoutTrackingBenchmark : TheBenchmark
    {
        public EfCoreWithoutTrackingBenchmark() : base(new EfCoreQueries(false))
        {
        }
    }
}
