using System.Threading.Tasks;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using AptekaManager.Internal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                        .AddDbContext<AptekaManagerContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection]"]))
                        .AddAutoMapper(typeof(Program))
                        .AddScoped<IAddressRepository, AddressRepository>()
                        .AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>()
                        .AddScoped<IProductRepository, ProductRepository>()
                        .AddScoped<IPharmacyRepository, PharmacyRepository>());

        public static IConfiguration Configuration { get; set; }
    }
}