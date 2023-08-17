using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using System.Reflection;
using WebAPI.Application.Features.UserCryptos.Rules;
using WebAPI.Application.Services.CryptoImages;
using WebAPI.Application.Services.Repositories;

namespace WebAPI.Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);

            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped<UserCryptoBusinessRules>();
            services.AddScoped<ICryptoImageService, CryptoImageService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
