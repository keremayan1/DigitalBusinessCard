using Core.Security.Entities;
using Core.Security.JWT;

namespace AuthServer.API.Application.Features.Auths.DTOs
{
    public class RefreshedTokenDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
