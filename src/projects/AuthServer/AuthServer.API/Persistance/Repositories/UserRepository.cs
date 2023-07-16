using AuthServer.API.Application.Services.Repositories;
using AuthServer.API.Persistance.Contexts;
using Core.Persistance.Repositories.EntityFramework;
using Core.Security.Entities;

namespace AuthServer.API.Persistance.Repositories
{
    public class UserRepository : EfRepositoryBase<User, SQLContext>, IUserRepository
    {
        public UserRepository(SQLContext context) : base(context)
        {
        }
    }
}
