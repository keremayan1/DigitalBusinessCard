using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class AddressRepository : EfRepositoryBase<Address, SQLDbContext>, IAddressRepository
    {
        public AddressRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
