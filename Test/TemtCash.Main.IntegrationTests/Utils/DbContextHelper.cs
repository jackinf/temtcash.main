using Microsoft.EntityFrameworkCore;
using TemtCash.Main.DAL;

namespace TemtCash.Main.IntegrationTests.Utils
{
    public class DbContextHelper
    {
        // TODO: take from appsettings.json
        public static string TestConnectionString { get; } = "Server=.;Database=SpeysCloud.Main.Test;Trusted_Connection=True;";

        public static DbContextOptions<ApplicationDbContext> GetApplicationDbContext()
        {
            DbContextOptions<ApplicationDbContext> options =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(TestConnectionString)
                    .Options;
            return options;
        }
    }
}