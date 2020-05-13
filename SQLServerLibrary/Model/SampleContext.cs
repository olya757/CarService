
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SQLServerLibrary.Model
{
    public class SampleContext:DbContext
    {
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SampleContext() : base("CarServiceDB") { }

    }
}
