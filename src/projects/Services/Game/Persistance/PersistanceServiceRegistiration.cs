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
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<SQLContext>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameImageRepository, GameImageRepository>();
            services.AddScoped<IUserGameRepository, UserGameRepository>();
            return services;
        }
    }
}
