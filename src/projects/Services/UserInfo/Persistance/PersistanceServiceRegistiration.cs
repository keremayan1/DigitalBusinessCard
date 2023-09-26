using Application.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services)
        {
            services.AddDbContext<SQLContext>();
            services.AddScoped<IUserBiographyRepository, UserBiographyRepository>();
            services.AddScoped<IUserImageRepository, UserImageRepository>();
            return services;
        }
    }
}
