using Core.Persistance.Repositories.EntityFramework;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;
using WebAPI.Persistance.Contexts;

namespace WebAPI.Persistance.Repositories
{
    public class UserCyrptoRepository : EfRepositoryBase<UserCyrpto, SQLDbContext>, IUserCryptoRepository
    {
        public UserCyrptoRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
