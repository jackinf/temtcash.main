using Microsoft.Extensions.DependencyInjection;
using TemtCash.Main.Api.Services;
using TemtCash.Main.DAL.Repository;
using TemtCash.Main.DAL.UnitOfWork;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.Services;

namespace TemtCash.Main.Api.Infrastructure
{
    public static class DependenciesRegistrationService
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            // Repositories
            //

            services.AddScoped<ICompanyRepository, CompanyRepository>();

            // Services
            //

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDashboardService, DashboardService>();
            
            return services;
        }
    }
}