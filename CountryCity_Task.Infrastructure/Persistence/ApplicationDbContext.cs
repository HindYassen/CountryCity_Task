
using CountryCity_Task.Domain;
using Microsoft.EntityFrameworkCore;

namespace CountryCity_Task.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
