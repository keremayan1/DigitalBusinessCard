using Core.Persistance.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Services.Repositories
{
    public interface ICryptoRepository:IAsyncRepository<Crypto>,IRepository<Crypto>
    {
    }
}
