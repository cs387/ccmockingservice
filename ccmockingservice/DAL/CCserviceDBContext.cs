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
        public virtual DbSet<CreditCardEntity> CreditCards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CreditCardEntity>()
            .HasIndex(p => p.Number)            
            .IsUnique();


        }

    }
}