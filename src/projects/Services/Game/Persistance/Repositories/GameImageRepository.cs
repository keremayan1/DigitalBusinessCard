using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class GameImageRepository : EfRepositoryBase<GameImage, SQLContext>, IGameImageRepository
    {
        public GameImageRepository(SQLContext context) : base(context)
        {
        }
    }
}
