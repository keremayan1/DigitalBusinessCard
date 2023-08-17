using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Shared.Services;
using MediatR;
using WebAPI.Application.Features.UserCryptos.Commands.Add;
using WebAPI.Application.Features.UserCryptos.DTOs;
using WebAPI.Application.Features.UserCryptos.Rules;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.UserCryptos.Commands.Update
{
    public class UpdateUserCryptoCommand : IRequest<UpdatedUserCryptoDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public int CryptoId { get; set; }
        public string CryptoUrl { get; set; }

        public string[] Roles => new[] { Permissions.Admin, Permissions.User, Permissions.Moderator };

        public class UpdateUserCryptoCommandHandler : IRequestHandler<UpdateUserCryptoCommand, UpdatedUserCryptoDto>
        {
            private IUserCryptoRepository _userCryptoRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;
            private UserCryptoBusinessRules _userCryptoBusinessRules;

            public UpdateUserCryptoCommandHandler(IUserCryptoRepository userCryptoRepository, IMapper mapper, ISharedIdentityService sharedIdentityService, UserCryptoBusinessRules userCryptoBusinessRules)
            {
                _userCryptoRepository = userCryptoRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
                _userCryptoBusinessRules = userCryptoBusinessRules;
            }

            public async Task<UpdatedUserCryptoDto> Handle(UpdateUserCryptoCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<UserCyrpto>(request);

                await _userCryptoBusinessRules.CheckIfUserCryptoIsExistsWhenSavedOrUpdated(request.CryptoUrl);

                mappedModel.UserId = _sharedIdentityService.GetUserId;

                await _userCryptoRepository.UpdateAsync(mappedModel);
                var result = _mapper.Map<UpdatedUserCryptoDto>(mappedModel);
                return result;
            }
        }
    }
}
