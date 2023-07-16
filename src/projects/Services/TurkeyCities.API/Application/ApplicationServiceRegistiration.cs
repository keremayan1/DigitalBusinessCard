

using TurkeyCities.API.Application.Services.CityService;

namespace TurkeyCities.API.Application
{
   
    public static class ApplicationServiceRegistiration 
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddHttpClient<IProvinceService, ProvinceManager>();
            return services;
        }
    }
}
