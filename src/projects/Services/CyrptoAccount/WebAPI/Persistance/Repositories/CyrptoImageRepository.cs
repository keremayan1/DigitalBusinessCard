using Core.Persistance.Repositories.EntityFramework;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;
using WebAPI.Persistance.Contexts;

namespace WebAPI.Persistance.Repositories
{
    public class CyrptoImageRepository : EfRepositoryBase<CryptoImage, SQLDbContext>, ICryptoImageRepository
    {
        public CyrptoImageRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
