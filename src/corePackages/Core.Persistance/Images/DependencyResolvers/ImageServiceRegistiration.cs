using Core.Persistance.Images.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Persistance.Images.DependencyResolvers
{
    public static class ImageServiceRegistiration
    {
        public static IServiceCollection AddImageServices(this IServiceCollection services)
        {
            services.AddScoped<ImageService, ImageManager>();
            return services;
        }
    }
}
