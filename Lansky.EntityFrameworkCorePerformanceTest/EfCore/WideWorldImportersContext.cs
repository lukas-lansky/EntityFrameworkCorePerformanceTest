using Microsoft.EntityFrameworkCore;

namespace Lansky.EntityFrameworkCorePerformanceTest.EfCore.Entities
{
    public partial class WideWorldImportersContext
    {
        public bool UseTracking;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=True;Initial Catalog=WideWorldImporters");
            optionsBuilder.UseQueryTrackingBehavior(UseTracking ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking);
        }
    }
}
