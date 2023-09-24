using Core.Persistance.Repositories;
using Domain.Concrete.Entities;
namespace Application.Services.Repositories
{
    public interface IUserBiographyRepository : IAsyncRepository<UserBiography>,IRepository<UserBiography>
    {
    }
}
