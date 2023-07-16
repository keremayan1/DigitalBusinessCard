using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserGameRepository : EfRepositoryBase<UserGame, SQLContext>, IUserGameRepository
    {
        public UserGameRepository(SQLContext context) : base(context)
        {
        }
    }
}
