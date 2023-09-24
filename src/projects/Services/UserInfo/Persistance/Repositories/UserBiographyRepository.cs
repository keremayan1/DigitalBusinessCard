using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Concrete.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserBiographyRepository : EfRepositoryBase<UserBiography, SQLContext>, IUserBiographyRepository
    {
        public UserBiographyRepository(SQLContext context) : base(context)
        {
        }
    }
}
