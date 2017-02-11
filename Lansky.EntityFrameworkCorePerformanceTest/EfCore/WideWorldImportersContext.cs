using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
