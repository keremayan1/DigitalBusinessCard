using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface IAddressRepository : IRepository<Address>, IAsyncRepository<Address>
    {
    }
}
