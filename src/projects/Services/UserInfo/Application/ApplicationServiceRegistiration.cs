﻿using Application.Features.Biographies.Rules;
using Application.Features.Images.Rules;
using Application.Services.TelephoneCountry;
using Application.Services.TelephoneType;
using Application.Services.TelephoneType.Concrete;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);

            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped<BiographyBusinessRules>();
            services.AddScoped<UserImageBusinessRules>();

            services.AddScoped<ITelephoneTypeService, TelephoneTypeManager>();
            services.AddScoped<ITelephoneCountryService, TelephoneCountryManager>();


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }


    }
}
