using Application.Features.Games.DTOs;
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

namespace Application.Features.Games.Commands.Update
{
    public class UpdateGameCommand : IRequest<UpdatedGameDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public IFormFile Photo { get; set; }
        public string[] Roles => new[] { Permissions.Admin };
        public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, UpdatedGameDto>
        {
            private IGameRepository _gameRepository;
            private IMapper _mapper;
            private IGameImageService _gameImageService;
            public UpdateGameCommandHandler(IGameRepository gameRepository, IMapper mapper, IGameImageService gameImageService)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
              
                _gameImageService = gameImageService;
            }

            public async Task<UpdatedGameDto> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Game>(request);
                await _gameRepository.UpdateAsync(mappedModel);
                await _gameImageService.UpdateGameImage(new GameImage { GameId=mappedModel.Id},request.Photo,cancellationToken);
                var result = _mapper.Map<UpdatedGameDto>(mappedModel);
                return result;
            }
        }
    }
}
