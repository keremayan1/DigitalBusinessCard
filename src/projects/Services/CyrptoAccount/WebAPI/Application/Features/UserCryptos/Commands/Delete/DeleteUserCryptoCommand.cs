using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Shared.Services;
using MediatR;
using WebAPI.Application.Features.UserCryptos.DTOs;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.UserCryptos.Commands.Delete
{
    public class DeleteUserCryptoCommand : IRequest<DeletedUserCryptoDto>, ISecuredRequest
    {
        public int Id { get; set; }
       

        public string[] Roles => new[] { Permissions.Admin, Permissions.User, Permissions.Moderator };

        public class DeleteUserCryptoCommandHandler : IRequestHandler<DeleteUserCryptoCommand, DeletedUserCryptoDto>
        {
            private IUserCryptoRepository _userCryptoRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;
            public DeleteUserCryptoCommandHandler(IUserCryptoRepository userCryptoRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userCryptoRepository = userCryptoRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<DeletedUserCryptoDto> Handle(DeleteUserCryptoCommand request, CancellationToken cancellationToken)
            {
                var getId = await _userCryptoRepository.GetAsync(x => x.Id == request.Id);

                await _userCryptoRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeletedUserCryptoDto>(getId);
                return result;
            }
        }
    }
}
