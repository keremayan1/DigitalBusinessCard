using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistance.Contexts
{
    public class SQLDbContext : DbContext
    {
        public IConfiguration Configuration { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Address> Addresses{ get; set; }
        public SQLDbContext(DbContextOptions dbContextOptions,IConfiguration configuration): base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
