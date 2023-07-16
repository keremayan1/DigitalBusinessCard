using Application.Features.GameImages.Rules;
using Application.Features.Games.Rules;
using Application.Features.UserGames.Rules;
using Core.Persistance.Images.DependencyResolvers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);

            services.AddScoped<GameBusinessRules>();
            services.AddScoped<GameImageBusinessRules>();
            services.AddScoped<UserGameBusinessRules>();

            return services;
          
        }
    }
}
