using Application.Features.Games.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Commands.Update
{
    public class UpdateGameCommand : IRequest<UpdatedGameDto>
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, UpdatedGameDto>
        {
            private IGameRepository _gameRepository;
            private IMapper _mapper;

            public UpdateGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedGameDto> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Game>(request);
                await _gameRepository.UpdateAsync(mappedModel);

                var result = _mapper.Map<UpdatedGameDto>(mappedModel);
                return result;
            }
        }
    }
}
