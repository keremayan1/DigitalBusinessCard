using Core.Persistance.Repositories.EntityFramework;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;
using IBANAccount.API.Persistance.Contexts;

namespace IBANAccount.API.Persistance.Repositories
{
    public class UserIbanRepository : EfRepositoryBase<UserIban, SQLContext>, IUserIbanRepository
    {
        public UserIbanRepository(SQLContext context) : base(context)
        {
        }
    }
}
