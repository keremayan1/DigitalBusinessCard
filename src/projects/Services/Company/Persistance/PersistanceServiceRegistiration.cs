using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistance
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SQLDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("SQLConnectionString"));
            });
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();
            services.AddScoped<ICompanyInfoImageRepository, CompanyInfoImageRepository>();
            services.AddScoped<IIbanAccountRepository, IbanAccountRepository>();
            services.AddScoped<IIbanInfoImageRepository, IbanInfoImageRepository>();
            services.AddScoped<IIbanInfoRepository, IbanInfoRepository>();
            return services;
        }
    }
}
