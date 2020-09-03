using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace car_service.API.Models
{
    public class CarServiceDbContext : DbContext
    {
        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }       
        public DbSet<Service> Service { get; set; }
        public DbSet<ExpendableMaterial> ExpendableMaterial { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Check> Check { get; set; }
        public DbSet<CheckServiceItem> CheckServiceItem { get; set; }
        public DbSet<CheckMaterialItem> CheckMaterialItem { get; set; }

    }
}