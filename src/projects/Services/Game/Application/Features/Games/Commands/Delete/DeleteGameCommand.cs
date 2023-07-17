using Application.Features.Games.DTOs;
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

            public DeleteGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<DeletedGameDto> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
            {
                var getId = await _gameRepository.GetAsync(x => x.Id == request.Id);
                await _gameRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedGameDto>(getId);
                return result;
            }
        }
    }
}
