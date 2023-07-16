using AuthServer.API.Application.Services.Repositories;
using AuthServer.API.Persistance.Contexts;
using Core.Persistance.Repositories.EntityFramework;
using Core.Security.Entities;

namespace AuthServer.API.Persistance.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, SQLContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(SQLContext context) : base(context)
        {
        }
    }
}
