using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Persistance.Contexts;
using IBANAccount.API.Persistance.Repositories;

namespace IBANAccount.API.Persistance
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<SQLContext>();
            services.AddScoped<IIbanRepository, IbanRepository>();
            services.AddScoped<IIbanImageRepository, IbanImageRepository>();
            services.AddScoped<IUserIbanRepository, UserIbanRepository>();
            return services;
        }
    }
}
