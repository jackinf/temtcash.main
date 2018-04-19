using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using TemtCash.Main.Api.Helpers;

namespace TemtCash.Main.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDatabase()
                .Run();
        }

        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
