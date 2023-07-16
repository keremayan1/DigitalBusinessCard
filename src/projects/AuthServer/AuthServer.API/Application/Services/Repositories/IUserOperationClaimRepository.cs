using Core.Persistance.Repositories;
using Core.Security.Entities;

namespace AuthServer.API.Application.Services.Repositories
{
    public interface IUserOperationClaimRepository : IRepository<UserOperationClaim>, IAsyncRepository<UserOperationClaim>
    {
    }
}
