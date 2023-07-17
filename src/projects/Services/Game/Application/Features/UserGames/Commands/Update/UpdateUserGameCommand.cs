using Application.Features.UserGames.DTOs;
using Application.Features.UserGames.Rules;
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

namespace Application.Features.UserGames.Commands.Update
{
    public class UpdateUserGameCommand : IRequest<UpdatedUserGameDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameUrl { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.User, Permissions.Moderator };
        public class UpdateUserGameCommandHandler : IRequestHandler<UpdateUserGameCommand, UpdatedUserGameDto>
        {
            private IUserGameRepository _userGameRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;
            private UserGameBusinessRules _userGameBusinessRules;

            public UpdateUserGameCommandHandler(IUserGameRepository userGameRepository, IMapper mapper, ISharedIdentityService sharedIdentityService, UserGameBusinessRules userGameBusinessRules)
            {
                _userGameRepository = userGameRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
                _userGameBusinessRules = userGameBusinessRules;
            }

            public async Task<UpdatedUserGameDto> Handle(UpdateUserGameCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<UserGame>(request);
              //  await _userGameBusinessRules.CheckIfUserGameIdWhenUpdated(mappedModel.Id);

                mappedModel.UserId = _sharedIdentityService.GetUserId;
                await _userGameRepository.UpdateAsync(mappedModel);

                var result = _mapper.Map<UpdatedUserGameDto>(mappedModel);
                return result;


            }
        }
    }
}
