using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Shared.Services;
using IBANAccount.API.Application.Features.UserIbans.DTOs;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;
using MediatR;

namespace IBANAccount.API.Application.Features.UserIbans.Commands.Update
{
    public class UpdateUserIbanCommand : IRequest<UpdatedUserIbanDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public int IbanId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNumber { get; set; }
        public string[] Roles => new[] { Permissions.User, Permissions.Admin, Permissions.Moderator };
        public class UpdateUserIbanCommandHandler : IRequestHandler<UpdateUserIbanCommand, UpdatedUserIbanDto>
        {
            private IUserIbanRepository _userIbanRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public UpdateUserIbanCommandHandler(IUserIbanRepository userIbanRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userIbanRepository = userIbanRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UpdatedUserIbanDto> Handle(UpdateUserIbanCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<UserIban>(request);
                mappedModel.UserId = _sharedIdentityService.GetUserId;
                await _userIbanRepository.UpdateAsync(mappedModel);
                var result = _mapper.Map<UpdatedUserIbanDto>(mappedModel);
                return result;
            }
        }
    }
}
