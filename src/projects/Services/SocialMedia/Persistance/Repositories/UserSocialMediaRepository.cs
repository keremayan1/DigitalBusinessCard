using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserSocialMediaRepository : EfRepositoryBase<UserSocialMedia, SQLContext>, IUserSocialMediaRepository
    {
        public UserSocialMediaRepository(SQLContext context) : base(context)
        {
        }
    }
}
