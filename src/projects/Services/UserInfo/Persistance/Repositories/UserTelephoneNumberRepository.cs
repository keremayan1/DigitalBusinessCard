using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Concrete.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserTelephoneNumberRepository : EfRepositoryBase<UserTelephoneNumber, SQLContext>, IUserTelephoneNumberRepository
    {
        public UserTelephoneNumberRepository(SQLContext context) : base(context)
        {
        }
    }
}
