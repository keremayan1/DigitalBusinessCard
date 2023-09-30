using Domain.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistance.Contexts
{
    public class SQLContext : DbContext
    {
        public IConfiguration Configuration { get; set; }
        public DbSet<UserBiography> UserBiographies { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<UserTelephoneNumber> UserTelephoneNumbers { get; set; }
        public DbSet<UserTelephoneType> UserTelephoneTypes { get; set; }
        public DbSet<UserTelephoneCountry> UserTelephoneCountries { get; set; }


        public SQLContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
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
