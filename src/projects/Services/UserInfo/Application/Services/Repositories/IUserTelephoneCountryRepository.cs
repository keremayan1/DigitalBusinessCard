using Core.Persistance.Repositories;
using Domain.Concrete.Entities;
namespace Application.Services.Repositories
{
    public interface IUserTelephoneCountryRepository : IAsyncRepository<UserTelephoneCountry>, IRepository<UserTelephoneCountry>
    {
    }
}
