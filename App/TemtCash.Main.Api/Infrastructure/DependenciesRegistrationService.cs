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

            services.AddScoped<ICompanyLicenceRepository, CompanyLicenceRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IInfoChannelMessageRepository, InfoChannelMessageRepository>();

            // Services
            //

            services.AddScoped<ICompanyLicenceRepository, CompanyLicenceRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IInfoChannelMessageService, InfoChannelMessageService>();
            services.AddScoped<ISystemUserService, SystemUserService>();
            
            return services;
        }
    }
}