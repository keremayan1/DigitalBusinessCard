using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebAPI.Persistance.Contexts
{
    public class SQLDbContext:DbContext
    {
        public IConfiguration Configuration { get; set; }
        public SQLDbContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SQLConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
