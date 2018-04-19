using System;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpeysCloud.Main.Api;
using SpeysCloud.Main.DAL;

namespace SpeysCloud.Main.IntegrationTests.Utils
{
    public class ApiServerFixture
    {
        public static readonly ApiServerFixture Current = new ApiServerFixture();

        public TestServer Server { get; }

        private ApiServerFixture()
        {
            var builder = new WebHostBuilder()
                .ConfigureLogging(options => options.AddConsole())
                .UseStartup<TestStartup>()
                .ConfigureServices(collection =>
                    {
                        collection.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                        collection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(DbContextHelper.TestConnectionString));
                    }
                );
            Server = new TestServer(builder);
        }

        public void DoDatabaseOperation(Action<ApplicationDbContext> action)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(DbContextHelper.GetApplicationDbContext()))
            {
                action(db);
            }
        }

        ~ApiServerFixture()
        {
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            // Run at end
        }
    }
}