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
        public DbSet<Сonsumable> Сonsumable { get; set; }

    }
}