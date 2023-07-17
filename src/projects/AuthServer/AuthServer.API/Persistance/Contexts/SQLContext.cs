using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.API.Persistance.Contexts
{
    public class SQLContext:DbContext
    {
        public IConfiguration Configuration { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public SQLContext(DbContextOptions dbContextOptions,IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: Configuration.GetConnectionString("SQLConnectionString"));
        }
    }
}
