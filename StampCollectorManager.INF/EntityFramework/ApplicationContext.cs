using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StampCollectorManager.INF.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() :
            base("StampCollectorManager")
        {

        }

        public DbSet<Stamp> Stamps { get; set; }

        public DbSet<StampCollector> StampCollectors { get; set; }

    }
}
