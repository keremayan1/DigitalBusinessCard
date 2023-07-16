
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities.Concrete;

namespace Persistance.Contexts
{
    public class SQLContext:DbContext
    {
        public IConfiguration Configuration { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SocialMediaImage> SocialMediaImages { get; set; }
        public DbSet<UserSocialMedia> UserSocialMedias { get; set; }

        public SQLContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(connectionString: Configuration.GetConnectionString("SQLConnectionString"));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
