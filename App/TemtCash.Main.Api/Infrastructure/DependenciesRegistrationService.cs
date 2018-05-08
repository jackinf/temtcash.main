using Microsoft.Extensions.DependencyInjection;
using TemtCash.Main.Api.Services;
using TemtCash.Main.DAL.Repository;
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
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IProductCatalogRepository, ProductCatalogRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPointOfSaleRepository, PointOfSaleRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();

            // Services
            //

            services.AddScoped<ICompanyLicenceService, CompanyLicenceService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IInfoChannelMessageService, InfoChannelMessageService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IProductCatalogService, ProductCatalogService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ISystemUserService, SystemUserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPointOfSaleService, PointOfSaleService>();
            services.AddScoped<IUnitService, UnitService>();

            return services;
        }
    }
}