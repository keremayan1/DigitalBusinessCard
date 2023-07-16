using Application.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistance
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<SQLContext>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ISocialMediaImageRepository, SocialMediaImageRepository>();
            services.AddScoped<IUserSocialMediaRepository, UserSocialMediaRepository>();
            return services;
        }
    }
}
