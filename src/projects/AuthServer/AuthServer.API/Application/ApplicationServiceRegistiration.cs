using AuthServer.API.Application.Features.Auths.Rules;
using AuthServer.API.Application.Services.AuthService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthServer.API.Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddAutoMapper(assembly);

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<IAuthService, AuthManager>();
            return services;
        }
    }
}
