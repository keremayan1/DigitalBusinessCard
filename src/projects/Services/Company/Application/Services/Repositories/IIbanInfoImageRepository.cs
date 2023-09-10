using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface IIbanInfoImageRepository : IRepository<IbanInfoImage>, IAsyncRepository<IbanInfoImage>
    {
    }
}
