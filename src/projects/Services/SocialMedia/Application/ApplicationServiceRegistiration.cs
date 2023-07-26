using MediatR;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

using Application.Features.SocialMediaImages.Rules;
using Application.Features.UserSocialMedias.Rules;
using Core.Persistance.Images.DependencyResolvers;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Application.Services.SocialMediaImages;

namespace Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.AddScoped<UserSocialMediaBusinessRules>();
            services.AddScoped<SocialMediaImageBusinessRules>();
            services.AddImageServices();
            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped<ISocialMediaImageService, SocialMediaImageManager>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
