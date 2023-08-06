using IBANAccount.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IBANAccount.API.Persistance.Contexts
{
    public class SQLContext:DbContext
    {
        public IConfiguration Configuration { get; set; }
        public DbSet<Iban> Iban { get; set; }
        public DbSet<UserIban> UserIbans { get; set; }
        public DbSet<IbanImage> IbanImages { get; set; }
        public SQLContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
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
