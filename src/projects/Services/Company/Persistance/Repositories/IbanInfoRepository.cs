using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class IbanInfoRepository : EfRepositoryBase<IbanInfo, SQLDbContext>, IIbanInfoRepository
    {
        public IbanInfoRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
