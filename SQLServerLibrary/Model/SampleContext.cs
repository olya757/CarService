
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
        
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<SampleContext>(null);

            modelBuilder.Entity<Order>().HasKey(o => o.ID);
            modelBuilder.Entity<CarOwner>().HasKey(co => co.ID);

            //Configure FK for one-to-many relationship
            modelBuilder.Entity<Order>()
            .HasRequired<CarOwner>(o => o.CarOwner)
            .WithMany(co => co.Orders)
            .HasForeignKey( o=>o.OwnerID);
        }
    }
}
