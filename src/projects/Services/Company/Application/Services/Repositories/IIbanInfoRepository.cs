using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface IIbanInfoRepository : IRepository<IbanInfo>, IAsyncRepository<IbanInfo>
    {
    }
}
