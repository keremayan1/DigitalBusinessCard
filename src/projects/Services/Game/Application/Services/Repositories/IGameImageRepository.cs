using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface IGameImageRepository : IAsyncRepository<GameImage>, IRepository<GameImage>
    {
    }
}
