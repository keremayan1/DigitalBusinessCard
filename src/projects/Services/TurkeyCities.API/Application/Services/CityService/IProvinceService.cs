using TurkeyCities.API.Domain.Entities.Concrete;
using TurkeyCities.API.Domain.Entities.Models;

namespace TurkeyCities.API.Application.Services.CityService
{
    public interface IProvinceService
    {
        public Task<List<Province>> GetAll();
        public Task<Province> GetByProvinceId(int id);
    }
}
