using AuthServer.API.Application.Features.Auths.DTOs;
using AuthServer.API.Application.Features.Auths.Rules;
using AuthServer.API.Application.Services.AuthService;
using AuthServer.API.Application.Services.Repositories;
using Core.Security.Dtos;
using MediatR;

namespace AuthServer.API.Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }
        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
        {
            private IAuthService _authService;
            private IUserRepository _userRepository;
            private AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IAuthService authService, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
            {
                _authService = authService;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(x => x.Email == request.UserForLoginDto.Email);

                await _authBusinessRules.EmailCanNotBeExistWhenLogined(request.UserForLoginDto.Email);
                await _authBusinessRules.PasswordVerify(user, request.UserForLoginDto);

                var accessToken = await _authService.CreateAccessToken(user);
                var refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                var addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

                LoginedDto logined = new()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
                return logined;


            }
        }
    }
}
