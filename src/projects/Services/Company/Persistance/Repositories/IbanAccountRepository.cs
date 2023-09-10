using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class IbanAccountRepository : EfRepositoryBase<IbanAccount, SQLDbContext>, IIbanAccountRepository
    {
        public IbanAccountRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
