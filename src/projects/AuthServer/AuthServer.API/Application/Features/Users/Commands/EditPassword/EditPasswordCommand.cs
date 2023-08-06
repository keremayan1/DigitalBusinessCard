using AuthServer.API.Application.Features.Auths.Rules;
using AuthServer.API.Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;

namespace AuthServer.API.Application.Features.Auths.Commands.EditPassword
{
    public class EditPasswordCommand : IRequest<UserForUpdatePasswordDto>
    {
       
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordVerify { get; set; }
        public class EditPasswordCommandHandler : IRequestHandler<EditPasswordCommand, UserForUpdatePasswordDto>
        {
            private IUserRepository _userRepository;
            private AuthBusinessRules _authBusinessRules;
            private IMapper _mapper;

            public EditPasswordCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IMapper mapper)
            {
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
                _mapper = mapper;
            }

            public async Task<UserForUpdatePasswordDto> Handle(EditPasswordCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;

                var user = await _userRepository.GetAsync(x => x.Email == request.Email);

                await _authBusinessRules.EmailCanNotBeExistWhenLogined(request.Email);
                 _authBusinessRules.CheckIfOldPasswordAndNewPasswordAreExists(request.OldPassword, request.NewPassword);
                _authBusinessRules.CheckPasswordSame(request.NewPassword, request.NewPasswordVerify);
                await _authBusinessRules.CheckPasswordOldWrong(request.Email, request.OldPassword);
               
                HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
               
                await _userRepository.UpdateAsync(user);

                var result = _mapper.Map<UserForUpdatePasswordDto>(user);
                return result;
            }
        }
    }
}
