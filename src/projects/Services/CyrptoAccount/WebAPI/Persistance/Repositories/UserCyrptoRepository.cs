using Core.Persistance.Repositories.EntityFramework;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;
using WebAPI.Persistance.Contexts;

namespace WebAPI.Persistance.Repositories
{
    public class UserCyrptoRepository : EfRepositoryBase<UserCyrpto, MySQLDbContext>, IUserCryptoRepository
    {
        public UserCyrptoRepository(MySQLDbContext context) : base(context)
        {
        }
    }
}
