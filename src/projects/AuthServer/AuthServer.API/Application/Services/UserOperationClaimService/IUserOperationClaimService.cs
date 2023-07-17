using Core.Security.Entities;

namespace AuthServer.API.Application.Services.UserOperationClaimService
{
    public interface IUserOperationClaimService
    {
        public Task<UserOperationClaim> Add(UserOperationClaim userOperationClaim);
        public Task<UserOperationClaim> Update(UserOperationClaim userOperationClaim);
        public Task<UserOperationClaim> DeleteByUserId(int userId);
    }
}
