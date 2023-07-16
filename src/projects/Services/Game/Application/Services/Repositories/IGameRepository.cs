

using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface IGameRepository : IAsyncRepository<Game>,IRepository<Game>
    {
    }
}
