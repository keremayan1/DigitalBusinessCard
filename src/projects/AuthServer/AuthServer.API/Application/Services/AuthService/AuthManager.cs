using AuthServer.API.Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.API.Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            var userOperationClaims = await _userOperationClaimRepository.GetListAsync(x => x.UserId == user.Id, include: x => x.Include(x => x.OperationClaim));
            var operationClaims = userOperationClaims.Items.Select(u => new OperationClaim
            {
                Id = u.OperationClaim.Id,
                Name = u.OperationClaim.Name
            }).ToList();
            var accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;

        }

        public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
           

            var refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return await Task.FromResult(refreshToken);

        }
    }
}
