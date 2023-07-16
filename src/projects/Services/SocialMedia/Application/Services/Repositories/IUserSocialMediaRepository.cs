using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface IUserSocialMediaRepository : IAsyncRepository<UserSocialMedia>, IRepository<UserSocialMedia>
    {
    }
}
