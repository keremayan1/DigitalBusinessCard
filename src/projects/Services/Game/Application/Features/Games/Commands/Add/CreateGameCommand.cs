using Application.Features.Games.DTOs;
using Application.Features.Games.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Commands.Add
{
    public class CreateGameCommand:IRequest<CreatedGameDto>
    {
        public string GameName { get; set; }
        public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, CreatedGameDto>
        {
            private IGameRepository _gameRepository;
            private IMapper _mapper;
            private GameBusinessRules _gameBusinessRules;

            public CreateGameCommandHandler(IGameRepository gameRepository, IMapper mapper, GameBusinessRules gameBusinessRules)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
                _gameBusinessRules = gameBusinessRules;
            }

            public async Task<CreatedGameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
            {
                
                var mappedModel = _mapper.Map<Game>(request);

                await _gameBusinessRules.GameNameCannotBeExistsWhenAdded(mappedModel.GameName);
                
                await _gameRepository.AddAsync(mappedModel);

                var result = _mapper.Map<CreatedGameDto>(mappedModel);
                return result;
            }
        }
    }
}
