using Application.Services.AddressService;
using Application.Services.CityService;
using Application.Services.CompanyImageService;
using Application.Services.IbanInfoImageService;
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

            services.AddHttpClient<IProvinceService, ProvinceManager>();

            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<ICompanyInfoImageService, CompanyInfoImageManager>();
            services.AddScoped<IIbanInfoImageService, IbanInfoImageManager>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
