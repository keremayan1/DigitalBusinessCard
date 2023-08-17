using WebAPI.Application.Services.Repositories;
using WebAPI.Persistance.Contexts;
using WebAPI.Persistance.Repositories;

namespace WebAPI.Persistance
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services)
        {

            services.AddDbContext<MySQLDbContext>();
            services.AddScoped<ICryptoRepository, CyrptoRepository>();
            services.AddScoped<ICryptoImageRepository, CyrptoImageRepository>();
            services.AddScoped<IUserCryptoRepository, UserCyrptoRepository>();
            return services;
        }
    }
}
