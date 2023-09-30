using Core.Persistance.Repositories;
using Domain.Concrete.Entities;
namespace Application.Services.Repositories
{
    public interface IUserTelephoneTypeRepository : IAsyncRepository<UserTelephoneType>, IRepository<UserTelephoneType>
    {
    }
}
