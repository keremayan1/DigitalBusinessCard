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
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<CompanyInfoImage> CompanyInfoImages { get; set; }
        public DbSet<IbanInfo> IbanInfos { get; set; }
        public DbSet<IbanInfoImage> IbanInfoImages { get; set; }
        public DbSet<IbanAccount> IbanAccounts { get; set; }
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
