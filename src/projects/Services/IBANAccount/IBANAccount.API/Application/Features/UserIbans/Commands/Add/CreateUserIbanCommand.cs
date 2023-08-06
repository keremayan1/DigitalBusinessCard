using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Shared.Services;
using IBANAccount.API.Application.Features.UserIbans.DTOs;
using IBANAccount.API.Application.Features.UserIbans.Rules;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;
using MediatR;

namespace IBANAccount.API.Application.Features.UserIbans.Commands.Add
{
    public class CreateUserIbanCommand:IRequest<CreatedUserIbanDto>,ISecuredRequest
    {
     
        public int IbanId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNumber { get; set; }

        public string[] Roles => new[] { Permissions.User, Permissions.Admin, Permissions.Moderator };

        public class CreateUserIbanCommandHandler : IRequestHandler<CreateUserIbanCommand, CreatedUserIbanDto>
        {
            private IUserIbanRepository _userIbanRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;
            private UserIbanBusinessRules _userIbanBusinessRules;

            public CreateUserIbanCommandHandler(IUserIbanRepository userIbanRepository, IMapper mapper, ISharedIdentityService sharedIdentityService, UserIbanBusinessRules userIbanBusinessRules)
            {
                _userIbanRepository = userIbanRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
                _userIbanBusinessRules = userIbanBusinessRules;
            }

            public async Task<CreatedUserIbanDto> Handle(CreateUserIbanCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<UserIban>(request);
               
                _userIbanBusinessRules.ToUpper(mappedModel);
                _userIbanBusinessRules.Trim(mappedModel);
                
                mappedModel.UserId = _sharedIdentityService.GetUserId;
               
                await _userIbanRepository.AddAsync(mappedModel);
               
                var result = _mapper.Map<CreatedUserIbanDto>(mappedModel);
                return result;
            }
        }
    }
}
