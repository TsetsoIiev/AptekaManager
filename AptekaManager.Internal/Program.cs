using System.Threading.Tasks;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using AptekaManager.Internal.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AptekaManager.Internal
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => 
                    services
                        .AddAutoMapper(typeof(Program))
                        .AddScoped<AptekaManagerContext>()
                        .AddScoped<IAddressRepository, AddressRepository>()
                        .AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>()
                        .AddScoped<IProductRepository, ProductRepository>()
                        .AddScoped<IPharmacyRepository, PharmacyRepository>());
    }
}