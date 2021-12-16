using Microsoft.EntityFrameworkCore;

namespace Example.DataRepository
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}