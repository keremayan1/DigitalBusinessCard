using Core.Persistance.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Services.Repositories
{
    public interface IUserCryptoRepository : IAsyncRepository<UserCyrpto>, IRepository<UserCyrpto>
    {
    }
}
