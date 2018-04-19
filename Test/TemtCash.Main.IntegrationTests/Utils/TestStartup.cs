using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeysCloud.Main.Api;
using SpeysCloud.Main.DAL;

namespace SpeysCloud.Main.IntegrationTests.Utils
{
    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment configuration) : base(configuration)
        {
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);
            AutoApplyMigrations(app);
        }

        private static void AutoApplyMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}