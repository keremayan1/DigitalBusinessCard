using Core.Persistance.Repositories;
using Domain.Concrete.Entities;
namespace Application.Services.Repositories
{
    public interface IUserTelephoneNumberRepository : IAsyncRepository<UserTelephoneNumber>, IRepository<UserTelephoneNumber>
    {
    }
}
