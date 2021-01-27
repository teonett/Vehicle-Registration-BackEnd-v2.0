using BE_Vehicle_Control.Domain.Handlers;
using BE_Vehicle_Control.Domain.Repositories;
using BE_Vehicle_Control.Infra.Contexts;
using BE_Vehicle_Control.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BE_Vehicle_Control.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("Database"));
            string connectionString = "Data Source=vehiclecontrol.db";
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlite(connectionString));

            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<BrandHandler, BrandHandler>();

            services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
            services.AddTransient<VehicleModelHandler, VehicleModelHandler>();

            services.AddTransient<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddTransient<VehicleTypeHandler, VehicleTypeHandler>();

            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<VehicleHandler, VehicleHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BE_Vehicle_Control.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BE_Vehicle_Control.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
