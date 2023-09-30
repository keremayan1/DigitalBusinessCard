using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Concrete.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserTelephoneTypeRepository : EfRepositoryBase<UserTelephoneType, SQLContext>, IUserTelephoneTypeRepository
    {
        public UserTelephoneTypeRepository(SQLContext context) : base(context)
        {
        }
    }
}
