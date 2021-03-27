using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using AptekaManager.Internal.Repositories;

namespace AptekaManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "AptekaManager.API", Version = "v1"});
            });

            services
                .AddAutoMapper(typeof(Startup))
                .AddScoped<AptekaManagerContext>()
                .AddScoped<IAddressRepository, AddressRepository>()
                .AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IPharmacyRepository, PharmacyRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AptekaManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "default", "{controller}/{action}/{id?}");
            });
        }
    }
}
