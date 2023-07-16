﻿using AuthServer.API.Application.Features.Auths.DTOs;
using AuthServer.API.Application.Features.Auths.Rules;
using AuthServer.API.Application.Services.AuthService;
using AuthServer.API.Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace AuthServer.API.Application.Features.Auths.Commands.Register
{
    public class RegisterCommand:IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private IUserRepository _userRepository;
            private AuthBusinessRules _businessRules;
            private IAuthService _authService;
            private IMapper _mapper;

            public RegisterCommandHandler(IUserRepository userRepository, AuthBusinessRules businessRules, IAuthService authService)
            {
                _userRepository = userRepository;
                _businessRules = businessRules;
                _authService = authService;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.EmailShouldNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);
                
                byte[] passwordHash, passwordSalt;
               
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User user = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Status = true
                };
                var createdUser = await _userRepository.AddAsync(user);
                
                var createdAccessToken = await _authService.CreateAccessToken(createdUser);
                var createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                var addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredDto registeredDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken
                };
                return registeredDto;



                
            }
        }
    }
}
