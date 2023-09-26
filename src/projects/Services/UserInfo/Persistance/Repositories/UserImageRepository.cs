using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Concrete.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserImageRepository : EfRepositoryBase<UserImage, SQLContext>, IUserImageRepository
    {
        public UserImageRepository(SQLContext context) : base(context)
        {
        }
    }
}
