using Application.Features.Games.DTOs;
using Application.Features.Games.Rules;
using Application.Services.GameImages;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Commands.Add
{
    public class CreateGameCommand : IRequest<CreatedGameDto>, ISecuredRequest
    {
        public string GameName { get; set; }
        public IFormFile Photo { get; set; }
        public string[] Roles => new[] { Permissions.Admin };
        public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, CreatedGameDto>
        {
            private IGameRepository _gameRepository;
            private IMapper _mapper;
            private GameBusinessRules _gameBusinessRules;
            private IGameImageService _gameImageService;

            public CreateGameCommandHandler(IGameRepository gameRepository, IMapper mapper, GameBusinessRules gameBusinessRules, IGameImageService gameImageService)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
                _gameBusinessRules = gameBusinessRules;
                _gameImageService = gameImageService;
            }

            public async Task<CreatedGameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
            {
                
                var mappedModel = _mapper.Map<Game>(request);
             
                await _gameBusinessRules.GameNameCannotBeExistsWhenAdded(mappedModel.GameName);

               await _gameRepository.AddAsync(mappedModel);

                var result2 = await _gameImageService.AddGameImage(new GameImage { GameId=mappedModel.Id},request.Photo, cancellationToken);


                var result = _mapper.Map<CreatedGameDto>(mappedModel);
                return result;
            }
        }
    }
}
