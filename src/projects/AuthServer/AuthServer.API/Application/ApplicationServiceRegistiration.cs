﻿using AuthServer.API.Application.Features.Auths.Rules;
using AuthServer.API.Application.Features.Users.Rules;
using AuthServer.API.Application.Services.AuthService;
using AuthServer.API.Application.Services.UserOperationClaimService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
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
            services.AddScoped<UserBusinessRules>();

            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
