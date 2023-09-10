using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class IbanInfoImageRepository : EfRepositoryBase<IbanInfoImage, SQLDbContext>, IIbanInfoImageRepository
    {
        public IbanInfoImageRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
