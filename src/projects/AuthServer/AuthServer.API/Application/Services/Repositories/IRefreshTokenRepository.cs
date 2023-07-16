using Core.Persistance.Repositories;
using Core.Security.Entities;

namespace AuthServer.API.Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>, IAsyncRepository<RefreshToken>
    {
    }
}
