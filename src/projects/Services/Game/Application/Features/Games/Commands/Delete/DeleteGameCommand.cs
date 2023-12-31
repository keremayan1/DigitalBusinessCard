﻿using Application.Features.Games.DTOs;
using Application.Features.Games.Rules;
using Application.Services.GameImages;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Commands.Delete
{
    public class DeleteGameCommand : IRequest<DeletedGameDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Permissions.Admin };
        public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, DeletedGameDto>
        {
            private IGameRepository _gameRepository;
            private IMapper _mapper;
            private IGameImageService _gameImageService;
            private GameBusinessRules _gameBusinessRules;

            public DeleteGameCommandHandler(IGameRepository gameRepository, IMapper mapper, IGameImageService gameImageService, GameBusinessRules gameBusinessRules)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
                _gameImageService = gameImageService;
                _gameBusinessRules = gameBusinessRules;
            }

            public async Task<DeletedGameDto> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
            {
                await _gameBusinessRules.GameNameCannotBeNullWhenDeleted(request.Id);

                var getId = await _gameRepository.GetAsync(x => x.Id == request.Id);
               

                await _gameImageService.DeleteGameImage(getId.Id);
                await _gameRepository.DeleteAsync(getId);
                
                var result = _mapper.Map<DeletedGameDto>(getId);
                return result;
            }
        }
    }
}
