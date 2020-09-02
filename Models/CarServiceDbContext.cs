using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace car_service.API.Models
{
    public class CarServiceDbContext : DbContext
    {
        public CarServiceDbContext(DbContextOptions<CarServiceDbContext> options) : base(options)
        {
        }

        public DbSet<CarServiceDbContext> Category { get; set; }
    }
}