using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ccmockingservice.Models;
namespace ccmockingservice.DAL
{
    public class CCServiceDBContext : DbContext
    {
        public CCServiceDBContext() : base("ccServiceDBContext")
        {

        }
        public virtual DbSet<CreditCard> CreditCards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CreditCard>()
            .HasIndex(p => p.Number)            
            .IsUnique();


        }

    }
}