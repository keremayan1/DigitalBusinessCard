

using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface IUserGameRepository : IAsyncRepository<UserGame>, IRepository<UserGame>
    {
    }
}
