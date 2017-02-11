using Microsoft.EntityFrameworkCore;

namespace Lansky.EntityFrameworkCorePerformanceTest.EfCore.Entities
{
    public partial class WideWorldImportersContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;Initial Catalog=WideWorldImporters");
        }
    }
}
