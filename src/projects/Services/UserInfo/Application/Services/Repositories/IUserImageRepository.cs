using Core.Persistance.Repositories;
using Domain.Concrete.Entities;
namespace Application.Services.Repositories
{
    public interface IUserImageRepository : IAsyncRepository<UserImage>, IRepository<UserImage>
    {
    }
}
