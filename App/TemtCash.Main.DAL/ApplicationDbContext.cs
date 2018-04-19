using Microsoft.EntityFrameworkCore;
using TemtCash.Main.Domain.Model;

namespace TemtCash.Main.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Company> Companies { get; set; }
    }
}