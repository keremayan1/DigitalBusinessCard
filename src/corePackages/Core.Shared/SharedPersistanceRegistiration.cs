using Core.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Shared
{
    public static class SharedServiceRegistiration
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ISharedIdentityService, SharedIdentityService>();

            return services;
        }
        
    }
}
