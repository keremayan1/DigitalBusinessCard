using Core.Security.Entities;
using Core.Security.JWT;
using System.Net;
using System.Net.WebSockets;

namespace AuthServer.API.Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);

    }
}
