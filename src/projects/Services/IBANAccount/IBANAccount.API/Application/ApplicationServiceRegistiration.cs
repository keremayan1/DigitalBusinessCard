using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using IBANAccount.API.Application.Features.Iban.Rules;
using IBANAccount.API.Application.Features.UserIbans.Rules;
using IBANAccount.API.Application.Services.IbanImages;
using MediatR;
using System.Reflection;

namespace IBANAccount.API.Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.AddScoped<IbanBusinessRules>();
            services.AddScoped<UserIbanBusinessRules>();
            services.AddScoped<IbanImageService, IbanImageManager>();
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
