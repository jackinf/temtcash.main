using Microsoft.Extensions.DependencyInjection;
using SpeysCloud.Main.DAL.Repository;
using SpeysCloud.Main.DAL.UnitOfWork;
using SpeysCloud.Main.Domain.Repository;
using SpeysCloud.Main.Domain.Services;
using SpeysCloud.Main.Services;

namespace SpeysCloud.Main.Api.Infrastructure
{
    public static class DependenciesRegistrationService
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            // Repositories
            //

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IShipmentRepository, ShipmentRepository>();

            // Services
            //

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IShipmentService, ShipmentService>();

            // Unit of work
            //

            services.AddScoped<AddressAndShipmentUnitOfWork>();

            return services;
        }
    }
}