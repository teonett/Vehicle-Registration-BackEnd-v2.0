using BE_Vehicle_Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE_Vehicle_Control.Infra.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Brand>().HasKey(x => x.Id);

            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Vehicle>().HasKey(x => x.Id);

            modelBuilder.Entity<VehicleModel>().ToTable("VehicleModel");
            modelBuilder.Entity<VehicleModel>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}