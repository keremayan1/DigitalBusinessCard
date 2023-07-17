using Application.Features.UserGames.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGames.Commands.Add
{
    public class CreateUserGameCommand:IRequest<CreatedUserGameDto>,ISecuredRequest
    {
        public int GameId { get; set; }
        public string GameUrl { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.User, Permissions.Moderator };
        public class CreateUserGameCommandHandler : IRequestHandler<CreateUserGameCommand, CreatedUserGameDto>
        {
            private IUserGameRepository _userGameRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public CreateUserGameCommandHandler(IUserGameRepository userGameRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userGameRepository = userGameRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<CreatedUserGameDto> Handle(CreateUserGameCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<UserGame>(request);
                mappedModel.UserId = _sharedIdentityService.GetUserId;
                await _userGameRepository.AddAsync(mappedModel);

                var result = _mapper.Map<CreatedUserGameDto>(mappedModel);
                return result;
            }
        }
    }
}
