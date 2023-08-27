

using Domain.Entities.Concrete;

namespace Application.Services.CityService
{
    public interface IProvinceService
    {
        public Task<List<Province>> GetAll();
        public Task<Province> GetByProvinceId(int id);
    }
}
