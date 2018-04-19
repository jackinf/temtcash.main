using Microsoft.EntityFrameworkCore;
using TemtCash.Main.Domain.Model;

namespace TemtCash.Main.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoChannelMessageSeen>()
                .HasKey(c => new { c.InfoChannelMessageId, c.UserId });
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyLicence> CompanyLicences { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DayPeriod> DayPeriodItems { get; set; }
        public DbSet<InfoChannelMessage> InfoChannelMessages { get; set; }
        public DbSet<InfoChannelMessageProfile> InfoChannelMessageProfiles { get; set; }
        public DbSet<InfoChannelMessageSeen> InfoChannelMessagesSeen { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicePaymentType> InvoicePaymentTypes { get; set; }
        public DbSet<InvoiceRow> InvoiceRow { get; set; }
        //public DbSet<InvoiceRowDeleted> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
    }
}