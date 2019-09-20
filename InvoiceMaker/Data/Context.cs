using InvoiceMaker.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InvoiceMaker.Data
{
    public class Context : DbContext 
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<WorkDone> WorkDones { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<FeeLineItem> FeeLineItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<WorkType>()
                .Property(p => p.Rate).HasPrecision(12, 2);
        }
    }
}