using Application.Features.GameImages.DTOs;
using Application.Features.UserGames.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGames.Commands.Delete
{
    public class DeleteUserGameCommand:IRequest<DeletedUserGameDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.User, Permissions.Moderator };
        public class DeleteUserGameCommandHandler : IRequestHandler<DeleteUserGameCommand, DeletedUserGameDto>
        {
            private IUserGameRepository _userGameRepository;
            private IMapper _mapper;

            public DeleteUserGameCommandHandler(IUserGameRepository userGameRepository, IMapper mapper)
            {
                _userGameRepository = userGameRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserGameDto> Handle(DeleteUserGameCommand request, CancellationToken cancellationToken)
            {
                var getId = await _userGameRepository.GetAsync(x => x.Id == request.Id);
                await _userGameRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedUserGameDto>(getId);
                return result;

            }
        }
    }
}
