using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Concrete.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserTelephoneCountryRepository : EfRepositoryBase<UserTelephoneCountry, SQLContext>, IUserTelephoneCountryRepository
    {
        public UserTelephoneCountryRepository(SQLContext context) : base(context)
        {
        }
    }
}
