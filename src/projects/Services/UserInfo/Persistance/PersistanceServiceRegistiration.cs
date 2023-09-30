using Application.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistance
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<SQLContext>();
            services.AddScoped<IUserBiographyRepository, UserBiographyRepository>();
            services.AddScoped<IUserImageRepository, UserImageRepository>();
            services.AddScoped<IUserTelephoneNumberRepository, UserTelephoneNumberRepository>();
            services.AddScoped<IUserTelephoneTypeRepository, UserTelephoneTypeRepository>();
            services.AddScoped<IUserTelephoneCountryRepository, UserTelephoneCountryRepository>();
            return services;
        }
    }
}
