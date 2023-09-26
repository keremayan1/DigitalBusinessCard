using AuthServer.API.Application.Features.Auths.Rules;
using AuthServer.API.Application.Features.Users.Rules;
using AuthServer.API.Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;

using Core.Security.Hashing;
using Core.Shared.Services;
using MediatR;

namespace AuthServer.API.Application.Features.Users.Commands.EditPassword
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
            private UserBusinessRules _userBusinessRules;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public EditPasswordCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ISharedIdentityService sharedIdentityService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UserForUpdatePasswordDto> Handle(EditPasswordCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;

                var user = await _userRepository.GetAsync(x => x.Id == Convert.ToInt32(_sharedIdentityService.GetUserId));

                _userBusinessRules.CheckIfOldPasswordAndNewPasswordAreExists(request.OldPassword, request.NewPassword);
                _userBusinessRules.CheckPasswordSame(request.NewPassword, request.NewPasswordVerify);
                await _userBusinessRules.CheckPasswordOldWrong(request.Email, request.OldPassword);

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
