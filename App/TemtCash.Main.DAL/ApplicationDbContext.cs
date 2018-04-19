using Microsoft.EntityFrameworkCore;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.Domain.Model;

namespace SpeysCloud.Main.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                entityType.Relational().TableName = "Main_" + entityType.Relational().TableName;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<ClassificationValue> ClassificationValues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; }
    }
}