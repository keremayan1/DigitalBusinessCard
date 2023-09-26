using AuthServer.API.Application.Features.Users.Rules;
using AuthServer.API.Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Shared.Services;
using MediatR;

namespace AuthServer.API.Application.Features.Users.Commands.EditEmail
{
    public class EditEmailCommand:IRequest<UserForUpdateEmailDto>
    {
        public string Email { get; set; }
        public class EditEmailCommandHandler : IRequestHandler<EditEmailCommand, UserForUpdateEmailDto>
        {
            private IUserRepository _userRepository;
            private IMapper _mapper;
            private UserBusinessRules _userBusinessRules;
            private ISharedIdentityService _sharedIdentityService;

            public EditEmailCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ISharedIdentityService sharedIdentityService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UserForUpdateEmailDto> Handle(EditEmailCommand request, CancellationToken cancellationToken)
            {
                
                var getEmail =await _userRepository.GetAsync(x => x.Id == Convert.ToInt32(_sharedIdentityService.GetUserId));

                _userBusinessRules.CheckIfOldEmailAndNewEmailAreExists(getEmail.Email, request.Email);
                getEmail.Email = request.Email;
                await _userRepository.UpdateAsync(getEmail);

                var result = _mapper.Map<UserForUpdateEmailDto>(request);
                return result;


            }
        }
    }
}
