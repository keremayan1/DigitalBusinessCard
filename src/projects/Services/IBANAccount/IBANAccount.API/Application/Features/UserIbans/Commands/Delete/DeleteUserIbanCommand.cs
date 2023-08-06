using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Shared.Services;
using IBANAccount.API.Application.Features.UserIbans.DTOs;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;
using MediatR;

namespace IBANAccount.API.Application.Features.UserIbans.Commands.Delete
{
    public class DeleteUserIbanCommand : IRequest<DeletedUserIbanDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Permissions.User, Permissions.Admin, Permissions.Moderator };
        public class DeleteUserIbanCommandHandler : IRequestHandler<DeleteUserIbanCommand, DeletedUserIbanDto>
        {
            private IUserIbanRepository _userIbanRepository;
            private IMapper _mapper;
            public DeleteUserIbanCommandHandler(IUserIbanRepository userIbanRepository, IMapper mapper)
            {
                _userIbanRepository = userIbanRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserIbanDto> Handle(DeleteUserIbanCommand request, CancellationToken cancellationToken)
            {
                var getId = await _userIbanRepository.GetAsync(x => x.Id == request.Id);
                await _userIbanRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedUserIbanDto>(getId);
                return result;
            }
        }
    }
}
