using Core.Persistance.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Services.Repositories
{
    public interface ICryptoImageRepository : IAsyncRepository<CryptoImage>, IRepository<CryptoImage>
    {
    }
}
