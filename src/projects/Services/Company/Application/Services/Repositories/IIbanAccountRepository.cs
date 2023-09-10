using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface IIbanAccountRepository : IRepository<IbanAccount>, IAsyncRepository<IbanAccount>
    {
    }
}
