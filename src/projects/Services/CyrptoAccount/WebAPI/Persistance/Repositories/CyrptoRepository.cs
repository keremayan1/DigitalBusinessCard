using Core.Persistance.Repositories.EntityFramework;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;
using WebAPI.Persistance.Contexts;

namespace WebAPI.Persistance.Repositories
{
    public class CyrptoRepository : EfRepositoryBase<Crypto, SQLDbContext>, ICryptoRepository
    {
        public CyrptoRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
