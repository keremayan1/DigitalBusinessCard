using Core.Persistance.Repositories;
using IBANAccount.API.Application.Features.UserIbans.DTOs;
using IBANAccount.API.Domain.Entities;

namespace IBANAccount.API.Application.Services.Repositories
{
    public interface IUserIbanRepository : IAsyncRepository<UserIban>, IRepository<UserIban>
    {
        
    }
}
