using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerLibrary.Model
{
    public class SampleContext:DbContext
    {
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SampleContext() : base("name = CarServiceDB") { }

    }
}
