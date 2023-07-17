using AuthServer.API.Application.Services.Repositories;
using Core.Security.Entities;

namespace AuthServer.API.Application.Services.UserOperationClaimService
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<UserOperationClaim> Add(UserOperationClaim userOperationClaim)
        {
            var result = await _userOperationClaimRepository.AddAsync(userOperationClaim);
            return result;
        }

        public async Task<UserOperationClaim> DeleteByUserId(int userId)
        {
            var getId = await _userOperationClaimRepository.GetAsync(x => x.UserId == userId);
            await _userOperationClaimRepository.DeleteAsync(getId);
            return getId;

        }

        public async Task<UserOperationClaim> Update(UserOperationClaim userOperationClaim)
        {
            var result = await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
            return result;
        }
    }
}
